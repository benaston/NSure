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

License & Copyright
--------

This software is released under the GNU Lesser GPL. It is Copyright 2012, Ben Aston. I may be contacted at ben@bj.ma.

How to Contribute
--------

Pull requests including bug fixes, new features and improved test coverage are welcomed. Please do your best, where possible, to follow the style of code found in the existing codebase.