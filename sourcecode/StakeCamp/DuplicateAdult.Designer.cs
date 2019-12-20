namespace StakeCamp
{
    partial class DuplicateAdult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateAdult));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addAdultbtn = new System.Windows.Forms.Button();
            this.editLinkBtn = new System.Windows.Forms.Button();
            this.dg = new System.Windows.Forms.DataGridView();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkAMain = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // addAdultbtn
            // 
            this.addAdultbtn.Location = new System.Drawing.Point(204, 193);
            this.addAdultbtn.Name = "addAdultbtn";
            this.addAdultbtn.Size = new System.Drawing.Size(132, 23);
            this.addAdultbtn.TabIndex = 2;
            this.addAdultbtn.Text = "Add Record Anyway";
            this.addAdultbtn.UseVisualStyleBackColor = true;
            this.addAdultbtn.Click += new System.EventHandler(this.addAdultbtn_Click);
            // 
            // editLinkBtn
            // 
            this.editLinkBtn.Location = new System.Drawing.Point(387, 193);
            this.editLinkBtn.Name = "editLinkBtn";
            this.editLinkBtn.Size = new System.Drawing.Size(75, 23);
            this.editLinkBtn.TabIndex = 3;
            this.editLinkBtn.Text = "Go to Edit";
            this.editLinkBtn.UseVisualStyleBackColor = true;
            this.editLinkBtn.Click += new System.EventHandler(this.editLinkBtn_Click);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(33, 64);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(646, 110);
            this.dg.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(494, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 17);
            this.linkLabel1.TabIndex = 65;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Back To Add";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkAMain
            // 
            this.linkAMain.AutoSize = true;
            this.linkAMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAMain.Location = new System.Drawing.Point(602, 9);
            this.linkAMain.Name = "linkAMain";
            this.linkAMain.Size = new System.Drawing.Size(77, 17);
            this.linkAMain.TabIndex = 66;
            this.linkAMain.TabStop = true;
            this.linkAMain.Text = "Main Menu";
            this.linkAMain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAMain_LinkClicked);
            // 
            // DuplicateAdult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(708, 246);
            this.Controls.Add(this.linkAMain);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.editLinkBtn);
            this.Controls.Add(this.addAdultbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DuplicateAdult";
            this.Text = "Duplicate Adult Validation";
            this.Load += new System.EventHandler(this.DuplicateAdult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addAdultbtn;
        private System.Windows.Forms.Button editLinkBtn;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkAMain;
    }
}