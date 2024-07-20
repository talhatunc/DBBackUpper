using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıYedek
{
    public partial class VeriTabaniEkle : Form
    {
        public int satirId;
        public VeriTabaniEkle(int satirIdd)
        {
           
            satirId = satirIdd;
            InitializeComponent();
            if (satirId != -1)
            {
                string dosyaYolu = "settings.ini";

                // Dosyadaki satırları oku
                string[] satirlar = File.ReadAllLines(dosyaYolu);

                Dictionary<string, string> veritabaniBilgileri = JsonConvert.DeserializeObject<Dictionary<string, string>>(satirlar[satirIdd]);

                comboBoxVeriTabaniAdres.Text = veritabaniBilgileri["veritabaniAdi"];
                textBoxVeritabaniAdresi.Text = veritabaniBilgileri["veritabaniAdres"].Replace("/", "\\");
                textBoxKullaniciAdi.Text = veritabaniBilgileri["kAdi"];
                textBoxSifre.Text = veritabaniBilgileri["sifre"];
                checkBoxSaatlik.Checked = bool.Parse(veritabaniBilgileri["saatlik"]);
                checkBoxGunluk.Checked = bool.Parse(veritabaniBilgileri["gunluk"]);
                checkBoxHaftalik.Checked = bool.Parse(veritabaniBilgileri["haftalik"]);
                btnBaglantiSina.Enabled = true;
                btnEkle.Text = "Düzenle";
            }
        }
        VeriTabaniController controller = new VeriTabaniController();
        AnaForm anaForm;
        private void VeriTabaniEkle_Load(object sender, EventArgs e)
        {
            anaForm = (AnaForm)this.Owner;
            anaForm.Enabled = false;
        }

        private void comboBoxVeriTabaniAdres_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVeriTabaniAdres.Text != "")
            {
                btnBaglantiSina.Enabled = true;
            }
            else
            {
                btnBaglantiSina.Enabled = false;
            }
        }

        private async void btnBaglantiSina_Click(object sender, EventArgs e)
        {
            comboBoxVeriTabaniAdres.Items.Clear();
            await controller.BagalntiSina(
                 textBoxVeritabaniAdresi.Text,
                 comboBoxVeriTabaniAdres.Text,
                 textBoxKullaniciAdi.Text,
                 textBoxSifre.Text,
                 true);
                List<string> veritabaniAdresleri = controller.VeritabanlariAdresleriniAl(textBoxVeritabaniAdresi.Text);
                comboBoxVeriTabaniAdres.Items.Clear();
                foreach (string adres in veritabaniAdresleri)
                {
                    comboBoxVeriTabaniAdres.Items.Add(adres); // Listbox'a ekleme yapabilirsiniz
                }
                btnEkle.Enabled = true;
        }

        private void textBoxSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxVeritabaniAdresi_TextChanged(object sender, EventArgs e)
        {
            if (textBoxVeritabaniAdresi.Text != "")
            {
                textBoxKullaniciAdi.Enabled = true;
                textBoxSifre.Enabled = true;
                comboBoxVeriTabaniAdres.Enabled = true;
            }
            else
            {
                textBoxKullaniciAdi.Enabled = false;
                textBoxSifre.Enabled = false;
                comboBoxVeriTabaniAdres.Enabled = false;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (satirId == -1)
            {
                try
                {
                    string veriler = "{" + $"\"veritabaniAdres\": \"{textBoxVeritabaniAdresi.Text.Replace("\\", "/")}\",\"veritabaniAdi\": \"{comboBoxVeriTabaniAdres.Text}\",\"kAdi\": \"{textBoxKullaniciAdi.Text}\",\"sifre\": \"{textBoxSifre.Text}\",\"saatlik\": \"{checkBoxSaatlik.Checked}\",\"gunluk\": \"{checkBoxGunluk.Checked}\",\"haftalik\": \"{checkBoxHaftalik.Checked}\"" +"}";
                    // Verileri yazmak için StreamWriter kullanıyoruz
                    using (StreamWriter writer = new StreamWriter("settings.ini", true))
                    {
                        writer.WriteLine(veriler);
                    }
                    anaForm.Enabled = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    string dosyaYolu = "settings.ini";

                    // Dosyadaki satırları oku
                    string[] satirlar = File.ReadAllLines(dosyaYolu);

                    satirlar[satirId] = "{" + $"\"veritabaniAdres\": \"{textBoxVeritabaniAdresi.Text.Replace("\\", "/")}\",\"veritabaniAdi\": \"{comboBoxVeriTabaniAdres.Text}\",\"kAdi\": \"{textBoxKullaniciAdi.Text}\",\"sifre\": \"{textBoxSifre.Text}\",\"saatlik\": \"{checkBoxSaatlik.Checked}\",\"gunluk\": \"{checkBoxGunluk.Checked}\",\"haftalik\": \"{checkBoxHaftalik.Checked}\"" + "}";

                    // Güncellenmiş satırları dosyaya yaz
                    File.WriteAllLines(dosyaYolu, satirlar );
                    anaForm.Enabled = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veriler kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void textBoxKullaniciAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private async void textBoxSifre_Leave(object sender, EventArgs e)
        {
            if (textBoxVeritabaniAdresi.Text != "" && textBoxKullaniciAdi.Text != "" && textBoxSifre.Text != "")
            {
                comboBoxVeriTabaniAdres.Items.Clear();
               await controller.BagalntiSina(
                textBoxVeritabaniAdresi.Text,
                comboBoxVeriTabaniAdres.Text,
                textBoxKullaniciAdi.Text,
                textBoxSifre.Text,
                false);
                List<string> veritabaniAdresleri = controller.VeritabanlariAdresleriniAl(textBoxVeritabaniAdresi.Text);
                comboBoxVeriTabaniAdres.Items.Clear();
                foreach (string adres in veritabaniAdresleri)
                {
                    comboBoxVeriTabaniAdres.Items.Add(adres); // Listbox'a ekleme yapabilirsiniz
                }

            }
        }
    }
}
