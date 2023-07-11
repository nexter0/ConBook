namespace ConBook
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            surnameTextBox = new TextBox();
            label3 = new Label();
            phoneTextBox = new TextBox();
            submitButton = new Button();
            menuStrip1 = new MenuStrip();
            pikToolStripMenuItem = new ToolStripMenuItem();
            nowyToolStripMenuItem = new ToolStripMenuItem();
            otwórzToolStripMenuItem = new ToolStripMenuItem();
            zapiszToolStripMenuItem = new ToolStripMenuItem();
            zapiszJakoToolStripMenuItem = new ToolStripMenuItem();
            listaToolStripMenuItem = new ToolStripMenuItem();
            sortujToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            dgvContacts = new DataGridView();
            colorDialog1 = new ColorDialog();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(6, 37);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(125, 23);
            nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 1;
            label1.Text = "Imię";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 19);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Nazwisko";
            // 
            // surnameTextBox
            // 
            surnameTextBox.Location = new Point(146, 37);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(125, 23);
            surnameTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(286, 19);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 5;
            label3.Text = "Telefon";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(286, 37);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(125, 23);
            phoneTextBox.TabIndex = 4;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(481, 49);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(93, 26);
            submitButton.TabIndex = 6;
            submitButton.Text = "Dodaj";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { pikToolStripMenuItem, listaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(604, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // pikToolStripMenuItem
            // 
            pikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nowyToolStripMenuItem, otwórzToolStripMenuItem, zapiszToolStripMenuItem, zapiszJakoToolStripMenuItem });
            pikToolStripMenuItem.Name = "pikToolStripMenuItem";
            pikToolStripMenuItem.Size = new Size(38, 20);
            pikToolStripMenuItem.Text = "Plik";
            // 
            // nowyToolStripMenuItem
            // 
            nowyToolStripMenuItem.Name = "nowyToolStripMenuItem";
            nowyToolStripMenuItem.Size = new Size(141, 22);
            nowyToolStripMenuItem.Text = "Nowy";
            // 
            // otwórzToolStripMenuItem
            // 
            otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            otwórzToolStripMenuItem.Size = new Size(141, 22);
            otwórzToolStripMenuItem.Text = "Otwórz...";
            otwórzToolStripMenuItem.Click += otwórzToolStripMenuItem_Click;
            // 
            // zapiszToolStripMenuItem
            // 
            zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            zapiszToolStripMenuItem.Size = new Size(141, 22);
            zapiszToolStripMenuItem.Text = "Zapisz";
            zapiszToolStripMenuItem.Click += zapiszToolStripMenuItem_Click;
            // 
            // zapiszJakoToolStripMenuItem
            // 
            zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            zapiszJakoToolStripMenuItem.Size = new Size(141, 22);
            zapiszJakoToolStripMenuItem.Text = "Zapisz jako...";
            zapiszJakoToolStripMenuItem.Click += zapiszJakoToolStripMenuItem_Click;
            // 
            // listaToolStripMenuItem
            // 
            listaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sortujToolStripMenuItem });
            listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            listaToolStripMenuItem.Size = new Size(43, 20);
            listaToolStripMenuItem.Text = "Lista";
            // 
            // sortujToolStripMenuItem
            // 
            sortujToolStripMenuItem.Name = "sortujToolStripMenuItem";
            sortujToolStripMenuItem.Size = new Size(105, 22);
            sortujToolStripMenuItem.Text = "Sortuj";
            sortujToolStripMenuItem.Click += sortujToolStripMenuItem_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nameTextBox);
            groupBox1.Controls.Add(submitButton);
            groupBox1.Controls.Add(surnameTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(phoneTextBox);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 448);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(580, 81);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Dodaj / edytuj kontakt";
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.BackgroundColor = SystemColors.ScrollBar;
            dgvContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContacts.Location = new Point(12, 27);
            dgvContacts.Name = "dgvContacts";
            dgvContacts.ReadOnly = true;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.RowTemplate.Height = 25;
            dgvContacts.Size = new Size(580, 415);
            dgvContacts.TabIndex = 9;
            // dgvContacts.RowHeadersVisible = true;
            dgvContacts.RowHeadersVisible = false;
            dgvContacts.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 9.75F, FontStyle.Bold);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 541);
            Controls.Add(dgvContacts);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ConBook";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Label label1;
        private Label label2;
        private TextBox surnameTextBox;
        private Label label3;
        private TextBox phoneTextBox;
        private Button submitButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem pikToolStripMenuItem;
        private ToolStripMenuItem nowyToolStripMenuItem;
        private ToolStripMenuItem otwórzToolStripMenuItem;
        private ToolStripMenuItem zapiszToolStripMenuItem;
        private ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private GroupBox groupBox1;
        private DataGridView dgvContacts;
        private ToolStripMenuItem listaToolStripMenuItem;
        private ToolStripMenuItem sortujToolStripMenuItem;
        private ColorDialog colorDialog1;
    }
}