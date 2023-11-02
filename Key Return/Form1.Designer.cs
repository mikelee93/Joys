namespace Key_Return
{
    partial class Form1
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
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvKeyReturn = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFD = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyReturn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnImport.Location = new System.Drawing.Point(23, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(195, 57);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "IMPORT EXCEL";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvKeyReturn
            // 
            this.dgvKeyReturn.AllowUserToAddRows = false;
            this.dgvKeyReturn.BackgroundColor = System.Drawing.Color.White;
            this.dgvKeyReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvKeyReturn.Location = new System.Drawing.Point(0, 89);
            this.dgvKeyReturn.Name = "dgvKeyReturn";
            this.dgvKeyReturn.RowHeadersVisible = false;
            this.dgvKeyReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeyReturn.Size = new System.Drawing.Size(799, 364);
            this.dgvKeyReturn.TabIndex = 2;
            this.dgvKeyReturn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKeyReturn_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "ProductKeyId";
            this.Column1.Name = "Column1";
            this.Column1.Width = 96;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "ReturnCode";
            this.Column2.Name = "Column2";
            this.Column2.Width = 89;
            // 
            // openFD
            // 
            this.openFD.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvKeyReturn);
            this.Name = "Form1";
            this.Text = "Key Return ver 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyReturn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.DataGridView dgvKeyReturn;
        private System.Windows.Forms.OpenFileDialog openFD;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}

