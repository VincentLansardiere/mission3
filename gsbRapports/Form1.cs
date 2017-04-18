using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gsbRapports
{
    public partial class Form1 : Form
    {
        private gsbrapports2016Entities objcontexte;

        public Form1()
        {
            this.InitializeComponent();
            this.objcontexte = new gsbrapports2016Entities();
        }

      

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormGerer f = new FormGerer(this.objcontexte);
            f.MdiParent = this;
            
            f.Show();
        }

        private void majToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRapports r = new FormRapports(this.objcontexte);
            r.MdiParent = this;
            r.Show();

        }
    }
}
