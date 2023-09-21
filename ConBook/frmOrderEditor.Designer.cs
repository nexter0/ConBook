namespace ConBook {
  partial class frmOrderEditor {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderEditor));
      dtpCreationDate = new DateTimePicker();
      txtOrderNumber = new TextBox();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      btnCancel = new Button();
      btnSubmit = new Button();
      label4 = new Label();
      cbxClients = new ComboBox();
      cbxProducts = new ComboBox();
      mtxtPrice = new TextBox();
      mtxtAmount = new TextBox();
      label5 = new Label();
      label6 = new Label();
      btnAddProduct = new Button();
      dgvOrderedProducts = new DataGridView();
      btnDeleteProduct = new Button();
      label7 = new Label();
      lbSuma = new Label();
      lbTotalSum = new Label();
      ((System.ComponentModel.ISupportInitialize)dgvOrderedProducts).BeginInit();
      SuspendLayout();
      // 
      // dtpCreationDate
      // 
      dtpCreationDate.Enabled = false;
      dtpCreationDate.Location = new Point(174, 24);
      dtpCreationDate.Name = "dtpCreationDate";
      dtpCreationDate.Size = new Size(200, 23);
      dtpCreationDate.TabIndex = 0;
      // 
      // txtOrderNumber
      // 
      txtOrderNumber.Location = new Point(12, 24);
      txtOrderNumber.Name = "txtOrderNumber";
      txtOrderNumber.Size = new Size(156, 23);
      txtOrderNumber.TabIndex = 1;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(11, 6);
      label1.Name = "label1";
      label1.Size = new Size(110, 15);
      label1.TabIndex = 3;
      label1.Text = "Numer zamówienia";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(174, 6);
      label2.Name = "label2";
      label2.Size = new Size(92, 15);
      label2.TabIndex = 4;
      label2.Text = "Data utworzenia";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(11, 50);
      label3.Name = "label3";
      label3.Size = new Size(55, 15);
      label3.TabIndex = 5;
      label3.Text = "Produkty";
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(472, 332);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 9;
      btnCancel.Text = "Anuluj";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // btnSubmit
      // 
      btnSubmit.Location = new Point(391, 332);
      btnSubmit.Name = "btnSubmit";
      btnSubmit.Size = new Size(75, 23);
      btnSubmit.TabIndex = 8;
      btnSubmit.Text = "Dodaj";
      btnSubmit.UseVisualStyleBackColor = true;
      btnSubmit.Click += btnSubmit_Click;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(341, 50);
      label4.Name = "label4";
      label4.Size = new Size(37, 15);
      label4.TabIndex = 11;
      label4.Text = "Klient";
      // 
      // cbxClients
      // 
      cbxClients.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxClients.FormattingEnabled = true;
      cbxClients.Location = new Point(341, 68);
      cbxClients.Name = "cbxClients";
      cbxClients.Size = new Size(175, 23);
      cbxClients.TabIndex = 12;
      // 
      // cbxProducts
      // 
      cbxProducts.DropDownStyle = ComboBoxStyle.DropDownList;
      cbxProducts.FormattingEnabled = true;
      cbxProducts.Location = new Point(12, 68);
      cbxProducts.Name = "cbxProducts";
      cbxProducts.Size = new Size(323, 23);
      cbxProducts.TabIndex = 13;
      cbxProducts.SelectedIndexChanged += cbxProducts_SelectedIndexChanged;
      // 
      // mtxtPrice
      // 
      mtxtPrice.Location = new Point(118, 112);
      mtxtPrice.Name = "mtxtPrice";
      mtxtPrice.Size = new Size(100, 23);
      mtxtPrice.TabIndex = 14;
      mtxtPrice.TextAlign = HorizontalAlignment.Right;
      // 
      // mtxtAmount
      // 
      mtxtAmount.Location = new Point(12, 112);
      mtxtAmount.Name = "mtxtAmount";
      mtxtAmount.Size = new Size(100, 23);
      mtxtAmount.TabIndex = 15;
      mtxtAmount.TextAlign = HorizontalAlignment.Right;
      mtxtAmount.Validating += mtxtAmount_Validating;
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(118, 94);
      label5.Name = "label5";
      label5.Size = new Size(88, 15);
      label5.TabIndex = 16;
      label5.Text = "Cena sprzedaży";
      // 
      // label6
      // 
      label6.AutoSize = true;
      label6.Location = new Point(11, 94);
      label6.Name = "label6";
      label6.Size = new Size(31, 15);
      label6.TabIndex = 17;
      label6.Text = "Ilość";
      // 
      // btnAddProduct
      // 
      btnAddProduct.Location = new Point(342, 112);
      btnAddProduct.Name = "btnAddProduct";
      btnAddProduct.Size = new Size(99, 23);
      btnAddProduct.TabIndex = 18;
      btnAddProduct.Text = "Dodaj produkt";
      btnAddProduct.UseVisualStyleBackColor = true;
      btnAddProduct.Click += btnAddProduct_Click;
      // 
      // dgvOrderedProducts
      // 
      dgvOrderedProducts.AllowUserToAddRows = false;
      dgvOrderedProducts.AllowUserToDeleteRows = false;
      dgvOrderedProducts.AllowUserToResizeColumns = false;
      dgvOrderedProducts.AllowUserToResizeRows = false;
      dgvOrderedProducts.BackgroundColor = Color.WhiteSmoke;
      dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle1.BackColor = SystemColors.Control;
      dataGridViewCellStyle1.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
      dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      dgvOrderedProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      dgvOrderedProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvOrderedProducts.Location = new Point(11, 141);
      dgvOrderedProducts.MultiSelect = false;
      dgvOrderedProducts.Name = "dgvOrderedProducts";
      dgvOrderedProducts.ReadOnly = true;
      dgvOrderedProducts.RowHeadersVisible = false;
      dgvOrderedProducts.RowTemplate.Height = 25;
      dgvOrderedProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      dgvOrderedProducts.Size = new Size(536, 185);
      dgvOrderedProducts.TabIndex = 19;
      dgvOrderedProducts.CellFormatting += dgvSelectedProducts_CellFormatting;
      // 
      // btnDeleteProduct
      // 
      btnDeleteProduct.Location = new Point(447, 112);
      btnDeleteProduct.Name = "btnDeleteProduct";
      btnDeleteProduct.Size = new Size(99, 23);
      btnDeleteProduct.TabIndex = 20;
      btnDeleteProduct.Text = "Usuń produkt";
      btnDeleteProduct.UseVisualStyleBackColor = true;
      btnDeleteProduct.Click += btnDeleteProduct_Click;
      // 
      // label7
      // 
      label7.AutoSize = true;
      label7.Location = new Point(224, 120);
      label7.Name = "label7";
      label7.Size = new Size(32, 15);
      label7.TabIndex = 21;
      label7.Text = "/ szt.";
      // 
      // lbSuma
      // 
      lbSuma.AutoSize = true;
      lbSuma.Location = new Point(12, 329);
      lbSuma.Name = "lbSuma";
      lbSuma.Size = new Size(40, 15);
      lbSuma.TabIndex = 22;
      lbSuma.Text = "Suma:";
      lbSuma.Visible = false;
      // 
      // lbTotalSum
      // 
      lbTotalSum.AutoSize = true;
      lbTotalSum.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
      lbTotalSum.Location = new Point(47, 329);
      lbTotalSum.Name = "lbTotalSum";
      lbTotalSum.Size = new Size(85, 15);
      lbTotalSum.TabIndex = 23;
      lbTotalSum.Text = "<lbTotalSum>";
      lbTotalSum.Visible = false;
      // 
      // frmOrderEditor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(558, 362);
      Controls.Add(lbTotalSum);
      Controls.Add(lbSuma);
      Controls.Add(label7);
      Controls.Add(btnDeleteProduct);
      Controls.Add(dgvOrderedProducts);
      Controls.Add(btnAddProduct);
      Controls.Add(label6);
      Controls.Add(label5);
      Controls.Add(mtxtAmount);
      Controls.Add(mtxtPrice);
      Controls.Add(cbxProducts);
      Controls.Add(cbxClients);
      Controls.Add(label4);
      Controls.Add(btnCancel);
      Controls.Add(btnSubmit);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(txtOrderNumber);
      Controls.Add(dtpCreationDate);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      KeyPreview = true;
      Name = "frmOrderEditor";
      StartPosition = FormStartPosition.CenterParent;
      Text = "Dodaj / Edytuj zamówienie";
      KeyUp += frmOrderDetails_KeyUp;
      ((System.ComponentModel.ISupportInitialize)dgvOrderedProducts).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DateTimePicker dtpCreationDate;
    private TextBox txtOrderNumber;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button btnCancel;
    private Button btnSubmit;
    private Label label4;
    private ComboBox cbxClients;
    private ComboBox cbxProducts;
    private TextBox mtxtPrice;
    private TextBox mtxtAmount;
    private Label label5;
    private Label label6;
    private Button btnAddProduct;
    private DataGridView dgvOrderedProducts;
    private Button btnDeleteProduct;
    private Label label7;
    private Label lbSuma;
    private Label lbTotalSum;
  }
}
