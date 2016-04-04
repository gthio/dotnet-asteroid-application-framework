using System;
using System.Collections;
using System.Collections.Generic;

namespace Asteroid.Data
{
    public class TransactionException : SystemException
    {
        public TransactionException()
        {
        }

        public TransactionException(string message)
            : base(message)
        {
        }

        public TransactionException(string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
