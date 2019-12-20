namespace StakeCamp
{
    partial class transCamper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(transCamper));
            this.AssginTranBt = new System.Windows.Forms.Button();
            this.linkMain = new System.Windows.Forms.LinkLabel();
            this.dg = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TransportCB = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // AssginTranBt
            // 
            this.AssginTranBt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssginTranBt.Location = new System.Drawing.Point(202, 228);
            this.AssginTranBt.Name = "AssginTranBt";
            this.AssginTranBt.Size = new System.Drawing.Size(75, 23);
            this.AssginTranBt.TabIndex = 0;
            this.AssginTranBt.Text = "ASSIGN";
            this.AssginTranBt.UseVisualStyleBackColor = true;
            this.AssginTranBt.Click += new System.EventHandler(this.AssginTranBt_Click);
            // 
            // linkMain
            // 
            this.linkMain.AutoSize = true;
            this.linkMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkMain.Location = new System.Drawing.Point(385, 9);
            this.linkMain.Name = "linkMain";
            this.linkMain.Size = new System.Drawing.Size(77, 17);
            this.linkMain.TabIndex = 50;
            this.linkMain.TabStop = true;
            this.linkMain.Text = "Main Menu";
            this.linkMain.Click += new System.EventHandler(this.linkMainMenu);
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dg.Location = new System.Drawing.Point(12, 45);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(450, 150);
            this.dg.TabIndex = 51;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(290, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(89, 17);
            this.linkLabel1.TabIndex = 52;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Back To Add";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddDecForm);
            // 
            // TransportCB
            // 
            this.TransportCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TransportCB.FormattingEnabled = true;
            this.TransportCB.Location = new System.Drawing.Point(177, 201);
            this.TransportCB.Name = "TransportCB";
            this.TransportCB.Size = new System.Drawing.Size(121, 21);
            this.TransportCB.TabIndex = 53;
            // 
            // transCamper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(474, 264);
            this.Controls.Add(this.TransportCB);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.dg);
            this.Controls.Add(this.linkMain);
            this.Controls.Add(this.AssginTranBt);
            this.Name = "transCamper";
            this.Text = "Transportation";
            this.Load += new System.EventHandler(this.girlTransport_load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AssginTranBt;
        private System.Windows.Forms.LinkLabel linkMain;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.ComboBox TransportCB;
    }
}

