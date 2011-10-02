namespace NHelpfulExceptions
{
    using System;

    public class ArgumentException : HelpfulException
    {
        public ArgumentException(string problemDescription, string[] resolutionSuggestions = default(string[]), Exception innerException = default(Exception)) : base(problemDescription, resolutionSuggestions, innerException) {}
    }
}