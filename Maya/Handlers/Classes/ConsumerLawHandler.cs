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
    public class ConsumerLawHandler : IConsumerLawHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            string responseStr = string.Empty;
            IntentRequest intentRequest = (IntentRequest)request.Request;
            if (intentRequest.DialogState == "COMPLETED")
            {

                responseStr +=
                    $@"We see that you had some consumer issue with your {intentRequest.Intent.Slots["consumer_slot"].Value}. 
                    ";
            }
            return ResponseBuilder.Tell(new PlainTextOutputSpeech( responseStr + 
                "We have recorded your question related to consumer law and we will revert you as soon as possible"));
        }
    }
}
