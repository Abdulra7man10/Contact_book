using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook
{
    public class PhoneNumber
    {
        private string phone;
        private string type;

        public PhoneNumber(string phone = "", string type = "Mobile")
        {
            this.phone = phone;
            this.type = type;
        }

        public void setPhone(string phone) { this.phone = phone; }
        public void setType(string type) { this.type = type; }

        public string getPhone() { return this.phone; }
        public string getType() { return this.type; }

        public void Show()
        {
            Console.WriteLine($"Phone Number : {getPhone()}");
            Console.WriteLine($"Type : {type}");
        }
    }
}
