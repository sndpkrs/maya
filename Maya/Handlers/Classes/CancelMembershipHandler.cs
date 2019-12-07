using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Maya.Handler.Interfaces;
using Maya.Handlers.Interfaces;

namespace Maya.Handlers.Classes
{
    public class CancelMembershipHandler : ICancelMembershipHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            var response = new SkillResponse();
            var intentRequest = (IntentRequest)request.Request;
            if (intentRequest.DialogState == DialogState.Started || intentRequest.DialogState == DialogState.InProgress)
            {
                if (intentRequest.Intent.Slots["good_reason_to_leave"].Value == null &&
                    intentRequest.Intent.Slots["bad_reason_to_leave"].Value == null)
                {
                    var sorrySpeech = new PlainTextOutputSpeech
                    {
                        Text = "Ohh, we are very sorry to hear that, Can you please specify a reason for your cancellation?"
                    };
                    return ResponseBuilder.DialogElicitSlot(sorrySpeech, "good_reason_to_leave");
                    //var speech = new PlainTextOutputSpeech
                    //{
                    //    Text = "Ohh, we are very sorry to hear that, Can you please specify a reason for your cancellation?"
                    //};
                    //return ResponseBuilder.Ask(speech, new Reprompt() { OutputSpeech = new PlainTextOutputSpeech() { Text = "Can you please specify a reason?" } });

                    //return ResponseBuilder.DialogDelegate();
                }
                else if (intentRequest.Intent.Slots["good_reason_to_leave"].Value != null && intentRequest.Intent.Slots["is_accepting_the_offer"].Value == null)
                {
                    if (intentRequest.Intent.Slots["good_reason_to_leave"].Resolution.Authorities[0].Status.Code ==
                        "ER_SUCCESS_NO_MATCH")
                    {
                        return TryToRetain();
                    };
                    
                    response = ResponseBuilder.Tell("Okay we have recorded your request for cancellation, hope you had a great time with us. Thank you.");
                }
                else if (intentRequest.Intent.Slots["bad_reason_to_leave"].Value != null && intentRequest.Intent.Slots["is_accepting_the_offer"].Value == null)
                {
                    return TryToRetain();
                }

                if (intentRequest.Intent.Slots["is_accepting_the_offer"].Value != null)
                {
                    if (intentRequest.Intent.Slots["is_accepting_the_offer"].Resolution.Authorities[0].Status.Code ==
                        "ER_SUCCESS_NO_MATCH")
                    {
                        return ResponseBuilder.Tell("Okay we have recorded your request for cancellation, hope you had a great time with us. Thank you.");
                    }
                    var speech = new PlainTextOutputSpeech
                    {
                        Text = "That's great !! Thank you for putting trust in us? How can I help you you today?"
                    };
                    response = ResponseBuilder.Ask(speech, new Reprompt(){ OutputSpeech = new PlainTextOutputSpeech(){ Text = "How can we help you today?"}});
                }
                else
                {
                    response = ResponseBuilder.Tell("Okay we have recorded your request for cancellation, hope you had a great time with us. Thank you.");
                }
            }
            return response;
        }

        private SkillResponse TryToRetain()
        {
            var sorrySpeech = new PlainTextOutputSpeech
            {
                Text = "We are sorry to know that, Would you like us to connect you to some other expert?"
            };
            return ResponseBuilder.DialogElicitSlot(sorrySpeech, "is_accepting_the_offer");
        }
    }
}
