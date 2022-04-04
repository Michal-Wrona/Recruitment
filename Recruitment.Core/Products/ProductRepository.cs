using Recruitment.Core.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Core.Products
{
    public class ProductRepository:IProductRepository
    {
        private readonly RecruitmentDbContext _dbContext;
        public ProductRepository(RecruitmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Guid AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(Guid id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public Product GetProduct(Guid id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            _dbContext.SaveChanges();
            return product;            
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Guid id, string description, int quantity)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            product.Description = description;
            product.Quantity = quantity;
            _dbContext.SaveChanges();
        }
    }
}
