﻿using ppedv.ADC2020.Model;
using ppedv.ADC2020.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2020.Data.EF
{
    public class EfRepository : IRepository
    {
        EfContext context = new EfContext();

        public void Add<T>(T entity) where T : Entity
        {
            //  if (typeof(T) == typeof(Auto))
            //      context.Autos.Add(entity as Auto);
            context.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }

        public T GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetById<T>(entity.Id);
            if (loaded != null)
            {
                context.Entry(loaded).CurrentValues.SetValues(entity);
            }
        }
    }
}
