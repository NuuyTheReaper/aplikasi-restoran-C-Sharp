using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplikasi_restoran
{
    public partial class Form2 : Form
    {
        string database = "server = localhost; database=restoran; uid=root; pwd=''";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        private MySqlCommand command;
        public Form2()
        {
            InitializeComponent();
        }
        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }
        public void disconek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Close();
        }

        // Fungsi untuk mendapatkan ID otomatis
        private string GetNewId()
        {
            string query = "SELECT MAX(id) FROM laporan"; // Ganti "laporan" dengan nama tabel yang menyimpan ID
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int lastId = Convert.ToInt32(result);
                    return (lastId + 1).ToString(); // ID baru adalah ID terakhir + 1
                }
                else
                {
                    return "1"; // Jika belum ada data, ID pertama adalah 1
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "1"; // Kembalikan ID default 1 jika terjadi error
            }
            finally
            {
                disconek();
            }
        }

        public DataTable makanan()
        {
            string sql = "select * from menumakanan";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            disconek();
            return dt;
        }
        public DataTable minuman()
        {
            string sql = "select * from menuminuman";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView2.DataSource = dt;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            disconek();
            return dt;
        }
        // Fungsi untuk memperbarui stok makanan
        private void UpdateStokMakanan(string namaMakanan, int stokBaru, MySqlTransaction transaction)
        {
            string query = "UPDATE menumakanan SET stok = @stok WHERE nama = @nama";
            try
            {
                cmd = new MySqlCommand(query, koneksi, transaction);
                cmd.Parameters.AddWithValue("@stok", stokBaru);
                cmd.Parameters.AddWithValue("@nama", namaMakanan);

                cmd.ExecuteNonQuery(); // Perbarui stok makanan
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal memperbarui stok makanan: {ex.Message}");
            }
        }

        // Fungsi untuk memperbarui stok minuman
        private void UpdateStokMinuman(string namaMinuman, int stokBaru, MySqlTransaction transaction)
        {
            string query = "UPDATE menuminuman SET stok = @stok WHERE nama = @nama";
            try
            {
                cmd = new MySqlCommand(query, koneksi, transaction);
                cmd.Parameters.AddWithValue("@stok", stokBaru);
                cmd.Parameters.AddWithValue("@nama", namaMinuman);

                cmd.ExecuteNonQuery(); // Perbarui stok minuman
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal memperbarui stok minuman: {ex.Message}");
            }
        }

        // Fungsi untuk mendapatkan harga makanan dari tabel database
        private int GetHargaMakanan(string namaMakanan)
        {
            string query = "SELECT harga FROM menumakanan WHERE nama = @nama";
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@nama", namaMakanan);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil harga makanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                disconek();
            }
        }

        // Fungsi untuk mendapatkan harga minuman dari tabel database
        private int GetHargaMinuman(string namaMinuman)
        {
            string query = "SELECT harga FROM menuminuman WHERE nama = @nama";
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@nama", namaMinuman);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil harga minuman: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                disconek();
            }
        }

        // Fungsi untuk mendapatkan stok makanan dari tabel database
        private int GetStokMakanan(string namaMakanan)
        {
            string query = "SELECT stok FROM menumakanan WHERE nama = @nama";
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@nama", namaMakanan);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil stok makanan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                disconek();
            }
        }

        // Fungsi untuk mendapatkan stok minuman dari tabel database
        private int GetStokMinuman(string namaMinuman)
        {
            string query = "SELECT stok FROM menuminuman WHERE nama = @nama";
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@nama", namaMinuman);

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengambil stok minuman: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                disconek();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult pilih = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (pilih == DialogResult.Yes)
            {
                MessageBox.Show("Terimakasih telah menggunakan aplikasi restoran kami", "keluar");
                Form1 login = new Form1(); // Form2 untuk Pelanggan
                login.Show();
                this.Hide();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            makanan();
            minuman();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Validasi input
            if (string.IsNullOrEmpty(labelid.Text) || string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi.");
                return;
            }

            string id = labelid.Text;
            string nama = textBox2.Text;
            string makan = textBox3.Text;
            string minum = textBox5.Text;
            int jumlahMakanan;
            int jumlahMinum;

            // Validasi jumlah makanan dan minuman
            if (!int.TryParse(textBox4.Text, out jumlahMakanan) || !int.TryParse(textBox6.Text, out jumlahMinum))
            {
                MessageBox.Show("Jumlah makanan dan minuman harus berupa angka.");
                return;
            }

            // Ambil harga dari database
            int hargaMakanan = GetHargaMakanan(makan);
            int hargaMinuman = GetHargaMinuman(minum);

            if (hargaMakanan == 0 || hargaMinuman == 0)
            {
                MessageBox.Show("Pilihan makanan atau minuman tidak valid.");
                return;
            }

            // Ambil stok yang tersedia untuk makanan dan minuman
            int stokMakanan = GetStokMakanan(makan);
            int stokMinuman = GetStokMinuman(minum);

            if (stokMakanan < jumlahMakanan || stokMinuman < jumlahMinum)
            {
                MessageBox.Show("Stok tidak cukup untuk transaksi ini.");
                return;
            }

            // Hitung total
            int totalMakanan = hargaMakanan * jumlahMakanan;
            int totalMinum = hargaMinuman * jumlahMinum;
            int total = totalMakanan + totalMinum;

            // Ambil tanggal dari DateTimePicker
            DateTime tanggalTransaksi = dateTimePicker1.Value;

            // Rincian transaksi
            string rincian = $"--------------- Rincian Pembelian --------------\n" +
                             $"Tanggal                  : {tanggalTransaksi.ToShortDateString()}\n\n" +
                             $"ID Pelanggan         : CUST-{id}\n" +
                             $"Nama Pelanggan    : {nama}\n" +
                             $"Makanan               : {makan} x {jumlahMakanan} = Rp.{totalMakanan}\n" +
                             $"Minuman               : {minum} x {jumlahMinum} = Rp.{totalMinum}\n" +
                             $"Catatan               : {textBox7.Text}\n" +
                             $"=============================\n" +
                             $"Total Pembelian         : Rp.{total}\n\n";

            DialogResult result = MessageBox.Show(rincian + 
                            "\n                  Ingin melanjutkan transaksi?",
                            "Konfirmasi Pembelian",
                             MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Pastikan koneksi terbuka sebelum transaksi dimulai


                konek();

                // Gunakan transaksi
                using (var transaction = koneksi.BeginTransaction()) // Memulai transaksi
                {
                    try
                    {
                        // Simpan transaksi
                        SimpanTransaksi(id, nama, makan, jumlahMakanan, minum, jumlahMinum, total, tanggalTransaksi, transaction);

                        // Perbarui stok makanan dan minuman
                        UpdateStokMakanan(makan, stokMakanan - jumlahMakanan, transaction);
                        UpdateStokMinuman(minum, stokMinuman - jumlahMinum, transaction);

                        // Commit transaksi jika tidak ada error
                        transaction.Commit();
                        MessageBox.Show("Transaksi berhasil!", "Sukses", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaksi jika terjadi error
                        transaction.Rollback();
                        MessageBox.Show($"Transaksi gagal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        disconek(); // Pastikan koneksi ditutup setelah transaksi selesai
                    }
                }
            }
            else
            {
                MessageBox.Show("Transaksi dibatalkan.", "Informasi", MessageBoxButtons.OK);
            }
        }

        // Fungsi untuk menyimpan transaksi ke dalam tabel database
        private void SimpanTransaksi(string id, string nama, string makan, int jumlahMakanan, string minum, int jumlahMinum, int total, DateTime tanggalTransaksi, MySqlTransaction transaction)
        {
            string query = "INSERT INTO laporan (id, `nama`, makan, jumlahmakan, minum, jumlahminuman, total, tanggal) " +
                           "VALUES (@id, @nama, @makan, @jumlahMakanan, @minum, @jumlahMinuman, @total, @tanggal)";
            try
            {
                cmd = new MySqlCommand(query, koneksi, transaction);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@makan", makan);
                cmd.Parameters.AddWithValue("@jumlahMakanan", jumlahMakanan);
                cmd.Parameters.AddWithValue("@minum", minum);
                cmd.Parameters.AddWithValue("@jumlahMinuman", jumlahMinum);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@tanggal", tanggalTransaksi);

                cmd.ExecuteNonQuery(); // Menyimpan data transaksi
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menyimpan transaksi: {ex.Message}");
            }
        }

        
        

        private void button3_Click(object sender, EventArgs e)
        {
            BersihkanForm();
        }
        // Fungsi untuk membersihkan form
        private void BersihkanForm()
        {
            labelid.Text = GetNewId();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            labelid.Text = GetNewId();
            makanan();
            minuman();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
