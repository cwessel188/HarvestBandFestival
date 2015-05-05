using HarvestBandFestival.Infrastructure;
using HarvestBandFestival.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;


namespace HarvestBandFestival
{

    
    public interface IGenericRepository : IDisposable
    {
        System.Linq.IQueryable<T> Query<T>() where T : class;
        System.Linq.IQueryable Query(string entityTypeName);
        void Add<T>(T entityToCreate) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void SaveChanges();
        System.Collections.Generic.IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);

    }

}