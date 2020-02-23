using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=pharmacy.accdb;";
        private OleDbConnection myConnection;
         
        public Form1()
        {
            InitializeComponent();
            //string patch = Environment.CurrentDirectory.ToString().Substring(0, Environment.CurrentDirectory.ToString().Length - 9);
            myConnection = new OleDbConnection(connectString);
            // Відкриває ДБ
            myConnection.Open();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            // текст запиту
            string query = "SELECT Inst,Name, Price,Data,Maker,Type,Pok,img,Prot,prep,his FROM pharmacy ";
            label7.Text = "...";
            label8.Text = "...";
            label9.Text = "...";
            label10.Text = "...";
            label11.Text = "...";
            textBox1.Text = "";
            
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
             
            textBox7.Text = "";

            richTextBox1.Clear();
            richTextBox2.Clear();
            // створюєм обєкт OleDbCommand для виконання запиту до БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            // получаємо обєкт OleDbDataReader для читання табличного результату запиту SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // ощищуємо listBox1
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            // в циклі по порядку виводжу  дані з БД
            for (int i = 1; reader.Read(); i++)
            {
                // виводимо дані в listBox1
                listBox1.Items.Add(reader[1].ToString());
                listBox2.Items.Add(reader[9].ToString());
            }
           
            // закриваєм OleDbDataReader
            reader.Close();
        }

        //пертворює jpeg в растрове зображення 
         

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBox1.SelectedIndex;
                Object selectedItem = listBox1.SelectedItem;
                string q = "select * from pharmacy where Name='" + selectedItem.ToString() + "'";
                OleDbCommand command = new OleDbCommand(q, myConnection);
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    label7.Text = dr[1].ToString();
                    label8.Text = dr[3].ToString() ;
                    label9.Text = dr[4].ToString();
                    label10.Text = dr[5].ToString();
                    label11.Text = dr[6].ToString();

                    textBox1.Text = dr[1].ToString();
                    
                    textBox3.Text = dr[6].ToString();
                    textBox4.Text = dr[4].ToString();
                    textBox5.Text = dr[5].ToString();
                    
                    textBox7.Text = dr[7].ToString();
                    
                     
                    richTextBox1.Text = dr[7].ToString();
                    string patch = Environment.CurrentDirectory.ToString().Substring(0, Environment.CurrentDirectory.ToString().Length - 9);
                    
                     




                }
                
            }
            catch
            {
                
                                MessageBox.Show("Введіть правильно дані",
                                "Помилка",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            richTextBox1.Clear();
             
            label9.Text = "...";
            label10.Text = "...";
            label11.Text = "...";
            label8.Text = "...";
            label7.Text = "...";
            textBox1.Text = "";
            
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
           
            textBox7.Text = "";
             

             
            //-----------------------------------------------------------------------------
            int selectedIndex = listBox1.SelectedIndex;
            Object selectedItem = listBox1.SelectedItem;
            string query = "DELETE * FROM pharmacy  where Name='" + selectedItem.ToString() + "'";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, myConnection);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            
        }

        

        

         

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                
                int selectedIndex = listBox1.SelectedIndex;
                Object selectedItem = listBox1.SelectedItem;
                string query = "UPDATE pharmacy SET Name ='" + textBox1.Text +   "',Type='" + textBox3.Text + "',Data='" + textBox4.Text + "',Maker='" + textBox5.Text   +  "',Pok='" + textBox7.Text +"'where Name='" + selectedItem.ToString() + "'";
                 
            OleDbCommand command = new OleDbCommand(query, myConnection);
                MessageBox.Show("Дані відредаговано");
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error");
            } 
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

         

        private void button8_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            label7.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            richTextBox1.Clear();
             
            textBox1.Text = "";
            
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
            textBox7.Text = "";
         
            string query = "SELECT * FROM pharmacy where Name like '%" + textBox8.Text + "%'";
           
            listBox1.Items.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);// створюєм обєкт OleDbCommand для виконання запиту до БД MS Access
            OleDbDataReader reader = command.ExecuteReader();// получаємо обєкт OleDbDataReader для читання табличного результату запиту SELECT
            listBox1.Items.Clear();// ощищуємо listBox1
            // в циклі по порядку виводжу  дані з БД
            for (int i = 1; reader.Read(); i++)
            {
                // виводимо дані в listBox1
                listBox1.Items.Add(reader[1].ToString());
            }

            // закриваєм OleDbDataReader
            reader.Close();
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int selectedIndex = listBox2.SelectedIndex;
                Object selectedItem = listBox2.SelectedItem;
                string q = "select * from pharmacy where prep='" + selectedItem.ToString() + "'";
                OleDbCommand command = new OleDbCommand(q, myConnection);
                OleDbDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                     


                    richTextBox2.Text = dr[11].ToString();
                    string patch = Environment.CurrentDirectory.ToString().Substring(0, Environment.CurrentDirectory.ToString().Length - 9);






                }

            }
            catch
            {

                MessageBox.Show("Введіть правильно дані",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        
    }
}
