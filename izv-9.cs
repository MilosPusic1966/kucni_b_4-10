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
    public partial class izv_9 : Form
    {
        public izv_9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
            SqlConnection veza = new SqlConnection(CS);
            string naredba = "SELECT * FROM promet_v ORDER BY org, trosak, datum";
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            SqlDataReader reader = komanda.ExecuteReader();
            reader.Read();
            string iznos = string.Format("{0,15:N2}", Convert.ToDecimal(reader["izlaz"]));
            string red = string.Format("{0,20} {1,20} {2,20}", reader["org"].ToString(), reader["trosak"].ToString(), iznos);
            listBox1.Items.Add(red);

            double sum_org = Convert.ToDouble(reader["izlaz"]);
            string old_org = reader["org"].ToString();
            double sum_tr = Convert.ToDouble(reader["izlaz"]);
            string old_tr = reader["trosak"].ToString();
            while (reader.Read())
            {
                if (old_org != reader["org"].ToString())
                {
                    red = "----------------------------------";
                    listBox1.Items.Add(red);
                    red = "                " + old_tr + " " + sum_tr.ToString();
                    listBox1.Items.Add(red);
                    red = "==================================";
                    listBox1.Items.Add(red);
                    red = "                " + old_org + " " + sum_org.ToString();
                    listBox1.Items.Add(red);
                    sum_org = 0;
                    old_org = reader["org"].ToString();
                    sum_tr = 0;
                    old_tr = reader["trosak"].ToString();
                }
                else
                {
                    if (old_tr != reader["trosak"].ToString())
                    {
                        red = "----------------------------------";
                        listBox1.Items.Add(red);
                        red = "                " + old_tr + " " + sum_tr.ToString();
                        listBox1.Items.Add(red);
                        sum_tr = 0;
                        old_tr = reader["trosak"].ToString();
                    }
                }
                sum_org = sum_org + Convert.ToDouble(reader["izlaz"]);
                sum_tr = sum_tr + Convert.ToDouble(reader["izlaz"]);
                iznos = string.Format("{0,15:N2}", Convert.ToDecimal(reader["izlaz"]));
                red = string.Format("{0,20} {1,20} {2,20}", reader["org"].ToString(), reader["trosak"].ToString(),iznos);
                listBox1.Items.Add(red);
            }
            red = "----------------------------------";
            listBox1.Items.Add(red);
            red = "                " + old_tr + " " + sum_tr.ToString();
            listBox1.Items.Add(red);
            red = "==================================";
            listBox1.Items.Add(red);
            red = "                " + old_org + " " + sum_org.ToString();
            listBox1.Items.Add(red);
        }
    }
}
