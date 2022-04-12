using Recruitment.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Validation
{
    public interface IAddValidation
    {
        bool NameProductIsNull(AddProductDto dto);
        bool NameProductLengthTooLong(AddProductDto dto);
        bool PriceProductIsNull(AddProductDto dto);
        bool DescriptionProductLengthTooLong(AddProductDto dto);

    }
}
