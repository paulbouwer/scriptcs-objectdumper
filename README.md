scriptcs-objectdumper
=====================

# About #

This [Script Pack](https://github.com/scriptcs/scriptcs/wiki) for [scriptcs](http://scriptcs.net/) provides provides object dumper behaviour.

This script pack allows the structure of objects to be dumped from within the REPL or scripts. It utilises JSON.Net for serialisation. A number of options are provided:

- Object References (Include/Exclude)
- Output Format (PrettyPrint/Compact)
- Null Values (Include/Exclude)

# Installation #

Install the nuget package by running

	scriptcs -install ScriptCs.ObjectDumper.ScriptPack


# Usage #

Obtain a reference to the Script Pack and configure using one ore more build methods. Finally call Build() to construct the dumper.

    var dumper = Require<ObjectDumper>()
		.Compact()
		.Build();

You can then dump an object as follows:

	public class Person  
	{
		public string FirstName {get; set;}
		public string LastName {get;set;}
	}
	var person = new Person { FirstName = "Paul", LastName = "Bouwer" }

	Console.WriteLine( dumper.Dump(person) );

# Configuration #

The object dumper can be build by combining one or more of the following methods. Remember to call Build() at the end of the chain to construct the dumper.

The following object will be used to demonstrate the build methods:

	public class Person  
	{
		public string FirstName {get; set;}
		public string LastName {get;set;}
		public Address Address1 {get;set;}
		public Address Address2 {get;set;}
	}
	public class Address 
	{
		public string Line1 {get;set;}
		public string Line2 {get;set;}
	}	
	var address = new Address { Line1 = "Line1" };
	var person = new Person { FirstName = "Paul", LastName = "Bouwer", Address1 = address, Address2 = address};

## Object References ##

You can include or exclude object references. The serialiser used (JSON.NET) can add references when the same object is referred to within the object being dumped.

**IncludeObjectReferences()**

	var dumper = Require<ObjectDumper>()
	  .IncludeObjectReferences()
	  .Build();

Results in the following:

	{
	  "$id": "1",
	  "FirstName": "Paul",
	  "LastName": "Bouwer",
	  "Address1": {
	    "$id": "2",
	    "Line1": "Line1"
	  },
	  "Address2": {
	    "$ref": "2"
	  }
	}

**ExcludeObjectReferences()**

	var dumper = Require<ObjectDumper>()
	  .ExcludeObjectReferences()
	  .Build();

Results in the following:

	{
	  "FirstName": "Paul",
	  "LastName": "Bouwer",
	  "Address1": {
	    "Line1": "Line1",
	    "Line2": null
	  },
	  "Address2": {
	    "Line1": "Line1",
	    "Line2": null
	  }
	}

## Formatting ##

You can format the dumped output as pretty printed or compact. Here is what that looks like:

** PrettyPrint() **

	var dumper = Require<ObjectDumper>()
	  .PrettyPrint()
	  .Build();

Results in the following:

	{
	  "FirstName": "Paul",
	  "LastName": "Bouwer",
	  "Address1": {
	    "Line1": "Line1",
	    "Line2": null
	  },
	  "Address2": {
	    "Line1": "Line1",
	    "Line2": null
	  }
	}
	
** Compact() **

	var dumper = Require<ObjectDumper>()
	  .PrettyPrint()
	  .Build();

Results in the following:

	{"FirstName":"Paul","LastName":"Bouwer","Address1":{"Line1":"Line1","Line2":null},"Address2":{"Line1":"Line1","Line2":null}}

## Null Values ##

You can also include or exclude null values from the dumped object. Here is what that looks like:

** IncludeNullValues() **

	var dumper = Require<ObjectDumper>()
	  .IncludeNullValues()
	  .Build();

Results in the following:

	{
	  "FirstName": "Paul",
	  "LastName": "Bouwer",
	  "Address1": {
	    "Line1": "Line1",
	    "Line2": null
	  },
	  "Address2": {
	    "Line1": "Line1",
	    "Line2": null
	  }
	}

** ExcludeNullValues() **

	var dumper = Require<ObjectDumper>()
	  .ExcludeNullValues()
	  .Build();

Results in the following:

	{
	  "FirstName": "Paul",
	  "LastName": "Bouwer",
	  "Address1": {
	    "Line1": "Line1",
	  },
	  "Address2": {
	    "Line1": "Line1",
	  }
	}

## Defaults ##

The following options are the defaults:

- Object References - ExcludeObjectReferences()
- Formatting - PrettyPrint()
- Null Values - IncludeNullValues()

# Sample #

A example of how to use the Script Pack is available in the ``sample`` folder. 
