using System.Windows.Forms;

namespace ConBook {
  partial class frmProductsModule {
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
      DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
      dgvProducts = new DataGridView();
      btnEdit = new Button();
      btnDelete = new Button();
      btnAdd = new Button();
      MenuStrip = new MenuStrip();
      tsmiPlik = new ToolStripMenuItem();
      tsmiNew = new ToolStripMenuItem();
      tsmiOpen = new ToolStripMenuItem();
      tsmiSave = new ToolStripMenuItem();
      tsmiSaveAs = new ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
      MenuStrip.SuspendLayout();
      SuspendLayout();
      // 
      // dgvProducts
      // 
      dgvProducts.AllowUserToAddRows = false;
      dgvProducts.AllowUserToDeleteRows = false;
      dgvProducts.AllowUserToResizeColumns = false;
      dgvProducts.AllowUserToResizeRows = false;
      dgvProducts.BackgroundColor = Color.WhiteSmoke;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = SystemColors.Control;
      dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvProducts.Location = new Point(12, 62);
      dgvProducts.Name = "dgvProducts";
      dgvProducts.ReadOnly = true;
      dgvProducts.RowHeadersVisible = false;
      dgvProducts.RowTemplate.Height = 25;
      dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvProducts.Size = new Size(826, 376);
      dgvProducts.TabIndex = 9;
      // 
      // btnEdit
      // 
      btnEdit.Image = Properties.Resources.edit_file;
      btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      btnEdit.Location = new Point(672, 27);
      btnEdit.Name = "btnEdit";
      btnEdit.Size = new Size(80, 29);
      btnEdit.TabIndex = 15;
      btnEdit.Text = "Edytuj";
      btnEdit.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnEdit.UseVisualStyleBackColor = true;
      btnEdit.Click += btnEdit_Click;
      // 
      // btnDelete
      // 
      btnDelete.Image = Properties.Resources.bin;
      btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
      btnDelete.Location = new Point(758, 27);
      btnDelete.Name = "btnDelete";
      btnDelete.Size = new Size(80, 29);
      btnDelete.TabIndex = 14;
      btnDelete.Text = "Usuń";
      btnDelete.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnDelete.UseVisualStyleBackColor = true;
      btnDelete.Click += btnDelete_Click;
      // 
      // btnAdd
      // 
      btnAdd.Image = Properties.Resources.plus;
      btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
      btnAdd.Location = new Point(586, 27);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new Size(80, 29);
      btnAdd.TabIndex = 13;
      btnAdd.Text = "Dodaj";
      btnAdd.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnAdd.UseVisualStyleBackColor = true;
      btnAdd.Click += btnAdd_Click;
      // 
      // MenuStrip
      // 
      MenuStrip.Items.AddRange(new ToolStripItem[] { tsmiPlik });
      MenuStrip.Location = new Point(0, 0);
      MenuStrip.Name = "MenuStrip";
      MenuStrip.Size = new Size(850, 24);
      MenuStrip.TabIndex = 16;
      MenuStrip.Text = "msProducts";
      // 
      // tsmiPlik
      // 
      tsmiPlik.DropDownItems.AddRange(new ToolStripItem[] { tsmiNew, tsmiOpen, tsmiSave, tsmiSaveAs });
      tsmiPlik.Name = "tsmiPlik";
      tsmiPlik.Size = new Size(38, 20);
      tsmiPlik.Text = "Plik";
      // 
      // tsmiNew
      // 
      tsmiNew.Name = "tsmiNew";
      tsmiNew.Size = new Size(141, 22);
      tsmiNew.Text = "Nowy";
      tsmiNew.Click += tsmiNew_Click;
      // 
      // tsmiOpen
      // 
      tsmiOpen.Name = "tsmiOpen";
      tsmiOpen.Size = new Size(141, 22);
      tsmiOpen.Text = "Otwórz...";
      tsmiOpen.Click += tsmiOpen_Click;
      // 
      // tsmiSave
      // 
      tsmiSave.Name = "tsmiSave";
      tsmiSave.Size = new Size(141, 22);
      tsmiSave.Text = "Zapisz";
      tsmiSave.Click += tsmiSave_Click;
      // 
      // tsmiSaveAs
      // 
      tsmiSaveAs.Name = "tsmiSaveAs";
      tsmiSaveAs.Size = new Size(141, 22);
      tsmiSaveAs.Text = "Zapisz jako...";
      tsmiSaveAs.Click += tsmiSaveAs_Click;
      // 
      // frmProductsModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(850, 450);
      Controls.Add(MenuStrip);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvProducts);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Name = "frmProductsModule";
      StartPosition = FormStartPosition.CenterParent;
      Text = "ConBook - Towary";
      FormClosing += frmProductsModule_FormClosing;
      Load += frmProductsModule_Load;
      ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
      MenuStrip.ResumeLayout(false);
      MenuStrip.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DataGridView dgvProducts;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnAdd;
    private MenuStrip MenuStrip;
    private ToolStripMenuItem tsmiPlik;
    private ToolStripMenuItem tsmiNew;
    private ToolStripMenuItem tsmiOpen;
    private ToolStripMenuItem tsmiSave;
    private ToolStripMenuItem tsmiSaveAs;
  }
}
