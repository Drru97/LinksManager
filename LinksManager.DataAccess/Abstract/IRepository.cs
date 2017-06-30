﻿using System;
using System.Collections.Generic;

namespace LinksManager.DataAccess.Abstract
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
