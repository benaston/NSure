namespace NHelpfulExceptions
{
    using System;

    public class ArgumentNullException : HelpfulException
    {
        public ArgumentNullException(string problemDescription, string[] resolutionSuggestions = default(string[]), Exception innerException = default(Exception)) : base(problemDescription, resolutionSuggestions, innerException) {}
    }
}