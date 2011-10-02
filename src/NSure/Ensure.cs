namespace NSure
{
    using System;
    using NHelpfulException;

    /// <summary>
    ///   Responsible for providing fluent argument 
    ///   checking functionality.
    /// </summary>
    public class Ensure
    {
        public static AssertionResult That(bool b, string message)
        {
            if (!b) throw new Exception(message);

            return new AssertionResult();
        }

        /// <summary>
        ///   Throws an exception with a meaningful error message,
        ///   that will be visible in the exception when converted 
        ///   to a string (e.g. in the default ASP.NET exception 
        ///   response).
        /// </summary>
        public static AssertionResult That<TException>(bool assertion, string message)
            where TException : HelpfulException
        {
            if (!assertion)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }

            return new AssertionResult();
        }

        public static AssertionResult That<TException>(bool assertion, string message, string source)
            where TException : HelpfulException
        {
            if (!assertion)
            {
                var e = (TException)Activator.CreateInstance(typeof(TException), message);
                e.Source = source;
                throw e;
            }

            return new AssertionResult();
        }

        public static void That(bool b, Action failureAction)
        {
            if (!b)
            {
                failureAction();
                throw new Exception("Unexpected condition.");
            }
        }

        /// <summary>
        ///   Note: no exception thrown.
        /// </summary>
        public static void That<TResponse>(bool b, Func<TResponse, TResponse> failureAction, out TResponse response)
            where TResponse : new()
        {
            response = !b ? failureAction(new TResponse()) : default(TResponse);
        }
    }
}