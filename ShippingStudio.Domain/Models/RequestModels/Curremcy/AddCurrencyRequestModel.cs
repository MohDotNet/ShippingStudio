using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.RequestModels.Curremcy
{
    public class AddCurrencyRequestModel
    {
        public string CurrencyDescription { get; set; }
        public string CurrencySymbol { get; set; }
    
    }
}
