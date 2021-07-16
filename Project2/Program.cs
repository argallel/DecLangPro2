﻿/*
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

        //Variables
        public static string userInput = "";
        public static string selectedRegion = "";
        public static string selectedSource = "";
        public static int startYear = 2015;
        public static int endYear = 2019;

        const string XML_FILE = "ghg-canada.xml";
        static void Main(string[] args)
        {
            //print initial title
            Proj2Toolbox.printTitle();

            //Console UI
            Proj2Toolbox.printMainMenu();










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
