using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTable_Linq
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void Main(string[] args)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));

            dt.Rows.Add("Michael", 35);
            dt.Rows.Add("Kobe", 34);
            dt.Rows.Add("Jordan", 3);

            var query = from DataRow o in dt.Rows
                        orderby (int)o["Age"]
                        select new Person(){ Name = (string)o["Name"], Age = Int32.Parse(o["Age"].ToString())}  ;

            var lst =  query.ToList();
        }
    }
}
