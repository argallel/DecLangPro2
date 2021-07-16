using System;
using System.Collections.Generic;
using System.Text;
//holding for future use
////Console.WriteLine($"{"Marks Earned",12:F1}{"Out Of",15:F1}{"Percent",15:F1}{"Course Marks",15:F1}{"Weight/100",15:F1}");


namespace Project2
{
    class Proj2Toolbox
    {

        public static void printMainMenu()
        {
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
                    adjustYears();
                    valid = true;
                }
                else if (Program.userInput == "R")
                {
                    selectRegion();
                    valid = true;
                }

                else if (Program.userInput == "S")
                {
                    selectGHGSrc();
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
        }

        public static void printTitle()
        {
            Console.WriteLine("Greenhouse Gas Emissions in Canada");
            Console.WriteLine("==================================\n");
        }

        public static void adjustYears()
        {

        }

        public static void selectRegion()
        {
            Console.WriteLine("\nSelect a region by number as shown below...");
            Console.WriteLine("1. Alberta");
            Console.WriteLine("2. British Columbia");
            Console.WriteLine("3. Manitoba");
            Console.WriteLine("4. New Brunswick");
            Console.WriteLine("5. Newfoundland and Labrador");
            Console.WriteLine("6. Northwest Territories");
            Console.WriteLine("7. Northwest Territories and Nunavut");
            Console.WriteLine("8. Nova Scotia");
            Console.WriteLine("9. Nunavut");
            Console.WriteLine("10. Ontario");
            Console.WriteLine("11. Prince Edward Island");
            Console.WriteLine("12. Quebec");
            Console.WriteLine("13. Saskatchewan");
            Console.WriteLine("14. Yukon");
            Console.WriteLine("15. Canada\n");

            bool valid = false;

            while (!valid)
            {
                Console.Write("Enter a region #: ");

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

        }

        public static void selectGHGSrc()
        {
            Console.WriteLine("\nSelect a source by number as shown below...");
            Console.WriteLine("1. Agriculture");
            Console.WriteLine("2. Buildings");
            Console.WriteLine("3. Heavy Industry");
            Console.WriteLine("4. Light Manufacturing, Construction and Forest Resources");
            Console.WriteLine("5. Oil and Gas");
            Console.WriteLine("6. Transport");
            Console.WriteLine("7. Waste");
            Console.WriteLine("8. Total");

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

        }


    }
}
