using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace BazaDannyh_aud
{
    public partial class Form1 : Form
    {
        static string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\StudentsFiles\RPZ\RPZ3\Чубіна\BD.mdf;Integrated Security=True;Connect Timeout=30";

       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                
                dataGridView1.DataSource = BD.GetTable(textBox1.Text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {

            comboBox1.ValueMember = "Id_prod";
            comboBox1.DisplayMember = "name_prod";
            comboBox1.DataSource = BD.GetTable("Product");

                
            comboBox2.ValueMember = "Id_categ";
            comboBox2.DisplayMember = "name_categ";
            comboBox2.DataSource = BD.GetTable("Category");
            } 

        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

            using (SqlConnection con = new SqlConnection(connect))
            {
                SqlCommand com = new SqlCommand("Select * FROM Users where name_user like '%" + textBox2.Text + "%'", con);
                SqlDataAdapter ad = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
