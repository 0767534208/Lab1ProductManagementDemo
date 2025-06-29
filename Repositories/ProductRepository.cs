using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductDAO _productDAO = new ProductDAO();
        public void SaveProduct(Product p) => _productDAO.SaveProduct(p);
        public void DeleteProduct(Product p) => _productDAO.DeleteProduct(p);
        public void UpdateProduct(Product p) => _productDAO.UpdateProduct(p);
        public List<Product> GetProducts() => _productDAO.GetProducts();
        public Product GetProductById(int id) => _productDAO.GetProductById(id);
    }
}
