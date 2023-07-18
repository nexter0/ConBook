namespace ConBook {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtName = new TextBox();
            NameLabel = new Label();
            SurnameLabel = new Label();
            txtSurname = new TextBox();
            PhoneLabel = new Label();
            txtPhone = new TextBox();
            btnSubmit = new Button();
            MenuStrip = new MenuStrip();
            tsmiPlik = new ToolStripMenuItem();
            tsmiNew = new ToolStripMenuItem();
            tsmiOpen = new ToolStripMenuItem();
            tsmiSave = new ToolStripMenuItem();
            tsmiSaveAs = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiAbout = new ToolStripMenuItem();
            tsmiList = new ToolStripMenuItem();
            tsmiSort = new ToolStripMenuItem();
            gbInteraction = new GroupBox();
            btnCancelEdit = new Button();
            btnEdit = new Button();
            dgvContacts = new DataGridView();
            cmsRows = new ContextMenuStrip(components);
            cmiEdit = new ToolStripMenuItem();
            cmiDelete = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            gbInteraction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            cmsRows.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(6, 37);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 23);
            txtName.TabIndex = 0;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(6, 19);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(30, 15);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Imię";
            // 
            // SurnameLabel
            // 
            SurnameLabel.AutoSize = true;
            SurnameLabel.Location = new Point(146, 19);
            SurnameLabel.Name = "SurnameLabel";
            SurnameLabel.Size = new Size(57, 15);
            SurnameLabel.TabIndex = 3;
            SurnameLabel.Text = "Nazwisko";
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(146, 37);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(125, 23);
            txtSurname.TabIndex = 2;
            txtSurname.KeyDown += txtSurname_KeyDown;
            // 
            // PhoneLabel
            // 
            PhoneLabel.AutoSize = true;
            PhoneLabel.Location = new Point(286, 19);
            PhoneLabel.Name = "PhoneLabel";
            PhoneLabel.Size = new Size(45, 15);
            PhoneLabel.TabIndex = 5;
            PhoneLabel.Text = "Telefon";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(286, 37);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 23);
            txtPhone.TabIndex = 4;
            txtPhone.KeyDown += txtPhone_KeyDown;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(481, 49);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(93, 26);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Dodaj";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { tsmiPlik, tsmiList });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(604, 24);
            MenuStrip.TabIndex = 7;
            MenuStrip.Text = "menuStrip1";
            // 
            // tsmiPlik
            // 
            tsmiPlik.DropDownItems.AddRange(new ToolStripItem[] { tsmiNew, tsmiOpen, tsmiSave, tsmiSaveAs, toolStripSeparator1, tsmiAbout });
            tsmiPlik.Name = "tsmiPlik";
            tsmiPlik.Size = new Size(38, 20);
            tsmiPlik.Text = "Plik";
            // 
            // tsmiNew
            // 
            tsmiNew.Name = "tsmiNew";
            tsmiNew.Size = new Size(180, 22);
            tsmiNew.Text = "Nowy";
            tsmiNew.Click += tsmiNew_Click;
            // 
            // tsmiOpen
            // 
            tsmiOpen.Name = "tsmiOpen";
            tsmiOpen.Size = new Size(180, 22);
            tsmiOpen.Text = "Otwórz...";
            tsmiOpen.Click += tsmiOpen_Click;
            // 
            // tsmiSave
            // 
            tsmiSave.Name = "tsmiSave";
            tsmiSave.Size = new Size(180, 22);
            tsmiSave.Text = "Zapisz";
            tsmiSave.Click += tsmiSave_Click;
            // 
            // tsmiSaveAs
            // 
            tsmiSaveAs.Name = "tsmiSaveAs";
            tsmiSaveAs.Size = new Size(180, 22);
            tsmiSaveAs.Text = "Zapisz jako...";
            tsmiSaveAs.Click += tsmiSaveAs_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(180, 22);
            tsmiAbout.Text = "O programie";
            tsmiAbout.Click += tsmiAbout_Click;
            // 
            // tsmiList
            // 
            tsmiList.DropDownItems.AddRange(new ToolStripItem[] { tsmiSort });
            tsmiList.Name = "tsmiList";
            tsmiList.Size = new Size(43, 20);
            tsmiList.Text = "Lista";
            // 
            // tsmiSort
            // 
            tsmiSort.Name = "tsmiSort";
            tsmiSort.Size = new Size(105, 22);
            tsmiSort.Text = "Sortuj";
            tsmiSort.Click += tsmiSort_Click;
            // 
            // gbInteraction
            // 
            gbInteraction.Controls.Add(btnCancelEdit);
            gbInteraction.Controls.Add(btnEdit);
            gbInteraction.Controls.Add(txtName);
            gbInteraction.Controls.Add(btnSubmit);
            gbInteraction.Controls.Add(txtSurname);
            gbInteraction.Controls.Add(PhoneLabel);
            gbInteraction.Controls.Add(txtPhone);
            gbInteraction.Controls.Add(SurnameLabel);
            gbInteraction.Controls.Add(NameLabel);
            gbInteraction.Location = new Point(12, 448);
            gbInteraction.Name = "gbInteraction";
            gbInteraction.Size = new Size(580, 81);
            gbInteraction.TabIndex = 8;
            gbInteraction.TabStop = false;
            gbInteraction.Text = "Dodaj / edytuj kontakt";
            // 
            // btnCancelEdit
            // 
            btnCancelEdit.Location = new Point(480, 49);
            btnCancelEdit.Name = "btnCancelEdit";
            btnCancelEdit.Size = new Size(93, 26);
            btnCancelEdit.TabIndex = 10;
            btnCancelEdit.Text = "Anuluj";
            btnCancelEdit.UseVisualStyleBackColor = true;
            btnCancelEdit.Visible = false;
            btnCancelEdit.Click += btnCancelEdit_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(481, 17);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(93, 26);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edytuj";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Visible = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.AllowUserToResizeColumns = false;
            dgvContacts.AllowUserToResizeRows = false;
            dgvContacts.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvContacts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Location = new Point(12, 27);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.ReadOnly = true;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.RowTemplate.Height = 25;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContacts.Size = new Size(580, 415);
            dgvContacts.TabIndex = 9;
            dgvContacts.MouseClick += dgvContacts_MouseClick;
            // 
            // cmsRows
            // 
            cmsRows.Items.AddRange(new ToolStripItem[] { cmiEdit, cmiDelete });
            cmsRows.Name = "cmsRows";
            cmsRows.Size = new Size(181, 70);
            // 
            // cmiEdit
            // 
            cmiEdit.Name = "cmiEdit";
            cmiEdit.Size = new Size(180, 22);
            cmiEdit.Text = "Edytuj";
            cmiEdit.Click += cmiEdit_Click;
            // 
            // cmiDelete
            // 
            cmiDelete.Name = "cmiDelete";
            cmiDelete.Size = new Size(180, 22);
            cmiDelete.Text = "Usuń";
            cmiDelete.Click += cmiDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 541);
            Controls.Add(dgvContacts);
            Controls.Add(gbInteraction);
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MenuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ConBook";
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            gbInteraction.ResumeLayout(false);
            gbInteraction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            cmsRows.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label NameLabel;
        private Label SurnameLabel;
        private TextBox txtSurname;
        private Label PhoneLabel;
        private TextBox txtPhone;
        private Button btnSubmit;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem tsmiPlik;
        private ToolStripMenuItem tsmiNew;
        private ToolStripMenuItem tsmiOpen;
        private ToolStripMenuItem tsmiSave;
        private ToolStripMenuItem tsmiSaveAs;
        private GroupBox gbInteraction;
        private DataGridView dgvContacts;
        private ToolStripMenuItem tsmiList;
        private ToolStripMenuItem tsmiSort;
        private ContextMenuStrip cmsRows;
        private ToolStripMenuItem cmiEdit;
        private ToolStripMenuItem cmiDelete;
        private Button btnEdit;
        private Button btnCancelEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiAbout;
    }
}
