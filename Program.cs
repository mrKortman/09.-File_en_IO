using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.File_en_IO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Een bestand naar de hardeschijf wegschrijjven
            string path = Path.GetTempFileName();
            
            using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
            {   
                string tekst = String.Empty;
                
                Console.WriteLine("Content uit bestand : " + path);
                Console.WriteLine("--------------------------------------");
                for (int i = 0; i < 20; i++)
                {
                    tekst += "Dit is tekst uit een bestand op regel " + i + ".\r\n";
                }

                Byte[] info = new UTF8Encoding(true).GetBytes(tekst);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            // Een bestand van de hardeschijf inlezen en op het scherm zetten
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Copyright 2017 (c) BOS5 (BoyOS 5)");
            Console.ReadLine();
        }

    }
}