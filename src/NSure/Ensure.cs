namespace NSure
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text.RegularExpressions;
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

                    throw (TException)Activator.CreateInstance(typeof(TException), problemDescription, resolutionSuggestions, null);
                }
                catch (MissingMethodException e)
                {
                    throw new InvalidAssertionFailureExceptionTypeException<TException>(e);
                }
            }

            return new AssertionResult();
        }

        /// <summary>
        ///   Throws an exception with a meaningful error message,
        ///   based upon analysis of the expression evaluated.
        ///   WARNING: this overload is significantly slower than 
        ///   the overload that simply takes a bool.
        /// </summary>
        [Description("Accepts an expression. WARNING: this overload is significantly slower than the overload that simply takes a bool.")]
        public static AssertionResult That<TException>(Expression<Func<bool>> func,
                                                       string problemDescription = "",
                                                       string[] resolutionSuggestions = default(string[]))
            where TException : HelpfulException
        {
            if (!func.Compile()())
            {
                try
                {
                    var expr = func.Body.ToString();
                    var fullDescription = problemDescription == String.Empty ? string.Format("Failing assertion: '{0}'.", expr) : string.Format("{0}\r\nFailing assertion: '{1}'.", problemDescription, expr);

                    throw (TException)Activator.CreateInstance(typeof(TException), fullDescription, resolutionSuggestions, null);
                }
                catch (MissingMethodException e)
                {
                    throw new InvalidAssertionFailureExceptionTypeException<TException>(e);
                }
            }

            return new AssertionResult();
        }
    }
}