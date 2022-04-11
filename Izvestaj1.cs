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
    public partial class Izvestaj1 : Form
    {
        string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
        public Izvestaj1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naredba = "SELECT * FROM promet_BIV ORDER BY org, trosak,datum";
            SqlConnection veza = new SqlConnection(CS);
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            SqlDataReader reader = komanda.ExecuteReader();
            reader.Read();
            string old_org = reader["org"].ToString();
            string old_tr = reader["trosak"].ToString();
            double sum_org = Convert.ToDouble(reader["izlaz"].ToString());
            double sum_tr = Convert.ToDouble(reader["izlaz"].ToString());
            DateTime datum = (DateTime)reader["datum"];
            string str_datum = datum.ToString("yyyy-MM-dd");
            string iznos = string.Format("{0,15:N2}", Convert.ToDecimal(reader["izlaz"]));
            string red = datum + " " + reader["osoba"].ToString() + " " + string.Format("{0,15} {1,15}",reader["org"].ToString(), reader["trosak"].ToString()) + iznos;
            listBox1.Items.Add(red);
            while (reader.Read())
            {
                
                if (old_org != reader["org"].ToString())
                {
                    red = "                       " + old_tr + sum_tr.ToString();
                    listBox1.Items.Add(red);
                    sum_tr = 0;
                    old_tr = reader["trosak"].ToString();

                    red = "                       " + old_org + sum_org.ToString();
                    listBox1.Items.Add(red);
                    sum_org = 0;
                    old_org = reader["org"].ToString();
                }
                else if (old_tr != reader["trosak"].ToString())
                {
                    red = "                       "+old_tr + sum_tr.ToString();
                    listBox1.Items.Add(red);
                    sum_tr = 0;
                    old_tr = reader["trosak"].ToString();

                }
                datum = (DateTime)reader["datum"];
                str_datum = datum.ToString("yyyy-MM-dd");
                iznos = string.Format("{0,15:N2}", Convert.ToDecimal(reader["izlaz"]));
                red = datum + " " + reader["osoba"].ToString() + " " + string.Format("{0,15} {1,15}", reader["org"].ToString(), reader["trosak"].ToString()) + iznos;
                sum_tr = sum_tr + Convert.ToDouble(reader["izlaz"].ToString());
                sum_org = sum_org + Convert.ToDouble(reader["izlaz"].ToString());
                listBox1.Items.Add(red);
            }
            red = "                       " + old_tr + sum_tr.ToString();
            listBox1.Items.Add(red);
            red = "                       " + old_org + sum_org.ToString();
            listBox1.Items.Add(red);
        }
    }
}
