using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;

namespace ShopBooks_2
{
   public  class Program
    {
        public static Operation _ShopBooks=new Operation();

 
        static void Main(string[] args)
        {
           
            
       

            while (true)
            {
               
                Console.WriteLine("<<<<<\t\tWellCome To Shop Books of CSU\t\t>>>>>\n");
                Console.WriteLine("======================================================================================================");
                Console.WriteLine("| F1 Main Menue" +
                                  "| F2 Books" +
                                  "| F3 Authers" +
                                  "| F4 Client" +
                                  "| F5 Cars"+
                                  "| F8 Clear|               " +
                                  "Any Keys to Close|\n______________________________________________________________________________________________________");
                Console.WriteLine("");

                ConsoleKeyInfo cmd = Console.ReadKey();
                if (cmd.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    //  goto str;
                }
                else if (cmd.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("\n\nF1 To AddNew\n" +
                                      "F2 To Display Galary\n" +
                                      "Any To Main Menue\n\n");

                    cmd = Console.ReadKey();
                    if (cmd.Key == ConsoleKey.F1)
                        _ShopBooks._clsBooks.Add();
                    else if (cmd.Key == ConsoleKey.F2)
                    {

                        _ShopBooks._clsBooks.DisplayAll();
                        while (true)
                        {
                            Console.WriteLine("\nF3 To Add Book To Car Any Key to main Mnue\n");
                            cmd = Console.ReadKey();
                            if (cmd.Key == ConsoleKey.F3)
                            {
                                Console.Write("Insert BookId:");
                                int _bookId = int.Parse(Console.ReadLine());
                                _ShopBooks.AddBookToCar(_bookId);
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }

                }
                else if (cmd.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.WriteLine("\n\nF1 To AddNew Auther\n" +
                                     "F2 To Display All Authers\n" +
                                     "Any To Main Menue\n\n");
                    cmd = Console.ReadKey();
                    if (cmd.Key == ConsoleKey.F1)
                        _ShopBooks._clsAuthers.Add();
                    else if (cmd.Key == ConsoleKey.F2)
                        _ShopBooks._clsAuthers.DisplayAll();
                }
                else if (cmd.Key == ConsoleKey.F4)
                {

                    Console.Clear();
                    Console.WriteLine("\n\nF1 To AddNew \n" +
                                     "F2 To Display All \n" +
                                     "Any To Main Menue\n\n");
                    cmd = Console.ReadKey();
                    if (cmd.Key == ConsoleKey.F1)
                        _ShopBooks._clsClients.Add();
                    else if (cmd.Key == ConsoleKey.F2)
                        _ShopBooks._clsClients.DisplayAll();

                }
                else if (cmd.Key == ConsoleKey.F5)
                {

                    if (_ShopBooks._MyCarShoping.Books.Count > 0)
                    {
                        while (true)
                        {

                            _ShopBooks.DisplayMyCarBooks();
                            Console.WriteLine("\n\nPress F1 to Main Menue \nPress F6 to Shipment \n\n");
                            cmd = Console.ReadKey();
                            if (cmd.Key == ConsoleKey.F1)
                            {
                                Console.Clear();
                                break;
                            }
                            else if (cmd.Key == ConsoleKey.F6)
                            {
                                _ShopBooks.CalculateCostCar();
                                Console.Clear();
                                Console.WriteLine("You are now in Shipment Step Press \n\nF1  \nF7 To Payment and Shipment Info  \nOther Keys to Close\n");
                                cmd = Console.ReadKey();
                                if (cmd.Key == ConsoleKey.F1)
                                {
                                    break;
                                }
                                else if (cmd.Key == ConsoleKey.F7)
                                {
                                    _ShopBooks.DisplayShipmentData();

                                }

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Your Car Is Empty \nPress F1 to Main Menue \nAny key to Close\n");
                        if (Console.ReadKey().Key == ConsoleKey.F1)
                        {
                            Console.Clear();

                        }
                        else
                            break;
                    }

                }
                else if (cmd.Key == ConsoleKey.F8)
                    Console.Clear();
                else
                    break;
            }
            Console.WriteLine("\n\nGood Bay: ");
           
        }
    }
}
