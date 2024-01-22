using Module8_2;
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
            string name = "Vik";
            long phoneNumber = 87052439520;
            string email = "painandlove95@mail.ru";

            Person person = new Person(name, phoneNumber, email);
            Console.WriteLine("Объект создан");
            Console.WriteLine();

            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("customers.dat", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, person);
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
                using (FileStream fs = new FileStream("customers.dat", FileMode.OpenOrCreate))
                {
                    Person newPerson = (Person)bf.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine();
                    Console.WriteLine(
                        $"Имя: {newPerson.Name}" +
                        $"\nНомер телефона: {newPerson.PhoneNumber}" +
                        $"\nEmail: {newPerson.Email}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
            }



        }
    }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Person(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}