using System;

namespace ValueVsRefTypes;

public static class DeepAndShallowCopy
{
    public static void DeepAndShallowCopyDemonstration(){
        Person person = new Person(){
            Name = "Olga",
            Scores = new int[]{20, 30, 40,}
        };
        Console.WriteLine($"This is an original copy of the object: {person.Name}, {string.Join(",", person.Scores)}");
        Person shallowCopyPerson = person.ShallowCopy();
        Person deepCopyPerson = person.DeepCopy();

        person.Scores[0] = 200;
        Console.WriteLine("The original object's scores were modified.");
        Console.WriteLine($"This is a shallow copy of the object: {shallowCopyPerson.Name}, {string.Join(",", shallowCopyPerson.Scores)}");
        Console.WriteLine($"This is a deep copy of the object: {deepCopyPerson.Name}, {string.Join(",", deepCopyPerson.Scores)}");

    }
}

public class Person
{
    public string Name { get; set; } = default!;
    public int[] Scores { get; set; } = default!;

    public Person ShallowCopy()
    {
        return (Person)this.MemberwiseClone();
    }

    public Person DeepCopy()
    {
        Person copy = (Person)this.MemberwiseClone();
        // do deep copy of the object
        copy.Scores = (int[])this.Scores.Clone();
        return copy;
    }
}