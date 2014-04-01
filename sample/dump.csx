var dumper = Require<ObjectDumper>()
  .ExcludeObjectReferences()
	.Build();

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

Console.WriteLine( dumper.Dump(person) );
