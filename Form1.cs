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

namespace kucni_b_4_10
{
    public partial class Form1 : Form
    {
        string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
        DataTable novcanik, osoba, trosak, org, partner, promet, promet_view;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(CS);
            novcanik = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from novcanik", veza);
            adapter.Fill(novcanik);
            comboBox2.DataSource = novcanik;
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "id";

            osoba = new DataTable();
            adapter = new SqlDataAdapter("select * from osoba", veza);
            adapter.Fill(osoba);
            comboBox1.DataSource = osoba;
            comboBox1.DisplayMember = "naziv";
            comboBox1.ValueMember = "id";

            trosak = new DataTable();
            adapter = new SqlDataAdapter("select * from trosak", veza);
            adapter.Fill(trosak);
            comboBox3.DataSource = trosak;
            comboBox3.DisplayMember = "naziv";
            comboBox3.ValueMember = "id";
            comboBox3.SelectedIndex = -1;

            org = new DataTable();
            adapter = new SqlDataAdapter("select * from org", veza);
            adapter.Fill(org);
            comboBox4.DataSource = org;
            comboBox4.DisplayMember = "naziv";
            comboBox4.ValueMember = "id";

            promet_view = new DataTable();
            adapter = new SqlDataAdapter("select * from promet_BIV", veza);
            adapter.Fill(promet_view);
            dataGridView1.DataSource = promet_view;
        }
    }
}
