using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBooks_2
{
   public class CartShoping
    {
        public CartShoping()
        {
            Client = new Clients() {Email="Moahmedslam2000@yahoo.com",Phone="+79292369570", Adress = "129 Brotov Kashrin", ClientId = 1, ClientName = "Mohamed Sallam" };
        }
        public int CarId;
        public Clients Client;

        public List<Books> Books = new List<Books>();
        public List<Books> BooksGift = new List<Books>();        
        public Shipments ShipEntity = new Shipments();

        public double CostOf_AllBooks;
        public double CostOf_PapersBooks;
        public double CostOf_ElctronicBooks;

        public double PrecentDiscount;
        public double CostDiscount;
        public double SumPayment;

    }
}
