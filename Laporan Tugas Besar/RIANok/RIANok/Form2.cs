using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RIANok
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();
        }
        SqlConnection Conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string qry;

        private void Form2_Load(object sender, EventArgs e)
        {
            Conn.ConnectionString = "Data Source = DESKTOP-J1DNFS8\\SQLEXPRESS; Initial Catalog=Vapor; Integrated Security=True";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            double bpnanas, bpanggur, bpstroberi, bpkopi, bptotalbiaya;
            double hargaNn, hargaAg, hargaSt, hargaKp, bptotalpembayaran;


            bpnanas = double.Parse(nanas.Text);
            bpanggur = double.Parse(anggur.Text);
            bpstroberi = double.Parse(stroberi.Text);
            bpkopi = double.Parse(kopi.Text);


            hargaNn = bpnanas * 50000;
            hargaAg = bpanggur * 60000;
            hargaSt = bpstroberi * 70000;
            hargaKp = bpkopi * 80000;

            bptotalbiaya = hargaNn + hargaAg + hargaSt + hargaKp;


            totalbiaya.Text = "Rp." + bptotalbiaya.ToString("N");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            double bpnanas, bpanggur, bpstroberi, bpkopi, bptotalbiaya, bpuang_byr, bpbiayapajak, bpkembalian;
            double hargaNn, hargaAg, hargaSt, hargaKp, bptotalpembayaran;


            bpnanas = double.Parse(nanas.Text);
            bpanggur = double.Parse(anggur.Text);
            bpstroberi = double.Parse(stroberi.Text);
            bpkopi = double.Parse(kopi.Text);
            bpuang_byr = double.Parse(uang_byr.Text);


            hargaNn = bpnanas * 50000;
            hargaAg = bpanggur * 60000;
            hargaSt = bpstroberi * 70000;
            hargaKp = bpkopi * 80000;

            bptotalbiaya = hargaNn + hargaAg + hargaSt + hargaKp;
            bpbiayapajak = bptotalbiaya * 0.1;

            bptotalpembayaran = bptotalbiaya + bpbiayapajak;
            bpkembalian = bpuang_byr - bptotalpembayaran;

            totalbiaya.Text = "Rp." + bptotalbiaya.ToString("N");
            biayapajak.Text = "Rp." + bpbiayapajak.ToString("N");
            totalbiaya.Text = "Rp." + bptotalpembayaran.ToString("N");
            kembalian.Text = "Rp." + bpkembalian.ToString("N");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "SELECT*FROM tb_vapor";
                cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandText = qry;
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dg1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                da.Dispose();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "DELETE FROM tb_vapor WHERE NAMA = " + dg1.CurrentRow.Cells["NAMA"].FormattedValue;
                cmd.Connection = Conn;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Conn.Open();
                cmd.ExecuteNonQuery();
                button4_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                qry = "INSERT INTO tb_vapor (NAMA,TANGGAL,TOTAL BIAYA,NANAS,ANGGUR,STROBERI,KOPI,BAYAR,BIAYA PAJAK,KEMBALIAN)VALUES('" + nama.Text + "','" + tglbeli.Text + "','"
                + totalbiaya.Text + "','" + nanas.Text + "','" + anggur.Text + "','" + stroberi.Text + "','" + kopi.Text + "','" + uang_byr.Text + "','" + biayapajak.Text + "','" + kembalian.Text + "')";
                cmd.Connection = Conn;
                cmd.CommandText = qry;
                MessageBox.Show("Berhasil Disimpan");
                Conn.Open();
                cmd.ExecuteNonQuery();
                button4_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login X = new Login();
            X.Show();
            this.Hide();
        }
    }
}
