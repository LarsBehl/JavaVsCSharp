using JavaVsCSharp.Domain.Local;

/*
Prior to .NET 6 / C# 10 toplevel statements were not supported.
Instead, much like java, one needed to define a Main-Method somewhere inside the application.
A sample class would have looked like this:
    using System;

    namesapce JavaVsCSharp
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }

In addition to not needing to write a bunch of boilerplate code, implicit-usings were added.
With implicit usings commonly used namspaces are available to all files inside an application.
Depending on the type of application that is developed, additional namespaces are available by default.
For more information refere to https://learn.microsoft.com/en-us/dotnet/core/project-sdk/overview#implicit-using-directives
The usage of implicit-usings can, much like a lot of other features, be configured inside the project definition.
In this case the project is called JavaCsCsharp.csproj
*/
Console.WriteLine("Hello, World!");

/*
A region is a pre-processor directive which can be used to cluster code
*/
#region sample
/*
Here we initialize a list of students.
In C# List is not an interface.
The implementation of a List is comparable to ArrayList in java.

Since .NET 8/C# 12 it is possible to initialize collections using the collection expression "[ <values> ]".
Additionally the object-initializer of a student is used
*/
List<Student> students =
[
    new Student()
    {
        FirstName = "Max",
        LastName = "Mustermann",
        City = "Mustertown",
        Number = 42,
        Street = "Musterstreet",
        Zip = "12345",
        RegistrationNumber = "123"
    }
];

/*
There is a lot going on here so lets dive right into it.
First of all we use Student? instead of Student.
The trailing ? indicates that the value of the variable may be null, so we have to make sure we perform null-checks.

The FirstOrDefault method is an extension Method for all classes implementing the IEnumerable<T> interface.
IEnumerable<T> is comparable to Java streams.

An extension method is a method that is originally not defined inside a given class or interface, but rather added later on.
This enables us to add methods to classes without the need to define a derived type.

In C# it is possible to overload operators.
For the string class, the equals-operator is overloaded to check if the content of the strings match rather than the reference of the objects are the same.
*/
Student? max = students.FirstOrDefault(s => s.FirstName == "Max");

/*
For null checking the 'is' keyword is typically used, but the equals-operator is also supported.
The 'is' keyword can be combined with the 'not' keyword.
*/
if (max is null)
{
    Console.WriteLine("We don't know a Max :(");
    return;
}

/*
Because of the previous nullcheck we can access all members of the object without the fear of a possible null-pointer (and without any warnings).
*/
Guid maxId = max.Id;

Student? heinz = students.FirstOrDefault(s => s.FirstName == "Heinz");
/*
Here we use the ? operator before a member access.
This ensures that the access is only performed if the lefthand value is not null.
If the lefthand value is null, null is the result of the access.
Thus the access of a member of a nullable value is also nullable.
In this case we break the nullable chain by using the ?? operator.
If the lefthand side of the operator evaluates to null, the righthand value is returned.
*/
string heinzStreet = heinz?.Street ?? string.Empty;

/*
Java differentiates between the value type int and the reference type Integer.
In C# the differentiation is not needed.
Instead the language also supports nullable value types (like int?)

We also see another extension method in action: Select()
This method is part of the LINQ namespace.
LINQ stands for Language Integrated Query.
In addition to extension methods for IEnumerable<T>,
LINQ also supports SQL-like queries on IEnumerable<T>:

    IEnumerable<int> numberEnumerable = from s in students
                                        select s.Number;
*/
List<int> numbers = students.Select(s => s.Number).ToList();
#endregion

#region async
/*
Another key difference between Java and C# is support for the asynchronous programming model.
C# has baked in support for async-await which, in comparison to JavaScript, uses multiple threads to perform the work in the background.
*/
HttpClient httpClient = new HttpClient();
Task<HttpResponseMessage> responseTask = httpClient.GetAsync("https://google.de");
Console.WriteLine("This message is printed while the request to google is in flight");
HttpResponseMessage responseMessage = await responseTask;

/*
The async-await support is a whole 'nother section which would take a lot of time to cover.
The most important things to note are:
    1. It is convention to use the 'Async' postfix for asynchronous methods
    2. Asynchronous methods return a Task, Task<T>, ValueTask or ValueTask<T>, even if the non asynchronous method is void!
    3. Asynchronous methods contain the async keyword in the method definition
    4. We have to explicitly await a Task

If someone wants to know more about how async-await works in .NET I really recommend this blogpost:
https://devblogs.microsoft.com/dotnet/how-async-await-really-works/

*/
#endregion
