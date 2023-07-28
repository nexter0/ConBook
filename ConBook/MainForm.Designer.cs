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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
      dgvContacts = new DataGridView();
      btnAdd = new Button();
      btnDelete = new Button();
      btnEdit = new Button();
      MenuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
      SuspendLayout();
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
      dgvContacts.Location = new Point(12, 62);
      dgvContacts.Name = "dgvContacts";
      dgvContacts.ReadOnly = true;
      dgvContacts.RowHeadersVisible = false;
      dgvContacts.RowTemplate.Height = 25;
      dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvContacts.Size = new Size(580, 467);
      dgvContacts.TabIndex = 9;
      dgvContacts.ColumnHeaderMouseClick += dgvContacts_ColumnHeaderMouseClick;
      // 
      // btnAdd
      // 
      btnAdd.Image = Properties.Resources.plus;
      btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      btnAdd.Location = new Point(340, 27);
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
      btnDelete.Location = new Point(512, 27);
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
      btnEdit.Location = new Point(426, 27);
      btnEdit.Name = "btnEdit";
      btnEdit.Size = new Size(80, 29);
      btnEdit.TabIndex = 12;
      btnEdit.Text = "Edytuj";
      btnEdit.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnEdit.UseVisualStyleBackColor = true;
      btnEdit.Click += btnEdit_Click;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(604, 541);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvContacts);
      Controls.Add(MenuStrip);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MainMenuStrip = MenuStrip;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "MainForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "ConBook";
      FormClosing += MainForm_FormClosing;
      FormClosed += MainForm_FormClosed;
      Load += MainForm_Load;
      MenuStrip.ResumeLayout(false);
      MenuStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private MenuStrip MenuStrip;
    private ToolStripMenuItem tsmiPlik;
    private ToolStripMenuItem tsmiNew;
    private ToolStripMenuItem tsmiOpen;
    private ToolStripMenuItem tsmiSave;
    private ToolStripMenuItem tsmiSaveAs;
    private DataGridView dgvContacts;
    private ToolStripMenuItem tsmiList;
    private ToolStripMenuItem tsmiSort;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem tsmiAbout;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnEdit;
  }
}
