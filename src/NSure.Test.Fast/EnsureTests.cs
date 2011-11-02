namespace NSure.Test.Fast
{
    using System;
    using NHelpfulException;
    using NUnit.Framework;

    [TestFixture]
    public class EnsureTests
    {
        [Test]
        public void EnsureThat_SuppliedWithTrue_DoesNotThrowAnException()
        {
            Assert.DoesNotThrow(() => Ensure.That(true, "m"));
        }

        [Test]
        public void EnsureThat_SuppliedWithFalseAndExceptionTypeNotSpecified_ThrowsAnException()
        {
            Assert.Throws<HelpfulException>(() => Ensure.That(false, "m"));
        }

        [Test]
        public void EnsureThat_SuppliedWithFalseAndAMessage_ThrowsAnExceptionWithTheCorrectMessage()
        {
            const string message = "My message.";

            try
            {
                Ensure.That(false, message);
            }
            catch (Exception e)
            {
                Assert.That(e.Message == message);
            }
        }

        [Test]
        public void EnsureThat_SuppliedWithExceptionTypeAndFalse_ThrowsATestException()
        {
            Assert.Throws<TestException>(() => Ensure.That<TestException>(false, "m"));
        }

        [Test]
        public void EnsureThat_SuppliedWithExceptionTypeFalseAndAMessage_ThrowsATestExceptionWithTheCorrectMessage()
        {
            const string message = "My message.";

            try
            {
                Ensure.That<TestException>(false, message);
            }
            catch (TestException e)
            {
                Assert.That(e.Message == message);
            }
        }

        [Test]
        public void EnsureThat_SuppliedWithExceptionTypeFalseAndAMessageAndResolutionSuggestions_ThrowsATestExceptionWithTheCorrectMessage()
        {
            const string message = "My message.";
            var resolutionSuggestions = new[] { "Try A.", "Try B." };

            try
            {
                Ensure.That<TestException>(false, message, resolutionSuggestions);
            }
            catch (TestException e)
            {
                Assert.That(e.Message == message + 
                                         HelpfulException.ResolutionSuggestionListPrefix + 
                                         HelpfulException.ResolutionSuggestionPrefix + 
                                         resolutionSuggestions[0] + 
                                         HelpfulException.ResolutionSuggestionDelimiter +
                                         HelpfulException.ResolutionSuggestionPrefix + 
                                         resolutionSuggestions[1] + 
                                         HelpfulException.ResolutionSuggestionListSuffix);
            }
        }

        [Test]
        public void EnsureThat_Expression_ReturnsCorrectMessage()
        {
            try
            {
                var a = 1;
                Ensure.That<TestException>(() => a == 2);
            }
            catch (TestException e)
            {
                Assert.That(e.Message == "Failing assertion: '(value(NSure.Test.Fast.EnsureTests+<>c__DisplayClass6).a == 2)'.");

            }
        }

        [Test]
        public void EnsureThat_SuppliedWithFalseAndInvalidExceptionType_ThrowsAnException()
        {
            Assert.Throws<InvalidAssertionFailureExceptionTypeException<InvalidTestException>>(() => Ensure.That<InvalidTestException>(false, "m"));
        }

        [Test]
        public void EnsureThatAnd_ChainedAssertionFails_ThrowsAnException()
        {
            Assert.Throws<HelpfulException>(() => Ensure.That<TestException>(true, String.Empty).And(false, "m"));
        }

        [Test]
        public void EnsureThatAndWithExceptionTypeSpecified_ChainedAssertionFails_ThrowsAnException()
        {
            Assert.Throws<TestException>(() => Ensure.That(true, String.Empty).And<TestException>(false, "m"));
        }

        private class TestException : HelpfulException
        {
            public TestException(string problemDescription, string[] resolutionSuggestions = default(string[]), Exception innerException = default(Exception)) : base(problemDescription, resolutionSuggestions, innerException) { }
        }

        private class InvalidTestException : HelpfulException
        {
            public InvalidTestException(string problemDescription) : base(problemDescription, null, null) { }
        }
    }
}