using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Products
{
    public interface IProductRepository
    {
        public Product GetProduct(Guid id);
        public IEnumerable<Product> GetProducts();
        public Guid AddProduct(Product product);
        public void UpdateProduct(Guid id, string description, int quantity);
        public void DeleteProduct(Guid id);
    }
}
