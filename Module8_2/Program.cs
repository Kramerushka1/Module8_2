using System;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module8
{
    /// <summary>
    /// Задание 8.4.3
    /// </summary>
    /// Дан класс. Доработайте его и сериализуйте в бинарный формат
    class Program
    {
        static void Main(string[] args)
        {
            Contact person = new Contact("Vik", 77052439520, "painandlove95@mail.ru");
            Console.WriteLine("Объект создан");
            Console.WriteLine();

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
                Console.WriteLine();
            }
        }
    }

    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}