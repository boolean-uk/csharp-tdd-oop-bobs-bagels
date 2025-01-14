using System;
using System.Dynamic;

namespace exercise.main;

public class Person
{
    public int SecurityLevel {get; set;}
    public Guid id = Guid.NewGuid();

    public Person(string role)
    {
        if (role == "Manager")
        {
            SecurityLevel = 1;
        }
        else
        {
            SecurityLevel = 0;
        }
     

    }
}
