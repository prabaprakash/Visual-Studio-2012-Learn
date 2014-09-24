using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;

namespace Linq
{
    class Program
    {
        private static void Main(string[] args)
        {
            //xmlTextReader
           XmlTextReader reader=new XmlTextReader(@"C:/users/Prabakarthi/Desktop/table.xml");
            while (reader.Read())
            {
               // Console.WriteLine("Name - {0}",reader.Name);
               // Console.WriteLine("NameTable - {0}", reader.NameTable);
                Console.WriteLine(reader.Depth.ToString());
            }
            reader.Close();
            //xmlTextWriter
            XmlTextWriter writer = new XmlTextWriter("C:/users/Prabakarthi/Desktop/table1.xml",null);
            writer.WriteStartDocument();
            writer.WriteStartElement("Name");
            writer.WriteString("Praba");
            writer.WriteEndElement();
            writer.Close();
            Timer n = new Timer(state => Console.WriteLine("Hello"));

            int i;
            for (i = 0; i <= 100; i++)
            {
                Console.WriteLine("{0}*9={1}", i, i * 318);
            }
            Console.ReadLine();
            Type t = Type.GetType("System.Console");
            MethodInfo[] pi = t.GetMethods();
            foreach (var propertyInfo in pi)
            {
                Console.WriteLine(propertyInfo.Name);
            }
            Console.ReadLine();
        }
     
    }
    
}
