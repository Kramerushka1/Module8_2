using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module8
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet("Gerda", 2);
            Console.WriteLine("Объект создан");
            Console.WriteLine();

            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, pet);
                    Console.WriteLine("Объект сериализован");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сериализации: {ex.Message}");
            }

            try
            {
                using (FileStream fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
                {
                    Pet newPet = (Pet)bf.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine();
                    Console.WriteLine($"Имя: {newPet.Name}\nВозраст: {newPet.Age}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
            }
        }
    }
    [Serializable]
    public class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}