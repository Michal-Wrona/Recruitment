using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Api
{
    public class UpdateProductDto
    {    
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}
