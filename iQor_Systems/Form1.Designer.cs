namespace iQor_Systems
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotnum = new System.Windows.Forms.TextBox();
            this.iQor_System = new System.Windows.Forms.DataGridView();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtreturnT = new System.Windows.Forms.TextBox();
            this.txtSnum = new System.Windows.Forms.TextBox();
            this.txtreturnQ = new System.Windows.Forms.TextBox();
            this.cboCondition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRepairable = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnreturnT = new System.Windows.Forms.Button();
            this.btnSnum = new System.Windows.Forms.Button();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnLotnum = new System.Windows.Forms.Button();
            this.btnReturnD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iQor_System)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(373, 186);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(103, 45);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lotnumber";
            // 
            // txtLotnum
            // 
            this.txtLotnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotnum.Location = new System.Drawing.Point(12, 53);
            this.txtLotnum.Name = "txtLotnum";
            this.txtLotnum.Size = new System.Drawing.Size(120, 23);
            this.txtLotnum.TabIndex = 2;
            // 
            // iQor_System
            // 
            this.iQor_System.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.iQor_System.Location = new System.Drawing.Point(0, 256);
            this.iQor_System.Name = "iQor_System";
            this.iQor_System.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.iQor_System.Size = new System.Drawing.Size(1215, 352);
            this.iQor_System.TabIndex = 3;
            this.iQor_System.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.iQor_System_CellClick);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(501, 186);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 45);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(309, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "ReturnTracking";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(208, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Snum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Condition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "ReturnQty";
            // 
            // txtreturnT
            // 
            this.txtreturnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnT.Location = new System.Drawing.Point(313, 131);
            this.txtreturnT.Name = "txtreturnT";
            this.txtreturnT.Size = new System.Drawing.Size(175, 23);
            this.txtreturnT.TabIndex = 9;
            // 
            // txtSnum
            // 
            this.txtSnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSnum.Location = new System.Drawing.Point(208, 53);
            this.txtSnum.Name = "txtSnum";
            this.txtSnum.Size = new System.Drawing.Size(110, 23);
            this.txtSnum.TabIndex = 10;
            // 
            // txtreturnQ
            // 
            this.txtreturnQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnQ.Location = new System.Drawing.Point(12, 129);
            this.txtreturnQ.Name = "txtreturnQ";
            this.txtreturnQ.Size = new System.Drawing.Size(120, 23);
            this.txtreturnQ.TabIndex = 11;
            // 
            // cboCondition
            // 
            this.cboCondition.FormattingEnabled = true;
            this.cboCondition.Items.AddRange(new object[] {
            "Damaged",
            "Good",
            "Missing Base",
            "Missing stand",
            "  "});
            this.cboCondition.Location = new System.Drawing.Point(168, 131);
            this.cboCondition.Name = "cboCondition";
            this.cboCondition.Size = new System.Drawing.Size(121, 21);
            this.cboCondition.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "ReturnedDate";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 195);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 23);
            this.dateTimePicker1.TabIndex = 14;
            this.dateTimePicker1.Value = new System.DateTime(2023, 9, 26, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(214, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Repairable";
            // 
            // cboRepairable
            // 
            this.cboRepairable.FormattingEnabled = true;
            this.cboRepairable.Items.AddRange(new object[] {
            "Y",
            "N",
            "  "});
            this.cboRepairable.Location = new System.Drawing.Point(218, 195);
            this.cboRepairable.Name = "cboRepairable";
            this.cboRepairable.Size = new System.Drawing.Size(107, 21);
            this.cboRepairable.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(673, 47);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 29);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnreturnT
            // 
            this.btnreturnT.Location = new System.Drawing.Point(494, 131);
            this.btnreturnT.Name = "btnreturnT";
            this.btnreturnT.Size = new System.Drawing.Size(56, 23);
            this.btnreturnT.TabIndex = 20;
            this.btnreturnT.Text = "Search";
            this.btnreturnT.UseVisualStyleBackColor = true;
            this.btnreturnT.Click += new System.EventHandler(this.btnreturnT_Click);
            // 
            // btnSnum
            // 
            this.btnSnum.Location = new System.Drawing.Point(324, 53);
            this.btnSnum.Name = "btnSnum";
            this.btnSnum.Size = new System.Drawing.Size(54, 23);
            this.btnSnum.TabIndex = 21;
            this.btnSnum.Text = "Search";
            this.btnSnum.UseVisualStyleBackColor = true;
            this.btnSnum.Click += new System.EventHandler(this.btnSnum_Click);
            // 
            // txtLname
            // 
            this.txtLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLname.Location = new System.Drawing.Point(548, 53);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(110, 23);
            this.txtLname.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(548, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 24);
            this.label8.TabIndex = 24;
            this.label8.Text = "Lname";
            // 
            // txtFname
            // 
            this.txtFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(405, 53);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(120, 23);
            this.txtFname.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(401, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 24);
            this.label9.TabIndex = 22;
            this.label9.Text = "Fname";
            // 
            // btnLotnum
            // 
            this.btnLotnum.Location = new System.Drawing.Point(138, 53);
            this.btnLotnum.Name = "btnLotnum";
            this.btnLotnum.Size = new System.Drawing.Size(52, 23);
            this.btnLotnum.TabIndex = 28;
            this.btnLotnum.Text = "Search";
            this.btnLotnum.UseVisualStyleBackColor = true;
            this.btnLotnum.Click += new System.EventHandler(this.btnLotnum_Click);
            // 
            // btnReturnD
            // 
            this.btnReturnD.Location = new System.Drawing.Point(145, 195);
            this.btnReturnD.Name = "btnReturnD";
            this.btnReturnD.Size = new System.Drawing.Size(54, 23);
            this.btnReturnD.TabIndex = 29;
            this.btnReturnD.Text = "Search";
            this.btnReturnD.UseVisualStyleBackColor = true;
            this.btnReturnD.Click += new System.EventHandler(this.btnReturnD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1219, 609);
            this.Controls.Add(this.btnReturnD);
            this.Controls.Add(this.btnLotnum);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSnum);
            this.Controls.Add(this.btnreturnT);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboRepairable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCondition);
            this.Controls.Add(this.txtreturnQ);
            this.Controls.Add(this.txtSnum);
            this.Controls.Add(this.txtreturnT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.iQor_System);
            this.Controls.Add(this.txtLotnum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "iQor_System ver 1.2.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iQor_System)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLotnum;
        private System.Windows.Forms.DataGridView iQor_System;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtreturnT;
        private System.Windows.Forms.TextBox txtSnum;
        private System.Windows.Forms.TextBox txtreturnQ;
        private System.Windows.Forms.ComboBox cboCondition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRepairable;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnreturnT;
        private System.Windows.Forms.Button btnSnum;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnLotnum;
        private System.Windows.Forms.Button btnReturnD;
    }
}

