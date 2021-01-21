using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopBooks_2
{
    public class ClsAuthers : MainClass, Ioperations
    {
        public List<Authors> _Authors;
        public void Add()
        {
            Console.Write("<<<<<<Add New Auther>>>>>>\n\n");

            try
            {
                Authors _newAuther = new Authors();
                if (_Authors == null)
                    _Authors = new List<Authors>();

                if (_Authors.Count == 0)
                    _newAuther.AuthorsId = 1;
                else
                    _newAuther.AuthorsId = _Authors.Last().AuthorsId + 1;

                Console.Write("\n AutherName :");
                _newAuther.AutherName = Console.ReadLine();
                _Authors.Add(_newAuther);
                dt[1].Rows.Add(_newAuther.AuthorsId, _newAuther.AutherName);
                dt[1].WriteXml(_dbDirctory + "/" + _Files[1]);
                Console.WriteLine("\n\n Auther Saved Success\n\n");
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
                if (_Authors != null)
                {
                    foreach (var itm in _Authors)
                        Console.WriteLine(itm.AuthorsId + " : Auther Name:" + itm.AutherName);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public void LoadData()
        {

            var data = new List<Authors>();
            int i = 1;
            dt[i].ReadXml(_dbDirctory + "/" + _Files[i]);

            foreach (DataRow r in dt[i].Rows)
            {
                var item = new Authors()
                {
                    AuthorsId = int.Parse(r["AuthorsId"].ToString()),
                    AutherName = r["AutherName"].ToString(),


                };
                data.Add(item);
            }
            _Authors = data;
        }              

    }
}
