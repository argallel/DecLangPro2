/*
 * Program:         Project2.exe
 * Course:          INFO-3138
 * Date:            July 30, 2021
 * Author:          K. Argall, R. Turner
 * Description:     A C# console program that uses the DOM to display information from
 *                  the file ghg-canada.xml and allows to user to choose what to display
 */


using System;
using System.Xml;

namespace Project2
{
    class Program
    {
        const string XML_FILE = "ghg-canada.xml";
        static void Main(string[] args)
        {

            //notes from roland!
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XML_FILE);
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"DOM ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GENERAL ERROR: {ex.Message}");
            }
        }
    }
}
