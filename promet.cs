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
    public partial class Promet : Form
    {
        string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
        DataTable novcanik, osoba, trosak, org, partner, promet, promet_view;

        private void popuni_combo_osoba()
        {
            SqlConnection veza = new SqlConnection(CS);
            osoba = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from osoba", veza);
            adapter.Fill(osoba);
            comboBox1.DataSource = osoba;
            comboBox1.DisplayMember = "naziv";
            comboBox1.ValueMember = "id";
            return;
        }
        private void popuni_combo_novcanik()
        {
            SqlConnection veza = new SqlConnection(CS);
            novcanik = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from novcanik", veza);
            adapter.Fill(novcanik);
            comboBox2.DataSource = novcanik;
            comboBox2.DisplayMember = "naziv";
            comboBox2.ValueMember = "id";
            return;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length != 0)
            {
                SqlConnection veza = new SqlConnection(CS);
                SqlCommand komanda = new SqlCommand("INSERT INTO osoba VALUES('" + textBox5.Text + "')",veza);
                // MessageBox.Show(komanda.CommandText);
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                //////////////////////////
                popuni_combo_osoba();
            }
            if (textBox7.Text.Length != 0)
            {
                SqlConnection veza = new SqlConnection(CS);
                SqlCommand komanda = new SqlCommand("INSERT INTO novcanik VALUES('" + textBox7.Text + "')", veza);
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
                popuni_combo_novcanik();
            }
        }

        private void osvezi_grid()
        {
            SqlDataAdapter adapter;
            SqlConnection veza = new SqlConnection(CS);
            promet_view = new DataTable();
            adapter = new SqlDataAdapter("select * from promet_BIV", veza);
            adapter.Fill(promet_view);
            dataGridView1.DataSource = promet_view;
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Ovde smo stali...
            SqlConnection veza = new SqlConnection(CS);
            // insert into promet values(
            //'2022-2-13',2,1,2,2,1,200,0,NULL)
            string str = "INSERT INTO promet VALUES(";
            str = str + "'"+dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")+"',";
            if (comboBox2.SelectedValue != null)
            {
                str = str + comboBox2.SelectedValue.ToString() + ",";
            }
            else
                str = str + "null,";
            if (comboBox1.SelectedValue != null)
            {
                str = str + comboBox1.SelectedValue.ToString() + ",";
            }
            else
                str = str + "null,";
            if (comboBox3.SelectedValue != null)
            {
                str = str + comboBox3.SelectedValue.ToString() + ",";
            }
            else
                str = str + "null,";
            if (comboBox4.SelectedValue != null)
            {
                str = str + comboBox4.SelectedValue.ToString() + ",";
            }
            else
                str = str + "null,";
            if (comboBox5.SelectedValue != null)
            {
                str = str + comboBox5.SelectedValue.ToString() + ",";
            }
            else
                str = str + "null,";

            if (textBox3.TextLength == 0)
            {
                str = str + "0,";
            }
            else str = str + textBox3.Text + ",";
            if (textBox6.TextLength == 0)
            {
                str = str + "0,";
            }
            else str = str + textBox6.Text + ",";
            str = str + "null)";
            // MessageBox.Show(str);
            SqlCommand naredba = new SqlCommand(str,veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            osvezi_grid();
        }

        public Promet()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            popuni_combo_novcanik();
            popuni_combo_osoba();
            SqlConnection veza = new SqlConnection(CS);
            trosak = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from trosak", veza);
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

            osvezi_grid();
        }
    }
}
