using System.Linq.Expressions;

namespace ObjectsWithPatternMatching;

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog { Name = "Lucky", BarkVolume = 5 };
        Cat cat = new Cat { Name = "Perry", IsGrumpy = true };
        Bird bird = new Bird { Name = "Mickey", CanTalk = false };
        Goat goat = new Goat { Name = "Little" };

        AnimalDescriber describer = new();

        Console.WriteLine(describer.DescribeAnimal(dog));
        Console.WriteLine(describer.DescribeAnimal(cat));
        Console.WriteLine(describer.DescribeAnimal(bird));
        Console.WriteLine(describer.DescribeAnimal(null));
        Console.WriteLine(describer.DescribeAnimal(goat));
    }
}

public class AnimalDescriber
{
    public string DescribeAnimal(Animal? animal)
    {
        return animal switch
        {
            Dog { BarkVolume: <= 3 } d => $"Quiet dog named {d.Name}",
            Dog { BarkVolume: <= 6 } d => $"Normal barking dog named {d.Name}",
            Dog d => $"Loud dog named {d.Name}",
            Cat c => $"Cat named {c.Name} who is {(c.IsGrumpy ? "grumpy" : "not grumpy")}",
            Bird b => $"Bird named {b.Name} who {(b.CanTalk ? "can talk" : "cannot talk")}",
            null => "No animal provided",
            _ => "Unknown animal"
        };
    }
}


public abstract class Animal
{
    public required string Name { get; set; }
}

public class Dog : Animal
{
    public int BarkVolume { get; set; } // Range: 1–10
}

public class Cat : Animal
{
    public bool IsGrumpy { get; set; }
}

public class Bird : Animal
{
    public bool CanTalk { get; set; }
}

public class Goat : Animal
{
    public void Meee() => Console.WriteLine("I say Meee!");
}
