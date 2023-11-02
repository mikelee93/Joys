namespace iQor_System
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLotnum = new System.Windows.Forms.TextBox();
            this.dgvupdate = new System.Windows.Forms.Button();
            this.dgviQorSystem = new System.Windows.Forms.DataGridView();
            this.btnLotnumber = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSnum = new System.Windows.Forms.Button();
            this.btnReturnT = new System.Windows.Forms.Button();
            this.txtReturnT = new System.Windows.Forms.TextBox();
            this.txtSnum = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtreturnQty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cborepairable = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbocondition = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgviQorSystem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "lotnumber";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(303, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "snum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(564, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "returnTracking";
            // 
            // txtLotnum
            // 
            this.txtLotnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotnum.Location = new System.Drawing.Point(12, 50);
            this.txtLotnum.Name = "txtLotnum";
            this.txtLotnum.Size = new System.Drawing.Size(189, 23);
            this.txtLotnum.TabIndex = 4;
            this.txtLotnum.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvupdate
            // 
            this.dgvupdate.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgvupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvupdate.Location = new System.Drawing.Point(355, 183);
            this.dgvupdate.Name = "dgvupdate";
            this.dgvupdate.Size = new System.Drawing.Size(101, 47);
            this.dgvupdate.TabIndex = 7;
            this.dgvupdate.Text = "Update";
            this.dgvupdate.UseVisualStyleBackColor = false;
            this.dgvupdate.Click += new System.EventHandler(this.dgvupdate_Click);
            // 
            // dgviQorSystem
            // 
            this.dgviQorSystem.AllowUserToAddRows = false;
            this.dgviQorSystem.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgviQorSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviQorSystem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgviQorSystem.Location = new System.Drawing.Point(4, 249);
            this.dgviQorSystem.Name = "dgviQorSystem";
            this.dgviQorSystem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgviQorSystem.Size = new System.Drawing.Size(793, 201);
            this.dgviQorSystem.TabIndex = 8;

            // 
            // btnLotnumber
            // 
            this.btnLotnumber.Location = new System.Drawing.Point(207, 50);
            this.btnLotnumber.Name = "btnLotnumber";
            this.btnLotnumber.Size = new System.Drawing.Size(59, 23);
            this.btnLotnumber.TabIndex = 10;
            this.btnLotnumber.Text = "Search";
            this.btnLotnumber.UseVisualStyleBackColor = true;
            this.btnLotnumber.Click += new System.EventHandler(this.btnLotnumber_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "1.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(541, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "3.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(283, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "2.";
            // 
            // btnSnum
            // 
            this.btnSnum.Location = new System.Drawing.Point(477, 50);
            this.btnSnum.Name = "btnSnum";
            this.btnSnum.Size = new System.Drawing.Size(59, 23);
            this.btnSnum.TabIndex = 16;
            this.btnSnum.Text = "Search";
            this.btnSnum.UseVisualStyleBackColor = true;
            this.btnSnum.Click += new System.EventHandler(this.btnSnum_Click);
            // 
            // btnReturnT
            // 
            this.btnReturnT.Location = new System.Drawing.Point(738, 50);
            this.btnReturnT.Name = "btnReturnT";
            this.btnReturnT.Size = new System.Drawing.Size(59, 23);
            this.btnReturnT.TabIndex = 17;
            this.btnReturnT.Text = "Search";
            this.btnReturnT.UseVisualStyleBackColor = true;
            this.btnReturnT.Click += new System.EventHandler(this.btnReturnT_Click);
            // 
            // txtReturnT
            // 
            this.txtReturnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReturnT.Location = new System.Drawing.Point(543, 50);
            this.txtReturnT.Name = "txtReturnT";
            this.txtReturnT.Size = new System.Drawing.Size(189, 23);
            this.txtReturnT.TabIndex = 18;
            this.txtReturnT.TextChanged += new System.EventHandler(this.txtReturnT_TextChanged);
            // 
            // txtSnum
            // 
            this.txtSnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSnum.Location = new System.Drawing.Point(282, 50);
            this.txtSnum.Name = "txtSnum";
            this.txtSnum.Size = new System.Drawing.Size(189, 23);
            this.txtSnum.TabIndex = 19;
            this.txtSnum.TextChanged += new System.EventHandler(this.txtSnum_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Clean";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.Width = 39;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "lotnumber";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 78;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "typename ";
            this.Column3.Name = "Column3";
            this.Column3.Width = 81;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "jnum ";
            this.Column4.Name = "Column4";
            this.Column4.Width = 57;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "snum ";
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "qty ";
            this.Column6.Name = "Column6";
            this.Column6.Width = 46;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "trackingnumber ";
            this.Column7.Name = "Column7";
            this.Column7.Width = 108;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column8.HeaderText = "shippedate ";
            this.Column8.Name = "Column8";
            this.Column8.Width = 87;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column9.HeaderText = "returnQty";
            this.Column9.Name = "Column9";
            this.Column9.Width = 75;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column10.HeaderText = "returnTracking ";
            this.Column10.Name = "Column10";
            this.Column10.Width = 104;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column11.HeaderText = "returneddate ";
            this.Column11.Name = "Column11";
            this.Column11.Width = 95;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column12.HeaderText = "condition ";
            this.Column12.Name = "Column12";
            this.Column12.Width = 78;
            // 
            // Column13
            // 
            this.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column13.HeaderText = "repairable";
            this.Column13.Name = "Column13";
            this.Column13.Width = 78;
            // 
            // txtreturnQty
            // 
            this.txtreturnQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnQty.Location = new System.Drawing.Point(12, 112);
            this.txtreturnQty.Name = "txtreturnQty";
            this.txtreturnQty.Size = new System.Drawing.Size(79, 20);
            this.txtreturnQty.TabIndex = 28;
            this.txtreturnQty.TextChanged += new System.EventHandler(this.txtreturnQty_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "returnQty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "returnedDate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(229, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 32;
            this.label8.Text = "repairable";
            // 
            // cborepairable
            // 
            this.cborepairable.FormattingEnabled = true;
            this.cborepairable.Items.AddRange(new object[] {
            "N",
            "Y"});
            this.cborepairable.Location = new System.Drawing.Point(233, 182);
            this.cborepairable.Name = "cborepairable";
            this.cborepairable.Size = new System.Drawing.Size(57, 21);
            this.cborepairable.TabIndex = 31;
            this.cborepairable.SelectedIndexChanged += new System.EventHandler(this.cborepairable_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(122, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "condition";
            // 
            // cbocondition
            // 
            this.cbocondition.FormattingEnabled = true;
            this.cbocondition.Items.AddRange(new object[] {
            "Damaged",
            "Good",
            "Minor scratch",
            "New",
            "Used"});
            this.cbocondition.Location = new System.Drawing.Point(124, 111);
            this.cbocondition.Name = "cbocondition";
            this.cbocondition.Size = new System.Drawing.Size(121, 21);
            this.cbocondition.TabIndex = 33;
            this.cbocondition.SelectedIndexChanged += new System.EventHandler(this.cbocondition_SelectedIndexChanged);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 183);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 35;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbocondition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cborepairable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtreturnQty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSnum);
            this.Controls.Add(this.txtReturnT);
            this.Controls.Add(this.btnReturnT);
            this.Controls.Add(this.btnSnum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLotnumber);
            this.Controls.Add(this.dgviQorSystem);
            this.Controls.Add(this.dgvupdate);
            this.Controls.Add(this.txtLotnum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "iQor System ver 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dgviQorSystem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLotnum;
        private System.Windows.Forms.Button dgvupdate;
        private System.Windows.Forms.DataGridView dgviQorSystem;
        private System.Windows.Forms.Button btnLotnumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSnum;
        private System.Windows.Forms.Button btnReturnT;
        private System.Windows.Forms.TextBox txtReturnT;
        private System.Windows.Forms.TextBox txtSnum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.TextBox txtreturnQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cborepairable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbocondition;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
    }
}

