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
    public partial class sifarnik : Form
    {
        string CS = "Data Source=INF_4_PROFESOR\\SQLPBG;Initial Catalog=kucni_budzet;Integrated Security=true";
        DataTable tabela;
        SqlDataAdapter adapter;
        string naziv;

        public sifarnik()
        {
            InitializeComponent();
        }
        public sifarnik(string ime_tabele)
        {
            naziv = ime_tabele;
            InitializeComponent();
        }
        private void sifarnik_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(CS);
            adapter = new SqlDataAdapter("SELECT * FROM "+naziv, veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
            dataGridView1.DataSource = tabela;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable menjano = tabela.GetChanges();
            adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
            if (menjano != null)
            {
                adapter.Update(menjano);
            }
            this.Close();
        }
    }
}
