namespace StakeCamp
{
    partial class editDecision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editDecision));
            this.buttonEditAdult = new System.Windows.Forms.Button();
            this.buttonEditCamper = new System.Windows.Forms.Button();
            this.buttonEditNest = new System.Windows.Forms.Button();
            this.buttonEditWards = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonEditAdult
            // 
            this.buttonEditAdult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditAdult.Location = new System.Drawing.Point(108, 98);
            this.buttonEditAdult.Name = "buttonEditAdult";
            this.buttonEditAdult.Size = new System.Drawing.Size(75, 23);
            this.buttonEditAdult.TabIndex = 0;
            this.buttonEditAdult.Text = "ADULT";
            this.buttonEditAdult.UseVisualStyleBackColor = true;
            this.buttonEditAdult.Click += new System.EventHandler(this.goeditAdult);
            // 
            // buttonEditCamper
            // 
            this.buttonEditCamper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCamper.Location = new System.Drawing.Point(108, 127);
            this.buttonEditCamper.Name = "buttonEditCamper";
            this.buttonEditCamper.Size = new System.Drawing.Size(75, 23);
            this.buttonEditCamper.TabIndex = 1;
            this.buttonEditCamper.Text = "CAMPER";
            this.buttonEditCamper.UseVisualStyleBackColor = true;
            this.buttonEditCamper.Click += new System.EventHandler(this.goeditCamper);
            // 
            // buttonEditNest
            // 
            this.buttonEditNest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditNest.Location = new System.Drawing.Point(108, 156);
            this.buttonEditNest.Name = "buttonEditNest";
            this.buttonEditNest.Size = new System.Drawing.Size(75, 23);
            this.buttonEditNest.TabIndex = 2;
            this.buttonEditNest.Text = "NESTS";
            this.buttonEditNest.UseVisualStyleBackColor = true;
            this.buttonEditNest.Click += new System.EventHandler(this.goeditNests);
            // 
            // buttonEditWards
            // 
            this.buttonEditWards.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditWards.Location = new System.Drawing.Point(108, 185);
            this.buttonEditWards.Name = "buttonEditWards";
            this.buttonEditWards.Size = new System.Drawing.Size(75, 23);
            this.buttonEditWards.TabIndex = 3;
            this.buttonEditWards.Text = "WARDS";
            this.buttonEditWards.UseVisualStyleBackColor = true;
            this.buttonEditWards.Click += new System.EventHandler(this.goeditWards);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "What would you like to edit?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(195, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Main Menu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMainMenu);
            // 
            // editDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 264);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEditWards);
            this.Controls.Add(this.buttonEditNest);
            this.Controls.Add(this.buttonEditCamper);
            this.Controls.Add(this.buttonEditAdult);
            this.Name = "editDecision";
            this.Text = "Edit Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEditAdult;
        private System.Windows.Forms.Button buttonEditCamper;
        private System.Windows.Forms.Button buttonEditNest;
        private System.Windows.Forms.Button buttonEditWards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}