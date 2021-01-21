using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopBooks_2
{
   public class ClsClients:MainClass,Ioperations
    {
        public List<Clients> _Clients;

        public void Add()
        {
            Console.Write("<<<<<<Add New Client>>>>>>\n\n");

            try
            {
                var _newclient = new Clients();
                if (_Clients == null)
                    _Clients = new List<Clients>();

                if (_Clients.Count == 0)
                    _newclient.ClientId = 1;
                else
                    _newclient.ClientId = _Clients.Last().ClientId + 1;

                Console.Write("\n ClientName :");
                _newclient.ClientName = Console.ReadLine();

                Console.Write("\n Email :");
                _newclient.Email = Console.ReadLine();

                Console.Write("\n Password :");
                _newclient.Password = Console.ReadLine();

                Console.Write("\n Adress :");
                _newclient.Adress = Console.ReadLine();

                Console.Write("\n Phone :");
                _newclient.Phone = Console.ReadLine();



                _Clients.Add(_newclient);

                dt[2].Rows.Add(_newclient.ClientId, _newclient.ClientName, _newclient.Adress, _newclient.Password, _newclient.Email, _newclient.Phone);
                dt[2].WriteXml(_dbDirctory + "/" + _Files[2]);
                Console.WriteLine("\n\n Client Saved Success\n\n");
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
                if (_Clients != null)
                {
                    foreach (var itm in _Clients)
                        Console.WriteLine("Id:" + itm.ClientId + " Name:" + itm.ClientName + " Phone:" + itm.Phone + " Email:" + itm.Email + " Adress:" + itm.Adress);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void LoadData()
        {
            var data = new List<Clients>();
            int i = 2;
            dt[i].ReadXml(_dbDirctory + "/" + _Files[i]);

            foreach (DataRow r in dt[i].Rows)
            {
                var item = new Clients()
                {
                    ClientId = int.Parse(r["ClientId"].ToString()),
                    ClientName = r["ClientName"].ToString(),
                    Adress = r["Adress"].ToString(),
                    Email = r["Email"].ToString(),
                    Phone = r["Phone"].ToString(),
                    Password = r["Password"].ToString(),

                };
                data.Add(item);
            }
            _Clients = data;

        }
    }
}
