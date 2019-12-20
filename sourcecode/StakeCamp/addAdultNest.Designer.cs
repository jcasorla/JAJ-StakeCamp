namespace StakeCamp
{
    partial class addAdultNest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addAdultNest));
            this.dg = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cbNest = new System.Windows.Forms.ComboBox();
            this.AssingNestButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dg.Location = new System.Drawing.Point(12, 49);
            this.dg.Name = "dg";
            this.dg.Size = new System.Drawing.Size(443, 150);
            this.dg.TabIndex = 0;
            this.dg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_CellContentClick);
            // 
            // Select
            // 
            this.Select.FalseValue = "No";
            this.Select.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Select.HeaderText = "Select";
            this.Select.IndeterminateValue = "what";
            this.Select.Name = "Select";
            this.Select.ToolTipText = "test";
            this.Select.TrueValue = "Yes";
            // 
            // cbNest
            // 
            this.cbNest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNest.FormattingEnabled = true;
            this.cbNest.Location = new System.Drawing.Point(174, 205);
            this.cbNest.Name = "cbNest";
            this.cbNest.Size = new System.Drawing.Size(121, 21);
            this.cbNest.TabIndex = 1;
            // 
            // AssingNestButton
            // 
            this.AssingNestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssingNestButton.Location = new System.Drawing.Point(198, 232);
            this.AssingNestButton.Name = "AssingNestButton";
            this.AssingNestButton.Size = new System.Drawing.Size(75, 23);
            this.AssingNestButton.TabIndex = 2;
            this.AssingNestButton.Text = "ASSIGN";
            this.AssingNestButton.UseVisualStyleBackColor = true;
            this.AssingNestButton.Click += new System.EventHandler(this.AssingNestButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(380, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 17);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Main Menu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMainMenu);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(285, 9);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(89, 17);
            this.linkLabel2.TabIndex = 68;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Back To Add";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // addAdultNest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(467, 293);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.AssingNestButton);
            this.Controls.Add(this.cbNest);
            this.Controls.Add(this.dg);
            this.Name = "addAdultNest";
            this.Text = "Add Adult Nest";
            this.Load += new System.EventHandler(this.AdultNest_load);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.ComboBox cbNest;
        private System.Windows.Forms.Button AssingNestButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
    }
}