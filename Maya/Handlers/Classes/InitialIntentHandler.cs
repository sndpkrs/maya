using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Maya.Handler.Interfaces;
using Maya.Handlers.Interfaces;

namespace Maya.Handler.Classes
{
    public class InitialIntentHandler: IInitialIntentHandler
    {

        private readonly IFamilyLawHandler _familyLawHandler;
        private readonly IConsumerLawHandler _consumerLawHandler;
        private readonly IHelloHandler _helloHandler;
        private readonly IDefaultHandler _defaultHandler;
        private readonly IDentalHandler _dentalHandler;
        private readonly IDermatologyHandler _dermatologyHandler;
        private readonly IConflictIntentHandler _conflictIntentHandler;
        private readonly ICancelMembershipHandler _cancelMembershipHandler;

        public InitialIntentHandler(
            IFamilyLawHandler familyLawHandler, 
            IConsumerLawHandler consumerLawHandler, 
            IHelloHandler helloHandler, 
            IDefaultHandler defaultHandler,
            IDentalHandler dentalHandler,
            IDermatologyHandler dermatologyHandler,
            IConflictIntentHandler conflictIntentHandler,
            ICancelMembershipHandler cancelMembershipHandler)
        {
            _familyLawHandler = familyLawHandler;
            _consumerLawHandler = consumerLawHandler;
            _helloHandler = helloHandler;
            _defaultHandler = defaultHandler;
            _dentalHandler = dentalHandler;
            _dermatologyHandler = dermatologyHandler;
            _conflictIntentHandler = conflictIntentHandler;
            _cancelMembershipHandler = cancelMembershipHandler;
        }
        public SkillResponse Process(SkillRequest request)
        {
            var response = new SkillResponse();
            var intentName = !(request.Request is IntentRequest intentRequest) ? "DefaultIntent" : intentRequest.Intent.Name;
            switch (intentName)
            {
                case "HelloIntent":
                    response = _helloHandler.Process(request); break;
                case "FamilyLaw":
                    response = _familyLawHandler.Process(request); break;
                case "ConsumerLaw":
                    response = _consumerLawHandler.Process(request); break;
                case "Dental":
                    response = _dentalHandler.Process(request); break;
                case "Dermatology":
                    response = _dermatologyHandler.Process(request); break;
                case "ConflictIntent":
                    response = _conflictIntentHandler.Process(request); break;
                case "DefaultIntent":
                    response = _defaultHandler.Process(request); break;
                case "CancelMembership":
                    response = _cancelMembershipHandler.Process(request); break;
                default:
                    response = _defaultHandler.Process(request); break;
            }
            return response;
        }
    }
}
