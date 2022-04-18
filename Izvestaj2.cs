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
    public partial class Izvestaj2 : Form
    {
        public Izvestaj2()
        {
            InitializeComponent();
        }
        string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
        private static string[] naziv_tabele = { "Osoba", "ORG", "Novcanik" };
        private void Izvestaj2_Load(object sender, EventArgs e)
        {
            ComboBox[] nizCB = { comboBox1, comboBox2, comboBox3 };
            // Osvezi.Refresh_combo(comboBox1, "osoba");
            // Osvezi.Refresh_combo(comboBox2, "org");
            
            foreach (Control ctrl in this.Controls){
                if (ctrl is ComboBox CB1 && nizCB.Contains(CB1))
                {
                    int indeksCB = Array.IndexOf(nizCB, CB1);
                    string Tabela = naziv_tabele[indeksCB];
                    Osvezi.Refresh_combo(CB1, Tabela);
                    CB1.SelectedIndex = -1;
                }
            }
        }
    }
    class Osvezi
    {
        static string CS = "Data source = INF_4_PROFESOR\\SQLPBG;Initial Catalog = kucni_budzet; Integrated Security = True";
        public static void Refresh_combo(ComboBox comb1, string tabela)
        {
            string naredba = "SELECT * FROM " + tabela;
            SqlConnection veza = new SqlConnection(CS);
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            DataTable Dt = new DataTable();
            adapter.Fill(Dt);
            comb1.DataSource = Dt;
            comb1.DisplayMember = "naziv";
            comb1.ValueMember = "id";
        }
    }
}
