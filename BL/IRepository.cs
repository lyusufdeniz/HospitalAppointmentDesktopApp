using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace BL
{
        //Repository Pattern aynı işlevi farklı enityler için gören classlar için aynı kodların tekrarlanmamasını sağlayan
        //Design pattern yapısıdır
        interface IRepository<T> //buradaki T Type anlamına gelir tüm entityleri kapsar
                                 //örnek List<T> getAll()==List<Patient> getAll()
        {
            List<T> getAll();
            List<T> getAll(Expression<Func<T, bool>> expression); //where ile filtrelenebilen kayıtları getirir
            T GetT(int id);
            T Find(Expression<Func<T, bool>> expression);
            int Add(T entity);
            int Update(T entity);
            int Delete(int id);

        }
    }
