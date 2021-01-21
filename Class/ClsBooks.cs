using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopBooks_2
{
    public class ClsBooks : MainClass, Ioperations
    {
        public ClsBooks() : base()
        {

        }
        public List<Books> _booksGallary;

        public void Add()
        {
            Console.Write("<<<<<<Add New Books>>>>>>\n\n");
            try
            {
                if (_booksGallary == null)
                    _booksGallary = new List<Books>();

                Books _newBook = new Books();
                _newBook.Authers = new Authors();

                if (_booksGallary.Count == 0)
                    _newBook.BookId = 1;
                else
                    _newBook.BookId = _booksGallary.Last().BookId + 1;

                Console.Write("\n BookName :");
                _newBook.BookName = Console.ReadLine();
                Console.Write("\n BookType 0 for Papers 1 For Elctronic :");
                _newBook.BookType = (Books.EBookType)int.Parse(Console.ReadLine());
                Console.Write("\n Price :");
                _newBook.Price = double.Parse(Console.ReadLine());
                _newBook.Count = 1;

                Console.Write("\n AutherId :");
                _newBook.Authers.AuthorsId = int.Parse(Console.ReadLine());

                _booksGallary.Add(_newBook);
                dt[0].Rows.Add(_newBook.BookId, _newBook.BookName, _newBook.BookType, _newBook.Price, _newBook.Authers.AuthorsId);
                dt[0].WriteXml(_dbDirctory + "/" + _Files[0]);
                Console.WriteLine("\n\n Book Saved Success\n\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DisplayAll()
        {
            try
            {
                Console.WriteLine("Welcome To Gallary CSU Shop Books \n\n");
                foreach (var itm in _booksGallary)
                    Console.WriteLine(itm.BookId + " : Book Name:" + itm.BookName + ">> Price:" + itm.Price + ">> By:" + itm.Authers.AuthorsId + ">> Type:" + Enum.GetName(itm.BookType.GetType(), itm.BookType));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void LoadData()
        {

            _booksGallary = new List<Books>();
            int i = 0;
            
            dt[i].ReadXml(_dbDirctory + "/" + _Files[i]);

            foreach (DataRow r in dt[i].Rows)
            {
                Books _Book = new Books()
                {
                    BookId = int.Parse(r["BookId"].ToString()),
                    BookName = r["BookName"].ToString(),
                    Price = double.Parse(r["Price"].ToString()),
                    Authers = new Authors() { AuthorsId = int.Parse(r["AuthersId"].ToString()) }

                };
                _booksGallary.Add(_Book);
            }

        }
    }
}
