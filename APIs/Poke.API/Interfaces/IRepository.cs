﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Poke.API.Entities;

namespace Poke.API.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(int id);
    }
}