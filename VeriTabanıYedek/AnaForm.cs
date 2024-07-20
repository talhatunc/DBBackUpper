using IWshRuntimeLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using File=System.IO.File;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VeriTabanıYedek
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnVeriTabaniEkle_Click(object sender, EventArgs e)
        {
            VeriTabaniEkle veriTabaniEkleForm = new VeriTabaniEkle(-1);
            veriTabaniEkleForm.Owner = this;
            veriTabaniEkleForm.FormClosing += (s, args) =>
            {
                this.Enabled = true;
                ListeYenile();
            };

            veriTabaniEkleForm.ShowDialog();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "\\" + AppDomain.CurrentDomain.FriendlyName;
            string appShortcutPath = Path.Combine(startupFolder, "DbYedekleyici.lnk");

            if (!File.Exists(appShortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(appShortcutPath);
                shortcut.Description = "Veritabanını otomatik yedeklemek üzere yazılmış program.";
                shortcut.TargetPath = appPath;
                shortcut.Save();
            }
            this.BeginInvoke(new MethodInvoker(delegate
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }));
            ListeYenile();
            VeriTabaniController controller = new VeriTabaniController();
            controller.VeriTabaniYedekle();
        }

        void ListeYenile()
        {
            string dosyaAdi = "settings.ini";

            // Dosyanın varlığını kontrol et
            if (File.Exists(dosyaAdi))
            {
                try
                {
                    // Dosyayı oku ve içeriği al
                    string dosyaIcerigi = File.ReadAllText(dosyaAdi);

                    string[] veriBloklari = dosyaIcerigi.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    // DataGridView'ı temizle
                    dataGridView1.Rows.Clear();
                    // JSON verisini deserializasyon ile oku
                    int i = 0;
                    foreach (var veri in veriBloklari)
                    {
                        i++;
                        {
                            // JSON verisini deserializasyon ile oku
                            Dictionary<string, string> veritabaniBilgileri = JsonConvert.DeserializeObject<Dictionary<string, string>>(veri.Replace("\r\n", ""));

                            // Veritabanı bilgilerini DataGridView'da yan yana yazdır
                            int rowIndex = dataGridView1.Rows.Add();
                            int columnIndex = 2;
                            foreach (var kvp in veritabaniBilgileri)
                            {
                                dataGridView1.Rows[rowIndex].Cells[kvp.Key].Value = kvp.Value;
                                columnIndex++;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bilgileri işlenirken bir hata oluştu: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Settings.ini dosyası bulunamadı.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (colName == "sil")
                {
                    string dosyaYolu = "settings.ini";

                    //Dosyadaki satırları oku
                    string[] satirlar = File.ReadAllLines(dosyaYolu);

                    //Silinecek satırı kaldır
                        satirlar = satirlar.Where((line, index) => index != e.RowIndex).ToArray();

                    //Güncellenmiş satırları dosyaya yaz
                    File.WriteAllLines(dosyaYolu, satirlar);
                    ListeYenile();
                }
                else if (colName == "duzenle")
                {
                    VeriTabaniEkle veriTabaniEkleForm = new VeriTabaniEkle(e.RowIndex);
                    veriTabaniEkleForm.Owner = this;
                    veriTabaniEkleForm.FormClosing += (s, args) =>
                    {
                        this.Enabled = true;
                        ListeYenile();
                    };

                    veriTabaniEkleForm.ShowDialog();
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show(); 
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized; 
                    this.Hide(); 
                }
            }
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 
                this.WindowState = FormWindowState.Minimized; 
                this.Hide(); 
            }
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapat
            Application.Exit();
        }

        private void timerYedekleme_Tick(object sender, EventArgs e)
        {
            VeriTabaniController controller = new VeriTabaniController();
            controller.VeriTabaniYedekle();
        }
    }
}
