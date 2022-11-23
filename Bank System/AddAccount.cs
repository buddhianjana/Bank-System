using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System
{
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();
            DisplayAcc();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=MADURA;Initial Catalog=Bank;Integrated Security=True");
        private void DisplayAcc()
        {
            Con.Open();
            string Query = "select * from AccountTable";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Reset()
        {
            name.Text = "";          
            address1.Text = "";
            address2.Text = "";
            city.Text = "";
            email.Text = "";
            phone.Text = "";
            country.Text = "";
            actype.Text = "";
            accnum.Text = "";
            sortcode.Text = ""; 
            initialbal.Text = "";
            over.Text = "";
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(name.Text=="" || address1.Text=="" || address2.Text=="" || city.Text=="" || email.Text=="" || phone.Text==""  || country.Text==""
                || actype.Text=="" || accnum.Text=="" ||sortcode.Text=="" || initialbal.Text=="" || over.Text=="")
            {
                MessageBox.Show("Missing Information","Required");
            }
            else {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into  AccountTable(ACName,ACAdd,ACAdd2,ACCity,ACEmail,ACPhone,ACCountry,ACType,ACNum," +
                        "ACSort,ACIntial,ACOver) Values(@name,@address1,@address2,@city,@email,@phone,@country,@actype,@accnum,@sortcode,@initialbal,@over)", Con);
                    cmd.Parameters.AddWithValue("@name", name.Text);
                    //cmd.Parameters.AddWithValue("@surname", surname.Text);
                    cmd.Parameters.AddWithValue("@address1", address1.Text);
                    cmd.Parameters.AddWithValue("@address2", address2.Text);
                    cmd.Parameters.AddWithValue("@city", city.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@phone", phone.Text);
                    cmd.Parameters.AddWithValue("@country", country.Text);
                    cmd.Parameters.AddWithValue("@actype", actype.Text);
                    cmd.Parameters.AddWithValue("@accnum", accnum.Text);
                    cmd.Parameters.AddWithValue("@sortcode", sortcode.Text);
                    cmd.Parameters.AddWithValue("@initialbal", initialbal.Text);
                    cmd.Parameters.AddWithValue("@over", over.Text);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!!","Successfully");
                    Con.Close();
                    Reset();
                    DisplayAcc();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Key ==0)
            {
                MessageBox.Show("Select the Account", "Error");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AccountTable where ACName=@ACName", Con);
                    cmd.Parameters.AddWithValue("@ACName", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted!!", "Successfully");
                    Con.Close();
                    DisplayAcc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }






        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //cmd.Parameters.AddWithValue("@name", );
            ////cmd.Parameters.AddWithValue("@surname", surname.Text);
            //cmd.Parameters.AddWithValue("@address1", address1.Text);
            //cmd.Parameters.AddWithValue("@address2", address2.Text);
            //cmd.Parameters.AddWithValue("@city", city.Text);
            //cmd.Parameters.AddWithValue("@email", email.Text);
            //cmd.Parameters.AddWithValue("@phone", phone.Text);
            //cmd.Parameters.AddWithValue("@country", country.Text);
            //cmd.Parameters.AddWithValue("@actype", actype.Text);
            //cmd.Parameters.AddWithValue("@accnum", accnum.Text);
            //cmd.Parameters.AddWithValue("@sortcode", sortcode.Text);
            //cmd.Parameters.AddWithValue("@initialbal", initialbal.Text);
            //cmd.Parameters.AddWithValue("@over", over.Text);


            name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
