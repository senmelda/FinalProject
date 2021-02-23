using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
   
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;//global değişken
        public InMemoryProductDal()
        {
            //Oracle,Sql Server , Postgres, MongoDb
            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitInStock=3},
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName="Bardak", UnitPrice=85, UnitInStock=1}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);//foreach işlemi için linq yapısı. Genelde aramalarda singleordefault(iki tane veri gelirse hata gelir.) methodu kullanılır.


            _products.Remove(productToDelete);//bu şekilde silinemez. Çünkü referans tipler referans numaraları üzerinden gider. Yukarıda tanımlananlar ile burada çağırılan ürünün referansı uyuşmaz.
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)//ekrandan gelen data
        {
            //Gönderilen ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);//güncellenecek referans bulunmalı.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
