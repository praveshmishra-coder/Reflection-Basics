using System;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type studentType = assembly.GetType("Reflection.Student");

            // Create instance of Student class
            object studentObj = Activator.CreateInstance(studentType);

            // Set PRIVATE Id property
            PropertyInfo idProp = studentType.GetProperty(
                "Id",
                BindingFlags.NonPublic | BindingFlags.Instance);

            idProp.SetValue(studentObj, 101);

            // Set PUBLIC Name property
            PropertyInfo nameProp = studentType.GetProperty("Name");
            nameProp.SetValue(studentObj, "Amit");

            // Call DisplayInfo method
            MethodInfo displayMethod = studentType.GetMethod("DisplayInfo");
            displayMethod.Invoke(studentObj, null);

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine("Class Name: " + type.Name);
                Console.WriteLine("\n--- Properties ---");
                foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine(prop.Name);
                }
                Console.WriteLine("\n--- Methods ---");
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    Console.WriteLine(method.Name);
                }
                Console.WriteLine("\n");
            }


        }
    }
}

