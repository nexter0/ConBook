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
            NameTextBox = new TextBox();
            NameLabel = new Label();
            SurnameLabel = new Label();
            SurnameTextBox = new TextBox();
            PhoneLabel = new Label();
            PhoneTextBox = new TextBox();
            SubmitButton = new Button();
            MenuStrip = new MenuStrip();
            pikToolStripMenuItem = new ToolStripMenuItem();
            NewTsmItem = new ToolStripMenuItem();
            OpenTsmItem = new ToolStripMenuItem();
            SaveTsmItem = new ToolStripMenuItem();
            SaveAsTsmItem = new ToolStripMenuItem();
            listaToolStripMenuItem = new ToolStripMenuItem();
            SortTsmItem = new ToolStripMenuItem();
            InteractionGroupBox = new GroupBox();
            CancelEditButton = new Button();
            EditButton = new Button();
            dgvContacts = new DataGridView();
            cmsRows = new ContextMenuStrip(components);
            EditCmItem = new ToolStripMenuItem();
            DeleteCmItem = new ToolStripMenuItem();
            MenuStrip.SuspendLayout();
            InteractionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
            cmsRows.SuspendLayout();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(6, 37);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(125, 23);
            NameTextBox.TabIndex = 0;
            NameTextBox.KeyDown += NameTextBox_KeyDown;
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
            // SurnameTextBox
            // 
            SurnameTextBox.Location = new Point(146, 37);
            SurnameTextBox.Name = "SurnameTextBox";
            SurnameTextBox.Size = new Size(125, 23);
            SurnameTextBox.TabIndex = 2;
            SurnameTextBox.KeyDown += SurnameTextBox_KeyDown;
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
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(286, 37);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(125, 23);
            PhoneTextBox.TabIndex = 4;
            PhoneTextBox.KeyDown += PhoneTextBox_KeyDown;
            // 
            // SubmitButton
            // 
            SubmitButton.Location = new Point(481, 49);
            SubmitButton.Name = "SubmitButton";
            SubmitButton.Size = new Size(93, 26);
            SubmitButton.TabIndex = 6;
            SubmitButton.Text = "Dodaj";
            SubmitButton.UseVisualStyleBackColor = true;
            SubmitButton.Click += SubmitButton_Click;
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
            pikToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewTsmItem, OpenTsmItem, SaveTsmItem, SaveAsTsmItem });
            pikToolStripMenuItem.Name = "pikToolStripMenuItem";
            pikToolStripMenuItem.Size = new Size(38, 20);
            pikToolStripMenuItem.Text = "Plik";
            // 
            // NewTsmItem
            // 
            NewTsmItem.Name = "NewTsmItem";
            NewTsmItem.Size = new Size(180, 22);
            NewTsmItem.Text = "Nowy";
            NewTsmItem.Click += NewTsmItem_Click;
            // 
            // OpenTsmItem
            // 
            OpenTsmItem.Name = "OpenTsmItem";
            OpenTsmItem.Size = new Size(180, 22);
            OpenTsmItem.Text = "Otwórz...";
            OpenTsmItem.Click += OpenTsmItem_Click;
            // 
            // SaveTsmItem
            // 
            SaveTsmItem.Name = "SaveTsmItem";
            SaveTsmItem.Size = new Size(180, 22);
            SaveTsmItem.Text = "Zapisz";
            SaveTsmItem.Click += SaveTsmItem_Click;
            // 
            // SaveAsTsmItem
            // 
            SaveAsTsmItem.Name = "SaveAsTsmItem";
            SaveAsTsmItem.Size = new Size(180, 22);
            SaveAsTsmItem.Text = "Zapisz jako...";
            SaveAsTsmItem.Click += SaveAsTsmItem_Click;
            // 
            // listaToolStripMenuItem
            // 
            listaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SortTsmItem });
            listaToolStripMenuItem.Name = "listaToolStripMenuItem";
            listaToolStripMenuItem.Size = new Size(43, 20);
            listaToolStripMenuItem.Text = "Lista";
            // 
            // SortTsmItem
            // 
            SortTsmItem.Name = "SortTsmItem";
            SortTsmItem.Size = new Size(105, 22);
            SortTsmItem.Text = "Sortuj";
            SortTsmItem.Click += SortTsmItem_Click;
            // 
            // InteractionGroupBox
            // 
            InteractionGroupBox.Controls.Add(CancelEditButton);
            InteractionGroupBox.Controls.Add(EditButton);
            InteractionGroupBox.Controls.Add(NameTextBox);
            InteractionGroupBox.Controls.Add(SubmitButton);
            InteractionGroupBox.Controls.Add(SurnameTextBox);
            InteractionGroupBox.Controls.Add(PhoneLabel);
            InteractionGroupBox.Controls.Add(PhoneTextBox);
            InteractionGroupBox.Controls.Add(SurnameLabel);
            InteractionGroupBox.Controls.Add(NameLabel);
            InteractionGroupBox.Location = new Point(12, 448);
            InteractionGroupBox.Name = "InteractionGroupBox";
            InteractionGroupBox.Size = new Size(580, 81);
            InteractionGroupBox.TabIndex = 8;
            InteractionGroupBox.TabStop = false;
            InteractionGroupBox.Text = "Dodaj / edytuj kontakt";
            // 
            // CancelEditButton
            // 
            CancelEditButton.Location = new Point(481, 49);
            CancelEditButton.Name = "CancelEditButton";
            CancelEditButton.Size = new Size(93, 26);
            CancelEditButton.TabIndex = 10;
            CancelEditButton.Text = "Anuluj";
            CancelEditButton.UseVisualStyleBackColor = true;
            CancelEditButton.Visible = false;
            CancelEditButton.Click += CancelEditButton_Click;
            // 
            // EditButton
            // 
            EditButton.Location = new Point(481, 17);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(93, 26);
            EditButton.TabIndex = 10;
            EditButton.Text = "Edytuj";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Visible = false;
            EditButton.Click += EditButton_Click;
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
            cmsRows.Items.AddRange(new ToolStripItem[] { EditCmItem, DeleteCmItem });
            cmsRows.Name = "cmsRows";
            cmsRows.Size = new Size(108, 48);
            // 
            // EditCmItem
            // 
            EditCmItem.Name = "EditCmItem";
            EditCmItem.Size = new Size(107, 22);
            EditCmItem.Text = "Edytuj";
            EditCmItem.Click += EditCmItem_Click;
            // 
            // DeleteCmItem
            // 
            DeleteCmItem.Name = "DeleteCmItem";
            DeleteCmItem.Size = new Size(107, 22);
            DeleteCmItem.Text = "Usuń";
            DeleteCmItem.Click += DeleteCmItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 541);
            Controls.Add(dgvContacts);
            Controls.Add(InteractionGroupBox);
            Controls.Add(MenuStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ConBook";
            Load += MainForm_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            InteractionGroupBox.ResumeLayout(false);
            InteractionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
            cmsRows.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private Label NameLabel;
        private Label SurnameLabel;
        private TextBox SurnameTextBox;
        private Label PhoneLabel;
        private TextBox PhoneTextBox;
        private Button SubmitButton;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem pikToolStripMenuItem;
        private ToolStripMenuItem NewTsmItem;
        private ToolStripMenuItem OpenTsmItem;
        private ToolStripMenuItem SaveTsmItem;
        private ToolStripMenuItem SaveAsTsmItem;
        private GroupBox InteractionGroupBox;
        private DataGridView dgvContacts;
        private ToolStripMenuItem listaToolStripMenuItem;
        private ToolStripMenuItem SortTsmItem;
        private ContextMenuStrip cmsRows;
        private ToolStripMenuItem EditCmItem;
        private ToolStripMenuItem DeleteCmItem;
        private Button EditButton;
        private Button CancelEditButton;
    }
}