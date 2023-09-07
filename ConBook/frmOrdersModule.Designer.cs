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
      DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
      dgvOrders = new DataGridView();
      btnEdit = new Button();
      btnDelete = new Button();
      btnAdd = new Button();
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
      dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = SystemColors.Control;
      dataGridViewCellStyle3.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
      dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvOrders.Location = new Point(12, 62);
      dgvOrders.Name = "dgvOrders";
      dgvOrders.ReadOnly = true;
      dgvOrders.RowHeadersVisible = false;
      dgvOrders.RowTemplate.Height = 25;
      dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvOrders.Size = new Size(626, 376);
      dgvOrders.TabIndex = 10;
      // 
      // btnEdit
      // 
      btnEdit.Image = Properties.Resources.edit_file;
      btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
      btnEdit.Location = new Point(470, 27);
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
      btnDelete.Location = new Point(556, 27);
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
      btnAdd.Location = new Point(384, 27);
      btnAdd.Name = "btnAdd";
      btnAdd.Size = new Size(80, 29);
      btnAdd.TabIndex = 13;
      btnAdd.Text = "Dodaj";
      btnAdd.TextImageRelation = TextImageRelation.TextBeforeImage;
      btnAdd.UseVisualStyleBackColor = true;
      btnAdd.Click += btnAdd_Click;
      // 
      // frmOrdersModule
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(650, 450);
      Controls.Add(btnEdit);
      Controls.Add(btnDelete);
      Controls.Add(btnAdd);
      Controls.Add(dgvOrders);
      Name = "frmOrdersModule";
      Text = "frmOrdersModule";
      Load += frmOrdersModule_Load;
      ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
      ResumeLayout(false);
    }

    #endregion

    private DataGridView dgvOrders;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnAdd;
  }
}