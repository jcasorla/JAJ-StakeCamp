﻿namespace StakeCamp
{
    partial class nestAdultsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(nestAdultsReport));
            this.dg = new System.Windows.Forms.DataGridView();
            this.nestAdultbtn = new System.Windows.Forms.Button();
            this.linklabel2 = new System.Windows.Forms.LinkLabel();
            this.linkUpdMainMenu = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Location = new System.Drawing.Point(12, 47);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.Size = new System.Drawing.Size(740, 178);
            this.dg.TabIndex = 0;
            // 
            // nestAdultbtn
            // 
            this.nestAdultbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nestAdultbtn.Location = new System.Drawing.Point(278, 231);
            this.nestAdultbtn.Name = "nestAdultbtn";
            this.nestAdultbtn.Size = new System.Drawing.Size(208, 23);
            this.nestAdultbtn.TabIndex = 1;
            this.nestAdultbtn.Text = "EXPORT TO EXCEL";
            this.nestAdultbtn.UseVisualStyleBackColor = true;
            this.nestAdultbtn.Click += new System.EventHandler(this.nestAdultbtn_Click);
            // 
            // linklabel2
            // 
            this.linklabel2.AutoSize = true;
            this.linklabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklabel2.Location = new System.Drawing.Point(555, 9);
            this.linklabel2.Name = "linklabel2";
            this.linklabel2.Size = new System.Drawing.Size(114, 17);
            this.linklabel2.TabIndex = 29;
            this.linklabel2.TabStop = true;
            this.linklabel2.Text = "Back To Reports";
            this.linklabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel2_LinkClicked);
            // 
            // linkUpdMainMenu
            // 
            this.linkUpdMainMenu.AutoSize = true;
            this.linkUpdMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpdMainMenu.Location = new System.Drawing.Point(675, 9);
            this.linkUpdMainMenu.Name = "linkUpdMainMenu";
            this.linkUpdMainMenu.Size = new System.Drawing.Size(77, 17);
            this.linkUpdMainMenu.TabIndex = 28;
            this.linkUpdMainMenu.TabStop = true;
            this.linkUpdMainMenu.Text = "Main Menu";
            this.linkUpdMainMenu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUpdMainMenu_LinkClicked);
            // 
            // nestAdultsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 272);
            this.Controls.Add(this.linklabel2);
            this.Controls.Add(this.linkUpdMainMenu);
            this.Controls.Add(this.nestAdultbtn);
            this.Controls.Add(this.dg);
            this.Name = "nestAdultsReport";
            this.Text = "Adults Nest Report";
            this.Load += new System.EventHandler(this.nestAdultsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button nestAdultbtn;
        private System.Windows.Forms.LinkLabel linklabel2;
        private System.Windows.Forms.LinkLabel linkUpdMainMenu;
    }
}