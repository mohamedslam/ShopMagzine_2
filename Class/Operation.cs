using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ShopBooks_2
{
    public class Operation
    {
        public Operation()
        {
            //Create_Files_db();

            _clsBooks.LoadData();
            _clsAuthers.LoadData();
            _clsClients.LoadData();
            LoadCarsShop();
        }
        public ClsAuthers _clsAuthers = new ClsAuthers();
        public ClsClients _clsClients = new ClsClients();
        public ClsBooks _clsBooks = new ClsBooks();
        public CarsShop _MyCarShoping = new CarsShop();



        public void LoadCarsShop()
        {

            var data = new List<CarsShop>();
            int i = 3;
            _clsBooks.dt[i].ReadXml(_clsBooks._dbDirctory + "/" + _clsBooks._Files[i]);

            foreach (DataRow r in _clsBooks.dt[i].Rows)
            {
                var item = new CarsShop()
                {
                    CarId = int.Parse(r["CarId"].ToString()),
                    Client=new Clients() {ClientId= int.Parse(r["ClientId"].ToString())},
                    


                };
                data.Add(item);
            }


        }                
        public void DisplayMyCarBooks()
        {
            Console.WriteLine("Books In Your Car now \n");

            foreach (var itm in _MyCarShoping.Books)
            {

                Console.WriteLine(itm.BookId +
                    " >> Book Name:" + itm.BookName +
                    " >> Price:" + itm.Price + " Count:" + itm.Count +
                    " >> WritenBy:" + itm.Authers.AuthorsId +
                    " >> Type:" + Enum.GetName(itm.BookType.GetType(), itm.BookType));
            }
            CalculateCostCar();
            Console.WriteLine("\nTotal Cost:" + _MyCarShoping.CostOf_AllBooks);
        }
        public void DisplayShipmentData()
        {
            CalculateCostCar();
            Console.WriteLine("\n<<<<<<<<Client Information>>>>>>>>>>>> "
                + "\n Id: " + _MyCarShoping.Client.ClientId
                + "\n Name: " + _MyCarShoping.Client.ClientName
                + "\n Adress: " + _MyCarShoping.Client.Adress
                + "\n Email: " + _MyCarShoping.Client.Email
                + "\n Phone: " + _MyCarShoping.Client.Phone
                + "\n\n<<<<<<<Cost Information>>>>>>>>>> \n\n"
                + "Elctornic Books: " + _MyCarShoping.CostOf_ElctronicBooks + " RUB"
                + "\nPapers Book: " + _MyCarShoping.CostOf_PapersBooks + " RUB"
                + "\nTotal Cost: " + _MyCarShoping.CostOf_AllBooks + " RUB"
                + "\nDiscount Percent: " + _MyCarShoping.PrecentDiscount + " %"
                + "\nDiscount Cost:" + _MyCarShoping.CostDiscount + " RUB"
                + "\n  Net Payment:" + (_MyCarShoping.CostOf_AllBooks - _MyCarShoping.CostDiscount) + " RUB"
                );
        }
        public void CalculateCostCar()
        {

            foreach (var itm in _MyCarShoping.Books)
                _MyCarShoping.CostOf_AllBooks += itm.Price * itm.Count;

            var GroupAuthar = from x in _MyCarShoping.Books
                              where x.BookType == Books.EBookType.Papers
                              group x by x.Authers.AuthorsId;

            foreach (var k in GroupAuthar)
            {
                int c = k.Count();
                if (c > 1)
                {
                    var AuthId = k.FirstOrDefault().Authers.AuthorsId;

                    Console.WriteLine("\n<<<<<<<<<<<<<Congratulation You Have Gift Elctronic Book For Auther: " + k.FirstOrDefault().Authers.AutherName + ">>>>>>>>>>>>>");
                    var Authar_EBook_Gifts = from x in _clsBooks._booksGallary
                                             where x.BookType == Books.EBookType.Elctronic && x.Authers.AuthorsId == AuthId
                                             select x;
                    Console.WriteLine("\n\n<<<<<<<<<<<<<< Select Book You Want>>>>>>>>>>>>\n");
                    foreach (var itm in Authar_EBook_Gifts)
                    {
                        Console.WriteLine(itm.BookId +
                               " >> Book Name:" + itm.BookName +
                               " >> Price:" + itm.Price + "\n");

                    }
                    string BookId = Console.ReadLine();
                    if (BookId != "" && BookId != null)
                    {
                        var SelectedBook = _clsBooks._booksGallary.Find(m => m.BookId == int.Parse(BookId));
                        if (SelectedBook != null)
                            _MyCarShoping.Books.Add(SelectedBook);

                    }



                }
            }




            _MyCarShoping.PrecentDiscount = 0.1;
            _MyCarShoping.CostDiscount = _MyCarShoping.CostOf_AllBooks * _MyCarShoping.PrecentDiscount;


        }

        #region AddMethod
        public void AddBookToCar(int BookId)
        {
            var SelectedBook = _clsBooks._booksGallary.Find(m => m.BookId == BookId);
            if (SelectedBook != null)
                _MyCarShoping.Books.Add(SelectedBook);
        }
        
     
        #endregion

    }
}
