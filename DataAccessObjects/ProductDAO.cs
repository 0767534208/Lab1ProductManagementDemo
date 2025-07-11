﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private List<Product> listProducts;
        private List<Category> listCategories;

        public ProductDAO()
        {
            listCategories = CategoryDAO.GetCategories();

            Product chai = new Product(1, "Chai", 3, 12, 18);
            chai.Category = listCategories.FirstOrDefault(c => c.CategoryId == chai.CategoryId);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            chang.Category = listCategories.FirstOrDefault(c => c.CategoryId == chang.CategoryId);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);
            aniseed.Category = listCategories.FirstOrDefault(c => c.CategoryId == aniseed.CategoryId);
            listProducts = new List<Product> { chai, chang, aniseed };
        }

        public List<Product> GetProducts()
        {
            return new List<Product>(listProducts);
        }

        //public static List<Product> GetProducts()
        //{
        //    var listProducts = new List<Product>();
        //    try
        //    {
        //        using var db = new MyStoreContext();
        //        listProducts = db.Products.ToList();
        //    }
        //    catch (Exception e)
        //    {

        //    }

        //    return listProducts;
        //}

        public void SaveProduct(Product p)
        {
            p.Category = listCategories.FirstOrDefault(c => c.CategoryId == p.CategoryId);
            listProducts.Add(p);
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = listProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.UnitPrice = product.UnitPrice;
                existingProduct.UnitsInStock = product.UnitsInStock;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Category = listCategories.FirstOrDefault(c => c.CategoryId == existingProduct.CategoryId);
            }
        }

        public void DeleteProduct(Product product)
        {
            Product productToRemove = listProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (productToRemove != null)
            {
                listProducts.Remove(productToRemove);
            }
        }

        public Product GetProductById(int id)
        {
            foreach (Product p in listProducts.ToList())
            {
                if(p.ProductId == id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
