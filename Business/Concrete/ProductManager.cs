using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService//iş katmanının soyut sınıfı
    {
        IProductDal _productDal;//const
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //iş kodları
            //yetkisi var mı?
            //bir takım kurallardan geçtikten sonra ürünleri sırala diyebiliriz.
            //bir iş sınıfı diğer classları newlemez.
            return _productDal.GetAll();

        }
    }
}
