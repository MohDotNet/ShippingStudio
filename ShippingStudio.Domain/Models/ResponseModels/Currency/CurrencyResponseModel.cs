using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.ResponseModels.Currency
{
    public class CurrencyResponseModel : BaseResponseModel
    {
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
    }
}
