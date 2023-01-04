using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace BL
{

        public class Repository<T> : IRepository<T> where T : class, IEntity, new()
        {
            static Context context;
        public static DbSet<T> _objectSet;
            public Repository()
            {
                if (context == null)
                {
                    context = new Context();
                    _objectSet = context.Set<T>();
                }

            }
            public int Add(T entity)
            {
                _objectSet.Add(entity);
                return context.SaveChanges();
            }

            public int Delete(int id)
            {
                _objectSet.Remove(GetT(id));
                return context.SaveChanges();
            }

            public T Find(Expression<Func<T, bool>> expression)
            {
                return _objectSet.FirstOrDefault(expression);
            }

            public List<T> getAll()
            {
                return _objectSet.ToList();
            }


            public T GetT(int id)
            {
                return _objectSet.Find(id);
            }

            public int Update(T entity)
            {
                _objectSet.AddOrUpdate(entity);
                return context.SaveChanges();
            }

            List<T> IRepository<T>.getAll(Expression<Func<T, bool>> expression)
            {
                return _objectSet.Where(expression).ToList();
            }

     public  List<T> getAll(Expression<Func<T, bool>> expression)
        {
         
            return _objectSet.Where(expression).ToList();
        }
    }
    }


