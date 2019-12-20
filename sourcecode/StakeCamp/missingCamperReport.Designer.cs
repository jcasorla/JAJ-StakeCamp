namespace StakeCamp
{
    partial class missingCamperReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(missingCamperReport));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.missingCamperbtn = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.linklabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1175, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 17);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Main Menu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.goMainMenu);
            // 
            // missingCamperbtn
            // 
            this.missingCamperbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missingCamperbtn.Location = new System.Drawing.Point(529, 236);
            this.missingCamperbtn.Name = "missingCamperbtn";
            this.missingCamperbtn.Size = new System.Drawing.Size(208, 23);
            this.missingCamperbtn.TabIndex = 4;
            this.missingCamperbtn.Text = "EXPORT TO EXCEL";
            this.missingCamperbtn.UseVisualStyleBackColor = true;
            this.missingCamperbtn.Click += new System.EventHandler(this.missingCamperbtn_Click);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(12, 52);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(1240, 178);
            this.dg.TabIndex = 3;
            // 
            // linklabel2
            // 
            this.linklabel2.AutoSize = true;
            this.linklabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklabel2.Location = new System.Drawing.Point(1055, 9);
            this.linklabel2.Name = "linklabel2";
            this.linklabel2.Size = new System.Drawing.Size(114, 17);
            this.linklabel2.TabIndex = 18;
            this.linklabel2.TabStop = true;
            this.linklabel2.Text = "Back To Reports";
            this.linklabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.goReports);
            // 
            // missingCamperReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 264);
            this.Controls.Add(this.linklabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.missingCamperbtn);
            this.Controls.Add(this.dg);
            this.Name = "missingCamperReport";
            this.Text = "Campers Missing Forms / Payment";
            this.Load += new System.EventHandler(this.missingCamperReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button missingCamperbtn;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.LinkLabel linklabel2;
    }
}