namespace gsbRapports
{
    partial class FormRapports
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bdgRapport = new System.Windows.Forms.BindingSource(this.components);
            this.bdgVisiteur = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toutdecocher = new System.Windows.Forms.Button();
            this.dgvListeRapports = new System.Windows.Forms.DataGridView();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtnbid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtlistid = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visiteur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bdgRapport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgVisiteur)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeRapports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bdgRapport
            // 
            this.bdgRapport.DataSource = typeof(gsbRapports.rapport);
            // 
            // bdgVisiteur
            // 
            this.bdgVisiteur.DataSource = typeof(gsbRapports.visiteur);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(45, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 361);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Liste des Visiteurs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toutdecocher);
            this.groupBox2.Controls.Add(this.dgvListeRapports);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnValider);
            this.groupBox2.Controls.Add(this.txtnbid);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Location = new System.Drawing.Point(371, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(818, 415);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ID des Rapports Visiteur";
            // 
            // toutdecocher
            // 
            this.toutdecocher.BackColor = System.Drawing.Color.SteelBlue;
            this.toutdecocher.Location = new System.Drawing.Point(234, 351);
            this.toutdecocher.Name = "toutdecocher";
            this.toutdecocher.Size = new System.Drawing.Size(103, 23);
            this.toutdecocher.TabIndex = 5;
            this.toutdecocher.Text = "Tout décocher";
            this.toutdecocher.UseVisualStyleBackColor = false;
            this.toutdecocher.Click += new System.EventHandler(this.toutdecocher_Click);
            // 
            // dgvListeRapports
            // 
            this.dgvListeRapports.AllowUserToAddRows = false;
            this.dgvListeRapports.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvListeRapports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListeRapports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListeRapports.Location = new System.Drawing.Point(62, 81);
            this.dgvListeRapports.Name = "dgvListeRapports";
            this.dgvListeRapports.ReadOnly = true;
            this.dgvListeRapports.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.dgvListeRapports.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListeRapports.Size = new System.Drawing.Size(669, 218);
            this.dgvListeRapports.TabIndex = 3;
            this.dgvListeRapports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListeRapports_CellContentClick);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.SteelBlue;
            this.btnValider.Location = new System.Drawing.Point(692, 386);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(120, 23);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Générer rapport";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSelect.Location = new System.Drawing.Point(40, 351);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(127, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "Tout sélectionner";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtnbid
            // 
            this.txtnbid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtnbid.Enabled = false;
            this.txtnbid.Location = new System.Drawing.Point(631, 305);
            this.txtnbid.Name = "txtnbid";
            this.txtnbid.ReadOnly = true;
            this.txtnbid.Size = new System.Drawing.Size(100, 20);
            this.txtnbid.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Nombre de Rapports";
            // 
            // txtlistid
            // 
            this.txtlistid.Location = new System.Drawing.Point(1011, 49);
            this.txtlistid.Name = "txtlistid";
            this.txtlistid.Size = new System.Drawing.Size(100, 20);
            this.txtlistid.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 133);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Visiteur});
            this.dataGridView1.Location = new System.Drawing.Point(6, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(189, 328);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Visiteur
            // 
            this.Visiteur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Visiteur.HeaderText = "";
            this.Visiteur.Name = "Visiteur";
            this.Visiteur.ReadOnly = true;
            // 
            // FormRapports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1214, 680);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtlistid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormRapports";
            this.Text = "FormRapports";
            ((System.ComponentModel.ISupportInitialize)(this.bdgRapport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdgVisiteur)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListeRapports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bdgRapport;
        private System.Windows.Forms.BindingSource bdgVisiteur;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvListeRapports;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button toutdecocher;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.TextBox txtnbid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtlistid;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Visiteur;
    }
}