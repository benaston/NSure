namespace NSure
{
    using System;
    using NHelpfulException;

    /// <summary>
    ///   Responsible for providing functionality to 
    ///   chain assertions together.
    /// </summary>
    public class AssertionResult
    {
        public AssertionResult And(bool assertion, string message)
        {
            if (!assertion)
            {
                var e = new Exception(message);
                throw e;
            }

            return new AssertionResult();
        }

        public AssertionResult And<TException>(bool assertion, string message, string source)
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

        public AssertionResult And<TException>(bool assertion, string message)
            where TException : HelpfulException
        {
            if (!assertion)
            {
                var e = (TException) Activator.CreateInstance(typeof (TException), message);
                throw e;
            }

            return new AssertionResult();
        }
    }
}