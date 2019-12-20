namespace StakeCamp
{
    partial class EditCamperForm
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
            this.components = new System.ComponentModel.Container();
            this.tbUpdateYear = new System.Windows.Forms.TextBox();
            this.YearDecision = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.linkUpdMainMenu = new System.Windows.Forms.LinkLabel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.girlsCampDataSet = new StakeCamp.girlsCampDataSet();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter = new StakeCamp.girlsCampDataSetTableAdapters.customersTableAdapter();
            this.tableAdapterManager = new StakeCamp.girlsCampDataSetTableAdapters.TableAdapterManager();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homePhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zipCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wardidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicalidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.girlsCampDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbUpdateYear
            // 
            this.tbUpdateYear.Location = new System.Drawing.Point(308, 91);
            this.tbUpdateYear.Name = "tbUpdateYear";
            this.tbUpdateYear.Size = new System.Drawing.Size(100, 20);
            this.tbUpdateYear.TabIndex = 1;
            // 
            // YearDecision
            // 
            this.YearDecision.AutoSize = true;
            this.YearDecision.Location = new System.Drawing.Point(305, 75);
            this.YearDecision.Name = "YearDecision";
            this.YearDecision.Size = new System.Drawing.Size(29, 13);
            this.YearDecision.TabIndex = 2;
            this.YearDecision.Text = "Year";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(609, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // linkUpdMainMenu
            // 
            this.linkUpdMainMenu.AutoSize = true;
            this.linkUpdMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkUpdMainMenu.Location = new System.Drawing.Point(1095, 9);
            this.linkUpdMainMenu.Name = "linkUpdMainMenu";
            this.linkUpdMainMenu.Size = new System.Drawing.Size(77, 17);
            this.linkUpdMainMenu.TabIndex = 7;
            this.linkUpdMainMenu.TabStop = true;
            this.linkUpdMainMenu.Text = "Main Menu";
            this.linkUpdMainMenu.Click += new System.EventHandler(this.linkMainMenu);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(518, 462);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerDataGridViewTextBoxColumn,
            this.lastnameDataGridViewTextBoxColumn,
            this.firstnameDataGridViewTextBoxColumn,
            this.homePhoneDataGridViewTextBoxColumn,
            this.cellPhoneDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.zipCodeDataGridViewTextBoxColumn,
            this.birthDateDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.wardidDataGridViewTextBoxColumn,
            this.medicalidDataGridViewTextBoxColumn,
            this.contactidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.customersBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(43, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1129, 304);
            this.dataGridView1.TabIndex = 10;
            // 
            // girlsCampDataSet
            // 
            this.girlsCampDataSet.DataSetName = "girlsCampDataSet";
            this.girlsCampDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "customers";
            this.customersBindingSource.DataSource = this.girlsCampDataSet;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.adult_assingments_linkTableAdapter = null;
            this.tableAdapterManager.adult_nest_linkTableAdapter = null;
            this.tableAdapterManager.adultsTableAdapter = null;
            this.tableAdapterManager.allergyTableAdapter = null;
            this.tableAdapterManager.assingmentsTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.contactTableAdapter = null;
            this.tableAdapterManager.customer_level_linkTableAdapter = null;
            this.tableAdapterManager.customersTableAdapter = this.customersTableAdapter;
            this.tableAdapterManager.emergency_contactTableAdapter = null;
            this.tableAdapterManager.enrollmentTableAdapter = null;
            this.tableAdapterManager.girl_nest_linkTableAdapter = null;
            this.tableAdapterManager.guardiansTableAdapter = null;
            this.tableAdapterManager.levelsTableAdapter = null;
            this.tableAdapterManager.limitationsTableAdapter = null;
            this.tableAdapterManager.medicalTableAdapter = null;
            this.tableAdapterManager.medicationsTableAdapter = null;
            this.tableAdapterManager.nestsTableAdapter = null;
            this.tableAdapterManager.transportation_customer_linkTableAdapter = null;
            this.tableAdapterManager.transportationTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = StakeCamp.girlsCampDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.wardsTableAdapter = null;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer#";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Customer#";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            // 
            // lastnameDataGridViewTextBoxColumn
            // 
            this.lastnameDataGridViewTextBoxColumn.DataPropertyName = "Last_name";
            this.lastnameDataGridViewTextBoxColumn.HeaderText = "Last_name";
            this.lastnameDataGridViewTextBoxColumn.Name = "lastnameDataGridViewTextBoxColumn";
            // 
            // firstnameDataGridViewTextBoxColumn
            // 
            this.firstnameDataGridViewTextBoxColumn.DataPropertyName = "First_name";
            this.firstnameDataGridViewTextBoxColumn.HeaderText = "First_name";
            this.firstnameDataGridViewTextBoxColumn.Name = "firstnameDataGridViewTextBoxColumn";
            // 
            // homePhoneDataGridViewTextBoxColumn
            // 
            this.homePhoneDataGridViewTextBoxColumn.DataPropertyName = "Home_Phone";
            this.homePhoneDataGridViewTextBoxColumn.HeaderText = "Home_Phone";
            this.homePhoneDataGridViewTextBoxColumn.Name = "homePhoneDataGridViewTextBoxColumn";
            // 
            // cellPhoneDataGridViewTextBoxColumn
            // 
            this.cellPhoneDataGridViewTextBoxColumn.DataPropertyName = "Cell_Phone";
            this.cellPhoneDataGridViewTextBoxColumn.HeaderText = "Cell_Phone";
            this.cellPhoneDataGridViewTextBoxColumn.Name = "cellPhoneDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "City";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            // 
            // zipCodeDataGridViewTextBoxColumn
            // 
            this.zipCodeDataGridViewTextBoxColumn.DataPropertyName = "Zip_Code";
            this.zipCodeDataGridViewTextBoxColumn.HeaderText = "Zip_Code";
            this.zipCodeDataGridViewTextBoxColumn.Name = "zipCodeDataGridViewTextBoxColumn";
            // 
            // birthDateDataGridViewTextBoxColumn
            // 
            this.birthDateDataGridViewTextBoxColumn.DataPropertyName = "Birth_Date";
            this.birthDateDataGridViewTextBoxColumn.HeaderText = "Birth_Date";
            this.birthDateDataGridViewTextBoxColumn.Name = "birthDateDataGridViewTextBoxColumn";
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "Level";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            // 
            // wardidDataGridViewTextBoxColumn
            // 
            this.wardidDataGridViewTextBoxColumn.DataPropertyName = "Ward_id";
            this.wardidDataGridViewTextBoxColumn.HeaderText = "Ward_id";
            this.wardidDataGridViewTextBoxColumn.Name = "wardidDataGridViewTextBoxColumn";
            // 
            // medicalidDataGridViewTextBoxColumn
            // 
            this.medicalidDataGridViewTextBoxColumn.DataPropertyName = "Medical_id";
            this.medicalidDataGridViewTextBoxColumn.HeaderText = "Medical_id";
            this.medicalidDataGridViewTextBoxColumn.Name = "medicalidDataGridViewTextBoxColumn";
            // 
            // contactidDataGridViewTextBoxColumn
            // 
            this.contactidDataGridViewTextBoxColumn.DataPropertyName = "contact_id";
            this.contactidDataGridViewTextBoxColumn.HeaderText = "contact_id";
            this.contactidDataGridViewTextBoxColumn.Name = "contactidDataGridViewTextBoxColumn";
            // 
            // EditCamperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 509);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.linkUpdMainMenu);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.YearDecision);
            this.Controls.Add(this.tbUpdateYear);
            this.Name = "EditCamperForm";
            this.Text = "Edit Camper Form";
            this.Load += new System.EventHandler(this.updateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.girlsCampDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUpdateYear;
        private System.Windows.Forms.Label YearDecision;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.LinkLabel linkUpdMainMenu;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private girlsCampDataSet girlsCampDataSet;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private StakeCamp.girlsCampDataSetTableAdapters.customersTableAdapter customersTableAdapter;
        private StakeCamp.girlsCampDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homePhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wardidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicalidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactidDataGridViewTextBoxColumn;
    }
}

