NSure
=====

Simple fluent assertions for .NET.

Examples:
--------
**Simple assertion:**

```C#


	Ensure.That(myObject != null, problemDescription:"myObject is null.");
	
```

**Assertion with suggestions for resolution in the failure case:**

```C#


	Ensure.That(myObject != null, "myObject is null.",
				resolutionSuggestions:new[]{ "Make sure myObject is instantiated.", "Go make some more coffee." });
				
```

**Custom exception type:**

```C#


	Ensure.That<MyCustomException>(myObject != null, "myObject is null.");
	
```

**Assertion chaining:**

```C#


	Ensure.That<MyCustomException>(myObject != null, "myObject is null.")
		  .And(myOtherObject != null, "myOtherObject is null.");
	
```

How to build and/or run the tests:
--------

1. Run `/build/build.bat`
1. Type in the desired option
1. Hit return