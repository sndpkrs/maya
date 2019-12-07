using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Maya.Enums
{
    public enum IntentEnums 
    {
        DefaultIntent = 0,
        HelloHandler,
        FamilyLawHandler,
        ConsumerLawHandler
    }
}
