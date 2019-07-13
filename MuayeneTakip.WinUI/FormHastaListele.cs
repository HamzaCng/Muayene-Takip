using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MuayeneTakip.WinUI.Enums;

using MuayeneTakip.WinUI.ViewModel;

namespace MuayeneTakip.WinUI
{
    public partial class FormHastaListele : Form
    {
        public FormHastaListele()
        {
            InitializeComponent();
            txtTcKimlikNo.KeyPress += Helper.OnlyNumber;
            txtAdSoyad.KeyPress += Helper.OnlyLetter;
            txtTelefon.KeyPress += Helper.OnlyNumber;
        }

        private void FormHastaListele_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.ListControlDoldur<CinsiyetEnum>();
            cmbKanGrubu.ListControlDoldur<KanGrubuEnum>();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Helper.ControlTemizle(grpAramaParametreleri);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            DataGridYukle();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            FormHastaEkle frm = new FormHastaEkle();
            frm.MdiParent = this.MdiParent;
            frm.KayitYapildi += DataGridYukle;
            frm.Show();
        }
        private void DataGridYukle()
        {
            SqlCommand cmd = new SqlCommand(@"select
            h.ID HastaId,
            h.TcKimlikNo,
	        h.Ad + ' ' + h.Soyad AdSoyad,
	        h.CinsiyetEnum Cinsiyet,
            i.Telefon,
	        hd.Notlar
        from Hasta h
            left join HastaDetay hd on h.ID = hd.HastaID
            left join Iletisim i on h.ID = i.HastaID", ConnectionHelper.Cnn);

            string where = "";
            if (!string.IsNullOrWhiteSpace(txtTcKimlikNo.Text))
            {
                where += where.Length == 0 ? " where " : " and ";
                where += "h.TcKimlikNo = @TcKimlikNo ";
                cmd.Parameters.AddWithValue("@TcKimlikNo", txtTcKimlikNo.Text);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtAdSoyad.Text))
                {
                    where += where.Length == 0 ? " where " : " and ";
                    where += "h.Ad+' '+h.Soyad like '%'+@AdSoyad+'%' ";
                    cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
                }
                if (!string.IsNullOrWhiteSpace(txtTelefon.Text))
                {
                    where += where.Length == 0 ? " where " : " and ";
                    where += "i.Telefon=@Telefon";
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                }
                if (cmbCinsiyet.SelectedIndex != -1)
                {
                    where += where.Length == 0 ? " where " : " and ";
                    where += " h.CinsiyetEnum=@Cinsiyet";
                    cmd.Parameters.AddWithValue("@Cinsiyet", (int)cmbCinsiyet.SelectedValue);
                }
                if (cmbKanGrubu.SelectedIndex != -1)
                {
                    where += where.Length == 0 ? " where " : " and ";
                    where += " h.KanGrubuEnum=@KanGrubu";
                    cmd.Parameters.AddWithValue("@KanGrubu", (int)cmbKanGrubu.SelectedValue);
                }
            }
            cmd.CommandText += where;




            List<HastaBilgileriVM> hastalar = new List<HastaBilgileriVM>();
            try
            {
                if (ConnectionHelper.Cnn.State != ConnectionState.Open)
                {
                    ConnectionHelper.Cnn.Open();
                }
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        HastaBilgileriVM vm = new HastaBilgileriVM();

                        vm.HastaID = (int)dr["HastaId"];
                        vm.AdSoyad = dr["AdSoyad"].ToString();
                        vm.Cinsiyet = (CinsiyetEnum)(byte)dr["Cinsiyet"];
                        vm.Notlar = dr["Notlar"].ToString();
                        vm.TcKimlikNo = dr["TcKimlikNo"].ToString();
                        vm.Telefon = dr["Telefon"].ToString();

                        hastalar.Add(vm);
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata nedeniyle okuma işlemi tamamlanamadı.");
            }
            finally
            {
                ConnectionHelper.Cnn.Close();
            }

            dgvHastalar.DataSource = hastalar;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silme işlemi yapabilmek için ilk önce silinecek veri seçilmelidir.");
                return;
            }

            int hastaId = (int)dgvHastalar.SelectedRows[0].Cells[0].Value;

            DialogResult result = MessageBox.Show("Seçilen öge silinecektir. Emin misiniz?", "Dikkat", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }            

            SqlCommand cmd1 = new SqlCommand("delete from Iletisim where HastaID=" + hastaId, ConnectionHelper.Cnn);
            SqlCommand cmd2=new SqlCommand("delete from HastaDetay where HastaID=" + hastaId, ConnectionHelper.Cnn);
            SqlCommand cmd3 = new SqlCommand("delete from Hasta where ID=" + hastaId, ConnectionHelper.Cnn);

            if (ConnectionHelper.Cnn.State != ConnectionState.Open)
            {
                ConnectionHelper.Cnn.Open();
            }

            var tran = ConnectionHelper.Cnn.BeginTransaction();
            cmd1.Transaction = tran;
            cmd2.Transaction = tran;
            cmd3.Transaction = tran;

            try
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                tran.Commit();
                DataGridYukle();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show("Bir hata nedeniyle silme işlemi gerçekleşemememişti.");
            }
            finally
            {
                ConnectionHelper.Cnn.Close();
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvHastalar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silme işlemi yapabilmek için ilk önce silinecek veri seçilmelidir.");
                return;
            }

            int hastaId = (int)dgvHastalar.SelectedRows[0].Cells[0].Value;

            FormHastaGuncelle frm = new FormHastaGuncelle(hastaId);
            frm.MdiParent = this.MdiParent;
            frm.Guncelledim += DataGridYukle;
            frm.Show();
        }
    }
}
