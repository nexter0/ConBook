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
      dtpCreationDate = new DateTimePicker();
      txtOrderNumber = new TextBox();
      clbProductsSelection = new CheckedListBox();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      btnCancel = new Button();
      btnSubmit = new Button();
      clbContactsSelection = new CheckedListBox();
      label4 = new Label();
      SuspendLayout();
      // 
      // dtpCreationDate
      // 
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
      // clbProductsSelection
      // 
      clbProductsSelection.FormattingEnabled = true;
      clbProductsSelection.Location = new Point(11, 65);
      clbProductsSelection.Name = "clbProductsSelection";
      clbProductsSelection.Size = new Size(362, 256);
      clbProductsSelection.TabIndex = 2;
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
      label3.Size = new Size(44, 15);
      label3.TabIndex = 5;
      label3.Text = "Towary";
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(458, 327);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 9;
      btnCancel.Text = "Anuluj";
      btnCancel.UseVisualStyleBackColor = true;
      // 
      // btnSubmit
      // 
      btnSubmit.Location = new Point(377, 327);
      btnSubmit.Name = "btnSubmit";
      btnSubmit.Size = new Size(75, 23);
      btnSubmit.TabIndex = 8;
      btnSubmit.Text = "Dodaj";
      btnSubmit.UseVisualStyleBackColor = true;
      btnSubmit.Click += btnSubmit_Click;
      // 
      // clbContactsSelection
      // 
      clbContactsSelection.FormattingEnabled = true;
      clbContactsSelection.Location = new Point(379, 65);
      clbContactsSelection.Name = "clbContactsSelection";
      clbContactsSelection.Size = new Size(154, 256);
      clbContactsSelection.TabIndex = 10;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(379, 47);
      label4.Name = "label4";
      label4.Size = new Size(37, 15);
      label4.TabIndex = 11;
      label4.Text = "Klient";
      // 
      // frmOrderEditor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(545, 357);
      Controls.Add(label4);
      Controls.Add(clbContactsSelection);
      Controls.Add(btnCancel);
      Controls.Add(btnSubmit);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(clbProductsSelection);
      Controls.Add(txtOrderNumber);
      Controls.Add(dtpCreationDate);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Name = "frmOrderEditor";
      StartPosition = FormStartPosition.CenterParent;
      Text = "frmOrderEditor";
      Load += frmOrderEditor_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private DateTimePicker dtpCreationDate;
    private TextBox txtOrderNumber;
    private CheckedListBox clbProductsSelection;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button btnCancel;
    private Button btnSubmit;
    private CheckedListBox clbContactsSelection;
    private Label label4;
  }
}