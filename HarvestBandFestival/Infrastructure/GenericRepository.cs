using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HarvestBandFestival.Models;

namespace HarvestBandFestival.Infrastructure
{
    public class GenericRepository : IGenericRepository
    {
        private ApplicationDbContext _dc = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
        /// <summary>
        /// Generic Query method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns> Query object (call ToList)</returns>
        public IQueryable<T> Query<T>() where T : class
        {
            return _dc.Set<T>().AsQueryable();
        }

        /// <summary>
        /// Non Generic query method
        /// Use model type name instead of model type
        /// </summary>
        public IQueryable Query(string entityTypeName)
        {
            var entityType = Type.GetType(entityTypeName);
            return _dc.Set(entityType).AsQueryable();
        }

        /// <summary>
        /// Ad new entity
        /// </summary>
        public void Add<T>(T entityToCreate) where T : class
        {
            _dc.Set<T>().Add(entityToCreate);
        }

        /// <summary>
        /// Find row by id
        /// </summary>
        public T Find<T>(params object[] keyValues) where T : class
        {
            return _dc.Set<T>().Find(keyValues);
        }

        /// <summary>
        /// Generic Delete Method
        /// </summary>
        public void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = this.Find<T>(keyValues);
            _dc.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Saves changes to avoid valistion exceptions
        /// </summary>
        public void SaveChanges()
        {
            try
            {
                _dc.SaveChanges();
            }
            catch (DbEntityValidationException dbVal)
            {
                var firstError = dbVal.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                throw new ValidationException(firstError);
            }
        }

        /// <summary>
        /// Execute stored procedures and dynamic sql
        /// </summary>
        public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
        {
            return this._dc.Database.SqlQuery<T>(sql, parameters);
        }

        public void Dispose()
        {
            _dc.Dispose();
        }



    }
}