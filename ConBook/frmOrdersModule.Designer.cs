namespace ConBook {
  partial class frmOrdersModule {
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
      dgvOrders = new DataGridView();
      btnEdit = new Button();
      btnDelete = new Button();
      btnAdd = new Button();
      label1 = new Label();
      ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
      SuspendLayout();
      // 
      // dgvOrders
      // 
      dgvOrders.AllowUserToAddRows = false;
      dgvOrders.AllowUserToDeleteRows = false;
      dgvOrders.AllowUserToResizeColumns = false;
      dgvOrders.AllowUserToResizeRows = false;
      dgvOrders.BackgroundColor = Color.WhiteSmoke;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = SystemColors.Control;
      dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvOrders.Location = new Point(12, 47);
      dgvOrders.MultiSelect = false;
      dgvOrders.Name = "dgvOrders";
      dgvOrders.ReadOnly = true;
      dgvOrders.RowHeadersVisible = false;
      dgvOrders.RowTemplate.Height = 25;
      dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvOrders.Size = new Size(626, 391);
      dgvOrders.TabIndex = 10;
      dgvOrders.CellDoubleClick += dgvOrders_CellDoubleClick;
      dgvOrders.CellFormatting += dgvOrders_CellFormatting;
      // 
      // btnEdit
      // 
      btnEdit.Image = Properties.Resources.edit_file;
      btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      btnEdit.Location = new Point(470, 12);
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
      btnDelete.Location = new Point(556, 12);
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
      btnAdd.Location = new Point(384, 12);
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
      label1.Location = new Point(12, 25);
      label1.Name = "label1";
      label1.Size = new Size(102, 19);
      label1.TabIndex = 16;
      label1.Text = "Lista zamówień";
      // 
      // frmOrdersModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(650, 450);
      Controls.Add(label1);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvOrders);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      KeyPreview = true;
      Name = "frmOrdersModule";
      Text = "ConBook - Zamówienia";
      Load += frmOrdersModule_Load;
      KeyUp += frmOrdersModule_KeyUp;
      ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DataGridView dgvOrders;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnAdd;
    private Label label1;
  }
}
