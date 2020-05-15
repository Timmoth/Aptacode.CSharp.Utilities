﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aptacode.CSharp.Utilities.Persistence.Repository
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<int> Create(TEntity entity);

        Task Update(TEntity entity);

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(int id);

        Task Delete(int id);
    }
}
