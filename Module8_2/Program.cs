using Module8_2;
using System;
using System.IO;
using System.Reflection;

namespace Module8
{
    class Program
    {
        const string SettingsFileName = "Settings.cfg";
        static void Main(string[] args)
        {
            WriteValues();
            ReadValues();
        }

        static void WriteValues()
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(SettingsFileName, FileMode.Create)))
            {
                bw.Write(20.666F);
                bw.Write(@"Text string");
                bw.Write(55);
                bw.Write(false);
            }
        }
        static void ReadValues()
        {
            float FloatValue;
            string StringValue;
            int IntValue;
            bool BoolValue;

            if(File.Exists(SettingsFileName))
            {
                using(BinaryReader br = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
                {
                    FloatValue = br.ReadSingle();
                    StringValue = br.ReadString();
                    IntValue = br.ReadInt32();
                    BoolValue = br.ReadBoolean();
                }
                Console.WriteLine("Из файла считано: ");
                Console.WriteLine($"Дробь: {FloatValue}");
                Console.WriteLine($"Строкаа: {StringValue}");
                Console.WriteLine($"Целое число: {IntValue}");
                Console.WriteLine($"Булевое значение: {BoolValue}");
            }
        }
    }
}