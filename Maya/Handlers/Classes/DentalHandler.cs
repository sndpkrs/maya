using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Maya.Handler.Interfaces;

namespace Maya.Handler.Classes
{
    public class DentalHandler : IDentalHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            string responseStr = string.Empty;
            IntentRequest intentRequest = (IntentRequest)request.Request;
            if (intentRequest.DialogState == "COMPLETED")
            {

                responseStr +=
                    $@"We see that you are suffering from {intentRequest.Intent.Slots["dental_slot"].Value}.
                    ";
            }
            return ResponseBuilder.Tell(new PlainTextOutputSpeech(responseStr +
                                                                  "We have post your question to a dentist, he will revert back to you as soon as possible"));
        }
    }
}
