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
namespace airline_projectFinal
{
    public partial class flight : Form
    {
        
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();
        string s = "Data Source=localhost\\sqlexpress;Initial Catalog=airline;Integrated Security=true";
        DateTime myDateTime = DateTime.Now;
        
        
        public flight()
        {
            InitializeComponent();
            con = new SqlConnection(s);
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                
                string s = "insert into Flight values ('" + textBox2.Text + " ','" +textBox3.Text + "','" + myDateTime.ToString("yyyy-MM-dd HH:mm:ss")+"'," + textBox5.Text+")";
                SqlCommand c = new SqlCommand(s, con);
                c.ExecuteNonQuery();
                MessageBox.Show("data added ");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                da = new SqlDataAdapter("Select * From Flight", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            flight f2 = new flight();
            this.Close();
            f2.Show();

            con.Close();
        }

        private void flight_Load(object sender, EventArgs e)
        {
            con.Open(); 
            this.flightTableAdapter.Fill(this.airlineDataSet.Flight);
            con.Close();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                
                  
                    
                   string s="Update Flight SET from_country='" + textBox2.Text + "',destination = '" + textBox3.Text + "', date_flight = '" + textBox4.Text + "',price = '" + textBox5.Text+"' where flight_code = '"+textBox1.Text+"'";

                    SqlCommand c = new SqlCommand(s, con);
                    c.ExecuteNonQuery();
                if(c.ExecuteNonQuery()==1)
                    MessageBox.Show("data edited");
                else
                    MessageBox.Show("Not Found");
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          
            flight f2 = new flight();
            this.Close();
            f2.Show();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                    string s = "Delete Flight  where flight_code = " + textBox1.Text ;
                    SqlCommand c = new SqlCommand(s, con);
                    c.ExecuteNonQuery();
              //  if (c.ExecuteNonQuery()>1)
                    MessageBox.Show("data deleted");
               
                  //  MessageBox.Show("Not Found");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            flight f2 = new flight();
            this.Close();
            f2.Show();
            con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            flight f2 = new flight();
            this.Close();
            f2.Show();
        }
    }
}
