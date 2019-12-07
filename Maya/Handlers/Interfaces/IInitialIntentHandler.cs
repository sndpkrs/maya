using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace Maya.Handler.Interfaces
{
    public interface IInitialIntentHandler
    {
        SkillResponse Process(SkillRequest request);
    }
}
