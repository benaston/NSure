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
	using System.ComponentModel;
	using System.Linq.Expressions;
	using NHelpfulException;

	/// <summary>
	/// 	Responsible for providing fluent argument checking functionality.
	/// </summary>
	public class Ensure
	{
		public static AssertionResult That(bool assertion, string problemDescription,
		                                   string[] resolutionSuggestions = default(string[]))
		{
			return That<HelpfulException>(assertion, problemDescription, resolutionSuggestions);
		}

		/// <summary>
		/// 	Throws an exception with a meaningful error message, that will be visible in the exception when converted to a string (e.g. in the default ASP.NET exception response).
		/// </summary>
		public static AssertionResult That<TException>(bool assertion, string problemDescription,
		                                               string[] resolutionSuggestions = default(string[]))
			where TException : HelpfulException
		{
			if (!assertion)
			{
				try
				{
					throw (TException)
					      Activator.CreateInstance(typeof (TException), problemDescription, resolutionSuggestions, null);
				}
				catch (MissingMethodException e)
				{
					throw new InvalidAssertionFailureExceptionTypeException<TException>(e);
				}
			}

			return new AssertionResult();
		}

		/// <summary>
		/// 	Throws an exception with a meaningful error message, based upon analysis of the expression evaluated. WARNING: this overload is experimental and significantly slower than the overload that simply takes a bool.
		/// </summary>
		[Description(
			"Accepts an expression. WARNING: this overload is significantly slower than the overload that simply takes a bool."
			)]
		public static AssertionResult That<TException>(Expression<Func<bool>> func,
		                                               string problemDescription = "",
		                                               string[] resolutionSuggestions = default(string[]))
			where TException : HelpfulException
		{
			if (!func.Compile()())
			{
				try
				{
					var expr = func.Body.ToString();
					var fullDescription = problemDescription == String.Empty
					                      	? string.Format("Failing assertion: '{0}'.", expr)
					                      	: string.Format("{0}\r\nFailing assertion: '{1}'.", problemDescription,
					                      	                expr);

					throw (TException)
					      Activator.CreateInstance(typeof (TException), fullDescription, resolutionSuggestions, null);
				}
				catch (MissingMethodException e)
				{
					throw new InvalidAssertionFailureExceptionTypeException<TException>(e);
				}
			}

			return new AssertionResult();
		}
	}
}