using System;
using System.Collections;
using System.Collections.Generic;

namespace Asteroid.Framework
{
    public abstract class EntityBase
    {
        private string code;

        public EntityBase()
        {
        }

        public EntityBase(string code)
        {
            this.code = code;
        }

        public virtual long Id
        {
            get;
            protected set;
        }

        public virtual long TenantId
        {
            get;
            protected set;
        }

        public virtual string Code
        {
            get
            {
                return this.code;
            }
            protected internal set
            {
                this.code = value;
            }
        }

        public virtual string UpdatedBy
        {
            get;
            set;
        }

        public virtual string CreatedBy
        {
            get;
            set;
        }

        public virtual DateTime? CreatedOn
        {
            get;
            set;
        }

        public virtual DateTime? UpdatedOn
        {
            get;
            set;
        }

        public virtual DateTime? TimeStamp
        {
            get;
            set;
        }
    }
}
