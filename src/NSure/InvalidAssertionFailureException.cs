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

namespace NSure
{
	using System;
	using NHelpfulException;

	/// <summary>
	/// 	Thrown when the exception supplied to be thrown upon an assertion failure cannot be instantiated by the NSure subsystem.
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