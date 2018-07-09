﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ametista.Core.Interfaces
{
    public interface IWriteOnlyRepository<TEntity> where TEntity : IAggregate
    {
        Task<TEntity> Find(Guid id); // only allowed find the entity for update or delete
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
