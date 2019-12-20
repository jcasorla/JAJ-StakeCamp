namespace StakeCamp
{
    partial class addWard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addWard));
            this.linkUpdMainMenu = new System.Windows.Forms.LinkLabel();
            this.tbWardName = new System.Windows.Forms.TextBox();
            this.WardNameLable = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
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
            // tbWardName
            // 
            this.tbWardName.Location = new System.Drawing.Point(131, 102);
            this.tbWardName.Name = "tbWardName";
            this.tbWardName.Size = new System.Drawing.Size(100, 20);
            this.tbWardName.TabIndex = 11;
            // 
            // WardNameLable
            // 
            this.WardNameLable.AutoSize = true;
            this.WardNameLable.Location = new System.Drawing.Point(61, 102);
            this.WardNameLable.Name = "WardNameLable";
            this.WardNameLable.Size = new System.Drawing.Size(64, 13);
            this.WardNameLable.TabIndex = 13;
            this.WardNameLable.Text = "Ward Name";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(105, 157);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 14;
            this.buttonSubmit.Text = "SUBMIT";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(110, 10);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(87, 16);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Back To Add";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddDecFrom);
            // 
            // addWard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.WardNameLable);
            this.Controls.Add(this.tbWardName);
            this.Controls.Add(this.linkUpdMainMenu);
            this.Name = "addWard";
            this.Text = "Add Ward";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkUpdMainMenu;
        private System.Windows.Forms.TextBox tbWardName;
        private System.Windows.Forms.Label WardNameLable;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}