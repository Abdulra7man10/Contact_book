using System;

namespace ContactBook
{
    public class Contact
    {
        private int id;
        private string name;
        private int gender;
        private string city;
        private string note;
        private string date;
        private int count_numbers;
        private PhoneNumber[] phoneNumbers;

        //constructor
        public Contact() { }
        public Contact(int id, string name, string date = "", int gender = 2, string city = "", string note = "")
        {
            this.id = id;
            this.name = name;
            this.date = date;
            this.gender = gender;
            this.city = city;
            this.note = note;
            count_numbers = 0;
            phoneNumbers = new PhoneNumber[5];
            //Array.Resize(ref phoneNumbers, 5);
        }

        // Setter methods
        public void setId(int id) { this.id = id; }
        public void setName(string name) { this.name = name; }
        public void setGender(int gender) { this.gender = gender; }
        public void setCity(string city) { this.city = city; }
        public void setNote(string note) { this.note = note; }
        public void setDate(string date) { this.date = date; }
        public void setPhoneNumbers(PhoneNumber[] phoneNumbers) { this.phoneNumbers = phoneNumbers; }

        // Getter methods
        public int getId() { return id; }
        public string getName() { return name; }
        public string getGender()
        {
            if (gender == 0)
                return "MALE";
            if (gender == 1)
                return "FEMALE";
            return "EMPTY";
        }
        public string getCity() { return city; }
        public string getNote() { return note; }
        public string getDate() { return date; }
        public PhoneNumber[] getPhoneNumbers() { return phoneNumbers; }

        //other
        // SearchNumber method
        public int SearchNumber(string phoneNumber)
        {
            if (phoneNumbers == null)
                return -1;

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (phoneNumbers[i] != null && phoneNumbers[i].getPhone() == phoneNumber)
                    return i;
            }
            return -1;
        }

        public bool AddNumber(string phoneNumber, string type = "Mobile")
        {
            if (SearchNumber(phoneNumber) != -1)
            {
                Console.WriteLine("This number is alread exist :)");
                return false;
            }
            if (count_numbers == 5)
            {
                Console.WriteLine("Numbers are full :(\nYou need to delete number to add new one :)");
                return false;
            }
            phoneNumbers[count_numbers] = new PhoneNumber(phoneNumber, type);
            count_numbers++;
            return true;
        }
        public bool DeleteNumber(string PhoneNumber)
        {
            if (phoneNumbers.Length == 0)
            {
                Console.WriteLine("NO NUMBER EXIST :(");
                return false;
            }
            int idx = SearchNumber(PhoneNumber);
            if (idx == -1)
            {
                Console.WriteLine("This number not exist here :)");
                return false;
            }
            phoneNumbers[idx] = phoneNumbers[phoneNumbers.Length - 1];
            phoneNumbers[phoneNumbers.Length - 1] = null;
            count_numbers--;
            return true;
        }

        public bool EditNumber(string PhoneNumber, string type = "")
        {
            int idx = SearchNumber(PhoneNumber);
            if (idx == -1)
            {
                Console.WriteLine("This number not exist here :)");
                return false;
            }
            if (type != "") phoneNumbers[idx].setType(type);
            return true;
        }

        public void Show()
        {
            string show_string = $"ID: {id}\nName: {name}\n";
            if (getGender() != "EMPTY")
                show_string += $"Gender: {getGender()}\n";
            if (city != "")
                show_string += $"City: {city}\n";
            if (note != "")
                show_string += $"Note: {note}\n";
            Console.WriteLine(show_string + $"Date: {date}");

            if (count_numbers > 0)
            {
                for (int i = 0; i < count_numbers; i++)
                {
                    phoneNumbers[i].Show();
                    Console.WriteLine("---------------");
                }
            }
            else
                Console.WriteLine("\nNo phone numbers");
        }
    }
}
