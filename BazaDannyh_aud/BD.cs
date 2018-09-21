using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace BazaDannyh_aud
{
    public class BD
    {
        static string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\StudentsFiles\RPZ\RPZ3\Чубіна\BD.mdf;Integrated Security=True;Connect Timeout=30";
        
        static SqlConnection con;

        public BD()
        {
            con = new SqlConnection(connect);
        }

        public static void InsertUsers(string n, string p)
        {
                con = new SqlConnection(connect);
                con.Open();

                SqlCommand com = new SqlCommand("insert into [dbo].Users(name_user, pass) values('" + n + "'," + p + ")", con);

                com.ExecuteNonQuery();
            
                con.Close();

        }
        public static DataTable GetTable(string t)
        {
            
            using (con = new SqlConnection(connect))
            {
                SqlCommand comm = new SqlCommand("select * from " + t, con);

                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }


    }
}
