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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection myConnection;
        DataTable theDataTable;
        double holderBoots, noBoots, boots, dailyTotal, holderNoBoots, val = 0.0;

        public Form1()
        {
            InitializeComponent();
        }
        //search
        private void button6_Click(object sender, EventArgs e)
        {
            //connect before search
            myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adrian\\Desktop\\CST4718\\Fall2021-CST4708.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection.Open();
            //commands
            SqlCommand myCommand = new SqlCommand();
            myCommand.Parameters.Add("@total", SqlDbType.Int, 100);
            myCommand.Parameters["@total"].Value = Convert.ToDouble(textBox10.Text);
            myCommand.CommandText = "select * from Customers where total > @total";
            myCommand.Connection = myConnection;

            //dataaddepter
            SqlDataAdapter theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = myCommand;
            theDataTable = new DataTable();
            theAdapter.Fill(theDataTable);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = theDataTable;

        }

        // update
        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "Update Customers SET name=@name, withboots=@withboots, noboots=@noboots, total=@total WHERE id=@id";
            myCommand.Parameters.Add("@name", SqlDbType.VarChar, 100, "name");
            myCommand.Parameters.Add("@withboots", SqlDbType.Int, 100, "withboots");
            myCommand.Parameters.Add("@noboots", SqlDbType.Int, 100, "noboots");
            myCommand.Parameters.Add("@total", SqlDbType.Int, 100, "total");
            myCommand.Parameters.Add("@id", SqlDbType.Int, 100, "id");
            SqlDataAdapter theAdapter = new SqlDataAdapter();
            theAdapter.UpdateCommand = myCommand;
        
        
            
        }

        //calculate
        private void button1_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox3.Text, out val))
            {
                holderNoBoots = Convert.ToDouble(textBox3.Text);
            }

            if (Double.TryParse(textBox4.Text, out val))
            {
                holderBoots = Convert.ToDouble(textBox4.Text);
            }

            noBoots = 20.0f * holderNoBoots;
            boots = 30.0f * holderBoots;
            dailyTotal = noBoots + boots;
            textBox9.Text = Convert.ToString(noBoots);
            textBox5.Text = Convert.ToString(boots);
            textBox6.Text = Convert.ToString(dailyTotal);
            textBox8.Text = textBox1.Text;
            textBox7.Text = textBox2.Text;
    
        }
        
        //db connection button
        private void button2_Click(object sender, EventArgs e)
        {

            //Database connection button
            myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adrian\\Desktop\\CST4718\\Fall2021-CST4708.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection.Open();
            MessageBox.Show("DB has connected");

        }

        //add to database
        private void button3_Click(object sender, EventArgs e)
        {
            myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adrian\\Desktop\\CST4718\\Fall2021-CST4708.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection.Open();

            //Add to database button
            //math without printing
            if (Double.TryParse(textBox3.Text, out val))
            {
                holderNoBoots = Convert.ToDouble(textBox3.Text);
            }

            if (Double.TryParse(textBox4.Text, out val))
            {
                holderBoots = Convert.ToDouble(textBox4.Text);
            }

            noBoots = 20.0f * holderNoBoots;
            boots = 30.0f * holderBoots;
            dailyTotal = noBoots + boots;

            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;

            myCommand.Parameters.Add("@id", SqlDbType.Int, 20);
            myCommand.Parameters.Add("@name", SqlDbType.VarChar, 100);
            myCommand.Parameters.Add("@withboots", SqlDbType.Int, 100);
            myCommand.Parameters.Add("@noboots", SqlDbType.Int, 100);
            myCommand.Parameters.Add("@total", SqlDbType.Int, 100);

            myCommand.Parameters["@name"].Value = textBox1.Text;
            myCommand.Parameters["@id"].Value = Convert.ToInt32(textBox2.Text);
            myCommand.Parameters["@withboots"].Value = Convert.ToDouble(textBox4.Text);
            myCommand.Parameters["@noboots"].Value = Convert.ToDouble(textBox3.Text);
            myCommand.Parameters["@total"].Value = Convert.ToDouble(dailyTotal);

            myCommand.CommandText = "INSERT INTO Customers (id, name, withboots, noboots, total) VALUES (@id, @name, @withboots, @noboots, @total)";

            //Data adapter
            SqlDataAdapter theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = myCommand;
            theDataTable = new DataTable();
            theAdapter.Fill(theDataTable);
          
            //binding
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = theDataTable;
        }

        //clear button
        private void button4_Click(object sender, EventArgs e)
        {
            //Clear button
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        //fill table with information
        private void button5_Click(object sender, EventArgs e)
        {
            //Fill table
            //connection
            myConnection = new SqlConnection();
            myConnection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Adrian\\Desktop\\CST4718\\Fall2021-CST4708.mdf;Integrated Security=True;Connect Timeout=30";
            myConnection.Open();

            //command object
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "SELECT * FROM Customers";

            //Data adapter
            SqlDataAdapter theAdapter = new SqlDataAdapter();
            theAdapter.SelectCommand = myCommand;
            DataTable theDataTable = new DataTable();
            theAdapter.Fill(theDataTable);

            //binding
            //dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = theDataTable;

        }
    }
}