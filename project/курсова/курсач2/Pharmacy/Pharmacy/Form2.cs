using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pharmacy
{
    public partial class Form2 : Form
    {

        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=pharmacy.accdb;";
        private OleDbConnection myConnection;
        public Form2()
        {
            InitializeComponent(); 
            myConnection = new OleDbConnection(connectString);
            //з.єднує
            myConnection.Open();

        }
        
        private void addData()
        {
            try
            {

                string query = "INSERT INTO pharmacy (Name,Price,Data,Maker,Type,prep) VALUES ('" + this.textBox1.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox8.Text + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                MessageBox.Show("Дані додано");
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Введіть правильно дані");
            }

        }
                                  
        private void Form2_Load(object sender, EventArgs e)
        {

        }

         

        private void button2_Click_1(object sender, EventArgs e)
        {
            if ((textBox1.Text.Length > 1) &&   (textBox3.Text.Length > 0) && (textBox4.Text.Length > 0) && (textBox5.Text.Length > 0) &&    (textBox8.Text.Length > 0))
            {
                addData();
                Close();

            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }
            

            //Hide();
            //Form2 add = new Form2();
            //add.ShowDialog();
            ////Закриває попереднє вікно
       
            }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }   
        }
    }

