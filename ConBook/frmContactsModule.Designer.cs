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
      dgvContacts = new DataGridView();
      btnAdd = new Button();
      btnDelete = new Button();
      btnEdit = new Button();
      label1 = new Label();
      ((System.ComponentModel.ISupportInitialize)dgvContacts).BeginInit();
      SuspendLayout();
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
      dgvContacts.Location = new Point(12, 47);
      dgvContacts.Name = "dgvContacts";
      dgvContacts.ReadOnly = true;
      dgvContacts.RowHeadersVisible = false;
      dgvContacts.RowTemplate.Height = 25;
      dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvContacts.Size = new Size(633, 482);
      dgvContacts.TabIndex = 9;
      dgvContacts.CellDoubleClick += dgvContacts_CellDoubleClick;
      dgvContacts.ColumnHeaderMouseClick += dgvContacts_ColumnHeaderMouseClick;
      // 
      // btnAdd
      // 
      btnAdd.Image = Properties.Resources.plus;
      btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      btnAdd.Location = new Point(393, 12);
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
      btnDelete.Location = new Point(565, 12);
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
      btnEdit.Location = new Point(479, 12);
      btnEdit.Name = "btnEdit";
      btnEdit.Size = new Size(80, 29);
      btnEdit.TabIndex = 12;
      btnEdit.Text = "Edytuj";
      btnEdit.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnEdit.UseVisualStyleBackColor = true;
      btnEdit.Click += btnEdit_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(12, 25);
      label1.Name = "label1";
      label1.Size = new Size(106, 19);
      label1.TabIndex = 13;
      label1.Text = "Lista kontaktów";
      // 
      // frmContactsModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(657, 541);
      Controls.Add(label1);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvContacts);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      KeyPreview = true;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "frmContactsModule";
      StartPosition = FormStartPosition.CenterParent;
      Text = "ConBook - Kontakty";
      Load += frmContactsModule_Load;
      KeyUp += frmContactsModule_KeyUp;
      ((System.ComponentModel.ISupportInitialize)dgvContacts).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private DataGridView dgvContacts;
    private Button btnAdd;
    private Button btnDelete;
    private Button btnEdit;
    private Label label1;
  }
}
