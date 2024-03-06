using System;

namespace ContactBook
{
    public class ContactBook
    {
        private Contact[] contacts;
        private int Count_contacts;
        private int overall_contacts;

        public ContactBook(ref Contact c)
        {
            contacts[Count_contacts++] = c;
            overall_contacts = 0;
        }
        public ContactBook()
        {
            Count_contacts = 0;
            overall_contacts = 0;
            contacts = new Contact[10];
        }

        public void AddUser()
        {
            if (Count_contacts == contacts.Length)
                Array.Resize(ref contacts, Count_contacts * 2);
            string name = "";
            do
            {
                Console.Write("Enter User's name : ");
                name = Console.ReadLine();
            } while (SearchUser(name) != -1);

            contacts[Count_contacts] = new Contact(overall_contacts++, name);

            Console.Write("Enter User's Number : ");
            string number = Console.ReadLine();
            contacts[Count_contacts].AddNumber(number);

            Console.Write("Enter User's City (0 = nothing) : ");
            string city = Console.ReadLine();
            if (city != "0") contacts[Count_contacts].setCity(city);

            Console.Write("Enter User's note (0 = nothing) : ");
            string note = Console.ReadLine();
            if (note != "0") contacts[Count_contacts].setNote(note);

            Console.Write("Enter User's gender [0:Male, 1:Female] : ");
            int gender = int.Parse(Console.ReadLine());
            if (gender == 0 || gender == 1) contacts[Count_contacts].setGender(gender);

            Console.Write("Enter User's type [0:Mobile, 1:Home, 2:Work] : ");
            string type = Console.ReadLine();
            if (type == "1" || type == "2")
            {
                if (type == "1") type = "Home";
                else type = "Work";
                contacts[Count_contacts].EditNumber(number, type);
            }

            DateTime currentDate = DateTime.Now;
            contacts[Count_contacts].setDate(currentDate.ToString("dd-MM-yyyy"));
            Count_contacts++;
            overall_contacts++;
            Console.ReadKey();
            Console.Clear();
        }
        public void EditUser()
        {
            string choose;
            do
            {
                Console.Write("**********************\n" +
                              "* [1] Name           *\n" +
                              "* [2] City           *\n" +
                              "* [3] Note           *\n" +
                              "* [4] Gender         *\n" +
                              "* [5] Add Number     *\n" +
                              "* [6] Edit type      *\n" +
                              "* [7] Delete Number  *\n" +
                              "* [0] Go back        *\n" +
                              "**********************\n");
                Console.Write("Choose Number : ");
                choose = Console.ReadLine();
                if (choose == "0")
                    return;
                Console.Write("User Name : ");
                string name = Console.ReadLine();
                int idx = SearchUser(name);
                if (idx == -1)
                {
                    Console.WriteLine("This name is not exist :(");
                    return;
                }
                switch (choose)
                {
                    case "1":
                        {
                            Console.Write("Enter New Name : ");
                            string new_name = Console.ReadLine();
                            if (SearchUser(new_name) == -1)
                                contacts[idx].setName(new_name);
                            else
                                Console.WriteLine("This new name is already exist :(");
                            break;
                        }

                    case "2":
                        {
                            Console.Write("Enter New City : ");
                            string new_city = Console.ReadLine();
                            contacts[idx].setCity(new_city);
                            break;
                        }

                    case "3":
                        {
                            Console.Write("Enter New Note : ");
                            string new_note = Console.ReadLine();
                            contacts[idx].setNote(new_note);
                            break;
                        }

                    case "4":
                        {
                            Console.Write("Enter Gender [0:Male, 1:Female] : ");
                            int new_gender = int.Parse(Console.ReadLine());
                            contacts[idx].setGender(new_gender);
                            break;
                        }

                    case "5":
                        {
                            Console.Write("Enter New Number : ");
                            string new_number = Console.ReadLine();
                            contacts[idx].AddNumber(new_number);
                            break;
                        }

                    case "6":
                        {
                            Console.Write("Enter one of your numbers : ");
                            string number = Console.ReadLine();
                            Console.Write("Enter User's type [0:Mobile, 1:Home, 2:Work] : ");
                            string type = Console.ReadLine();
                            if (type == "1" || type == "2")
                            {
                                if (type == "1") type = "Home";
                                else type = "Work";
                                contacts[idx].EditNumber(number, type);
                            }
                            break;
                        }

                    case "7":
                        {
                            Console.Write("Enter a number to delete : ");
                            string number = Console.ReadLine();
                            contacts[idx].DeleteNumber(number);
                            break;
                        }

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Please, enter a valid number :)");
                        break;

                }
                Console.ReadKey();
                Console.Clear();
            } while (choose != "0");
        }
        public int CountUser() => Count_contacts;

        public int SearchUser(string name)
        {
            if (Count_contacts == 0)
                return -1;

            for (int i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] != null && contacts[i].getName() == name)
                    return i;
            }
            return -1;
        }

        public void DeleteUser(string name)
        {
            if (contacts.Length == 0)
            {
                Console.WriteLine("The Contacts are Empty :(");
                return;
            }

            int idx = SearchUser(name);
            if (idx == -1)
            {
                Console.WriteLine("This name is not exist :(");
                return;
            }

            contacts[idx] = contacts[contacts.Length - 1];
            contacts[contacts.Length - 1] = null;
            Count_contacts--;
        }

        public void Show(string name)
        {
            if (contacts.Length == 0)
            {
                Console.WriteLine("The Contacts are Empty :(");
                return;
            }

            int idx = SearchUser(name);
            if (idx == -1)
            {
                Console.WriteLine("This name is not exist :(");
                return;
            }
            contacts[idx].Show();
        }
        public void ShowAll()
        {
            if (Count_contacts == 0)
            {
                Console.WriteLine("There is no contacts :)");
                return;
            }
            foreach (var contact in contacts)
            {
                Console.WriteLine("-----------------------");
                contact.Show();
            }
        }
    }
}
