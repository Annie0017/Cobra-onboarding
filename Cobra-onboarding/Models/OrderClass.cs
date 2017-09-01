using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobra_onboarding.Models
{
    public class OrderClass
    {  
            public int OrderId { get; set; }
            public string Name { get; set; }
            public System.DateTime OrderDate { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
        
    }
}