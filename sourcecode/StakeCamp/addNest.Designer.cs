namespace StakeCamp
{
    partial class addNest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addNest));
            this.linkUpdMainMenu = new System.Windows.Forms.LinkLabel();
            this.nestNametbx = new System.Windows.Forms.TextBox();
            this.nestDescTbx = new System.Windows.Forms.TextBox();
            this.labelNestName = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkUpdMainMenu
            // 
            this.linkUpdMainMenu.AutoSize = true;
            this.linkUpdMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpdMainMenu.Location = new System.Drawing.Point(203, 9);
            this.linkUpdMainMenu.Name = "linkUpdMainMenu";
            this.linkUpdMainMenu.Size = new System.Drawing.Size(77, 17);
            this.linkUpdMainMenu.TabIndex = 9;
            this.linkUpdMainMenu.TabStop = true;
            this.linkUpdMainMenu.Text = "Main Menu";
            this.linkUpdMainMenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMainMenu);
            // 
            // nestNametbx
            // 
            this.nestNametbx.Location = new System.Drawing.Point(129, 89);
            this.nestNametbx.Name = "nestNametbx";
            this.nestNametbx.Size = new System.Drawing.Size(100, 20);
            this.nestNametbx.TabIndex = 10;
            // 
            // nestDescTbx
            // 
            this.nestDescTbx.Location = new System.Drawing.Point(129, 115);
            this.nestDescTbx.Name = "nestDescTbx";
            this.nestDescTbx.Size = new System.Drawing.Size(100, 20);
            this.nestDescTbx.TabIndex = 11;
            // 
            // labelNestName
            // 
            this.labelNestName.AutoSize = true;
            this.labelNestName.Location = new System.Drawing.Point(63, 89);
            this.labelNestName.Name = "labelNestName";
            this.labelNestName.Size = new System.Drawing.Size(60, 13);
            this.labelNestName.TabIndex = 13;
            this.labelNestName.Text = "Nest Name";
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Location = new System.Drawing.Point(63, 115);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(60, 13);
            this.labelDesc.TabIndex = 14;
            this.labelDesc.Text = "Description";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(109, 190);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 15;
            this.buttonSubmit.Text = "SUBMIT";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(106, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(89, 17);
            this.linkLabel2.TabIndex = 69;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Back To Add";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // addNest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(292, 225);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelNestName);
            this.Controls.Add(this.nestDescTbx);
            this.Controls.Add(this.nestNametbx);
            this.Controls.Add(this.linkUpdMainMenu);
            this.Name = "addNest";
            this.Text = "Create New Nest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkUpdMainMenu;
        private System.Windows.Forms.TextBox nestNametbx;
        private System.Windows.Forms.TextBox nestDescTbx;
        private System.Windows.Forms.Label labelNestName;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}