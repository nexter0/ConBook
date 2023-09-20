using System.Windows.Forms;

namespace ConBook {
  partial class frmOrderDetails {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderDetails));
      panel1 = new Panel();
      lbTotal = new Label();
      label6 = new Label();
      label5 = new Label();
      dgvProducts = new DataGridView();
      lbDateCreated = new Label();
      label2 = new Label();
      panel2 = new Panel();
      lbClientPhone = new Label();
      label4 = new Label();
      lbClientSurname = new Label();
      lbClientName = new Label();
      label3 = new Label();
      label1 = new Label();
      lbOrderNumber = new Label();
      panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
      panel2.SuspendLayout();
      SuspendLayout();
      // 
      // panel1
      // 
      panel1.BorderStyle = BorderStyle.FixedSingle;
      panel1.Controls.Add(lbTotal);
      panel1.Controls.Add(label6);
      panel1.Controls.Add(label5);
      panel1.Controls.Add(dgvProducts);
      panel1.Controls.Add(lbDateCreated);
      panel1.Controls.Add(label2);
      panel1.Location = new Point(5, 61);
      panel1.Name = "panel1";
      panel1.Size = new Size(547, 321);
      panel1.TabIndex = 0;
      // 
      // lbTotal
      // 
      lbTotal.AutoSize = true;
      lbTotal.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbTotal.Location = new Point(6, 64);
      lbTotal.Name = "lbTotal";
      lbTotal.Size = new Size(107, 19);
      lbTotal.TabIndex = 12;
      lbTotal.Text = "<TOTAL PRICE>";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label6.Location = new Point(3, 49);
      label6.Name = "label6";
      label6.Size = new Size(151, 15);
      label6.TabIndex = 11;
      label6.Text = "Łączna kwota zamówienia";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label5.Location = new Point(6, 110);
      label5.Name = "label5";
      label5.Size = new Size(97, 15);
      label5.TabIndex = 6;
      label5.Text = "Lista produktów";
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
      dgvProducts.Location = new Point(6, 131);
      dgvProducts.Name = "dgvProducts";
      dgvProducts.ReadOnly = true;
      dgvProducts.RowHeadersVisible = false;
      dgvProducts.RowTemplate.Height = 25;
      dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvProducts.Size = new Size(536, 185);
      dgvProducts.TabIndex = 10;
      dgvProducts.CellFormatting += dgvProducts_CellFormatting;
      // 
      // lbDateCreated
      // 
      lbDateCreated.AutoSize = true;
      lbDateCreated.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbDateCreated.Location = new Point(3, 25);
      lbDateCreated.Name = "lbDateCreated";
      lbDateCreated.Size = new Size(121, 19);
      lbDateCreated.TabIndex = 4;
      lbDateCreated.Text = "<DATE CREATED>";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label2.Location = new Point(3, 10);
      label2.Name = "label2";
      label2.Size = new Size(99, 15);
      label2.TabIndex = 3;
      label2.Text = "Data utworzenia";
      // 
      // panel2
      // 
      panel2.BorderStyle = BorderStyle.FixedSingle;
      panel2.Controls.Add(lbClientPhone);
      panel2.Controls.Add(label4);
      panel2.Controls.Add(lbClientSurname);
      panel2.Controls.Add(lbClientName);
      panel2.Controls.Add(label3);
      panel2.Location = new Point(288, 61);
      panel2.Name = "panel2";
      panel2.Size = new Size(264, 126);
      panel2.TabIndex = 1;
      // 
      // lbClientPhone
      // 
      lbClientPhone.AutoSize = true;
      lbClientPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbClientPhone.Location = new Point(3, 90);
      lbClientPhone.Name = "lbClientPhone";
      lbClientPhone.Size = new Size(75, 19);
      lbClientPhone.TabIndex = 8;
      lbClientPhone.Text = "<PHONE>";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label4.Location = new Point(3, 75);
      label4.Name = "label4";
      label4.Size = new Size(52, 15);
      label4.TabIndex = 7;
      label4.Text = "Kontakt";
      // 
      // lbClientSurname
      // 
      lbClientSurname.AutoSize = true;
      lbClientSurname.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbClientSurname.Location = new Point(3, 45);
      lbClientSurname.Name = "lbClientSurname";
      lbClientSurname.Size = new Size(93, 19);
      lbClientSurname.TabIndex = 6;
      lbClientSurname.Text = "<SURNAME>";
      // 
      // lbClientName
      // 
      lbClientName.AutoSize = true;
      lbClientName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbClientName.Location = new Point(3, 25);
      lbClientName.Name = "lbClientName";
      lbClientName.Size = new Size(68, 19);
      lbClientName.TabIndex = 5;
      lbClientName.Text = "<NAME>";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label3.Location = new Point(3, 10);
      label3.Name = "label3";
      label3.Size = new Size(92, 15);
      label3.TabIndex = 4;
      label3.Text = "Klient zlecający";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(5, 9);
      label1.Name = "label1";
      label1.Size = new Size(172, 15);
      label1.TabIndex = 2;
      label1.Text = "Szczegóły zamówienia numer";
      // 
      // lbOrderNumber
      // 
      lbOrderNumber.AutoSize = true;
      lbOrderNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
      lbOrderNumber.Location = new Point(5, 24);
      lbOrderNumber.Name = "lbOrderNumber";
      lbOrderNumber.Size = new Size(133, 19);
      lbOrderNumber.TabIndex = 3;
      lbOrderNumber.Text = "<ORDER NUMBER>";
      lbOrderNumber.TextAlign = ContentAlignment.TopCenter;
      // 
      // frmOrderDetails
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(573, 396);
      Controls.Add(lbOrderNumber);
      Controls.Add(label1);
      Controls.Add(panel2);
      Controls.Add(panel1);
      Icon = (Icon)resources.GetObject("$this.Icon");
      KeyPreview = true;
      Name = "frmOrderDetails";
      RightToLeftLayout = true;
      ShowIcon = false;
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "Szczegóły zamówienia";
      KeyUp += frmOrderDetails_KeyUp;
      panel1.ResumeLayout(false);
      panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
      panel2.ResumeLayout(false);
      panel2.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Panel panel1;
    private Label lbDateCreated;
    private Label label2;
    private Panel panel2;
    private Label lbClientSurname;
    private Label lbClientName;
    private Label label3;
    private Label label1;
    private Label lbOrderNumber;
    private Label lbClientPhone;
    private Label label4;
    private Label label5;
    private DataGridView dgvProducts;
    private Label lbTotal;
    private Label label6;
  }
}
