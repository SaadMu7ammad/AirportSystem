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
   
    public partial class ticket : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt = new DataTable();
        string s = "Data Source=localhost\\sqlexpress;Initial Catalog=airline;Integrated Security=true";
        public ticket()
        {
            con = new SqlConnection(s);
            InitializeComponent();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            passenger f = new passenger();
            this.Hide();
            f.Show();
        }

        private void ticket_Load(object sender, EventArgs e)
        {
            
            this.flightTableAdapter.Fill(this.airlineDataSet.Flight);
            this.ticketTableAdapter1.Fill(this.airlineDataSet5.Ticket);

            try
            {
                da = new SqlDataAdapter("Select * From Flight", con);
                DataTable dt3 = new DataTable();
                da.Fill(dt3);
                dataGridView1.DataSource = dt3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MemoryStream ms = new MemoryStream(passenger.IMAGE);
            Bitmap b = new Bitmap(ms);
            pictureBox1.Image = b;
            label7.Text = passenger.NAME;
            label8.Text = passenger.NATIONALITY;
            label9.Text = passenger.PHONE;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            con.Open();

            try
            {

  MemoryStream ms = new MemoryStream();  //for the img buffer to save the img temporary before convert it to another type(byte)
                pictureBox1.Image.Save(ms, ImageFormat.Bmp);  //save the img
                //Convert it to byte
                DataRow r4 = airlineDataSet5.Tables["Ticket"].NewRow(); //make a new row at the dataset on the table info
                r4["flight_code"] = textBox1.Text;
                r4["from_country"] = textBox2.Text;
                r4["destination"] = textBox3.Text;
                r4["date_flight"] = textBox4.Text;
                r4["price"] = textBox5.Text;
                 
                r4["name_passenger"] = passenger.NAME ;
                r4["nationality"] = passenger.NATIONALITY;
                r4["phone_num"] = passenger.PHONE;
                r4["img"] = passenger.IMAGE; ;

                airlineDataSet5.Tables["Ticket"].Rows.Add(r4);  //add the whole row
                try
                {
                    ticketTableAdapter1.Update(airlineDataSet5.Ticket);

                    MessageBox.Show("data saved successfully");
                }
                catch
                {
                    MessageBox.Show("failure occured");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


          

            ticket f2 = new ticket();
            this.Close();
            f2.Show();
            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
              
              
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
               

                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

     
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string doc = "flight code : ";
               
                    doc += dataGridView2.SelectedRows[0].Cells[0].Value.ToString();

                doc += "\n from_country: " + dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                doc += "\n destination: " + dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                doc += "\n date_flight: " + dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                doc += "\n price: " + dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                doc += "\n name_passenger:" + dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                doc += "\n nationality: " + dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
                doc += "\n phone_num: " + dataGridView2.SelectedRows[0].Cells[7].Value.ToString();

               
                byte[] arr = (byte[])(dataGridView2.SelectedRows[0].Cells[8].Value);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap b = new Bitmap(ms);
                
                e.Graphics.DrawImage(b, new Rectangle(400, 0, 200, 200));


                e.Graphics.DrawString(doc, new Font("Times New Roman", 34, FontStyle.Bold), Brushes.Black, new Point(25, 25));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string s = "Delete from Ticket where flight_code='"+textBox1.Text+"'AND phone_num='"+passenger.PHONE+"'";
                SqlCommand c = new SqlCommand(s,con);
              
                c.ExecuteNonQuery();
              //  if (c.ExecuteNonQuery() > 0)
                    MessageBox.Show("data deleted");
               
                  //  MessageBox.Show("Not Found");
               
                
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ticket f2 = new ticket();
            this.Close();
            f2.Show();
            con.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
              