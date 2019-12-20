using System;

namespace StakeCamp
{
    partial class addDecision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null; ******test*******

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected void override Dispose(bool disposing)      *****test*********
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addDecision));
            this.btnCamper = new System.Windows.Forms.Button();
            this.btnAdult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonWards = new System.Windows.Forms.Button();
            this.buttonNests = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnTrans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCamper
            // 
            this.btnCamper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamper.Location = new System.Drawing.Point(77, 112);
            this.btnCamper.Name = "btnCamper";
            this.btnCamper.Size = new System.Drawing.Size(131, 23);
            this.btnCamper.TabIndex = 0;
            this.btnCamper.Text = "CAMPER";
            this.btnCamper.UseVisualStyleBackColor = true;
            this.btnCamper.Click += new System.EventHandler(this.goaddCamperForm);
            // 
            // btnAdult
            // 
            this.btnAdult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdult.Location = new System.Drawing.Point(77, 83);
            this.btnAdult.Name = "btnAdult";
            this.btnAdult.Size = new System.Drawing.Size(131, 23);
            this.btnAdult.TabIndex = 1;
            this.btnAdult.Text = "ADULT";
            this.btnAdult.UseVisualStyleBackColor = true;
            this.btnAdult.Click += new System.EventHandler(this.goaddAdultForm);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "What would you like to add?";
            // 
            // buttonWards
            // 
            this.buttonWards.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWards.Location = new System.Drawing.Point(77, 199);
            this.buttonWards.Name = "buttonWards";
            this.buttonWards.Size = new System.Drawing.Size(131, 23);
            this.buttonWards.TabIndex = 5;
            this.buttonWards.Text = "WARDS";
            this.buttonWards.UseVisualStyleBackColor = true;
            this.buttonWards.Click += new System.EventHandler(this.buttonWards_Click);
            // 
            // buttonNests
            // 
            this.buttonNests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNests.Location = new System.Drawing.Point(77, 141);
            this.buttonNests.Name = "buttonNests";
            this.buttonNests.Size = new System.Drawing.Size(131, 23);
            this.buttonNests.TabIndex = 6;
            this.buttonNests.Text = "NESTS";
            this.buttonNests.UseVisualStyleBackColor = true;
            this.buttonNests.Click += new System.EventHandler(this.gonestDecision);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(195, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 17);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Main Menu";
            this.linkLabel1.Click += new System.EventHandler(this.goMainMenu);
            // 
            // btnTrans
            // 
            this.btnTrans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrans.Location = new System.Drawing.Point(77, 170);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(131, 23);
            this.btnTrans.TabIndex = 8;
            this.btnTrans.Text = "TRANSPORTATION";
            this.btnTrans.UseVisualStyleBackColor = true;
            this.btnTrans.Click += new System.EventHandler(this.gotransportDecisionForm);
            // 
            // addDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonNests);
            this.Controls.Add(this.buttonWards);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdult);
            this.Controls.Add(this.btnCamper);
            this.Name = "addDecision";
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCamper;
        private System.Windows.Forms.Button btnAdult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonWards;
        private System.Windows.Forms.Button buttonNests;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnTrans;
    }
}

