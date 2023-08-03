using System;

using System.Reflection;


namespace ConAppAssignment22
{
    public class Program
    {
        public static void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                PropertyInfo matchingDestinationProperty = Array.Find(destinationProperties, dp => dp.Name == sourceProperty.Name);

                if (matchingDestinationProperty != null && matchingDestinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    matchingDestinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
    
            static void Main(string[] args)
        {
            Source source = new Source
            {
                Id = 1,
                Name = "John",
                Age = 30,
               
        };

            Destination destination = new Destination
            {
                Address ="4A,Vinay Street, Chennai,Tamilnadu"
            };

        MapProperties(source, destination);

        Console.WriteLine("Mapped Properties:");
        Console.WriteLine("Destination Properties");
        Console.WriteLine($"Id: {destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Salary: {destination.Salary}");
        Console.WriteLine($"Address: {destination.Address}");

            Console.ReadKey();
    }
}

}
 
