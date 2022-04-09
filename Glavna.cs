using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucni_b_4_10
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        private void osobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("osoba");
            nova.Show();
        }

        private void novcaniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("novcanik");
            nova.Show();
        }

        private void troskoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("trosak");
            nova.Show();
        }

        private void oRGoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("org");
            nova.Show();
        }

        private void partneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("firma");
            nova.Show();
        }

        private void prometToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Promet nova = new Promet();
            nova.Show();
        }
    }
}
