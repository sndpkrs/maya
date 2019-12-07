using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Maya.Handler.Interfaces;

namespace Maya.Handler.Classes
{
    public class HelloHandler : IHelloHandler
    {
        public SkillResponse Process(SkillRequest request)
        {
            return ResponseBuilder.Tell(new PlainTextOutputSpeech("Hi from Maya"));
        }
    }
}
