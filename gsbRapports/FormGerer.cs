using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace gsbRapports
{
    public partial class FormGerer : Form
    {
        private string idV;
        private gsbrapports2016Entities objcontexte;
        private string evenement;

        // Methode qui remet par défaut les paramètres du Form //

        public void Init()
        {
            evenement = "null";
            txtLogin.Enabled = true;
            txtMdp.Enabled = true;
            dataGridView1.Enabled = true;
            groupBox4.Text = "Pas d'action sélectionnée";
            groupBox1.BackColor = Color.LightGray;
        }

        // Methode qui remplit les TextBox avec les infos du visiteur actuel. //

        public void remplitTextBox()
        {

            int numrow = this.dataGridView1.CurrentRow.Index;
            //string idVi = dataGridView1.Rows[numrow].Cells[0].ToString();
            string idVi = dataGridView1[0, numrow].Value.ToString();
            var req = (from v in this.objcontexte.visiteur
                       where v.id == idVi
                       select v);


            foreach (var item in req)
            {
                this.txtId.Text = item.id;
                this.txtNom.Text = item.nom;
                this.txtPrenom.Text = item.prenom;
                this.txtLogin.Text = item.login;
                this.txtMdp.Text = item.mdp;
                this.txtAdresse.Text = item.adresse;
                this.txtCp.Text = item.cp;
                this.txtVille.Text = item.ville;
                this.dateTimePicker1.Value = Convert.ToDateTime(item.dateEmbauche);
                this.idV = item.id;
            }

        }

        // Constructeur du Form qui prend en paramètre le modèle entities.

        public FormGerer(gsbrapports2016Entities objcontexte)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.objcontexte = new gsbrapports2016Entities();
            this.bdgVisiteur.DataSource = objcontexte.visiteur;
            evenement = "null";

            // Requete linq qui récupère toutes les infos des visiteur classées par nom.

            var req = (from v in this.objcontexte.visiteur
                       orderby v.nom
                       select v); 
                       

            // Pour chaque résultat on ajoute un nom dans la listebox.
            int i = 1;


            
            foreach (var item in req)
            {

             

                //id caché qui permet de liée le string nom+prenom au visiteur correspondant.

                string[] Ligne = new string[] { item.id, item.nom + ' ' + item.prenom };

                dataGridView1.Rows.Add(Ligne);

                i = i + 1;


            }


            dataGridView1.Columns[1].Width = dataGridView1.Width;
            dataGridView1.Refresh();

        }



        //MODIFIER CLICK/
        // Au clique du bouton modifier , paramétrage de l'action modifier //

        private void modifier_Click(object sender, EventArgs e)
        {
            // Check qui vérifie si l'utilisateur à sélectionné un visiteur et si oui on passe dans l'évènement modifier. ( evenement="modifier")

            if (txtId.Text == "" || txtNom.Text == "")
            {
                MessageBox.Show("Veuilliez selectionné un visiteur");
                Init();
                return;
            }
            else
            {
                remplitTextBox();
                groupBox4.Text = "Modification du Visiteur";
                groupBox1.BackColor = Color.LightSalmon;

                txtId.Enabled = false;
                txtLogin.Enabled = true;
                txtMdp.Enabled = true;
                dataGridView1.Enabled = true;
                evenement = "modifier";
            }


        }
        // END MODIFIER CLICK //

            // BEGIN AJOUTER CLICK //
        // Au clique du bouton ajouter , paramétrage de l'action ajouter , On vide les champs //

        private void Ajouter_Click(object sender, EventArgs e)
        {
            groupBox4.Text = "Ajout du Visiteur";
            groupBox1.BackColor = Color.LightGreen;
            this.txtId.Text = "";
            this.txtNom.Text = "";
            this.txtPrenom.Text = "";
            this.txtLogin.Text = "";
            this.txtLogin.Text = "";
            this.txtMdp.Text = "";
            this.txtAdresse.Text = "";
            this.txtCp.Text = "";
            this.txtVille.Text = "";
            this.dateTimePicker1.Value = DateTime.Today;


            txtId.Enabled = false;
            txtLogin.Enabled = false;
            txtMdp.Enabled = false;
            dataGridView1.Enabled = false;

            // déclaration de la connection //

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;" +
    "pwd=root;database=gsbrapports2016;";

            // Fonction de génération de ID //

            int check = 0;
            string idalea = "";
            do
            {
                // On déclare le dictionnaire avec les caractères pouvant se trouver dans le mot générer.
                string dico = "abcdefghijklmnopqrstuvwxz0123456789";
                char[] chars = new char[4];
                Random rand = new Random();

                for (int i = 0; i < 4; i++)
                {
                    chars[i] = dico[rand.Next(0, dico.Length)];
                }

                idalea = new string(chars);
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                MySqlCommand sel = new MySqlCommand("Select count(idVisiteur) FROM rapport  WHERE idVisiteur = '" + idalea + "';", conn);


            } while (check >= 1);

            this.txtId.Text = idalea;

            //

            // Fonction de génération du Login  //


            int verif = 0;
            string loginalea = "";
            //  (*a voir plus bas pourquoi j'utilise une do while)
            do
            {

                string dico2 = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxz";
                char[] chars2 = new char[8];
                Random rand2 = new Random();

                for (int i = 0; i < 8; i++)
                {
                    chars2[i] = dico2[rand2.Next(0, dico2.Length)];
                }

                loginalea = new string(chars2);

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                // Si j'ai préféré utilisé le MysqlCommand plutôt qu'une requete linq de façon a pouvoir récupéré via le ExecuteScalar si la requete a retourné un
                // resultat ou non.  Ici on vérifie simplement si le login générer aléatoirement existe déja dans la base de donnée. Il y a peux de chance mais on
                // ne sait jamais .. 
                MySqlCommand sel = new MySqlCommand("Select count(idVisiteur) FROM rapport  WHERE idVisiteur = '" + loginalea + "';", conn);

                // Le ExecuteScalar permet d'executer la requête en retournant un seul résultat.

                verif = Convert.ToInt16(sel.ExecuteScalar());

                // (*) Avec la while on couvre le cas ou l'id créer est existant dans la base de donnée. Du coup si l'id créer est déja existant on recommence tant que
                // l'id est existant dans la bdd.

            } while (verif >= 1);

            this.txtLogin.Text = loginalea;

            //

            // Fonction de génération du mdp //

            string dico3 = "0123456789abcdefghijklmnopqrstuvwxz";
            char[] chars3 = new char[8];
            Random rand3 = new Random();

            for (int i = 0; i < 6; i++)
            {
                chars3[i] = dico3[rand3.Next(0, dico3.Length)];
            }

            string mdpalea = new string(chars3);
            this.txtMdp.Text = mdpalea;


            evenement = "ajouter";
        }

        // END AJOUTER CLICK //


        // Au clique du bouton supprimer , paramétrage de l'action supprimer //

        private void Supprimer_Click(object sender, EventArgs e)
        {
            // Verif si l'utilisateur est sélectionné.

            if (txtId.Text == "" || txtNom.Text == "")
            {
                MessageBox.Show("Veuilliez selectionné un visiteur");
                Init();
                return;
            }
            else
            {
                groupBox4.Text = "Suppression du Visiteur";
                groupBox1.BackColor = Color.OrangeRed;
                remplitTextBox();
                dataGridView1.Enabled = true;
                evenement = "supprimer";
            }
        }

        // Clique du bouton Valider

        private void txtValider_Click(object sender, EventArgs e)
        {
            switch (evenement)
            {
                case "null":
                    MessageBox.Show("Veuilliez choisir une action avant de valider");
                    break;
                case "ajouter":
                    AjoutVisiteur();
                    break;
                case "supprimer":
                    // DEBUT SUPPRIMER //
                    DialogResult dialogResult = MessageBox.Show("Attention vous-êtes sur le point de supprimer le visteur, voulez vous continuez ?", "Supprimer", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SuppressionVisiteur();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                    break;
                case "modifier":
                    ModificationVisiteur();
                    break;

                default:
                    break;
            }

            //dataGridView1.Rows.Clear();

            // Requete linq qui récupère toutes les infos des visiteur classées par nom.

            /*    var req2 = (from v in this.objcontexte.visiteur
                            orderby v.nom
                            select v);


                int i = 1;
                dataGridView2.DataSource = req2;


                foreach (var item2 in req2)
                {

                    // this.listBox1.Items.Add(item.nom+"      "+item.prenom);

                    string[] Ligne = new string[] { item2.id, item2.nom + ' ' + item2.prenom };

                    dataGridView1.Rows.Add(Ligne);



                    i = i + 1;
                }
                */

            /*  var req2 = (from v in this.objcontexte.visiteur
                         orderby v.nom
                         select v);

              // Pour chaque résultat on ajoute un nom dans la listebox.
              int i = 1;



              foreach (var item in req2)
              {

                  //dataGridView1.Rows[i].Cells[0].Value = item.nom;
                  //dataGridView1.Rows[i].Cells[1].Value = item.prenom;




                  i = i + 1;


              }
              // dataGridView1.SetSelected(0, true);
              */

            Init();

            //gsbRapports.FormGerer(objcontexte);





        }
        //**************** FIN VALIDER *****************//

        // Lors de la sortie ddu champ text box nom , on regarde les caractères fournies dans la textBox. Si ils ne font pas partit de l'expression réguliaire ( pour
        // cela on utilise en haut de page le "using System.Text.RegularExpressions;" ) le champ passe en rouge et reste focus sur le champ tant qu'il ne change pas.


        private void txtNom_Validating(object sender, CancelEventArgs e)
        {

            TextBox ChampTeste = (TextBox)sender;

            if (!Regex.IsMatch(ChampTeste.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seul les lettres sont aurtorisées dans ce champ");
                ChampTeste.BackColor = Color.Red;
                ChampTeste.Focus();

            }
            else
            {
                ChampTeste.BackColor = Color.White;
            }


        }

        // Pareil que au dessus pour Prenom.

        private void txtPrenom_Validating(object sender, CancelEventArgs e)
        {
            TextBox ChampTeste = (TextBox)sender;

            if (!Regex.IsMatch(ChampTeste.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seul les lettres sont aurtorisées dans ce champ");
                ChampTeste.BackColor = Color.Red;
                ChampTeste.Focus();

            }
            else
            {
                ChampTeste.BackColor = Color.White;
            }

        }

        // Idem pour Ville

        private void txtVille_Validating(object sender, CancelEventArgs e)
        {
            TextBox ChampTeste = (TextBox)sender;

            if (!Regex.IsMatch(ChampTeste.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Seul les lettres sont aurtorisées dans ce champ");
                ChampTeste.BackColor = Color.Red;
                ChampTeste.Focus();

            }
            else
            {
                ChampTeste.BackColor = Color.White;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormGerer_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            remplitTextBox();
        }


        // =======> !!! A faire Test pour code postal 


        /*

        private void textBox6_Validating_1(object sender, CancelEventArgs e)
        {
            TextBox ChampTeste = (TextBox)sender;

            if (!Regex.IsMatch(ChampTeste.Text, @"^[a-zA-Z]+$"))
            {
                MessageBox.Show("Please enter letters only");
                ChampTeste.BackColor = Color.Red;
                ChampTeste.Focus();

            }
            else
            {
                ChampTeste.BackColor = Color.White;
            }
        }
        */
        public void SuppressionVisiteur()
        {
            groupBox4.Text = "Suppression";

            string idvi = "";
            this.objcontexte = new gsbrapports2016Entities();

            // Ici on récupère l'id du visiteur sélectionné dans la liste

            var req = (from v in this.objcontexte.visiteur
                       where v.id == this.idV
                       select v);
            foreach (var item in req)
            {
                idvi = item.id;
            }

            // on déclare les variables de connection

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;" +
        "pwd=root;database=gsbrapports2016;";

            // on fais un try catch qui m'as permis de me rendre compte de la raison des erreurs rencontrées.
            try
            {
                // On initialise et on ouvre la connection.

                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                // Ici on vérifie grâçe au count si un visiteur est concerné par un rapport.
                MySqlCommand sel = new MySqlCommand("Select count(idVisiteur) FROM rapport  WHERE idVisiteur = '" + idvi + "';", conn);

                // Le ExecuteScalar permet d'executer la requête en retournant un seul résultat.
                int verif = Convert.ToInt16(sel.ExecuteScalar());

                // Si il n'y a pas de visiteur dans rapport ( count = 0) on supprime le visiteur.
                if (verif == 0)
                {
                    MySqlCommand cmd1 = new MySqlCommand("DELETE FROM rapport WHERE idVisiteur = '" + idvi + "';", conn);
                    cmd1.ExecuteNonQuery();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM visiteur WHERE id = '" + idvi + "';", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Visiteur supprimé");
                    int numrow = this.dataGridView1.CurrentRow.Index;
                    dataGridView1.Rows.RemoveAt(numrow);
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Le visiteur sélectionné est concerné par des rapports , il ne peut être supprimer.");
                    return;
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void ModificationVisiteur()
        {
            groupBox4.Text = "Modification";

            this.objcontexte = new gsbrapports2016Entities();

            // On select les informations du visiteur de l'objet contexte.

            var req = (from v in this.objcontexte.visiteur
                       where v.id == this.idV
                       select v);

            // On attribue la valeur des infos du visteur à la textbox correspondante.

            foreach (var item in req)
            {
                item.nom = this.txtNom.Text;
                item.prenom = this.txtPrenom.Text;
                item.login = this.txtLogin.Text;
                item.mdp = this.txtMdp.Text;
                item.adresse = this.txtAdresse.Text;
                item.cp = this.txtCp.Text;
                item.ville = this.txtVille.Text;
                item.dateEmbauche = this.dateTimePicker1.Value;

            }

            // On sauvegarde tous changement effectués.

            evenement = "modifier";
            objcontexte.SaveChanges();
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
            MessageBox.Show("Visiteur modifié.");

            // FIN MODIFIER //
            // FIN du if == modifier //

        }


        public void AjoutVisiteur()
        {
            groupBox4.Text = "Ajout";
            this.objcontexte = new gsbrapports2016Entities();
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;" +
        "pwd=root;database=gsbrapports2016;";

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            string dt = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // On vérifie si tous les champs ont bien été remplis.

            if (this.txtNom.Text != "" && this.txtPrenom.Text != "" && this.txtAdresse.Text != "" && this.txtCp.Text != "" && this.txtVille.Text != ""/* && this.dateTimePicker1.Value != "00/00/0000"*/)
            {
                MySqlCommand ajout = new MySqlCommand("insert into visiteur(id,nom,prenom,login,mdp,adresse,cp,ville,dateEmbauche) values('" + this.txtId.Text + "','" + this.txtNom.Text + "','" + this.txtPrenom.Text + "','" + this.txtLogin.Text + "','" + this.txtMdp.Text + "','" + this.txtAdresse.Text + "','" + this.txtCp.Text + "','" + this.txtVille.Text + "','" + dt + "')", conn);
                ajout.ExecuteNonQuery();

                string[] AjoutV = new string[] { this.txtId.Text, this.txtNom.Text + this.txtPrenom.Text,this.txtLogin.Text,this.txtMdp.Text,this.txtAdresse.Text,
                    this.txtCp.Text,this.txtVille.Text,dt};

                dataGridView1.Rows.Add(AjoutV);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
                MessageBox.Show("Visiteur ajouté.");

            }
            else
            {
                MessageBox.Show("Un champ n'as pas été remplit");
                return;
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataGridViewRow toto = new DataGridViewRow[4];
            dataGridView1.Rows.RemoveAt(4);
        }
    }




}

