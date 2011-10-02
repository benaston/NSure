namespace NSure
{
    using System;
    using NHelpfulException;

    /// <summary>
    ///   Thrown when the exception supplied to be thrown upon an 
    ///   assertion failure cannot be instantiated by the NSure 
    ///   subsystem.
    /// </summary>
    public class InvalidAssertionFailureExceptionTypeException<TException> : HelpfulException
    {
        private const string ProblemDescription =
            @"Unable to instantiate supplied exception type ('{0}'). The exception type supplied must expose the HelpfulException constructor in order to be used with NSure.";

        private static readonly string[] ResolutionSuggestions = new[]
                                                                     {
                                                                         "Expose the HelpfulException constructor in your exception type."
                                                                     };

        public InvalidAssertionFailureExceptionTypeException(Exception innerException = default(Exception))
            : base(String.Format(ProblemDescription, typeof (TException)), ResolutionSuggestions, innerException) {}
    }
}