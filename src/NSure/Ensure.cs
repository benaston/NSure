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
        public static AssertionResult That(bool b, string problemDescription)
        {
            if (!b) throw new Exception(problemDescription);

            return new AssertionResult();
        }

        /// <summary>
        ///   Throws an exception with a meaningful error message,
        ///   that will be visible in the exception when converted 
        ///   to a string (e.g. in the default ASP.NET exception 
        ///   response).
        /// </summary>
        public static AssertionResult That<TException>(bool assertion, string problemDescription, string[] resolutionSuggestions = default(string[]))
            where TException : HelpfulException
        {
            if (!assertion)
            {
                try
                {
                    throw (TException) Activator.CreateInstance(typeof (TException), problemDescription, resolutionSuggestions, null);
                }
                catch(MissingMethodException e)
                {
                    throw new InvalidAssertionFailureExceptionTypeException<TException>(e);
                }
            }

            return new AssertionResult();
        }
    }
}