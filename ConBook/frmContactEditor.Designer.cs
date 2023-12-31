﻿namespace ConBook {
  partial class frmContactEditor {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContactEditor));
      lbName = new Label();
      txtName = new TextBox();
      txtSurname = new TextBox();
      lbSurname = new Label();
      txtPhone = new TextBox();
      lbPhone = new Label();
      btnSubmit = new Button();
      btnCancel = new Button();
      rtbDescription = new RichTextBox();
      lbDescription = new Label();
      rtbNotes = new RichTextBox();
      label1 = new Label();
      SuspendLayout();
      // 
      // lbName
      // 
      lbName.AutoSize = true;
      lbName.Location = new Point(12, 9);
      lbName.Name = "lbName";
      lbName.Size = new Size(30, 15);
      lbName.TabIndex = 0;
      lbName.Text = "Imię";
      // 
      // txtName
      // 
      txtName.Location = new Point(12, 27);
      txtName.Name = "txtName";
      txtName.Size = new Size(352, 23);
      txtName.TabIndex = 1;
      // 
      // txtSurname
      // 
      txtSurname.Location = new Point(12, 72);
      txtSurname.Name = "txtSurname";
      txtSurname.Size = new Size(352, 23);
      txtSurname.TabIndex = 3;
      // 
      // lbSurname
      // 
      lbSurname.AutoSize = true;
      lbSurname.Location = new Point(12, 54);
      lbSurname.Name = "lbSurname";
      lbSurname.Size = new Size(57, 15);
      lbSurname.TabIndex = 2;
      lbSurname.Text = "Nazwisko";
      // 
      // txtPhone
      // 
      txtPhone.Location = new Point(12, 116);
      txtPhone.Name = "txtPhone";
      txtPhone.Size = new Size(162, 23);
      txtPhone.TabIndex = 5;
      // 
      // lbPhone
      // 
      lbPhone.AutoSize = true;
      lbPhone.Location = new Point(12, 98);
      lbPhone.Name = "lbPhone";
      lbPhone.Size = new Size(45, 15);
      lbPhone.TabIndex = 4;
      lbPhone.Text = "Telefon";
      // 
      // btnSubmit
      // 
      btnSubmit.Location = new Point(330, 306);
      btnSubmit.Name = "btnSubmit";
      btnSubmit.Size = new Size(75, 23);
      btnSubmit.TabIndex = 6;
      btnSubmit.Text = "Dodaj";
      btnSubmit.UseVisualStyleBackColor = true;
      btnSubmit.Click += btnSubmit_Click;
      // 
      // btnCancel
      // 
      btnCancel.Location = new Point(330, 335);
      btnCancel.Name = "btnCancel";
      btnCancel.Size = new Size(75, 23);
      btnCancel.TabIndex = 7;
      btnCancel.Text = "Anuluj";
      btnCancel.UseVisualStyleBackColor = true;
      btnCancel.Click += btnCancel_Click;
      // 
      // rtbDescription
      // 
      rtbDescription.Location = new Point(12, 162);
      rtbDescription.Name = "rtbDescription";
      rtbDescription.Size = new Size(263, 88);
      rtbDescription.TabIndex = 8;
      rtbDescription.Text = "";
      // 
      // lbDescription
      // 
      lbDescription.AutoSize = true;
      lbDescription.Location = new Point(12, 144);
      lbDescription.Name = "lbDescription";
      lbDescription.Size = new Size(31, 15);
      lbDescription.TabIndex = 9;
      lbDescription.Text = "Opis";
      // 
      // rtbNotes
      // 
      rtbNotes.Location = new Point(12, 270);
      rtbNotes.Name = "rtbNotes";
      rtbNotes.Size = new Size(263, 88);
      rtbNotes.TabIndex = 10;
      rtbNotes.Text = "";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 253);
      label1.Name = "label1";
      label1.Size = new Size(46, 15);
      label1.TabIndex = 11;
      label1.Text = "Notatki";
      // 
      // frmContactEditor
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      CancelButton = btnCancel;
      ClientSize = new Size(412, 368);
      Controls.Add(label1);
      Controls.Add(rtbNotes);
      Controls.Add(lbDescription);
      Controls.Add(rtbDescription);
      Controls.Add(btnCancel);
      Controls.Add(btnSubmit);
      Controls.Add(txtPhone);
      Controls.Add(lbPhone);
      Controls.Add(txtSurname);
      Controls.Add(lbSurname);
      Controls.Add(txtName);
      Controls.Add(lbName);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      KeyPreview = true;
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "frmContactEditor";
      ShowInTaskbar = false;
      StartPosition = FormStartPosition.CenterParent;
      Text = "ConBook";
      KeyUp += frmContactEditor_KeyUp;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lbName;
    private TextBox txtName;
    private TextBox txtSurname;
    private Label lbSurname;
    private TextBox txtPhone;
    private Label lbPhone;
    private Button btnSubmit;
    private Button btnCancel;
    private RichTextBox rtbDescription;
    private Label lbDescription;
    private RichTextBox rtbNotes;
    private Label label1;
  }
}
