namespace VeriTabanıYedek
{
    partial class VeriTabaniEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeriTabaniEkle));
            this.comboBoxVeriTabaniAdres = new System.Windows.Forms.ComboBox();
            this.lblVeriTabaniAdi = new System.Windows.Forms.Label();
            this.textBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.textBoxSifre = new System.Windows.Forms.TextBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblSifre = new System.Windows.Forms.Label();
            this.btnBaglantiSina = new System.Windows.Forms.Button();
            this.textBoxVeritabaniAdresi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkle = new System.Windows.Forms.Button();
            this.checkBoxSaatlik = new System.Windows.Forms.CheckBox();
            this.checkBoxGunluk = new System.Windows.Forms.CheckBox();
            this.checkBoxHaftalik = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboBoxVeriTabaniAdres
            // 
            this.comboBoxVeriTabaniAdres.Enabled = false;
            this.comboBoxVeriTabaniAdres.FormattingEnabled = true;
            this.comboBoxVeriTabaniAdres.Location = new System.Drawing.Point(122, 106);
            this.comboBoxVeriTabaniAdres.Name = "comboBoxVeriTabaniAdres";
            this.comboBoxVeriTabaniAdres.Size = new System.Drawing.Size(140, 21);
            this.comboBoxVeriTabaniAdres.TabIndex = 0;
            this.comboBoxVeriTabaniAdres.SelectedIndexChanged += new System.EventHandler(this.comboBoxVeriTabaniAdres_SelectedIndexChanged);
            // 
            // lblVeriTabaniAdi
            // 
            this.lblVeriTabaniAdi.AutoSize = true;
            this.lblVeriTabaniAdi.Location = new System.Drawing.Point(12, 15);
            this.lblVeriTabaniAdi.Name = "lblVeriTabaniAdi";
            this.lblVeriTabaniAdi.Size = new System.Drawing.Size(99, 13);
            this.lblVeriTabaniAdi.TabIndex = 1;
            this.lblVeriTabaniAdi.Text = "Veri Tabanı Adresi :";
            // 
            // textBoxKullaniciAdi
            // 
            this.textBoxKullaniciAdi.Enabled = false;
            this.textBoxKullaniciAdi.Location = new System.Drawing.Point(122, 54);
            this.textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            this.textBoxKullaniciAdi.Size = new System.Drawing.Size(140, 20);
            this.textBoxKullaniciAdi.TabIndex = 2;
            this.textBoxKullaniciAdi.TextChanged += new System.EventHandler(this.textBoxKullaniciAdi_TextChanged);
            // 
            // textBoxSifre
            // 
            this.textBoxSifre.Enabled = false;
            this.textBoxSifre.Location = new System.Drawing.Point(122, 80);
            this.textBoxSifre.Name = "textBoxSifre";
            this.textBoxSifre.Size = new System.Drawing.Size(140, 20);
            this.textBoxSifre.TabIndex = 3;
            this.textBoxSifre.TextChanged += new System.EventHandler(this.textBoxSifre_TextChanged);
            this.textBoxSifre.Leave += new System.EventHandler(this.textBoxSifre_Leave);
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(12, 57);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(70, 13);
            this.lblKullaniciAdi.TabIndex = 4;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı :";
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(12, 83);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(37, 13);
            this.lblSifre.TabIndex = 5;
            this.lblSifre.Text = "Şifre : ";
            // 
            // btnBaglantiSina
            // 
            this.btnBaglantiSina.Enabled = false;
            this.btnBaglantiSina.Location = new System.Drawing.Point(10, 185);
            this.btnBaglantiSina.Name = "btnBaglantiSina";
            this.btnBaglantiSina.Size = new System.Drawing.Size(101, 23);
            this.btnBaglantiSina.TabIndex = 6;
            this.btnBaglantiSina.Text = "Bağlantıyı Sına";
            this.btnBaglantiSina.UseVisualStyleBackColor = true;
            this.btnBaglantiSina.Click += new System.EventHandler(this.btnBaglantiSina_Click);
            // 
            // textBoxVeritabaniAdresi
            // 
            this.textBoxVeritabaniAdresi.Location = new System.Drawing.Point(122, 12);
            this.textBoxVeritabaniAdresi.Name = "textBoxVeritabaniAdresi";
            this.textBoxVeritabaniAdresi.Size = new System.Drawing.Size(140, 20);
            this.textBoxVeritabaniAdresi.TabIndex = 7;
            this.textBoxVeritabaniAdresi.TextChanged += new System.EventHandler(this.textBoxVeritabaniAdresi_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Veri Tabanı : ";
            // 
            // btnEkle
            // 
            this.btnEkle.Enabled = false;
            this.btnEkle.Location = new System.Drawing.Point(187, 185);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // checkBoxSaatlik
            // 
            this.checkBoxSaatlik.AutoSize = true;
            this.checkBoxSaatlik.Location = new System.Drawing.Point(15, 133);
            this.checkBoxSaatlik.Name = "checkBoxSaatlik";
            this.checkBoxSaatlik.Size = new System.Drawing.Size(58, 17);
            this.checkBoxSaatlik.TabIndex = 10;
            this.checkBoxSaatlik.Text = "Saatlik";
            this.checkBoxSaatlik.UseVisualStyleBackColor = true;
            // 
            // checkBoxGunluk
            // 
            this.checkBoxGunluk.AutoSize = true;
            this.checkBoxGunluk.Location = new System.Drawing.Point(101, 133);
            this.checkBoxGunluk.Name = "checkBoxGunluk";
            this.checkBoxGunluk.Size = new System.Drawing.Size(60, 17);
            this.checkBoxGunluk.TabIndex = 11;
            this.checkBoxGunluk.Text = "Günlük";
            this.checkBoxGunluk.UseVisualStyleBackColor = true;
            // 
            // checkBoxHaftalik
            // 
            this.checkBoxHaftalik.AutoSize = true;
            this.checkBoxHaftalik.Location = new System.Drawing.Point(187, 133);
            this.checkBoxHaftalik.Name = "checkBoxHaftalik";
            this.checkBoxHaftalik.Size = new System.Drawing.Size(62, 17);
            this.checkBoxHaftalik.TabIndex = 12;
            this.checkBoxHaftalik.Text = "Haftalık";
            this.checkBoxHaftalik.UseVisualStyleBackColor = true;
            // 
            // VeriTabaniEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 222);
            this.Controls.Add(this.checkBoxHaftalik);
            this.Controls.Add(this.checkBoxGunluk);
            this.Controls.Add(this.checkBoxSaatlik);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxVeritabaniAdresi);
            this.Controls.Add(this.btnBaglantiSina);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.textBoxSifre);
            this.Controls.Add(this.textBoxKullaniciAdi);
            this.Controls.Add(this.lblVeriTabaniAdi);
            this.Controls.Add(this.comboBoxVeriTabaniAdres);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VeriTabaniEkle";
            this.Text = "Veri Tabanı Ekle";
            this.Load += new System.EventHandler(this.VeriTabaniEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVeriTabaniAdres;
        private System.Windows.Forms.Label lblVeriTabaniAdi;
        private System.Windows.Forms.TextBox textBoxKullaniciAdi;
        private System.Windows.Forms.TextBox textBoxSifre;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button btnBaglantiSina;
        private System.Windows.Forms.TextBox textBoxVeritabaniAdresi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.CheckBox checkBoxSaatlik;
        private System.Windows.Forms.CheckBox checkBoxGunluk;
        private System.Windows.Forms.CheckBox checkBoxHaftalik;
    }
}