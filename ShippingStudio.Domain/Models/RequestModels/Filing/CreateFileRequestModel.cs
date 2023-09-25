using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.RequestModels.Filing
{
    public class CreateFileRequestModel
    {
        public string Code { get; set; }
        public string FileDescription { get; set; }
        public int SupplierId { get; set; }
    }
}
