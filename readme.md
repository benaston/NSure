NSure
=====

Simple fluent assertions for .NET.

Examples:
--------
**Simple assertion:**

`

	Ensure.That(myObject != null, "myObject is null.");
	
`

**Assertion with suggestions for resolution in the failure case:**

`

	Ensure.That(myObject != null, "myObject is null.",
				resolutionSuggestions:new[]{ "Make sure myObject is instantiated.", "Go make some more coffee." });
				
`

**Custom exception type:**

`

	Ensure.That<MyCustomException>(myObject != null, "myObject is null.");
	
`

**Assertion chaining:**

`

	Ensure.That<MyCustomException>(myObject != null, "myObject is null.")
		  .And(myOtherObject != null, "myOtherObject is null.");
	
`