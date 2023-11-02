namespace iQor_inbound_T_insert
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
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateReceived = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTypename = new System.Windows.Forms.ComboBox();
            this.txtTrackingnum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.iQor_inbound = new System.Windows.Forms.DataGridView();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnreturnT = new System.Windows.Forms.Button();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRepairable = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReceivedD = new System.Windows.Forms.Button();
            this.dateToDate = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iQor_inbound)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(434, 68);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(75, 23);
            this.txtQty.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(430, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 24);
            this.label9.TabIndex = 48;
            this.label9.Text = "Qty";
            // 
            // dateReceived
            // 
            this.dateReceived.CustomFormat = "dd-MM-yyyy";
            this.dateReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateReceived.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateReceived.Location = new System.Drawing.Point(541, 68);
            this.dateReceived.Name = "dateReceived";
            this.dateReceived.Size = new System.Drawing.Size(102, 23);
            this.dateReceived.TabIndex = 42;
            this.dateReceived.Value = new System.DateTime(2023, 9, 25, 0, 0, 0, 0);
            this.dateReceived.ValueChanged += new System.EventHandler(this.dateReceived_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(569, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 24);
            this.label6.TabIndex = 41;
            this.label6.Text = "ReceivedDate";
            // 
            // cboTypename
            // 
            this.cboTypename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTypename.FormattingEnabled = true;
            this.cboTypename.Items.AddRange(new object[] {
            "ac/adapter",
            "VGA cable",
            "DVI cable",
            "HDMI cable",
            "displayport adaptor",
            "webcam",
            "headset",
            "network cable",
            "  "});
            this.cboTypename.Location = new System.Drawing.Point(32, 67);
            this.cboTypename.Name = "cboTypename";
            this.cboTypename.Size = new System.Drawing.Size(121, 24);
            this.cboTypename.TabIndex = 40;
            // 
            // txtTrackingnum
            // 
            this.txtTrackingnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrackingnum.Location = new System.Drawing.Point(175, 67);
            this.txtTrackingnum.Name = "txtTrackingnum";
            this.txtTrackingnum.Size = new System.Drawing.Size(175, 23);
            this.txtTrackingnum.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Typename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(176, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 24);
            this.label2.TabIndex = 33;
            this.label2.Text = "Trackingnumber";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(494, 241);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 45);
            this.btnReset.TabIndex = 32;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // iQor_inbound
            // 
            this.iQor_inbound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iQor_inbound.Location = new System.Drawing.Point(2, 319);
            this.iQor_inbound.Name = "iQor_inbound";
            this.iQor_inbound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iQor_inbound.Size = new System.Drawing.Size(939, 332);
            this.iQor_inbound.TabIndex = 53;
            this.iQor_inbound.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iQor_inbound_CellContentClick);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(159, 241);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(103, 45);
            this.btnInsert.TabIndex = 54;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnreturnT
            // 
            this.btnreturnT.Location = new System.Drawing.Point(356, 68);
            this.btnreturnT.Name = "btnreturnT";
            this.btnreturnT.Size = new System.Drawing.Size(56, 23);
            this.btnreturnT.TabIndex = 46;
            this.btnreturnT.Text = "Search";
            this.btnreturnT.UseVisualStyleBackColor = true;
            this.btnreturnT.Click += new System.EventHandler(this.btnreturnT_Click);
            // 
            // cboCondition
            // 
            this.cboCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "Good",
            "Damaged",
            "  "});
            this.cboCondition.Location = new System.Drawing.Point(32, 141);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(121, 24);
            this.cboCondition.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 55;
            this.label1.Text = "Condition";
            // 
            // cboRepairable
            // 
            this.cboRepairable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRepairable.FormattingEnabled = true;
            this.cboRepairable.Items.AddRange(new object[] {
            "Y",
            "N",
            "  "});
            this.cboRepairable.Location = new System.Drawing.Point(180, 141);
            this.cboRepairable.Name = "cboRepairable";
            this.cboRepairable.Size = new System.Drawing.Size(121, 24);
            this.cboRepairable.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(176, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 57;
            this.label4.Text = "Repairable";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(619, 241);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 45);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(288, 241);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 45);
            this.btnUpdate.TabIndex = 61;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReceivedD
            // 
            this.btnReceivedD.Location = new System.Drawing.Point(751, 64);
            this.btnReceivedD.Name = "btnReceivedD";
            this.btnReceivedD.Size = new System.Drawing.Size(56, 26);
            this.btnReceivedD.TabIndex = 62;
            this.btnReceivedD.Text = "Search";
            this.btnReceivedD.UseVisualStyleBackColor = true;
            this.btnReceivedD.Click += new System.EventHandler(this.btnReceivedD_Click);
            // 
            // dateToDate
            // 
            this.dateToDate.CustomFormat = "dd-MM-yyyy";
            this.dateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateToDate.Location = new System.Drawing.Point(649, 68);
            this.dateToDate.Name = "dateToDate";
            this.dateToDate.Size = new System.Drawing.Size(96, 23);
            this.dateToDate.TabIndex = 63;
            this.dateToDate.Value = new System.DateTime(2023, 9, 25, 0, 0, 0, 0);
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(742, 241);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(103, 45);
            this.btnExport.TabIndex = 64;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 653);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dateToDate);
            this.Controls.Add(this.btnReceivedD);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cboRepairable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboCondition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.iQor_inbound);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnreturnT);
            this.Controls.Add(this.dateReceived);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboTypename);
            this.Controls.Add(this.txtTrackingnum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Name = "Form1";
            this.Text = "iQor_inbound_T ver 1.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iQor_inbound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTypename;
        private System.Windows.Forms.TextBox txtTrackingnum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView iQor_inbound;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnreturnT;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRepairable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReceivedD;
        private System.Windows.Forms.DateTimePicker dateToDate;
        private System.Windows.Forms.Button btnExport;
    }
}

