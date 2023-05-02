using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        public static List<ProductDTO> Get()
        {
            var data = DataAccessFactory.ProductData().Get();
            return Convert(data);
        }

        public static ProductDTO Get(int id)
        {
            return Convert(DataAccessFactory.ProductData().Get(id));
        }


        public static bool Create(ProductDTO product)
        {
            var data = Convert(product);
            return DataAccessFactory.ProductData().Insert(data);
        }


        public static bool Update(ProductDTO product)
        {
            var data = Convert(product);
            return DataAccessFactory.ProductData().Update(data);
        }


        public static bool Delete(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }


        static List<ProductDTO> Convert(List<Product> products)
        {
            var data = new List<ProductDTO>();
            foreach (var product in products)
            {
                data.Add(Convert(product));
            }
            return data;
        }


        static ProductDTO Convert(Product product)
        {
            return new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty,
                CId = product.CId,
                SId = product.SId

            };
        }


        static Product Convert(ProductDTO product)
        {
            return new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Qty = product.Qty,
                CId = product.CId,
                SId = product.SId
            };
        }
    }
}
