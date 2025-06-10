using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace aplikasi_restoran
{
    public partial class Form4 : Form
    {
        string database = "server = localhost; database=restoran; uid=root; pwd=''";
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        private MySqlCommand command;
        public Form4()
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
        public void Query(string query)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(query, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ali)
            {
                MessageBox.Show(ali.Message);
            }
            finally
            {
                koneksi.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Query("insert into menumakanan values('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox3.Text + "')");
            MessageBox.Show("Menambah Menu Makanan Berhasil");
            BersihkanForm();
            makanan();
            minuman();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Query("insert into menuminuman values('" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "')");
            MessageBox.Show("Menambah Menu Minuman Berhasil");
            BersihkanForm();
            makanan();
            minuman();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            makanan();
            minuman();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Input untuk makanan
                string namaMakanan = textBox1.Text; // Nama makanan
                string hargaBaruMakanan = textBox2.Text; // Harga baru makanan
                string stokTambahMakanan = textBox3.Text; // Jumlah stok tambahan makanan

                // Input untuk minuman
                string namaMinuman = textBox4.Text; // Nama minuman
                string hargaBaruMinuman = textBox5.Text; // Harga baru minuman
                string stokTambahMinuman = textBox6.Text; // Jumlah stok tambahan minuman

                // Menambah stok dan mengupdate harga makanan
                if (!string.IsNullOrEmpty(namaMakanan))
                {
                    string queryMakanan = "UPDATE menumakanan SET ";
                    if (!string.IsNullOrEmpty(hargaBaruMakanan))
                        queryMakanan += $"harga = '{hargaBaruMakanan}'";

                    if (!string.IsNullOrEmpty(stokTambahMakanan))
                    {
                        queryMakanan += !string.IsNullOrEmpty(hargaBaruMakanan) ? ", " : "";
                        queryMakanan += $"stok = stok + {stokTambahMakanan}";
                    }
                    queryMakanan += $" WHERE nama = '{namaMakanan}'";
                    Query(queryMakanan);

                    MessageBox.Show("Data makanan berhasil diperbarui.");
                }

                // Menambah stok dan mengupdate harga minuman
                if (!string.IsNullOrEmpty(namaMinuman))
                {
                    string queryMinuman = "UPDATE menuminuman SET ";
                    if (!string.IsNullOrEmpty(hargaBaruMinuman))
                        queryMinuman += $"harga = '{hargaBaruMinuman}'";

                    if (!string.IsNullOrEmpty(stokTambahMinuman))
                    {
                        queryMinuman += !string.IsNullOrEmpty(hargaBaruMinuman) ? ", " : "";
                        queryMinuman += $"stok = stok + {stokTambahMinuman}";
                    }
                    queryMinuman += $" WHERE nama = '{namaMinuman}'";
                    Query(queryMinuman);

                    MessageBox.Show("Data minuman berhasil diperbarui.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                // Refresh data di DataGridView
                makanan();
                minuman();

                //Membersihkan Textbox
                BersihkanForm();
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Mengambil nama makanan dan minuman dari TextBox
                string namaMakanan = textBox1.Text; // Nama makanan dari TextBox1
                string namaMinuman = textBox4.Text; // Nama minuman dari TextBox4

                // Hapus makanan berdasarkan nama
                if (!string.IsNullOrEmpty(namaMakanan))
                {
                    string queryMakanan = $"DELETE FROM menumakanan WHERE nama = '{namaMakanan}'";
                    Query(queryMakanan);
                    MessageBox.Show("Menu makanan berhasil dihapus.");
                }

                // Hapus minuman berdasarkan nama
                if (!string.IsNullOrEmpty(namaMinuman))
                {
                    string queryMinuman = $"DELETE FROM menuminuman WHERE nama = '{namaMinuman}'";
                    Query(queryMinuman);
                    MessageBox.Show("Menu minuman berhasil dihapus.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}");
            }
            finally
            {
                // Refresh data di DataGridView
                makanan();
                minuman();
                BersihkanForm();
            }

        }
        private void BersihkanForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void updateStokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menu update harga dan stok digunakan untuk mengubah harga menu yang telah ada dan menambah stok.\n" +
                "cara penggunaan:\n\n" +
                "Update harga:\n" +
                "1. menginput nama menu yang ingin diupdate\n" +
                "2. masukan harga baru\n" +
                "3. konfirmasi dengan menekan button update harga dan stok\n\n" +
                "Update stok:\n" +
                "1. menginput nama menu yang ingin ditambah stoknya\n" +
                "2. masukan Stok yang ingin ditambah\n" +
                "3. konfirmasi dengan menekan button update harga dan stok\n\n" +
                "keduanya bisa digabungkan secara bersamaan untuk mengubah harga dan menambah stok", "Informasi", MessageBoxButtons.OK);
        }

        private void tambahMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tambah menu digunakan untuk menambah menu makanan dan minuman yang ingin di tambah dengan mengisi nama harga dan stok.\n\n" +
                "Cara penggunaan:\n1. masukan nama makanan/minuman sesuai dengan keinginan" +
                "\n2. memasukan harga" +
                "\n3. memasukan stok" +
                "\n4. jika sudah tekan button tamabah makanan/minuman agar menu bisa di tambahkan", "Informasi", MessageBoxButtons.OK);
        }

        private void lihatMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lihat menu digunakan untuk menampilkan semua data menu yang telah ditambah", "Informasi", MessageBoxButtons.OK);
        }

        private void deleteMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteMenuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Delete menu digunakan untuk menghapus menu yang ada\n" +
                "cara penggunaan:\n" +
                "1. masukan nama menu makanan/minuman yang ingin dihapus\n" +
                "2. konfirmasi dengan menekan button delete menu", "Informasi", MessageBoxButtons.OK);
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
    }
}
