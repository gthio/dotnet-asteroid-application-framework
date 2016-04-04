using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Asteroid.Data
{
    public interface IDataContext : IDisposable
    {
        void Add(object item);

        void Save(object item);

        void AddOrSave(object item);

        void DeleteEntity(object item);

        void BeginTransaction(IsolationLevel isolationLevel);

        void Commit();

        void Rollback();

        bool IsInTransaction
        {
            get;
        }
    }
}
