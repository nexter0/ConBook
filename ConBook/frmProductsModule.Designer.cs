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
      label1 = new Label();
      ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
      dgvProducts.Location = new Point(12, 49);
      dgvProducts.MultiSelect = false;
      dgvProducts.Name = "dgvProducts";
      dgvProducts.ReadOnly = true;
      dgvProducts.RowHeadersVisible = false;
      dgvProducts.RowTemplate.Height = 25;
      dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvProducts.Size = new Size(826, 389);
      dgvProducts.TabIndex = 9;
      // 
      // btnEdit
      // 
      btnEdit.Image = Properties.Resources.edit_file;
      btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      btnEdit.Location = new Point(672, 12);
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
      btnDelete.Location = new Point(758, 12);
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
      btnAdd.Location = new Point(586, 12);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new Size(80, 29);
      btnAdd.TabIndex = 13;
      btnAdd.Text = "Dodaj";
      btnAdd.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnAdd.UseVisualStyleBackColor = true;
      btnAdd.Click += btnAdd_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(12, 27);
      label1.Name = "label1";
      label1.Size = new Size(108, 19);
      label1.TabIndex = 17;
      label1.Text = "Lista produktów";
      // 
      // frmProductsModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(850, 450);
      Controls.Add(label1);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvProducts);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      KeyPreview = true;
      Name = "frmProductsModule";
      StartPosition = FormStartPosition.CenterParent;
      Text = "ConBook - Produkty";
      FormClosing += frmProductsModule_FormClosing;
      Load += frmProductsModule_Load;
      KeyUp += frmProductsModule_KeyUp;
      ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DataGridView dgvProducts;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnAdd;
    private Label label1;
  }
}
