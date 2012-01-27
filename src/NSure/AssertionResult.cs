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
	using System.Linq.Expressions;
	using NHelpfulException;

	/// <summary>
	/// 	Responsible for providing functionality to chain assertions together.
	/// </summary>
	public class AssertionResult
	{
		public AssertionResult And(bool assertion, string problemDescription,
		                           string[] resolutionSuggestions = default(string[]))
		{
			return Ensure.That<HelpfulException>(assertion, problemDescription, resolutionSuggestions);
		}

		public AssertionResult And<TException>(bool assertion, string problemDescription,
		                                       string[] resolutionSuggestions = default(string[]))
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