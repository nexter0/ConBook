﻿namespace ConBook
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            dataGridViewContacts = new DataGridView();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContacts).BeginInit();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { pikToolStripMenuItem });
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
            // 
            // zapiszToolStripMenuItem
            // 
            zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            zapiszToolStripMenuItem.Size = new Size(141, 22);
            zapiszToolStripMenuItem.Text = "Zapisz";
            // 
            // zapiszJakoToolStripMenuItem
            // 
            zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
            zapiszJakoToolStripMenuItem.Size = new Size(141, 22);
            zapiszJakoToolStripMenuItem.Text = "Zapisz jako...";
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
            // dataGridViewContacts
            // 
            dataGridViewContacts.AllowUserToAddRows = false;
            dataGridViewContacts.AllowUserToDeleteRows = false;
            dataGridViewContacts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewContacts.Location = new Point(12, 36);
            dataGridViewContacts.Name = "dataGridViewContacts";
            dataGridViewContacts.ReadOnly = true;
            dataGridViewContacts.RowTemplate.Height = 25;
            dataGridViewContacts.Size = new Size(574, 406);
            dataGridViewContacts.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 541);
            Controls.Add(dataGridViewContacts);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "ConBook";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewContacts).EndInit();
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
        private DataGridView dataGridViewContacts;
    }
}