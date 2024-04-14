/*
A namespace is comparable to a package.
While java enforces that the package structure represents the folder structure,
C# allows us to use arbitrary namespace names and structures.
However it is good practice that the namespace structure represents the package structure.
Prior to C# 10, another syntax for the definition of a namespace was the only allowed:

namespace JavaVsCSharp.Domain.local
{

}

All classes have to be part of an namespace and thus reside inside the namespace definition.
With C# 10 file-scoped namespaces were added, as this is how they are most often used.
*/
namespace JavaVsCSharp.Domain.Local;

/*
Just like Java, the definition of a class consists of a visibility modifier, the keyword class and the name of the class.
In general it is convention to use PascalCase for classnames, members and methods and to use camelCase for parameters
There are other modifiers that can be added to this general structure (like abstract, or sealed),
but this is also similar to Java.
More information on this topic can be found in the official documentation: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members
*/
public class Person
{
    /*
    We have a lot of differences to cover here, so lets start.
    In Java when we add attributes so a class, we typically define the attribute as private and implement getter and setter methods (or use something like lombok to generate the getters and setters).
    C# on the other hand supports properties.
    Properties can be thought of like getter and setter methods for attributes of a class.
    All properties of this class, except the FullName property are socalled auto-implemented properties.
    The C# compiler automatically generates a backing field where the actual values are stored.

    In addition, all auto-implemented properties of this class have the required keyword after the visibility modifier.
    This keyword describes that on object initialization, the given property has to be filled with a value.
    This is especially usefull when unsing Nullability and object initializers, which are onther way to initialize an object instead of needing to define constructors.
    */
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Zip { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required int Number { get; set; }
    /*
    This is the only property, which is not auto-implemented.
    Instead we defined an explicit getter, which utilizes other properties of this class
    */
    public string FullName { get => $"{this.FirstName} {this.LastName}"; }

    /*
    This is a classic constructor.
    As far as coding conventions go, it is not needed (encouraged) to specify the this-keyword when accessing members or methods of the current class.
    However I personally prefere to specify that whatever I am accessing or calling, is part of the current class.
    For everybody coding with TypeScript they might feel like home
    */
    public Person(string firstName, string lastName, string zip, string city, string street, int number)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Zip = zip;
        this.City = city;
        this.Street = street;
        this.Number = number;
    }

    /*
    When this constructor is called, all required properties need to be initialized using the object initializer.
    A sample usage can be found in Program.cs
    */
    public Person()
    {

    }
}
