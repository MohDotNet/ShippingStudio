using ShippingStudio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.ResponseModels
{
    public class DbFilingResponseModel : BaseResponseModel
    {

        public DbFilingResponseModel()
        {
            FilingList = new List<Filing>();
        }

        public Filing Filing { get; set; }
        public List<Filing> FilingList { get; set; }

    }
}
