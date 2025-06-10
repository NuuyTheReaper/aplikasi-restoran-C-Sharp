using MySql.Data.MySqlClient;
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
    public partial class Form5 : Form
    {
        string database = "server = localhost; database=restoran; uid=root; pwd=''";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        private MySqlCommand command;
        public Form5()
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
        public DataTable laporan()
        {
            string sql = "SELECT * FROM laporan";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql, koneksi);
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt); // Isi DataTable

                // Tangani nilai NULL pada kolom tanggal
                foreach (DataRow row in dt.Rows)
                {
                    if (row["tanggal"] == DBNull.Value)  // Cek jika tanggal NULL
                    {
                        row["tanggal"] = DateTime.MinValue; // Tentukan nilai default jika NULL
                    }
                }

                dataGridView1.DataSource = dt;
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            disconek();
            return dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            laporan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Ambil tanggal yang dipilih dari DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Query untuk mencari data berdasarkan tanggal yang dipilih
            string query = "SELECT * FROM laporan WHERE tanggal = @tanggal";

            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(query, koneksi);
                cmd.Parameters.AddWithValue("@tanggal", selectedDate); // Tambahkan parameter tanggal untuk mencegah SQL Injection

                // Gunakan MySqlDataAdapter untuk mengisi DataTable dengan hasil query
                adp = new MySqlDataAdapter(cmd);
                adp.Fill(dt);  // Isi DataTable dengan data yang ditemukan

                // Tampilkan data pada DataGridView
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mencari data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                disconek(); // Pastikan koneksi ditutup
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Ambil tanggal yang dipilih dari DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Konfirmasi penghapusan berdasarkan tanggal
            DialogResult result = MessageBox.Show($"Apakah Anda yakin ingin menghapus data dengan tanggal {selectedDate.ToShortDateString()}?",
                                                  "Konfirmasi Penghapusan",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Query untuk menghapus data berdasarkan tanggal yang dipilih
                string query = "DELETE FROM laporan WHERE tanggal = @tanggal";
                try
                {
                    konek();
                    cmd = new MySqlCommand(query, koneksi);
                    cmd.Parameters.AddWithValue("@tanggal", selectedDate); // Tambahkan parameter tanggal untuk mencegah SQL Injection

                    cmd.ExecuteNonQuery(); // Eksekusi query untuk menghapus data berdasarkan tanggal
                    MessageBox.Show($"Semua data dengan tanggal {selectedDate.ToShortDateString()} berhasil dihapus.",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    disconek(); // Pastikan koneksi ditutup
                }
            }
            else
            {
                MessageBox.Show("Penghapusan data dibatalkan.", "Informasi", MessageBoxButtons.OK);
            }
            laporan();
        }

        private void lihatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu lihat digunakan untuk menampilkan semua data transaksi", "Informasi", MessageBoxButtons.OK);
        }

        private void cariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu cari digunakan untuk mencari semua data transaksi yang di tentukan sesuai dengan tanggal", "Informasi", MessageBoxButtons.OK);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu delete digunakan untuk menghapus semua data transaksi yang di tentukan sesuai dengan tanggal", "Informasi", MessageBoxButtons.OK);
        }

        private void kembaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu kembali digunakan untuk kembali ke form sebelumnya", "Informasi", MessageBoxButtons.OK);
        }

        private void keluarAplikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult pilih = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (pilih == DialogResult.Yes)
            {
                MessageBox.Show("Terimakasih telah menggunakan aplikasi restoran kami", "keluar");
                Application.Exit();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {






        }
    }
}
