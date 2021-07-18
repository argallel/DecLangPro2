using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;
//holding for future use
////Console.WriteLine($"{"Marks Earned",12:F1}{"Out Of",15:F1}{"Percent",15:F1}{"Course Marks",15:F1}{"Weight/100",15:F1}");


namespace Project2
{
    class Proj2Toolbox
    {

        public static void PrintMainMenu()
        {

            while (true)
            {
                PrintTitle();

                Console.WriteLine("'Y' to adjust the range of years");
                Console.WriteLine("'R' to select a region");
                Console.WriteLine("'S' to select a specific GHG source");
                Console.WriteLine("'X' to exit the program");

                bool valid = false;

                while (!valid)
                {
                    Console.Write("Your Selection: ");
                    Program.userInput = Console.ReadLine();

                    if (Program.userInput == "Y")
                    {
                        AdjustYears();
                        valid = true;
                    }
                    else if (Program.userInput == "R")
                    {
                        SelectRegion();
                        valid = true;
                    }

                    else if (Program.userInput == "S")
                    {
                        SelectGHGSrc();
                        valid = true;
                    }

                    else if (Program.userInput == "X")
                    {
                        Console.WriteLine("\nClosing application...");
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        Console.WriteLine("\nERROR: Input must be one of the above options.");
                    }
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void PrintTitle()
        {
            Console.WriteLine("Greenhouse Gas Emissions in Canada");
            Console.WriteLine("==================================\n");
        }

        public static void AdjustYears()
        {
            while (true)
            {
                Console.Write("Starting year (1990 to 2019: ");
                string temp = Console.ReadLine();

                if(int.TryParse(temp, out int num) && num >= 1990 && num < 2020)
                {
                    Program.startYear = num;
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR: starting year must be between 1990 and 2019.");
                }
            }

            while (true)
            {
                Console.Write("Ending year (1990 to 2019: ");
                string temp = Console.ReadLine();

                if (int.TryParse(temp, out int num) && num >= 1990 && num < 2020)
                {
                    if(num - Program.startYear <= 5 && num - Program.startYear >= 0)
                    {
                        Program.endYear = num;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Ending year must be within 5 years following the starting date.");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: starting year must be between 1990 and 2019.");
                }
            }

        }

        public static void SelectRegion()
        {
            string queryTexts = "//region/@name";
            XPathNodeIterator regionNameNode = Program.nav.Select(queryTexts);

            int counter = 1;

            Console.WriteLine("\nSelect a region by number as shown below...");

            while (regionNameNode.MoveNext())
            {
                Console.WriteLine($"{counter,3}. {regionNameNode.Current.Value}");
                counter++;
            }

            bool valid = false;

            while (!valid)
            {
                Console.Write("\nEnter a region #: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Program.selectedRegion = "Alberta";
                        valid = true;
                        break;

                    case "2":
                        Program.selectedRegion = "British Columbia";
                        valid = true;
                        break;

                    case "3":
                        Program.selectedRegion = "Manitoba";
                        valid = true;
                        break;

                    case "4":
                        Program.selectedRegion = "New Brunswick";
                        valid = true;
                        break;

                    case "5":
                        Program.selectedRegion = "Newfoundland and Labrador";
                        valid = true;
                        break;

                    case "6":
                        Program.selectedRegion = "Northwest Territories";
                        valid = true;
                        break;

                    case "7":
                        Program.selectedRegion = "Northwest Territories and Nunavut";
                        valid = true;
                        break;

                    case "8":
                        Program.selectedRegion = "Nova Scotia";
                        valid = true;
                        break;

                    case "9":
                        Program.selectedRegion = "Nunavut";
                        valid = true;
                        break;

                    case "10":
                        Program.selectedRegion = "Ontario";
                        valid = true;
                        break;

                    case "11":
                        Program.selectedRegion = "Prince Edward Island";
                        valid = true;
                        break;

                    case "12":
                        Program.selectedRegion = "Quebec";
                        valid = true;
                        break;

                    case "13":
                        Program.selectedRegion = "Saskatchewan";
                        valid = true;
                        break;

                    case "14":
                        Program.selectedRegion = "Yukon";
                        valid = true;
                        break;

                    case "15":
                        Program.selectedRegion = "Canada";
                        valid = true;
                        break;

                    default:
                        Console.WriteLine("That was an invalid region please try again...");
                        break;
                }
            }

            //print selected data.
            string queryText = "//region[@name='" + Program.selectedRegion + "']/source/emissions[@year >=" + Program.startYear + " and @year <= " + Program.endYear + "]";
            XPathNodeIterator nodeIt = Program.nav.Select(queryText);

            List<Tuple<double, string>> data = new List<Tuple<double, string>>();

            while (nodeIt.MoveNext())
            {
                
                data.Add(new Tuple<double, string>(Convert.ToDouble(nodeIt.Current.GetAttribute("year", "")), nodeIt.Current.Value));
            }

            int listCounter = 0;
            int yearCounter = 0;

            List<double> years = new List<double>();
            for(int k = Program.startYear; k <= Program.endYear; k++)
            {
                years.Add(k);
            }


            if(data.Count == 0)
            {
                data.Add(new Tuple<double, string>(Program.startYear, "-"));
            }

            while (true)
            {
                if (listCounter < data.Count && data[listCounter].Item1 != years[yearCounter])
                {
                    data.Insert(listCounter, new Tuple<double, string>(years[yearCounter], "-"));
                }
                yearCounter++;
                if(yearCounter == years.Count)
                {
                    yearCounter = 0;
                }

                if(listCounter == (Program.endYear - Program.startYear + 1) * 8 - 1)
                {
                    break;
                }

                listCounter++;
            }

            while(data.Count < (Program.endYear - Program.startYear + 1) * 8 - 1)
            {
                for(int d = 0; d < Program.endYear - Program.startYear + 1; d++)
                {
                    data.Insert(d, new Tuple<double, string>(d + Program.startYear, "-"));
                }
            }


            queryText = "//region[1]/source/@description";
            XPathNodeIterator sourceTypeNode = Program.nav.Select(queryText);

            string title = "\nEmissions in " + Program.selectedRegion + " (Megatonnes)";

            DymanicTitle(title);

            Console.Write($"\n{"Source", 54}");

            for (int i = Program.startYear; i <= Program.endYear; i++)
            {
                Console.Write($"{i,9}");
            }

            Console.WriteLine("\n");

            int dataCounter = 0;

            double f;

            while (sourceTypeNode.MoveNext())
            {
                Console.Write($"{sourceTypeNode.Current.Value, 54}");

                for (int i = Program.startYear; i <= Program.endYear; i++)
                {
                    if (double.TryParse(data[dataCounter].Item2, out f))
                    {
                        Console.Write($"{Math.Round(Convert.ToDouble(data[dataCounter].Item2), 3),9}");
                    }
                    else
                    {
                        Console.Write($"{data[dataCounter].Item2, 9}");
                    }
                    dataCounter++;
                }

                Console.WriteLine();
            }
        }

        public static void SelectGHGSrc()
        {
            string sourceQuery = "//region[1]/source/@description";
            XPathNodeIterator sourceTypeNode = Program.nav.Select(sourceQuery);

            sourceQuery = "//region/@name";
            XPathNodeIterator regionNameNode = Program.nav.Select(sourceQuery);

            int counter = 1;

            Console.WriteLine("\nSelect a region by number as shown below...");

            while (sourceTypeNode.MoveNext())
            {
                Console.WriteLine($"{counter , 3}. {sourceTypeNode.Current.Value}");
                counter++;
            }

            bool valid = false;

            while (!valid)
            {
                Console.Write("\nEnter a source #: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Program.selectedSource = "Agriculture";
                        valid = true;
                        break;

                    case "2":
                        Program.selectedSource = "Buildings";
                        valid = true;
                        break;

                    case "3":
                        Program.selectedSource = "Heavy Industry";
                        valid = true;
                        break;

                    case "4":
                        Program.selectedSource = "Light Manufacturing, Construction and Forest Resources";
                        valid = true;
                        break;

                    case "5":
                        Program.selectedSource = "Oil and Gas";
                        valid = true;
                        break;

                    case "6":
                        Program.selectedSource = "Transport";
                        valid = true;
                        break;

                    case "7":
                        Program.selectedSource = "Waste";
                        valid = true;
                        break;

                    case "8":
                        Program.selectedSource = "Total";
                        valid = true;
                        break;

                    default:
                        Console.WriteLine("That was an invalid source please try again...");
                        break;
                }
            }

            //print selected data.
            string queryText = "//region/source[@description = '" + Program.selectedSource + "']/emissions[@year >=" + Program.startYear + " and @year <= " + Program.endYear + "]";
            XPathNodeIterator sourceDataNode = Program.nav.Select(queryText);

            List<Tuple<double, string>> data = new List<Tuple<double, string>>();

            while (sourceDataNode.MoveNext())
            {

                data.Add(new Tuple<double, string>(Convert.ToDouble(sourceDataNode.Current.GetAttribute("year", "")), sourceDataNode.Current.Value));
            }

            int listCounter = 0;
            int yearCounter = 0;

            List<double> years = new List<double>();
            for (int k = Program.startYear; k <= Program.endYear; k++)
            {
                years.Add(k);
            }


            if (data.Count == 0)
            {
                data.Add(new Tuple<double, string>(Program.startYear, "-"));
            }

            while (true)
            {
                if (listCounter < data.Count && data[listCounter].Item1 != years[yearCounter])
                {
                    data.Insert(listCounter, new Tuple<double, string>(years[yearCounter], "-"));
                }
                yearCounter++;
                if (yearCounter == years.Count)
                {
                    yearCounter = 0;
                }

                if (listCounter == (Program.endYear - Program.startYear + 1) * 15 - 1)
                {
                    break;
                }

                listCounter++;
            }

            while(data.Count < (Program.endYear - Program.startYear + 1) * 15 - 1)
            {
                for (int d = 25; d < Program.endYear - Program.startYear + 26; d++)
                {
                    data.Insert(d, new Tuple<double, string>(d + Program.startYear, "-"));
                }
                for (int d = 30; d < Program.endYear - Program.startYear + 31; d++)
                {
                    data.Insert(d, new Tuple<double, string>(d + Program.startYear, "-"));
                }
                for (int d = 40; d < Program.endYear - Program.startYear + 41; d++)
                {
                    data.Insert(d, new Tuple<double, string>(d + Program.startYear, "-"));
                }
            }

            string title = "\nEmissions from " + Program.selectedSource + " (Megatonnes)";
            DymanicTitle(title);

            Console.Write($"\n{"Region",54}");

            for (int i = Program.startYear; i <= Program.endYear; i++)
            {
                Console.Write($"{i,9}");
            }

            Console.WriteLine("\n");

            int dataCounter = 0;

            double f;

            while (regionNameNode.MoveNext())
            {
                Console.Write($"{regionNameNode.Current.Value,54}");

                for (int i = Program.startYear; i <= Program.endYear; i++)
                {
                    if (double.TryParse(data[dataCounter].Item2, out f))
                    {
                        Console.Write($"{Math.Round(Convert.ToDouble(data[dataCounter].Item2), 3),9}");
                    }
                    else
                    {
                        Console.Write($"{data[dataCounter].Item2,9}");
                    }
                    dataCounter++;
                }

                Console.WriteLine();
            }



            //while (sourceDataNode.MoveNext())
            //{
            //    Console.WriteLine(sourceDataNode.Current.Value);
            //}

        }

        public static void DymanicTitle(string title)
        {
            Console.WriteLine(title);
            for (int i = 1; i < title.Length; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }

    }
}
