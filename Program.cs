using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactBook contactBook = new ContactBook();
            string choose;
            do
            {
                Console.Write("***********************\n" +
                          "* [1] Add             *\n" +
                          "* [2] Edit            *\n" +
                          "* [3] Delete          *\n" +
                          "* [4] Search          *\n" +
                          "* [5] Diplay All      *\n" +
                          "* [0] Exit Program    *\n" +
                          "***********************\n");
                Console.Write("Choose Number : ");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        contactBook.AddUser();
                        break;

                    case "2":
                        contactBook.EditUser();
                        break;

                    case "3":
                        {
                            Console.Write("User Name : ");
                            string name = Console.ReadLine();
                            contactBook.DeleteUser(name);
                            break;
                        }

                    case "4":
                        {
                            Console.Write("User Name : ");
                            string name = Console.ReadLine();
                            contactBook.Show(name);
                            break;
                        }

                    case "5":
                        contactBook.ShowAll();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Enter a valid number :)");
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            } while (choose != "0");
        }
    }  
}
