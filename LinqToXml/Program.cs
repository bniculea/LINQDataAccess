using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateXmlFile();
            //LoadingXmlFiles();
            //ReadingXmlFile();
            //ReadingXmlFile2();
            UsingStandardQueryOperators();
        }

        private static void UsingStandardQueryOperators()
        {


            XDocument document = XDocument.Load("Employees.xml");
            var developers = from element in document.Descendants("Job")
                where element.Name == "Job" && element.Value == "Developer"
                orderby element.Value
                select element.Value;

            foreach (var developer in developers)
            {
                Console.WriteLine(developer);
            }

        }

        private static void ReadingXmlFile2()
        {
            //Puts the document in memory
            XDocument document = XDocument.Load("Employees.xml");
            XElement root = document.Root;

            foreach (XElement xElement in document.Elements("Employees").Elements("Employee"))
            {
                string value = xElement.Value;
                Console.WriteLine($"Name: {xElement.Name}\tValue:{value}");
            }
        }

        private static void ReadingXmlFile()
        {
            //Explicit conversions perform value extraction
            //Values stored as text
                //parsed on an as-needed basis
            //Support for nullable types
            XElement xml = XElement.Parse("<Employee Type=\"Developer\">Bogdan </Employee>");
            string name = (string) xml; //Bogdan
            string type = (string) xml.Attribute("Type"); //Developer
            double? salary = (double?) xml.Attribute("Salary"); //yields null
            int age = (int) xml.Attribute("Age"); // exception!!

        }

        private static void LoadingXmlFiles()
        {
            XDocument document = XDocument.Load("Employees.xml");
           // XElement element = XElement.Load("http://wwww.pluralsight.com/blogs/rss/apx");

            using (XmlReader reader = document.CreateReader())
            {
                if (reader.Read())
                {
                    XNode node = XNode.ReadFrom(reader);
                }
            }
           // XElement  inline = XElement.Parse(@"<Employees\>");
        }

        private static void CreateXmlFile()
        {
            XDocument doc = new XDocument(
                new XElement("Modules",
                    new XElement("Module", "Introduction to LINQ"),
                    new XElement("Module", "LINQ and C#")));
            doc.Save("Modules.xml");
        }
    }
}
