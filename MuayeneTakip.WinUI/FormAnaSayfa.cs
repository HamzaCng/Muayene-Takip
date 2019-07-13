using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuayeneTakip.WinUI
{
    public partial class FormAnaSayfa : Form
    {
        public FormAnaSayfa()
        {
            InitializeComponent();
        }

        private void hastaEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHastaEkle frm = new FormHastaEkle();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hastaListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHastaListele frm = new FormHastaListele();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
