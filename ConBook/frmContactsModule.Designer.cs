namespace ConBook {
  partial class frmContactsModule {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
      msContacts = new MenuStrip();
      tsmiPlik = new ToolStripMenuItem();
      tsmiNew = new ToolStripMenuItem();
      tsmiOpen = new ToolStripMenuItem();
      tsmiSave = new ToolStripMenuItem();
      toolStripSeparator1 = new ToolStripSeparator();
      dgvContacts = new DataGridView();
      btnAdd = new Button();
      btnDelete = new Button();
      btnEdit = new Button();
      zapiszJakoToolStripMenuItem = new ToolStripMenuItem();
      msContacts.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
      SuspendLayout();
      // 
      // msContacts
      // 
      msContacts.Items.AddRange(new ToolStripItem[] { tsmiPlik });
      msContacts.Location = new Point(0, 0);
      msContacts.Name = "msContacts";
      msContacts.Size = new Size(657, 24);
      msContacts.TabIndex = 7;
      msContacts.Text = "menuStrip1";
      // 
      // tsmiPlik
      // 
      tsmiPlik.DropDownItems.AddRange(new ToolStripItem[] { tsmiNew, tsmiOpen, tsmiSave, toolStripSeparator1, zapiszJakoToolStripMenuItem });
      tsmiPlik.Name = "tsmiPlik";
      tsmiPlik.Size = new Size(38, 20);
      tsmiPlik.Text = "Plik";
      tsmiPlik.Click += tsmiPlik_Click;
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
      // toolStripSeparator1
      // 
      toolStripSeparator1.Name = "toolStripSeparator1";
      toolStripSeparator1.Size = new Size(177, 6);
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
      dgvContacts.Location = new Point(12, 62);
      dgvContacts.Name = "dgvContacts";
      dgvContacts.ReadOnly = true;
      dgvContacts.RowHeadersVisible = false;
      dgvContacts.RowTemplate.Height = 25;
      dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvContacts.Size = new Size(633, 467);
      dgvContacts.TabIndex = 9;
      dgvContacts.CellDoubleClick += dgvContacts_CellDoubleClick;
      dgvContacts.ColumnHeaderMouseClick += dgvContacts_ColumnHeaderMouseClick;
      // 
      // btnAdd
      // 
      btnAdd.Image = Properties.Resources.plus;
      btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      btnAdd.Location = new Point(393, 27);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new Size(80, 29);
      btnAdd.TabIndex = 10;
      btnAdd.Text = "Dodaj";
      btnAdd.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnAdd.UseVisualStyleBackColor = true;
      btnAdd.Click += btnAdd_Click;
      // 
      // btnDelete
      // 
      btnDelete.Image = Properties.Resources.bin;
      btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
      btnDelete.Location = new Point(565, 27);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new Size(80, 29);
      btnDelete.TabIndex = 11;
      btnDelete.Text = "Usuń";
      btnDelete.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // btnEdit
      // 
      btnEdit.Image = Properties.Resources.edit_file;
      btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      btnEdit.Location = new Point(479, 27);
      btnEdit.Name = "btnEdit";
      btnEdit.Size = new Size(80, 29);
      btnEdit.TabIndex = 12;
      btnEdit.Text = "Edytuj";
      btnEdit.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnEdit.UseVisualStyleBackColor = true;
      btnEdit.Click += btnEdit_Click;
      // 
      // zapiszJakoToolStripMenuItem
      // 
      zapiszJakoToolStripMenuItem.Name = "zapiszJakoToolStripMenuItem";
      zapiszJakoToolStripMenuItem.Size = new Size(180, 22);
      zapiszJakoToolStripMenuItem.Text = "Zapisz jako...";
      // 
      // frmContactsModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(657, 541);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvContacts);
      Controls.Add(msContacts);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MainMenuStrip = msContacts;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "frmContactsModule";
      StartPosition = FormStartPosition.CenterParent;
      Text = "ConBook - Kontakty";
      FormClosed += frmContactsModule_FormClosed;
      Load += frmContactsModule_Load;
      msContacts.ResumeLayout(false);
      msContacts.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private MenuStrip msContacts;
    private ToolStripMenuItem tsmiPlik;
    private ToolStripMenuItem tsmiNew;
    private ToolStripMenuItem tsmiOpen;
    private ToolStripMenuItem tsmiSave;
    private DataGridView dgvContacts;
    private ToolStripSeparator toolStripSeparator1;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnEdit;
    private ToolStripMenuItem zapiszJakoToolStripMenuItem;
  }
}
