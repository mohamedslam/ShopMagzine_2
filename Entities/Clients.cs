using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBooks_2
{
   public class Clients
    {
        
        public int ClientId;
        public String ClientName;
        public string Email;
        public string Password;
        public string Adress;
        public string Phone;
        public string PromoCode;
        public List<Books> Books = new List<Books>();

    }
}
