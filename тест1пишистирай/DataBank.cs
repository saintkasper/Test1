using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тест1пишистирай
{
    public static class DataBank
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-TL7NP8K\SQLEXPRESS;Initial Catalog=Тест1;Integrated Security=True");
    }
}
