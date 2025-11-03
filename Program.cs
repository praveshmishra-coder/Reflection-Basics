using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main()
        {
            // Get the type of the Student class
            Type type = typeof(Student);

            Console.WriteLine("Class Name: " + type.Name);
            Console.WriteLine("\n--- Properties ---");
            foreach (PropertyInfo prop in type.GetProperties())
            {
                Console.WriteLine(prop.Name);
            }

            Console.WriteLine("\n--- Methods ---");
            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

            // Create object using reflection
            object obj = Activator.CreateInstance(type);
            type.GetProperty("Id")?.SetValue(obj, 1);
            type.GetProperty("Name")?.SetValue(obj, "Pravesh");

            // Call method using reflection
            MethodInfo displayMethod = type.GetMethod("DisplayInfo");
            displayMethod.Invoke(obj, null);
        }
    }
}

