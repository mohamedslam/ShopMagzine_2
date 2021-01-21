using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBooks_2
{
   public class Books: MainClass
    {
        public Books() { }
   
        public enum EBookType
        { 
        Papers,Elctronic
        }
        public int BookId;
        public string BookName;
        public  Authors Authers ;   
        public EBookType BookType;
        public double Price;
        public int Count = 1;



    }
}
