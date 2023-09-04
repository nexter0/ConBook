namespace ConBook {
  partial class MainForm {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      btnContactsModule = new Button();
      btnProductsModule = new Button();
      lbSelectModule = new Label();
      label1 = new Label();
      SuspendLayout();
      // 
      // btnContactsModule
      // 
      btnContactsModule.Image = Properties.Resources.contactsModuleIcon;
      btnContactsModule.Location = new Point(30, 110);
      btnContactsModule.Name = "btnContactsModule";
      btnContactsModule.Size = new Size(130, 120);
      btnContactsModule.TabIndex = 0;
      btnContactsModule.Text = "Kontakty";
      btnContactsModule.TextAlign = ContentAlignment.BottomCenter;
      btnContactsModule.UseVisualStyleBackColor = true;
      btnContactsModule.Click += btnContactsModule_Click;
      // 
      // btnProductsModule
      // 
      btnProductsModule.Image = Properties.Resources.productsModuleIcon;
      btnProductsModule.Location = new Point(179, 110);
      btnProductsModule.Name = "btnProductsModule";
      btnProductsModule.Size = new Size(130, 120);
      btnProductsModule.TabIndex = 1;
      btnProductsModule.Text = "Towary";
      btnProductsModule.TextAlign = ContentAlignment.BottomCenter;
      btnProductsModule.UseVisualStyleBackColor = true;
      btnProductsModule.Click += btnProductsModule_Click;
      // 
      // lbSelectModule
      // 
      lbSelectModule.AutoSize = true;
      lbSelectModule.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
      lbSelectModule.Location = new Point(114, 46);
      lbSelectModule.Name = "lbSelectModule";
      lbSelectModule.Size = new Size(116, 21);
      lbSelectModule.TabIndex = 2;
      lbSelectModule.Text = "Wybierz moduł\r\n";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(105, 9);
      label1.Name = "label1";
      label1.Size = new Size(125, 37);
      label1.TabIndex = 3;
      label1.Text = "ConBook";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(334, 261);
      Controls.Add(label1);
      Controls.Add(lbSelectModule);
      Controls.Add(btnProductsModule);
      Controls.Add(btnContactsModule);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MaximizeBox = false;
      MinimizeBox = false;
      Name = "MainForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "ConBook";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button btnContactsModule;
    private Button btnProductsModule;
    private Label lbSelectModule;
    private Label label1;
  }
}
