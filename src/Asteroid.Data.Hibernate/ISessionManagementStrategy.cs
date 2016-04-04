using System;

using NHibernate;

namespace Asteroid.Data.Hibernate
{
    public interface ISessionManagementStrategy
    {
        ISession GetSession();
    }
}
