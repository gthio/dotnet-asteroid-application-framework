using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Asteroid.Data;

namespace Asteroid.Data.Hibernate
{
    public class DataContext : IDataContext
    {
        private readonly ISessionManagementStrategy sessionManagementStrategy;

        public DataContext(ISessionManagementStrategy sessionManagementStrategy)
        {
            this.sessionManagementStrategy = sessionManagementStrategy;
        }

        public bool IsInTransaction
        {
            get
            {
                return (this.sessionManagementStrategy.GetSession().Transaction != null)
                    && this.sessionManagementStrategy.GetSession().Transaction.IsActive;
            }
        }

        protected ISessionManagementStrategy SessionManager
        {
            get
            {
                return this.sessionManagementStrategy;
            }
        }

        public void Add(object item)
        {
            if (!this.IsInTransaction)
            {
                this.BeginTransaction(IsolationLevel.ReadCommitted);

                this.sessionManagementStrategy
                    .GetSession()
                    .Save(item);

                this.Commit();
            }
            else
            {
                this.sessionManagementStrategy
                    .GetSession()
                    .Save(item);
            }
        }

        public void Save(object item)
        {
            if (!this.IsInTransaction)
            {
                this.BeginTransaction(IsolationLevel.ReadCommitted);

                this.sessionManagementStrategy
                    .GetSession()
                    .Update(item);

                this.Commit();
            }
            else
            {
                this.sessionManagementStrategy
                    .GetSession()
                    .Update(item);
            }
        }

        public void AddOrSave(object item)
        {
            if (!this.IsInTransaction)
            {
                this.BeginTransaction(IsolationLevel.ReadCommitted);

                this.sessionManagementStrategy
                    .GetSession()
                    .SaveOrUpdate(item);

                this.Commit();
            }
            else
            {
                this.sessionManagementStrategy
                    .GetSession()
                    .SaveOrUpdate(item);
            }
        }

        public void DeleteEntity(object item)
        {
            if (!this.IsInTransaction)
            {
                this.BeginTransaction(IsolationLevel.ReadCommitted);

                this.sessionManagementStrategy
                    .GetSession()
                    .Delete(item);

                this.Commit();
            }
            else
            {
                this.sessionManagementStrategy
                    .GetSession()
                    .Delete(item);
            }
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (this.IsInTransaction)
            {
                throw new InvalidOperationException("A transaction is already opened.");
            }
            else
            {
                try
                {
                    this.sessionManagementStrategy
                        .GetSession()
                        .Transaction
                        .Begin(isolationLevel);
                }
                catch (Exception ex)
                {
                    throw new TransactionException(ex.Message, ex);
                }
            }
        }

        public void Commit()
        {
            if (!this.IsInTransaction)
            {
                throw new InvalidOperationException("Operation requires an active transaction.");
            }
            else
            {
                try
                {
                    var session = this.sessionManagementStrategy
                        .GetSession();

                    session.Flush();
                    session.Transaction.Commit();
                    //session.Transaction.Dispose();    27052014
                }
                catch (Exception ex)
                {
                    throw new TransactionException(ex.Message, ex);
                }
            }
        }

        public void Rollback()
        {
            if (!this.IsInTransaction)
            {
                throw new InvalidOperationException("Operation requires an active transaction.");
            }
            else
            {
                try
                {
                    var session = this.sessionManagementStrategy
                        .GetSession();

                    session.Transaction.Rollback();
                    session.Transaction.Dispose();
                }
                catch (Exception ex)
                {
                    throw new TransactionException(ex.Message, ex);
                }
            }
        }

        public void Dispose()
        {
            var session = this.sessionManagementStrategy
                .GetSession();

            session.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
