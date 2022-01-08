namespace Pendulum
{
    partial class FrmMain
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbArtist = new System.Windows.Forms.ComboBox();
            this.cbAlbum = new System.Windows.Forms.ComboBox();
            this.pbAlbumcover = new System.Windows.Forms.PictureBox();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linklbUrl = new System.Windows.Forms.LinkLabel();
            this.btnDiscography = new System.Windows.Forms.Button();
            this.btnUrl = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumcover)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Artist";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(174, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Album";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Search in track\'s title";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTitle,
            this.ColumnLength,
            this.ColumnUrl,
            this.ColumnId,
            this.ColumnAlbum});
            this.dgv.Location = new System.Drawing.Point(12, 150);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(301, 271);
            this.dgv.TabIndex = 3;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_CellClick);
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.FillWeight = 204.9232F;
            this.ColumnTitle.HeaderText = "Title";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // ColumnLength
            // 
            this.ColumnLength.FillWeight = 81.96928F;
            this.ColumnLength.HeaderText = "Length";
            this.ColumnLength.Name = "ColumnLength";
            this.ColumnLength.ReadOnly = true;
            this.ColumnLength.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnUrl
            // 
            this.ColumnUrl.FillWeight = 44.67006F;
            this.ColumnUrl.HeaderText = "Url";
            this.ColumnUrl.Name = "ColumnUrl";
            this.ColumnUrl.Visible = false;
            // 
            // ColumnId
            // 
            this.ColumnId.FillWeight = 51.31939F;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnAlbum
            // 
            this.ColumnAlbum.FillWeight = 57.1182F;
            this.ColumnAlbum.HeaderText = "Album";
            this.ColumnAlbum.Name = "ColumnAlbum";
            this.ColumnAlbum.Visible = false;
            // 
            // tbSearch
            // 
            this.tbSearch.Enabled = false;
            this.tbSearch.Location = new System.Drawing.Point(12, 108);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(301, 20);
            this.tbSearch.TabIndex = 4;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            // 
            // cbArtist
            // 
            this.cbArtist.FormattingEnabled = true;
            this.cbArtist.Location = new System.Drawing.Point(12, 47);
            this.cbArtist.Name = "cbArtist";
            this.cbArtist.Size = new System.Drawing.Size(136, 21);
            this.cbArtist.TabIndex = 5;
            this.cbArtist.SelectedIndexChanged += new System.EventHandler(this.CbArtist_SelectedIndexChanged);
            // 
            // cbAlbum
            // 
            this.cbAlbum.Enabled = false;
            this.cbAlbum.FormattingEnabled = true;
            this.cbAlbum.Location = new System.Drawing.Point(177, 47);
            this.cbAlbum.Name = "cbAlbum";
            this.cbAlbum.Size = new System.Drawing.Size(136, 21);
            this.cbAlbum.TabIndex = 6;
            this.cbAlbum.SelectedValueChanged += new System.EventHandler(this.CbAlbum_SelectedValueChanged);
            // 
            // pbAlbumcover
            // 
            this.pbAlbumcover.Location = new System.Drawing.Point(330, 150);
            this.pbAlbumcover.Name = "pbAlbumcover";
            this.pbAlbumcover.Size = new System.Drawing.Size(132, 122);
            this.pbAlbumcover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbumcover.TabIndex = 7;
            this.pbAlbumcover.TabStop = false;
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(477, 150);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(261, 122);
            this.rtb.TabIndex = 8;
            this.rtb.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(362, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "URL (if any):";
            // 
            // linklbUrl
            // 
            this.linklbUrl.AutoSize = true;
            this.linklbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linklbUrl.Location = new System.Drawing.Point(456, 308);
            this.linklbUrl.Name = "linklbUrl";
            this.linklbUrl.Size = new System.Drawing.Size(0, 17);
            this.linklbUrl.TabIndex = 11;
            this.linklbUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinklbUrl_LinkClicked);
            // 
            // btnDiscography
            // 
            this.btnDiscography.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDiscography.Location = new System.Drawing.Point(330, 368);
            this.btnDiscography.Name = "btnDiscography";
            this.btnDiscography.Size = new System.Drawing.Size(132, 53);
            this.btnDiscography.TabIndex = 12;
            this.btnDiscography.Text = "Add Discography";
            this.btnDiscography.UseVisualStyleBackColor = true;
            this.btnDiscography.Click += new System.EventHandler(this.BtnDiscography_Click);
            // 
            // btnUrl
            // 
            this.btnUrl.Enabled = false;
            this.btnUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUrl.Location = new System.Drawing.Point(468, 368);
            this.btnUrl.Name = "btnUrl";
            this.btnUrl.Size = new System.Drawing.Size(132, 53);
            this.btnUrl.TabIndex = 13;
            this.btnUrl.Text = "Add URL";
            this.btnUrl.UseVisualStyleBackColor = true;
            this.btnUrl.Click += new System.EventHandler(this.BtnUrl_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEdit.Location = new System.Drawing.Point(606, 368);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(132, 53);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit Selected";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 433);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnUrl);
            this.Controls.Add(this.btnDiscography);
            this.Controls.Add(this.linklbUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.pbAlbumcover);
            this.Controls.Add(this.cbAlbum);
            this.Controls.Add(this.cbArtist);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "Discography Tracker";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbumcover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbArtist;
        private System.Windows.Forms.ComboBox cbAlbum;
        private System.Windows.Forms.PictureBox pbAlbumcover;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linklbUrl;
        private System.Windows.Forms.Button btnDiscography;
        private System.Windows.Forms.Button btnUrl;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAlbum;
    }
}

