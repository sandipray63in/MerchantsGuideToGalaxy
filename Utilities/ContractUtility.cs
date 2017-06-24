using System;

namespace Utilities
{
    public static class ContractUtility
    {
        public static void Requires<TException>(bool conditionToBeSatisfied, string exceptionMessage)
            where TException : Exception
        {
            if (!conditionToBeSatisfied)
            {
                throw Activator.CreateInstance(typeof(TException), exceptionMessage) as TException;
            }
        }

        /// <summary>
        /// This is useful when exceptionMessage itself needs to be build after checking the value of conditionToBeSatisfied.
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="conditionToBeSatisfied"></param>
        /// <param name="exceptionMessageFunc"></param>
        public static void Requires<TException>(bool conditionToBeSatisfied, Func<string> exceptionMessageFunc)
            where TException : Exception
        {
            if (!conditionToBeSatisfied)
            {
                var exceptionMessage = exceptionMessageFunc();
                throw Activator.CreateInstance(typeof(TException), exceptionMessage) as TException;
            }
        }
    }
}
