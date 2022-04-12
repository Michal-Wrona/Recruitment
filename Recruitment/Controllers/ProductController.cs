using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recruitment.Api;
using Recruitment.Core.Products;
using Recruitment.Core.Validation;

namespace Recruitment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<AddProductDto> _validatorAdd;
        private readonly IValidator<UpdateProductDto> _validatorUpdate;


        public ProductController(IProductRepository productRepository, IValidator<AddProductDto> validatorAdd, IValidator<UpdateProductDto> validatorUpdate, IAddValidation validation)
        {
            _productRepository = productRepository;
            _validatorAdd = validatorAdd;
            _validatorUpdate = validatorUpdate;
        }

        [HttpGet]
        public ActionResult<IList<GetProductDto>> GetAllProducts()
        {
            var products = _productRepository.GetProducts();
            var productsList = new List<GetProductDto>();

            foreach (var product in products)
            {
                productsList.Add(new GetProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Number = product.Number,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Price = product.Price
                });

            }   
                return Ok(productsList);
        }
        [HttpGet("{id}")]
        public ActionResult<GetProductDto> GetProduct(Guid id)
        {
            
            var product =_productRepository.GetProduct(id);
            if(product == null)
            {
                return NotFound($"Not found product with id:{id}");
            }
            var productDto = new GetProductDto()
            {
                Id= product.Id,
                Name= product.Name,
                Number= product.Number,
                Quantity= product.Quantity,
                Description= product.Description,
                Price= product.Price
            };
            return Ok(productDto);
        }

        [HttpPost]
        public ActionResult AddProduct(AddProductDto dto)
        {
            AddValidation validation = new AddValidation();
            var a=validation.NameProductIsNull(dto);
            if (a == false)
            {
                return BadRequest("No product name");
            }
            var b = validation.NameProductLengthTooLong(dto);
            if (b == false)
            {
                return BadRequest("Product name is too long");
            }
            var c = validation.PriceProductIsNull(dto);
            if (c == false)
            {
                return BadRequest("No price");
            }
            //var result = _validatorAdd.Validate(dto);
            //if (!result.IsValid)
            //{
            //    return BadRequest(result);
            //}

            var product = new Product { Description = dto.Description, Name = dto.Name, Number = dto.Number, Price = dto.Price, Quantity = dto.Quantity };
            _productRepository.AddProduct(product);
            return Ok(product.Id);
        }

        [HttpPut("{id}")] 
        public ActionResult UpdateProduct(UpdateProductDto dto,Guid id)
        {
            var result = _validatorUpdate.Validate(dto);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound($"Not found product with id:{id}");
            }
            _productRepository.UpdateProduct(id, dto.Description, dto.Quantity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(Guid id)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound($"Not found product with id:{id}");
            }
            _productRepository.DeleteProduct(id);
            return Ok();
        }
}   }
