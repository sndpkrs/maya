using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Maya.Handlers.Interfaces;

namespace Maya.Handlers.Classes
{
    public class ConflictIntentHandler : IConflictIntentHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            var speech = new PlainTextOutputSpeech();
            speech.Text = "Unfortunately we couldn't get you clearly. \n Can you please be more specific about your issue?";

            var repromptMessage = new PlainTextOutputSpeech();
            repromptMessage.Text = "Can you please be more specific about your issue?";

            var repromptBody = new Reprompt();
            repromptBody.OutputSpeech = repromptMessage;
            return ResponseBuilder.Ask(speech, repromptBody);
        }
    }
}
