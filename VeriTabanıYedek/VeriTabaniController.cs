using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Writers;
using SharpCompress.Writers.Tar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabanıYedek
{
    public class VeriTabaniController
    {
        string connectionString;
        public  List<string> VeritabanlariAdresleriniAl(string serverAdi=".")
        {
            List<string> veritabaniAdresleri = new List<string>();

            try
            {

                //SqlConnection oluştur ve bağlantıyı aç
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanı adreslerini almak için sorguyu çalıştır
                    string query = "SELECT name FROM sys.databases";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string veritabaniAdi = reader.GetString(0);
                                veritabaniAdresleri.Add(veritabaniAdi);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı adreslerini alma sırasında bir hata oluştu: " + ex.Message);
            }

            return veritabaniAdresleri;
        }

        public async Task BagalntiSina(string veritabaniAdresi, string veritabaniAdi ,string kAdi,string sifre,bool hataGoster)
        {
            try
            {
                connectionString = $"data source={veritabaniAdresi};initial catalog={veritabaniAdi};user id={kAdi};password={sifre};";
                //SqlConnection oluştur ve bağlantıyı aç
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if(hataGoster)
                    MessageBox.Show("Veritabanı bağlantısı başarılı bir şekilde açıldı.");
                }
            }
            catch (Exception ex)
            {
                if (hataGoster)
                    MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }

        public async Task VeriTabaniYedekle()
        {
            try
            {
                string dosyaYolu = "settings.ini";
                string[] dosyaYolları = { "C:\\Yedek\\SaatlikYedek\\", "C:\\Yedek\\GunlukYedek\\", "C:\\Yedek\\HaftalikYedek\\" };
                foreach (var item in dosyaYolları)
                {
                    string dosyaDizini = Path.GetDirectoryName(item);
                    if (!Directory.Exists(dosyaDizini))
                    {
                        Directory.CreateDirectory(dosyaDizini);
                    }
                }
                
                //Dosya varsa oku
                if (File.Exists(dosyaYolu))
                {
                    //Dosyadaki satırları oku
                    string[] satirlar = File.ReadAllLines(dosyaYolu);
                    string[] eskiYedekBak;
                    string[] eskiYedekZip;
                    foreach (string satir in satirlar)
                    {
                        //Satırı JSON deserializasyonu ile bir nesneye dönüştür
                        Dictionary<string, string> veritabaniBilgileri = JsonConvert.DeserializeObject<Dictionary<string, string>>(satir);
                        string sikistirilmisDosyaYolu;
                        //Veritabanı bağlantısı için gerekli bilgileri al
                        string veritabaniAdresi = veritabaniBilgileri["veritabaniAdres"].Replace("/", "\\");
                        string veritabaniAdi = veritabaniBilgileri["veritabaniAdi"];
                        string kullaniciAdi = veritabaniBilgileri["kAdi"];
                        string sifre = veritabaniBilgileri["sifre"];

                        //Veritabanına bağlan
                        string connectionString = $"Data Source={veritabaniAdresi};Initial Catalog={veritabaniAdi};User ID={kullaniciAdi};Password={sifre}";
                        //Saatlik yedek alma işlemi
                        if (bool.Parse(veritabaniBilgileri["saatlik"]))
                        {
                            string saatlikYedekAdi = $"{veritabaniAdi}_{DateTime.Now.ToString("yyyy-MM-dd_HH")}-00.bak";
                            string saatlikYedekYolu = $"C:\\Yedek\\SaatlikYedek\\{saatlikYedekAdi}";
                            sikistirilmisDosyaYolu = $"C:\\Yedek\\SaatlikYedek\\{veritabaniAdi}_{DateTime.Now.ToString("yyyy-MM-dd_HH")}-00.zip";

                            // Daha önce bugün günlük yedek alınmamışsa yedekleme işlemini gerçekleştir
                            if (!File.Exists(sikistirilmisDosyaYolu))
                            {
                                //Eski .bak uzantılı dosyayı sil
                                eskiYedekBak = Directory.GetFiles(@"C:\Yedek\SaatlikYedek\", "*.bak");
                                if (eskiYedekBak.Length > 0)
                                {
                                    foreach (var item in eskiYedekBak)
                                    {
                                        File.Delete(item);
                                    }
                                }
                                //Eski zip sayısı X den fazla ise eskileri sil
                                eskiYedekBak = Directory.GetFiles(@"C:\Yedek\SaatlikYedek\", "*.zip");
                                if (eskiYedekBak.Length > 500)
                                {
                                    var siraliDosyaListesi = eskiYedekBak.OrderBy(d => File.GetCreationTime(d));

                                    int silinecekDosyaSayisi = eskiYedekBak.Length - 500;

                                    for (int i = 0; i < silinecekDosyaSayisi; i++)
                                    {
                                        File.Delete(siraliDosyaListesi.ElementAt(i));
                                    }
                                }
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand gunlukCommand = new SqlCommand($"BACKUP DATABASE [{veritabaniAdi}] TO DISK = '{saatlikYedekYolu}'", connection);
                                    await gunlukCommand.ExecuteNonQueryAsync();
                                    connection.Close();
                                }
                                using (Stream sikistirilmisDosya = File.OpenWrite(sikistirilmisDosyaYolu))
                                using (FileStream saatlikYedekDosyasi = File.OpenRead(saatlikYedekYolu))
                                {
                                    using (var writer = WriterFactory.Open(sikistirilmisDosya, ArchiveType.Zip, CompressionType.Deflate))
                                    {
                                        writer.Write(Path.GetFileName(saatlikYedekYolu), saatlikYedekDosyasi, null);
                                    }
                                }
                                //File.Delete(saatlikYedekYolu);
                            }
                        }
                        //Günlük yedek alma işlemi
                        if (bool.Parse(veritabaniBilgileri["gunluk"]))
                        {
                            string gunlukYedekAdi = $"{veritabaniAdi}_{DateTime.Now.ToString("yyyy-MM-dd-HH")}.bak";
                            string gunlukYedekYolu = $"C:\\Yedek\\GunlukYedek\\{gunlukYedekAdi}";
                            sikistirilmisDosyaYolu = $"C:\\Yedek\\GunlukYedek\\{veritabaniAdi}_{DateTime.Now.ToString("yyyy-MM-dd-HH")}.zip";
                            //Eski .bak uzantılı dosyayı sil
                            eskiYedekBak = Directory.GetFiles(@"C:\Yedek\GunlukYedek\", "*.bak");
                            if (eskiYedekBak.Length > 0)
                            {
                                foreach (var item in eskiYedekBak)
                                {
                                    File.Delete(item);
                                }
                            }
                            //Eski zip sayısı X den fazla ise eskileri sil
                            eskiYedekBak = Directory.GetFiles(@"C:\Yedek\GunlukYedek\", "*.zip");
                            if (eskiYedekBak.Length > 100)
                            {
                                var siraliDosyaListesi = eskiYedekBak.OrderBy(d => File.GetCreationTime(d));

                                int silinecekDosyaSayisi = eskiYedekBak.Length - 100;

                                for (int i = 0; i < silinecekDosyaSayisi; i++)
                                {
                                    File.Delete(siraliDosyaListesi.ElementAt(i));
                                }
                            }
                            // Daha önce bugün günlük yedek alınmamışsa yedekleme işlemini gerçekleştir
                            if (!File.Exists(sikistirilmisDosyaYolu))
                            {
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand gunlukCommand = new SqlCommand($"BACKUP DATABASE [{veritabaniAdi}] TO DISK = '{gunlukYedekYolu}'", connection);
                                    await gunlukCommand.ExecuteNonQueryAsync();
                                    connection.Close();
                                }
                                using (Stream sikistirilmisDosya = File.OpenWrite(sikistirilmisDosyaYolu))
                                using (FileStream gunlukYedekDosyasi = File.OpenRead(gunlukYedekYolu))
                                {
                                    using (var writer = WriterFactory.Open(sikistirilmisDosya, ArchiveType.Zip, CompressionType.Deflate))
                                    {
                                        writer.Write(Path.GetFileName(gunlukYedekYolu), gunlukYedekDosyasi, null);
                                    }
                                }
                                //File.Delete(gunlukYedekYolu);
                            }
                        }

                        //Haftalık yedek alma işlemi
                        if (bool.Parse(veritabaniBilgileri["haftalik"]))
                        {
                            CultureInfo culture = new CultureInfo("tr-TR");
                            CalendarWeekRule rule = culture.DateTimeFormat.CalendarWeekRule;
                            DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;
                            int haftaNumarasi = culture.Calendar.GetWeekOfYear(DateTime.Now, rule, firstDayOfWeek);
                            string haftalikYedekAdi = $"{veritabaniAdi}_{DateTime.Now.ToString("yyyy")}-{haftaNumarasi}-Hafta.bak";
                            string haftalikYedekYolu = $"C:\\Yedek\\HaftalikYedek\\{haftalikYedekAdi}";
                            sikistirilmisDosyaYolu = $"C:\\Yedek\\HaftalikYedek\\{veritabaniAdi}_{DateTime.Now.ToString("yyyy")}-{haftaNumarasi}-Hafta.zip";
                            //Eski .bak uzantılı dosyayı sil
                            eskiYedekBak = Directory.GetFiles(@"C:\Yedek\HaftalikYedek\", "*.bak");
                            if (eskiYedekBak.Length > 0)
                            {
                                foreach (var item in eskiYedekBak)
                                {
                                    File.Delete(item);
                                }
                            }
                            //Eski zip sayısı X den fazla ise eskileri sil
                            eskiYedekBak = Directory.GetFiles(@"C:\Yedek\HaftalikYedek\", "*.zip");
                            if (eskiYedekBak.Length > 50)
                            {
                                var siraliDosyaListesi = eskiYedekBak.OrderBy(d => File.GetCreationTime(d));

                                int silinecekDosyaSayisi = eskiYedekBak.Length - 50;

                                for (int i = 0; i < silinecekDosyaSayisi; i++)
                                {
                                    File.Delete(siraliDosyaListesi.ElementAt(i));
                                }
                            }
                            // Daha önce bu hafta haftalık yedek alınmamışsa yedekleme işlemini gerçekleştir
                            if (!File.Exists(sikistirilmisDosyaYolu))
                            {
                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();
                                    SqlCommand gunlukCommand = new SqlCommand($"BACKUP DATABASE [{veritabaniAdi}] TO DISK = '{haftalikYedekYolu}'", connection);
                                    await gunlukCommand.ExecuteNonQueryAsync();
                                    connection.Close();
                                }
                                using (Stream sikistirilmisDosya = File.OpenWrite(sikistirilmisDosyaYolu))
                                using (FileStream haftalikYedekDosyasi = File.OpenRead(haftalikYedekYolu))
                                {
                                    using (var writer = WriterFactory.Open(sikistirilmisDosya, ArchiveType.Zip, CompressionType.Deflate))
                                    {
                                        writer.Write(Path.GetFileName(haftalikYedekYolu), haftalikYedekDosyasi, null);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanı bağlantı bilgileri dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı yedekleme hatası: " + ex.Message);
            }
        }
    }
}
