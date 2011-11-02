namespace NSure
{
    using System;
    using System.Linq.Expressions;
    using NHelpfulException;

    /// <summary>
    ///   Responsible for providing functionality to 
    ///   chain assertions together.
    /// </summary>
    public class AssertionResult
    {
        public AssertionResult And(bool assertion, string problemDescription, string[] resolutionSuggestions = default(string[]))
        {
            return Ensure.That<HelpfulException>(assertion, problemDescription, resolutionSuggestions);
        }

        public AssertionResult And<TException>(bool assertion, string problemDescription, string[] resolutionSuggestions = default(string[]))
            where TException : HelpfulException
        {
            return Ensure.That<TException>(assertion, problemDescription, resolutionSuggestions);
        }

        public AssertionResult And<TException>(Expression<Func<bool>> func,
                                                       string problemDescription,
                                                       string[] resolutionSuggestions = default(string[]))
            where TException : HelpfulException
        {
            return Ensure.That<TException>(func, problemDescription, resolutionSuggestions);
        }
    }
}