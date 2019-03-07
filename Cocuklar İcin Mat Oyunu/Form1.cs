using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;//data base için

namespace Cocuklar_İcin_Mat_Oyunu
{
    public partial class Form1 : Form
    {
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=kurallar1.accdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable table = new DataTable();
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\muham\\Desktop\\c# Games\\Cocuklar İcin Mat Oyunu\\Cocuklar İcin Mat Oyunu\\Properties\\kurallar1.accdb
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            baglantı.Open();
            komut = new  OleDbCommand("select * From kurallar",baglantı);
            adtr = new OleDbDataAdapter(komut);
            adtr.Fill(table);
            frm4.dataGridView1.DataSource = table;
            baglantı.Close();
            frm4.Show();

        }
    }
}