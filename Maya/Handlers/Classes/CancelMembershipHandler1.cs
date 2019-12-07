using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Maya.Handlers.Interfaces;

namespace Maya.Handlers.Classes
{
    public class CancelMembershipHandler1 : ICancelMembershipHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            var response = new SkillResponse();
            var intentRequest = (IntentRequest)request.Request;
            if (intentRequest.DialogState == DialogState.Started || intentRequest.DialogState == DialogState.InProgress)
            {
                // check what all are required
                if (intentRequest.Intent.Slots["reason_to_leave"].Value == null)
                {
                    response = ResponseBuilder.DialogElicitSlot(new PlainTextOutputSpeech()
                    { Text = @"Can you please let us know the reason of your cancellation.
1 for unaffordable, 2 for unsatisfactory quality,  3 for timing issues " }, "reason_to_leave");
                }
                else if (intentRequest.Intent.Slots["reason_to_leave"].Value != null && intentRequest.Intent.Slots["is_accepting_the_offer"].Value == null)
                {
                    var reasonToLeave = int.TryParse(intentRequest.Intent.Slots["reason_to_leave"].Value, out int reasonToLeaveInt);
                    switch (reasonToLeaveInt)
                    {
                        case 1:
                            response = ResponseBuilder.Tell("Okay we have recorded your request for cancellation, hope you had a great time with us. Thank you.");
                            break;
                        //case 2:
                        //    var qualitySorrySpeech = new PlainTextOutputSpeech
                        //    {
                        //        Text = "We are sorry to know that, Would you like to use our premium service for free"
                        //    };
                        //    response = ResponseBuilder.DialogElicitSlot(qualitySorrySpeech, "is_accepting_the_offer");
                        //    break;
                        //case 3:
                        //    var sorrySpeech = new PlainTextOutputSpeech
                        //    {
                        //        Text = "We are sorry to know that, Would you like us to connect you to some other expert?"
                        //    };
                        //    response = ResponseBuilder.DialogElicitSlot(sorrySpeech, "is_accepting_the_offer");
                        //    break;

                    }
                }
                else if (intentRequest.Intent.Slots["is_accepting_the_offer"].Value != null)
                {
                    var reasonToLeave = int.TryParse(intentRequest.Intent.Slots["is_accepting_the_offer"].Value, out int isAcceptingTheOfferInt);
                    switch (isAcceptingTheOfferInt)
                    {
                        case 1:
                            //return ResponseBuilder.DialogDelegate();
                            response = ResponseBuilder.Tell("Great !! We love to see you trusting us. Continue using Just answer.");
                            break;
                        case 2:
                            response = ResponseBuilder.Tell("Okay we have recorded your request for cancellation");
                            break;
                    }
                }
                //response = ResponseBuilder.DialogDelegate(new Intent(){ Name = "FamilyLaw"});
            }
            else
            {
                var speech = new PlainTextOutputSpeech
                {
                    Text = "We are very sorry to hear that, would you like to let us know the reason of your cancellation?"
                };
                intentRequest.DialogState = DialogState.InProgress;

                var repromptMessage = new PlainTextOutputSpeech();
                repromptMessage.Text =
                    @"Please choose 
                    1 for quality
                    2 if its not affordable";

                var repromptBody = new Reprompt();
                repromptBody.OutputSpeech = repromptMessage;
                var respSession = request.Session;
                respSession.Attributes = respSession.Attributes ?? new Dictionary<string, object>();
                respSession.Attributes["ask_reason"] = "asking reason";
                response = ResponseBuilder.Ask(speech, repromptBody, respSession);
            }
            return response;


            //if (intentRequest.Intent.ConfirmationStatus == ConfirmationStatus.Confirmed)
            //{
            //    return ResponseBuilder.Tell("Okay we have cancelled your memo");
            //}
            //else
            //{
            //    return ResponseBuilder.Tell("Ohh we love to see you continue.");
            //}
        }
    }
}
