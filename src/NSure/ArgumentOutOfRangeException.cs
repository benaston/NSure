namespace NHelpfulExceptions
{
    using System;

    public class ArgumentOutOfRangeException : HelpfulException
    {
        public ArgumentOutOfRangeException(string problemDescription, string[] resolutionSuggestions = default(string[]), Exception innerException = default(Exception)) : base(problemDescription, resolutionSuggestions, innerException) {}
    }
}