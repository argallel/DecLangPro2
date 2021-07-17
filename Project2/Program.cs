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
using System.Xml.XPath;

namespace Project2
{
    class Program
    {

        //Variables
        public static string userInput = "";
        public static string selectedRegion = "";
        public static string selectedSource = "";
        public static int startYear = 2015;
        public static int endYear = 2019;
        public static XmlDocument doc;
        public static XPathNavigator nav;

        const string XML_FILE = "ghg-canada.xml";
        static void Main(string[] args)
        {
         

            try
            {
                doc = new XmlDocument();
                doc.Load(XML_FILE);

                nav = Program.doc.CreateNavigator();

                //Console UI
                Proj2Toolbox.PrintMainMenu();
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"DOM ERROR: {ex.Message}");
            }
            catch (XPathException ex)
            {
                Console.WriteLine($"PATH ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GENERAL ERROR: {ex.Message}");
            }
        }
    }
}
