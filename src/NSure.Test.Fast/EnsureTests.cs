// Copyright 2011, Ben Aston (ben@bj.ma).
// 
// This file is part of NSure.
// 
// NSure is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NSure is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NSure.  If not, see <http://www.gnu.org/licenses/>.

namespace NSure.Test.Fast
{
	using System;
	using NHelpfulException;
	using NUnit.Framework;

	[TestFixture]
	public class EnsureTests
	{
		private class TestException : HelpfulException
		{
			public TestException(string problemDescription, string[] resolutionSuggestions = default(string[]),
			                     Exception innerException = default(Exception))
				: base(problemDescription, resolutionSuggestions, innerException) {}
		}

		private class InvalidTestException : HelpfulException
		{
			public InvalidTestException(string problemDescription) : base(problemDescription, null, null) {}
		}

		[Test]
		public void EnsureThatAndWithExceptionTypeSpecified_ChainedAssertionFails_ThrowsAnException()
		{
			Assert.Throws<TestException>(() => Ensure.That(true, String.Empty).And<TestException>(false, "m"));
		}

		[Test]
		public void EnsureThatAnd_ChainedAssertionFails_ThrowsAnException()
		{
			Assert.Throws<HelpfulException>(() => Ensure.That<TestException>(true, String.Empty).And(false, "m"));
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
				Assert.That(e.Message == "Failing assertion: '(value(NSure.Test.Fast.EnsureTests+<>c__DisplayClass4).a == 2)'.");
			}
		}

		[Test]
		public void EnsureThat_SuppliedWithExceptionTypeAndFalse_ThrowsATestException()
		{
			Assert.Throws<TestException>(() => Ensure.That<TestException>(false, "m"));
		}

		[Test]
		public void
			EnsureThat_SuppliedWithExceptionTypeFalseAndAMessageAndResolutionSuggestions_ThrowsATestExceptionWithTheCorrectMessage
			()
		{
			const string message = "My message.";
			var resolutionSuggestions = new[] {"Try A.", "Try B."};

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
		public void EnsureThat_SuppliedWithFalseAndExceptionTypeNotSpecified_ThrowsAnException()
		{
			Assert.Throws<HelpfulException>(() => Ensure.That(false, "m"));
		}

		[Test]
		public void EnsureThat_SuppliedWithFalseAndInvalidExceptionType_ThrowsAnException()
		{
			Assert.Throws<InvalidAssertionFailureExceptionTypeException<InvalidTestException>>(
				() => Ensure.That<InvalidTestException>(false, "m"));
		}

		[Test]
		public void EnsureThat_SuppliedWithTrue_DoesNotThrowAnException()
		{
			Assert.DoesNotThrow(() => Ensure.That(true, "m"));
		}
	}
}