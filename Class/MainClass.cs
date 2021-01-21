using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace ShopBooks_2
{
  public abstract  class MainClass
    {
        public MainClass()
        {
            Create_Files_db();
        }
    
        public String _dbDirctory = "Database";
        public string[] _Files = new string[] { "Books.xml", "Authers.xml", "Clients.xml", "Cars.xml" };
        public DataTable[] dt;
        private void Create_Files_db()
        {

            dt = new DataTable[_Files.Length];
            if (!Directory.Exists(_dbDirctory))
                Directory.CreateDirectory(_dbDirctory);

            for (int i = 0; i < _Files.Length; i++)
            {
                string FullPath = _dbDirctory + "/" + _Files[i];

                dt[i] = new DataTable(_Files[i]);

                if (_Files[i] == "Books.xml")
                {
                    dt[i].Columns.Add("BookId");
                    dt[i].Columns.Add("BookName");
                    dt[i].Columns.Add("BookType");
                    dt[i].Columns.Add("Price");
                    dt[i].Columns.Add("AuthersId");
                }
                else if (_Files[i] == "Authers.xml")
                {
                    dt[i].Columns.Add("AuthorsId");
                    dt[i].Columns.Add("AutherName");
                }
                else if (_Files[i] == "Clients.xml")
                {
                    dt[i].Columns.Add("ClientId");
                    dt[i].Columns.Add("ClientName");
                    dt[i].Columns.Add("Adress");
                    dt[i].Columns.Add("Password");
                    dt[i].Columns.Add("Email");
                    dt[i].Columns.Add("Phone");

                }
                else if (_Files[i] == "Cars.xml")
                {
                    dt[i].Columns.Add("ClientId");
                    dt[i].Columns.Add("BookId");
                }

                if (!File.Exists(FullPath))
                {
                    dt[i].WriteXmlSchema(FullPath);
                }
                else
                {
                    dt[i].ReadXmlSchema(FullPath);
                }




            }


        }
        

    }
}
