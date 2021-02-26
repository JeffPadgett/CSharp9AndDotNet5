using static System.Console;
using System;

public class Person
{
    public virtual string DoStuff()
    {       
        WriteLine("This is from person");
        return "Base class returned from Person";
    }
}

public class Employee : Person
{
    public override string DoStuff()
    {
        WriteLine("This is from Employee");
        WriteLine(base.DoStuff());
        return "Base class returned from employee";
    }

}

public class Manager : Employee
{

    public override string DoStuff()
    {
        WriteLine("This is from Manager");
        WriteLine(base.DoStuff());
        return "not obtained because no other class overrides.";
    }

}
