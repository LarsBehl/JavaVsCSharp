namespace JavaVsCSharp.Domain.Local;

/*
While Java uses the implements or extends keywords for implementing an interface or extending a class,
C# uses the :-Operator for both.
*/
public class Student : Person
{
    /*
    The readonly keyword is comparable to final in Java.
    A readonly field can only be initialized once.
    For private fields it is convention to use a leading underscore followed by camelcase for the name.
    */
    private readonly Guid _id;

    /*
    This is an auto-implemented property where the value can only be initialized, but not set later on.
    */
    public required string RegistrationNumber { get; init; }
    /*
    This property uses an explicit backing field to provide a value.
    */
    public Guid Id { get => this._id; }

    /*
    In java, the constructor of the extended class would be called by using super() as the first statement inside the constructors body.
    C# uses once again the :-Operator and the keyword base to refere to the extended class
    */
    public Student() : base()
    {
        this._id = Guid.NewGuid();
    }
}
