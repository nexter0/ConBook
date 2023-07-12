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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            nameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            surnameTextBox = new TextBox();
            label3 = new Label();
            phoneTextBox = new TextBox();
            submitButton = new Button();
            MenuStrip = new MenuStrip();
            pikToolStripMenuItem = new ToolStripMenuItem();
            nowyToolStripMenuItem = new ToolStripMenuItem();
            otwórzToolStripMenuItem = new ToolStripMenuItem();
            zapiszToolStripMenuItem = new ToolStripMenuItem();
            zapiszJakoToolStripMenuItem = new ToolStripMenuItem();
            listaToolStripMenuItem = new ToolStripMenuItem();
            sortujToolStripMenuItem = new ToolStripMenuItem();
            groupBox1 = new GroupBox();
            cancelEditButton = new Button();
            editButton = new Button();
            dgvContacts = new DataGridView();
            cmsRows = new ContextMenuStrip(components);
            edytujToolStripMenuItem = new ToolStripMenuItem();
            usuńToolStripMenuItem = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            cmsRows.SuspendLayout();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(6, 37);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(125, 23);
            nameTextBox.TabIndex = 0;
            nameTextBox.KeyDown += nameTextBox_KeyDown;
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
            surnameTextBox.KeyDown += surnameTextBox_KeyDown;
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
            phoneTextBox.KeyDown += phoneTextBox_KeyDown;
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
            // MenuStrip
            // 
            MenuStrip.Items.AddRange(new ToolStripItem[] { pikToolStripMenuItem, listaToolStripMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Size = new Size(604, 24);
            MenuStrip.TabIndex = 7;
            MenuStrip.Text = "menuStrip1";
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
            groupBox1.Controls.Add(cancelEditButton);
            groupBox1.Controls.Add(editButton);
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
            // cancelEditButton
            // 
            cancelEditButton.Location = new Point(481, 49);
            cancelEditButton.Name = "cancelEditButton";
            cancelEditButton.Size = new Size(93, 26);
            cancelEditButton.TabIndex = 10;
            cancelEditButton.Text = "Anuluj";
            cancelEditButton.UseVisualStyleBackColor = true;
            cancelEditButton.Visible = false;
            cancelEditButton.Click += cancelEditButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(481, 17);
            editButton.Name = "editButton";
            editButton.Size = new Size(93, 26);
            editButton.TabIndex = 10;
            editButton.Text = "Edytuj";
            editButton.UseVisualStyleBackColor = true;
            editButton.Visible = false;
            editButton.Click += editButton_Click;
            // 
            // dgvContacts
            // 
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.AllowUserToDeleteRows = false;
            dgvContacts.AllowUserToResizeColumns = false;
            dgvContacts.AllowUserToResizeRows = false;
            dgvContacts.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvContacts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            cmsRows.Items.AddRange(new ToolStripItem[] { edytujToolStripMenuItem, usuńToolStripMenuItem });
            cmsRows.Name = "cmsRows";
            cmsRows.Size = new Size(108, 48);
            // 
            // edytujToolStripMenuItem
            // 
            edytujToolStripMenuItem.Name = "edytujToolStripMenuItem";
            edytujToolStripMenuItem.Size = new Size(107, 22);
            edytujToolStripMenuItem.Text = "Edytuj";
            edytujToolStripMenuItem.Click += edytujToolStripMenuItem_Click;
            // 
            // usuńToolStripMenuItem
            // 
            usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            usuńToolStripMenuItem.Size = new Size(107, 22);
            usuńToolStripMenuItem.Text = "Usuń";
            usuńToolStripMenuItem.Click += usuńToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 541);
            Controls.Add(dgvContacts);
            Controls.Add(groupBox1);
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ConBook";
            Load += Form1_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            cmsRows.ResumeLayout(false);
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
        private MenuStrip MenuStrip;
        private ToolStripMenuItem pikToolStripMenuItem;
        private ToolStripMenuItem nowyToolStripMenuItem;
        private ToolStripMenuItem otwórzToolStripMenuItem;
        private ToolStripMenuItem zapiszToolStripMenuItem;
        private ToolStripMenuItem zapiszJakoToolStripMenuItem;
        private GroupBox groupBox1;
        private DataGridView dgvContacts;
        private ToolStripMenuItem listaToolStripMenuItem;
        private ToolStripMenuItem sortujToolStripMenuItem;
        private ContextMenuStrip cmsRows;
        private ToolStripMenuItem edytujToolStripMenuItem;
        private ToolStripMenuItem usuńToolStripMenuItem;
        private Button editButton;
        private Button cancelEditButton;
    }
}