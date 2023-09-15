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
using System.IO;  //MemoryStream stream import
using System.Drawing.Imaging;//image format 
namespace airline_projectFinal
{
    public partial class passenger : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();
        string s = "Data Source=localhost\\sqlexpress;Initial Catalog=airline;Integrated Security=true";
        DateTime myDateTime = DateTime.Now;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();

        public static int ID;
        public static string NAME;
        public static string NATIONALITY;

        public static string PHONE;
        public static byte [] IMAGE;


        public passenger()
        {
            con = new SqlConnection(s);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ticket f = new ticket();
            this.Hide();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
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
                    DataRow r3 = airlineDataSet.Tables["Passenger"].NewRow(); //make a new row at the dataset on the table info
                    r3["name_passenger"] = textBox2.Text;
                    NAME = textBox2.Text;
               


                     r3["nationality"] = textBox3.Text;
                     r3["phone_num"] = textBox4.Text;
             
                     NATIONALITY = textBox3.Text;
                     PHONE = textBox4.Text;
                     MemoryStream ms = new MemoryStream();  //for the img buffer to save the img temporary before convert it to another type(byte)
                    pictureBox1.Image.Save(ms, ImageFormat.Bmp);  //save the img
                    byte[] arr = ms.ToArray(); //Convert it to byte
                    r3["img"] = arr;


                IMAGE = ms.ToArray();
                airlineDataSet.Tables["Passenger"].Rows.Add(r3);  //add the whole row
                    try
                    {
                        passengerTableAdapter.Update(airlineDataSet.Passenger);
                      
                        MessageBox.Show("data saved successfully");
                    }
                    catch
                    {
                        MessageBox.Show("failure occured");
                    }
                }
                catch
                {
                    MessageBox.Show("insert an id and name");
                }


            passenger f2 = new passenger();
            this.Close();
            f2.Show();
            con.Close();
        }

        private void passenger_Load(object sender, EventArgs e)
        {


            this.passengerTableAdapter.Fill(this.airlineDataSet.Passenger);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files| *.bmp;*.gif;*.jpg;*.png;*.tif;*.jfif; |All files| *.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {

                string s = "Delete Passenger where id_passenger = " + textBox1.Text;
                SqlCommand c = new SqlCommand(s, con);
                c.ExecuteNonQuery();
               
                    MessageBox.Show("data deleted");
               
                 //   MessageBox.Show("Not Found");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            passenger f2 = new passenger();
            this.Close();
            f2.Show();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passenger f = new passenger();
            this.Close();
            f.Show();
           
        }


    }
}
