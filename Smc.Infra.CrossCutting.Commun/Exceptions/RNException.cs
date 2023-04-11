using System;

namespace Smc.Infra.CrossCutting.Commun.Exceptions
{
    public class RNException : Exception
    {
        public RNException(string message) : base (message)
        {

        }
    }
}
