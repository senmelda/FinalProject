using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //generic constraint
    //class : referans tip olabilir demektir
    //ya referans olabilir yada IEntity nesnesi olmalı diyerek sınırlandırdık.
    //IEntity:IEntity olabilir veya IEntity implement eden bir nesne olabilir.
    //new(): new'lenebilir olması.IEntity newlenemez çünkü.Yani Dal sınıflarında IEntity olarakta işimizi görmeyeceği için bu şekilde filtre koymalıyız.
    public interface IEntityRepository<T> where T:class,IEntity,new()//T tipinde döndür
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);//tek tek filtre işlemi yapmamak için
        T Get(Expression<Func<T, bool>> filter = null);//filtreleme yapma, tek bir sonuç getirme
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAllByCategory(int categoryId);
    }
}
