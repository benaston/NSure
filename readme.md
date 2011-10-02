NSure
=====

Simple fluent assertions for .NET.

Examples:
--------
*Simple assertion:*
<code>
Ensure.That(myObject != null, "myObject is null.");
</code>

*Assertion with suggestions for resolution in the failure case:*
<code>
Ensure.That(myObject != null, "myObject is null.", resolutionSuggestions:new[]{ "Make sure myObject is instantiated.", "Go make some more coffee." });
</code>

*Custom exception type:*
<code>
Ensure.That<MyCustomException>(myObject != null, "myObject is null.");
</code>

*Assertion chaining:*
<code>
Ensure.That<MyCustomException>(myObject != null, "myObject is null.")
	  .And(myOtherObject != null, "myOtherObject is null.");
</code>