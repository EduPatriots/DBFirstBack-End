using DBFirstBack_End.DataAccess;
using DBFirstBack_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class ProductsSC : Conexion<Products>
    {
        NorthwindContext dataContext = new NorthwindContext();

        public IQueryable<Products> GetData()
        {
            return dataContext.Products.Select(s => s);
        }

        public Products GetDataByID(int id)
        {
            var product = GetData().Where(w => w.ProductId == id).FirstOrDefault();
            
            if(product == null)
            {
                throw new Exception("El id solicitado para el producto que quieres obtener, no existe");
            }

            return product;
        }

        public void AddProduct(ProductModel newProduct)
        {
            var newProductRegister = new Products()
            {
                ProductName = newProduct.ProductName,
                Discontinued = newProduct.Discontinued
            };
            dataContext.Products.Add(newProductRegister);
            dataContext.SaveChanges();
        }

        public void updateProductNameByID(int id, string newName)
        {
            Products currentProduct = GetDataByID(id);
            if(currentProduct == null)
                throw new Exception("No se encontró el producto con el ID proporcionado");

            currentProduct.ProductName = newName;
            dataContext.SaveChanges();
        }

        public void DeleteProductByID(int id)
        {
            var product = GetDataByID(id);
            if (product == null)
            {
                throw new Exception("El id solicitado para el producto que quieres obtener, no existe");
            }
            dataContext.Products.Remove(product);
            dataContext.SaveChanges();
        }
    }
}
