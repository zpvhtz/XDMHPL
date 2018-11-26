namespace ProjectQLCuocDT
{
    partial class frmHoaDonThanhToan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSua = new System.Windows.Forms.Button();
            this.chkThoiGian = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpNgayApDung = new System.Windows.Forms.DateTimePicker();
            this.dtpTGKT = new System.Windows.Forms.DateTimePicker();
            this.dtpTGBD = new System.Windows.Forms.DateTimePicker();
            this.numericGiaCuoc = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvLoaiCuoc = new System.Windows.Forms.DataGridView();
            this.cbbTinhTrang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtMaLoaiCuoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericGiaCuoc)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiCuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(600, 15);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 30);
            this.btnLamMoi.TabIndex = 2;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(300, 15);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 30);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Status";
            this.Column7.HeaderText = "Tình trạng";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "GiaCuoc";
            this.Column6.HeaderText = "Giá cước";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayApDung";
            this.Column5.HeaderText = "Ngày áp dụng";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TG_KetThuc";
            this.Column4.HeaderText = "Thời gian kết thúc";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TG_BatDau";
            this.Column3.HeaderText = "Thời gian bắt đầu";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaLoaiCuoc";
            this.Column2.HeaderText = "Mã";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "STT";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(450, 15);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 30);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // chkThoiGian
            // 
            this.chkThoiGian.AutoSize = true;
            this.chkThoiGian.Checked = true;
            this.chkThoiGian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThoiGian.Location = new System.Drawing.Point(675, 239);
            this.chkThoiGian.Name = "chkThoiGian";
            this.chkThoiGian.Size = new System.Drawing.Size(61, 22);
            this.chkThoiGian.TabIndex = 42;
            this.chkThoiGian.Text = "Sáng";
            this.chkThoiGian.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(550, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "Thời gian";
            // 
            // txtSTT
            // 
            this.txtSTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSTT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTT.Location = new System.Drawing.Point(240, 58);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.ReadOnly = true;
            this.txtSTT.Size = new System.Drawing.Size(200, 24);
            this.txtSTT.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(115, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 39;
            this.label7.Text = "STT";
            // 
            // dtpNgayApDung
            // 
            this.dtpNgayApDung.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpNgayApDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayApDung.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayApDung.Location = new System.Drawing.Point(675, 57);
            this.dtpNgayApDung.Name = "dtpNgayApDung";
            this.dtpNgayApDung.Size = new System.Drawing.Size(200, 24);
            this.dtpNgayApDung.TabIndex = 38;
            this.dtpNgayApDung.Value = new System.DateTime(2018, 11, 26, 13, 34, 23, 0);
            // 
            // dtpTGKT
            // 
            this.dtpTGKT.CustomFormat = "HH:mm:ss";
            this.dtpTGKT.Enabled = false;
            this.dtpTGKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTGKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGKT.Location = new System.Drawing.Point(240, 237);
            this.dtpTGKT.Name = "dtpTGKT";
            this.dtpTGKT.ShowUpDown = true;
            this.dtpTGKT.Size = new System.Drawing.Size(200, 24);
            this.dtpTGKT.TabIndex = 37;
            // 
            // dtpTGBD
            // 
            this.dtpTGBD.CustomFormat = "HH:mm:ss";
            this.dtpTGBD.Enabled = false;
            this.dtpTGBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTGBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGBD.Location = new System.Drawing.Point(240, 177);
            this.dtpTGBD.Name = "dtpTGBD";
            this.dtpTGBD.ShowUpDown = true;
            this.dtpTGBD.Size = new System.Drawing.Size(200, 24);
            this.dtpTGBD.TabIndex = 36;
            // 
            // numericGiaCuoc
            // 
            this.numericGiaCuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericGiaCuoc.Location = new System.Drawing.Point(675, 117);
            this.numericGiaCuoc.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numericGiaCuoc.Name = "numericGiaCuoc";
            this.numericGiaCuoc.Size = new System.Drawing.Size(200, 24);
            this.numericGiaCuoc.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 659);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 70);
            this.panel1.TabIndex = 34;
            // 
            // dgvLoaiCuoc
            // 
            this.dgvLoaiCuoc.AllowUserToAddRows = false;
            this.dgvLoaiCuoc.AllowUserToResizeRows = false;
            this.dgvLoaiCuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaiCuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoaiCuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiCuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoaiCuoc.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLoaiCuoc.Location = new System.Drawing.Point(0, 287);
            this.dgvLoaiCuoc.MultiSelect = false;
            this.dgvLoaiCuoc.Name = "dgvLoaiCuoc";
            this.dgvLoaiCuoc.ReadOnly = true;
            this.dgvLoaiCuoc.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLoaiCuoc.RowHeadersVisible = false;
            this.dgvLoaiCuoc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLoaiCuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiCuoc.Size = new System.Drawing.Size(1008, 340);
            this.dgvLoaiCuoc.TabIndex = 33;
            // 
            // cbbTinhTrang
            // 
            this.cbbTinhTrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTinhTrang.FormattingEnabled = true;
            this.cbbTinhTrang.Items.AddRange(new object[] {
            "Khoá",
            "Không khoá"});
            this.cbbTinhTrang.Location = new System.Drawing.Point(675, 177);
            this.cbbTinhTrang.Name = "cbbTinhTrang";
            this.cbbTinhTrang.Size = new System.Drawing.Size(200, 24);
            this.cbbTinhTrang.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 18);
            this.label5.TabIndex = 31;
            this.label5.Text = "Tình trạng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(550, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 30;
            this.label6.Text = "Giá cước";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(115, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "Thời gian kết thúc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 18);
            this.label4.TabIndex = 28;
            this.label4.Text = "Thời gian bắt đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(550, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ngày áp dụng";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(430, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(135, 25);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "LOẠI CƯỚC";
            // 
            // txtMaLoaiCuoc
            // 
            this.txtMaLoaiCuoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaLoaiCuoc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaLoaiCuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLoaiCuoc.Location = new System.Drawing.Point(240, 117);
            this.txtMaLoaiCuoc.Name = "txtMaLoaiCuoc";
            this.txtMaLoaiCuoc.Size = new System.Drawing.Size(200, 24);
            this.txtMaLoaiCuoc.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Mã loại cước";
            // 
            // frmHoaDonThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.chkThoiGian);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSTT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpNgayApDung);
            this.Controls.Add(this.dtpTGKT);
            this.Controls.Add(this.dtpTGBD);
            this.Controls.Add(this.numericGiaCuoc);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvLoaiCuoc);
            this.Controls.Add(this.cbbTinhTrang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtMaLoaiCuoc);
            this.Controls.Add(this.label1);
            this.Name = "frmHoaDonThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDonThanhToan";
            ((System.ComponentModel.ISupportInitialize)(this.numericGiaCuoc)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiCuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.CheckBox chkThoiGian;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSTT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNgayApDung;
        private System.Windows.Forms.DateTimePicker dtpTGKT;
        private System.Windows.Forms.DateTimePicker dtpTGBD;
        private System.Windows.Forms.NumericUpDown numericGiaCuoc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLoaiCuoc;
        private System.Windows.Forms.ComboBox cbbTinhTrang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMaLoaiCuoc;
        private System.Windows.Forms.Label label1;
    }
}