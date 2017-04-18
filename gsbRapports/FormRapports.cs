using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace gsbRapports
{
    public partial class FormRapports : Form
    {
        private gsbrapports2016Entities objcontexte;
        int compteur = 0;
        public DataSet rapportdt;
        private DataTable toto = new DataTable();


        public bool genererXML(int nbligne)
        {
            return true;
        }

        // Constructeur du Form qui prend en paramètre le modèle entities.

        public FormRapports(gsbrapports2016Entities objcontexte)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.objcontexte = new gsbrapports2016Entities();
            this.bdgVisiteur.DataSource = objcontexte.visiteur;
            this.bdgRapport.DataSource = objcontexte.rapport;

            // Requete linq qui récupère toutes les infos des visiteur classées par nom.
            var req = (from v in this.objcontexte.visiteur
                       orderby v.nom
                       select v);

            int i = 1;



            foreach (var item in req)
            {



                string[] Ligne = new string[] { item.id, item.nom + ' ' + item.prenom };

                dataGridView1.Rows.Add(Ligne);

                i = i + 1;
            }




        }

        // Lors du clique sur un nom dans la listebox.






        private void dgvListeRapports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                bool caseacocher = Convert.ToBoolean(dgvListeRapports.Rows[e.RowIndex].Cells[0].Value);



                if (caseacocher == true)
                {

                    dgvListeRapports.Rows[e.RowIndex].Cells[0].Value = false;
                    txtlistid.Text = this.txtlistid.Text.Replace(e.RowIndex.ToString() + ";", "");
                }

                else
                {
                    dgvListeRapports.Rows[e.RowIndex].Cells[0].Value = true;
                    txtlistid.Text = this.txtlistid.Text + e.RowIndex.ToString() + ";";
                }
            }


        }

        private void toutdecocher_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < compteur; i++)
            {
                txtlistid.Clear();
                dgvListeRapports.Rows[i].Cells[0].Value = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtlistid.Clear();

            for (int i = 0; i < compteur; i++)
            {

                dgvListeRapports.Rows[i].Cells[0].Value = true;
                txtlistid.Text = this.txtlistid.Text + i.ToString() + ";";

            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {

            /*
            dataGridView1 = dgvListeRapports;
            rapportdt = new DataSet();
            DataTable lesrapports = new DataTable("Rapports");
            DataColumn id = new DataColumn("id", System.Type.GetType("System.String"));
            DataColumn date = new DataColumn("Date", System.Type.GetType("System.String"));
            DataColumn motif = new DataColumn("Motif", System.Type.GetType("System.String"));
            DataColumn bilan = new DataColumn("Bilan", System.Type.GetType("System.String"));
            DataColumn idVisiteur = new DataColumn("idVisiteur", System.Type.GetType("System.String"));
            DataColumn idMedecin = new DataColumn("Adresse", System.Type.GetType("System.String"));

            lesrapports.Columns.Add(id);
            lesrapports.Columns.Add(date);
            lesrapports.Columns.Add(motif);
            lesrapports.Columns.Add(bilan);
            lesrapports.Columns.Add(idVisiteur);
            lesrapports.Columns.Add(idMedecin);



            rapportdt.Tables.Add(lesrapports);

            dgvListeRapports.DataSource = rapportdt;
            dgvListeRapports.DataMember = "Rapports";
            rapportdt.WriteXml(@"d:\rapport.xml");
            
            /*
                        string[] toto;
                        toto = txtlistid.ToString().Split(';');

                        for (int i = 0; i < compteur; i++)
                        {
                            if()
                            {


                            }


                        }


                */


            /*  DataTable data = dgvListeRapports;
              data.WriteXml(@"d:\carnet.xml");
              */

            int numrow = this.dataGridView1.CurrentRow.Index;

            string idVi = dataGridView1[1, numrow].Value.ToString();

            StreamWriter FichierRapport = new StreamWriter(@"d:\rapport_" + idVi + ".xml");
            FichierRapport.WriteLine("<Rapports>");

            for (int i = 0; i < compteur; i++)
            {

                bool caseacocher = Convert.ToBoolean(dgvListeRapports.Rows[i].Cells[0].Value);

                if (caseacocher == true)
                {




                    FichierRapport.WriteLine("\t<Rapport>");

                    for (int a = 1; a < dgvListeRapports.ColumnCount; a++)
                    {
                        bool estafficher = dgvListeRapports.Columns[a].Visible;
                        if (estafficher == true)
                        {

                            FichierRapport.WriteLine("\t\t<" + dgvListeRapports.Columns[a].Name + ">" + dgvListeRapports.Rows[i].Cells[a].Value + "</" + dgvListeRapports.Columns[a].Name + ">");
                        }
                    }


                    FichierRapport.WriteLine("\t</Rapport>");
                }

            }

            MessageBox.Show("Le rapport de " + idVi + " à bien été créé.");

            FichierRapport.WriteLine("</Rapports>");
            FichierRapport.Close();









        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtlistid.Clear();
            dgvListeRapports.Rows.Clear();
            dgvListeRapports.Refresh();
            this.objcontexte = new gsbrapports2016Entities();

            int numrow = this.dataGridView1.CurrentRow.Index;
            string idVi = dataGridView1[0, numrow].Value.ToString();

            //On va chercher  les infos du visiteur séléctionné.

            var req = (from v in this.objcontexte.visiteur
                       where v.id == idVi
                       select v);



            /*foreach (var item in req)
            {
                idV = item.id;
            }*/

            var req2 = (from r in this.objcontexte.rapport
                            // let choix = ""
                        where r.idVisiteur == idVi
                        select r);

            // dataGridView1.DataSource = req2;
            dgvListeRapports.DataSource = req2;
            //toto = req2.CopyToDatatable();

            if (dgvListeRapports.Columns[0].Name != "Choix")
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                checkBoxColumn.Width = 50;
                checkBoxColumn.Name = "Choix";
                checkBoxColumn.HeaderText = "Choix";
                dgvListeRapports.Columns.Insert(0, checkBoxColumn);

            }



            // dataGridView1.Columns[0].Visible = false; cacher la colonne

            /*foreach (var item2 in req2)
            {
                //this.listBox2.Items.Add(item2.id);
                compteur = compteur + 1;
                // dgvListeRapports.Rows.Add(false);




            }
            */

            compteur = dgvListeRapports.Rows.Count;


            dgvListeRapports.Columns[7].Visible = false;
            dgvListeRapports.Columns[8].Visible = false;
            dgvListeRapports.Columns[9].Visible = false;

            this.txtnbid.Text = dgvListeRapports.RowCount.ToString();


        }
    }

}
