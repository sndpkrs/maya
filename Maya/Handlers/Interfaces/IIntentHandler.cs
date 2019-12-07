using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;

namespace Maya.Handler.Interfaces
{
    public interface IIntentHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The <see cref="SkillResponse"/></returns>
        SkillResponse Process(SkillRequest request);
    }
}
