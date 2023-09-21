namespace ConBook {
  partial class frmProductEditor {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductEditor));
      txtName = new TextBox();
      txtSymbol = new TextBox();
      txtPrice = new TextBox();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      btnSubmit = new Button();
      btnCancel = new Button();
      SuspendLayout();
      // 
      // txtName
      // 
      txtName.Location = new Point(12, 28);
      txtName.Name = "txtName";
      txtName.Size = new Size(329, 23);
      txtName.TabIndex = 0;
      // 
      // txtSymbol
      // 
      txtSymbol.Location = new Point(12, 70);
      txtSymbol.Name = "txtSymbol";
      txtSymbol.Size = new Size(100, 23);
      txtSymbol.TabIndex = 1;
      // 
      // txtPrice
      // 
      txtPrice.Location = new Point(12, 114);
      txtPrice.Name = "txtPrice";
      txtPrice.Size = new Size(100, 23);
      txtPrice.TabIndex = 2;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 10);
      label1.Name = "label1";
      label1.Size = new Size(42, 15);
      label1.TabIndex = 3;
      label1.Text = "Nazwa";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(12, 54);
      label2.Name = "label2";
      label2.Size = new Size(47, 15);
      label2.TabIndex = 4;
      label2.Text = "Symbol";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(12, 96);
      label3.Name = "label3";
      label3.Size = new Size(34, 15);
      label3.TabIndex = 5;
      label3.Text = "Cena";
      // 
      // btnSubmit
      // 
      btnSubmit.Location = new Point(266, 85);
      btnSubmit.Name = "btnSubmit";
      btnSubmit.Size = new Size(75, 23);
      btnSubmit.TabIndex = 6;
      btnSubmit.Text = "Dodaj";
      btnSubmit.UseVisualStyleBackColor = true;
      btnSubmit.Click += btnSubmit_Click;
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(266, 114);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Anuluj";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // frmProductEditor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(353, 149);
      Controls.Add(btnCancel);
      Controls.Add(btnSubmit);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(txtPrice);
      Controls.Add(txtSymbol);
      Controls.Add(txtName);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      KeyPreview = true;
      Name = "frmProductEditor";
      StartPosition = FormStartPosition.CenterParent;
      Text = "frmProductEditor";
      KeyUp += frmProductEditor_KeyUp;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtName;
    private TextBox txtSymbol;
    private TextBox txtPrice;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button btnSubmit;
    private Button btnCancel;
  }
}
