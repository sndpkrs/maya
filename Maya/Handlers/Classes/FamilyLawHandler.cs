using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Alexa.NET.Response.Ssml;
using Maya.Handler.Interfaces;

namespace Maya.Handler.Classes
{
    public class FamilyLawHandler :IFamilyLawHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public SkillResponse Process(SkillRequest request)
        {
            string responseStr = string.Empty;
            IntentRequest intentRequest = (IntentRequest)request.Request;
            if (intentRequest.DialogState == "COMPLETED")
                responseStr +=
                    $@"We see that you had some family issue with your {intentRequest.Intent.Slots["family_slot"].Value}.
                    ";
            //if (intentRequest.Intent.Slots["which_city_you_are_in"].Value != ) 
            return ResponseBuilder.Tell(new PlainTextOutputSpeech(responseStr + 
                "We have recorded your question related to family law and we will revert you as soon as possible"));
        }
    }
}
