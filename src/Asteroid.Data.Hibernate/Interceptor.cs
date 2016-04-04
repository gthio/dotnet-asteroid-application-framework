using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using NHibernate;
using NHibernate.Type;

namespace Asteroid.Data.Hibernate
{
    public class Interceptor : EmptyInterceptor
    {
        private const string PROPERTY_NAME_DATE_CREATED = "CreatedDateTime";
        private const string PROPERTY_NAME_DATE_UPDATED = "UpdatedDateTime";
        private const string PROPERTY_NAME_TIME_STAMP = "DateLastUpdated";
        private const string PROPERTY_NAME_UPDATED_BY = "UpdatedBy";

        public override bool OnSave(object entity,
            object id,
            object[] state,
            string[] propertyNames,
            IType[] types)
        {
            var timeStampPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_TIME_STAMP);
            var dateCreatedPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_DATE_CREATED);
            var dateUpdatedPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_DATE_UPDATED);
            var updatedByPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_UPDATED_BY);

            if (timeStampPosition != -1)
            {
                state[timeStampPosition] = DateTime.Now;
            }

            if (dateCreatedPosition != -1)
            {
                state[dateCreatedPosition] = DateTime.Now;
            }

            if (dateUpdatedPosition != -1)
            {
                state[dateUpdatedPosition] = DateTime.Now;
            }

            if (updatedByPosition != -1)
            {
                state[updatedByPosition] = "Creator";
            }

            return true;
        }

        public override bool OnFlushDirty(object entity,
            object id,
            object[] currentState,
            object[] previousState,
            string[] propertyNames,
            IType[] types)
        {
            var dateUpdatedPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_DATE_UPDATED);
            var updatedByPosition = Array.IndexOf(propertyNames, PROPERTY_NAME_UPDATED_BY);

            if (dateUpdatedPosition != -1)
            {
                currentState[dateUpdatedPosition] = DateTime.Now;
            }

            if (updatedByPosition != -1)
            {
                currentState[updatedByPosition] = "Updater";
            }

            return true;
        }
    }

}
