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
      btnOrdersModule = new Button();
      toolStrip1 = new ToolStrip();
      tsbCreateDataBase = new ToolStripButton();
      lbDataBaseStatus = new Label();
      toolStrip1.SuspendLayout();
      SuspendLayout();
      // 
      // btnContactsModule
      // 
      btnContactsModule.Image = Properties.Resources.contactsModuleButtonImg;
      btnContactsModule.Location = new Point(30, 168);
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
      btnProductsModule.Image = Properties.Resources.productsModuleButtonImg;
      btnProductsModule.Location = new Point(179, 168);
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
      lbSelectModule.Location = new Point(193, 104);
      lbSelectModule.Name = "lbSelectModule";
      lbSelectModule.Size = new Size(116, 21);
      lbSelectModule.TabIndex = 2;
      lbSelectModule.Text = "Wybierz moduł\r\n";
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
      label1.Location = new Point(188, 67);
      label1.Name = "label1";
      label1.Size = new Size(125, 37);
      label1.TabIndex = 3;
      label1.Text = "ConBook";
      // 
      // btnOrdersModule
      // 
      btnOrdersModule.Image = Properties.Resources.ordersModuleButtonImg;
      btnOrdersModule.Location = new Point(329, 168);
      btnOrdersModule.Name = "btnOrdersModule";
      btnOrdersModule.Size = new Size(130, 120);
      btnOrdersModule.TabIndex = 4;
      btnOrdersModule.Text = "Zamówienia";
      btnOrdersModule.TextAlign = ContentAlignment.BottomCenter;
      btnOrdersModule.UseVisualStyleBackColor = true;
      btnOrdersModule.Click += btnOrdersModule_Click;
      // 
      // toolStrip1
      // 
      toolStrip1.Items.AddRange(new ToolStripItem[] { tsbCreateDataBase });
      toolStrip1.Location = new Point(0, 0);
      toolStrip1.Name = "toolStrip1";
      toolStrip1.Size = new Size(494, 25);
      toolStrip1.TabIndex = 5;
      toolStrip1.Text = "toolStrip1";
      // 
      // tsbCreateDataBase
      // 
      tsbCreateDataBase.DisplayStyle = ToolStripItemDisplayStyle.Image;
      tsbCreateDataBase.Image = (Image)resources.GetObject("tsbCreateDataBase.Image");
      tsbCreateDataBase.ImageTransparentColor = Color.Magenta;
      tsbCreateDataBase.Name = "tsbCreateDataBase";
      tsbCreateDataBase.Size = new Size(23, 22);
      tsbCreateDataBase.Text = "tsbCreateDataBase";
      tsbCreateDataBase.ToolTipText = "Utwórz bazę danych";
      tsbCreateDataBase.Click += tsbCreateDataBase_Click;
      // 
      // lbDataBaseStatus
      // 
      lbDataBaseStatus.Location = new Point(0, 25);
      lbDataBaseStatus.Name = "lbDataBaseStatus";
      lbDataBaseStatus.Size = new Size(470, 37);
      lbDataBaseStatus.TabIndex = 6;
      lbDataBaseStatus.Text = "lbDataBaseStatus";
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(494, 307);
      Controls.Add(lbDataBaseStatus);
      Controls.Add(toolStrip1);
      Controls.Add(btnOrdersModule);
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
      toolStrip1.ResumeLayout(false);
      toolStrip1.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button btnContactsModule;
    private Button btnProductsModule;
    private Label lbSelectModule;
    private Label label1;
    private Button btnOrdersModule;
    private ToolStrip toolStrip1;
    private ToolStripButton tsbCreateDataBase;
    private Label lbDataBaseStatus;
  }
}
