using Recruitment.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Validation
{
    public class AddValidation:IAddValidation
    {
        public bool NameProductIsNull(AddProductDto dto)
        {
            if (dto.Name == null)
            {
                return false;
            }
            return true;
        }

        public bool NameProductLengthTooLong(AddProductDto dto)
        {
            if (dto.Name.Length > 100)
            {
                return false;
            }
            return true ;
        }

        public bool PriceProductIsNull (AddProductDto dto)
        {
            if (dto.Price == null)
            {
                return false;
            }
            return true;
        }

        public bool DescriptionProductLengthTooLong(AddProductDto dto)
        {
            if (dto.Description.Length > 200)
            {
                return false;
            }
            return true;
        }
    }
}
