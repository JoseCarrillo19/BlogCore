﻿using System.Linq.Expressions;

namespace BlogCore.Domain.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null
            );

        T GetFirstOrderDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
