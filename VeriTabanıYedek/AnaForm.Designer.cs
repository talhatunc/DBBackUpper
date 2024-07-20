namespace VeriTabanıYedek
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sil = new System.Windows.Forms.DataGridViewImageColumn();
            this.duzenle = new System.Windows.Forms.DataGridViewImageColumn();
            this.veritabaniAdres = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.veritabaniAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sifre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saatlik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunluk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haftalik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnVeriTabaniEkle = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripExit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timerYedekleme = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStripExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sil,
            this.duzenle,
            this.veritabaniAdres,
            this.veritabaniAdi,
            this.kAdi,
            this.sifre,
            this.saatlik,
            this.gunluk,
            this.haftalik});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(585, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // sil
            // 
            this.sil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sil.HeaderText = "";
            this.sil.Image = ((System.Drawing.Image)(resources.GetObject("sil.Image")));
            this.sil.Name = "sil";
            this.sil.ReadOnly = true;
            this.sil.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sil.Width = 19;
            // 
            // duzenle
            // 
            this.duzenle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.duzenle.HeaderText = "";
            this.duzenle.Image = ((System.Drawing.Image)(resources.GetObject("duzenle.Image")));
            this.duzenle.Name = "duzenle";
            this.duzenle.ReadOnly = true;
            this.duzenle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.duzenle.Width = 5;
            // 
            // veritabaniAdres
            // 
            this.veritabaniAdres.HeaderText = "Veri Tabanı Adresi";
            this.veritabaniAdres.Name = "veritabaniAdres";
            this.veritabaniAdres.ReadOnly = true;
            // 
            // veritabaniAdi
            // 
            this.veritabaniAdi.HeaderText = "Veri Tabanı Adı";
            this.veritabaniAdi.Name = "veritabaniAdi";
            this.veritabaniAdi.ReadOnly = true;
            // 
            // kAdi
            // 
            this.kAdi.HeaderText = "Kullanıcı Adı";
            this.kAdi.Name = "kAdi";
            this.kAdi.ReadOnly = true;
            // 
            // sifre
            // 
            this.sifre.HeaderText = "Şifre";
            this.sifre.Name = "sifre";
            this.sifre.ReadOnly = true;
            // 
            // saatlik
            // 
            this.saatlik.HeaderText = "Saatlik";
            this.saatlik.Name = "saatlik";
            this.saatlik.ReadOnly = true;
            // 
            // gunluk
            // 
            this.gunluk.HeaderText = "Günlük";
            this.gunluk.Name = "gunluk";
            this.gunluk.ReadOnly = true;
            // 
            // haftalik
            // 
            this.haftalik.HeaderText = "Haftalık";
            this.haftalik.Name = "haftalik";
            this.haftalik.ReadOnly = true;
            // 
            // btnVeriTabaniEkle
            // 
            this.btnVeriTabaniEkle.Location = new System.Drawing.Point(497, 172);
            this.btnVeriTabaniEkle.Name = "btnVeriTabaniEkle";
            this.btnVeriTabaniEkle.Size = new System.Drawing.Size(100, 23);
            this.btnVeriTabaniEkle.TabIndex = 1;
            this.btnVeriTabaniEkle.Text = "Veri Tabanı Ekle";
            this.btnVeriTabaniEkle.UseVisualStyleBackColor = true;
            this.btnVeriTabaniEkle.Click += new System.EventHandler(this.btnVeriTabaniEkle_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStripExit;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Veri Tabanı Yedekleyici";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStripExit
            // 
            this.contextMenuStripExit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.contextMenuStripExit.Name = "contextMenuStripExit";
            this.contextMenuStripExit.Size = new System.Drawing.Size(105, 26);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItemExit.Text = "Kapat";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // timerYedekleme
            // 
            this.timerYedekleme.Enabled = true;
            this.timerYedekleme.Interval = 3600000;
            this.timerYedekleme.Tick += new System.EventHandler(this.timerYedekleme_Tick);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 207);
            this.Controls.Add(this.btnVeriTabaniEkle);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaForm";
            this.Text = "Veri Tabanı Yedekleyici";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AnaForm_FormClosing);
            this.Load += new System.EventHandler(this.AnaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStripExit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVeriTabaniEkle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn sil;
        private System.Windows.Forms.DataGridViewImageColumn duzenle;
        private System.Windows.Forms.DataGridViewTextBoxColumn veritabaniAdres;
        private System.Windows.Forms.DataGridViewTextBoxColumn veritabaniAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn kAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifre;
        private System.Windows.Forms.DataGridViewTextBoxColumn saatlik;
        private System.Windows.Forms.DataGridViewTextBoxColumn gunluk;
        private System.Windows.Forms.DataGridViewTextBoxColumn haftalik;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Timer timerYedekleme;
    }
}

