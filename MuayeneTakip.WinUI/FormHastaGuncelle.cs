using MuayeneTakip.WinUI.Enums;

using MuayeneTakip.WinUI.ViewModel;
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

namespace MuayeneTakip.WinUI
{
    public partial class FormHastaGuncelle : Form
    {
        int _hastaId;
        HastaViewModel _vm;
        public event EventTipim Guncelledim;
        public FormHastaGuncelle(int hastaId)
        {
            InitializeComponent();
            _hastaId = hastaId;
            Guncelledim += Patlatma;
        }

        private void FormHastaGuncelle_Load(object sender, EventArgs e)
        {
            cmbCinsiyet.ListControlDoldur<CinsiyetEnum>();
            cmbKanGrubu.ListControlDoldur<KanGrubuEnum>();
            cmbMedeniHal.ListControlDoldur<MedeniHalEnum>();
            OgeleriDoldur();
        }
        private void OgeleriDoldur()
        {
            SqlCommand cmd = new SqlCommand(@"select
                h.ID HastaId,
                h.TcKimlikNo,
	            h.Ad,
                h.Soyad,
	            h.CinsiyetEnum Cinsiyet,
                h.DogumTarihi,
                i.Telefon,
	            hd.Notlar,
                i.Adres,
                h.KanGrubuEnum KanGrubu,
                hd.MedeniHalEnum MedeniHal,
                hd.ResimYolu
            from Hasta h
            left join HastaDetay hd on h.ID = hd.HastaID
            left join Iletisim i on h.ID = i.HastaID
            where h.ID=" + _hastaId, ConnectionHelper.Cnn);


            _vm = new HastaViewModel();
            try
            {
                if (ConnectionHelper.Cnn.State != ConnectionState.Open)
                {
                    ConnectionHelper.Cnn.Open();
                }
                var dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int sayac = 0;
                    while (dr.Read())
                    {
                        sayac++;

                        _vm.HastaID = (int)dr["HastaId"];
                        _vm.Ad = dr["Ad"].ToString();
                        _vm.Soyad = dr["Soyad"].ToString();
                        _vm.Cinsiyet = (CinsiyetEnum)(byte)dr["Cinsiyet"];
                        _vm.Notlar = dr["Notlar"].ToString();
                        _vm.TcKimlikNo = dr["TcKimlikNo"].ToString();
                        _vm.Telefon = dr["Telefon"].ToString();
                        _vm.Adres = dr["Adres"].ToString();
                        _vm.DogumTarihi = Convert.ToDateTime(dr["DogumTarihi"]);
                        _vm.KanGrubu = (KanGrubuEnum)(byte)dr["KanGrubu"];
                        _vm.MedeniHal = (MedeniHalEnum)(byte)dr["MedeniHal"];
                        _vm.ResimYolu = dr["ResimYolu"].ToString();

                    }

                    dr.Close();
                    if (sayac > 1)
                    {
                        throw new Exception("Aynı id ile birden fazla okuma gerçekleşti");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata nedeniyle okuma işlemi tamamlanamadı.");
                return;
            }
            finally
            {
                ConnectionHelper.Cnn.Close();
            }

            txtTcKimlikNo.Text = _vm.TcKimlikNo;
            txtAd.Text = _vm.Ad;
            txtSoyad.Text = _vm.Soyad;
            txtAdres.Text = _vm.Adres;
            txtNotlar.Text = _vm.Notlar;
            txtTelefon.Text = _vm.Telefon;
            cmbCinsiyet.SelectedValue = (int)_vm.Cinsiyet;
            cmbKanGrubu.SelectedValue = (int)_vm.KanGrubu;
            cmbMedeniHal.SelectedValue = (int)_vm.MedeniHal;
            pcbResim.ImageLocation = _vm.ResimYolu;
            dtpDogumTarihi.Value = _vm.DogumTarihi;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            _vm.TcKimlikNo= txtTcKimlikNo.Text;
            _vm.Ad= txtAd.Text;
            _vm.Soyad= txtSoyad.Text;
            _vm.Adres=txtAdres.Text ;
            _vm.Notlar= txtNotlar.Text ;
            _vm.Telefon= txtTelefon.Text ;
            _vm.Cinsiyet=(CinsiyetEnum) cmbCinsiyet.SelectedValue;
            _vm.KanGrubu=(KanGrubuEnum) cmbKanGrubu.SelectedValue;
            _vm.MedeniHal=(MedeniHalEnum)cmbMedeniHal.SelectedValue ;
            _vm.ResimYolu= pcbResim.ImageLocation;
            _vm.DogumTarihi=dtpDogumTarihi.Value.Date;

            SqlCommand cmd = new SqlCommand("sp_HastaGuncelle",ConnectionHelper.Cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", _vm.HastaID);
            cmd.Parameters.AddWithValue("@Tc", _vm.TcKimlikNo);
            cmd.Parameters.AddWithValue("@Ad", _vm.Ad);
            cmd.Parameters.AddWithValue("@Soyad", _vm.Soyad);
            cmd.Parameters.AddWithValue("@DogumTarihi", _vm.DogumTarihi);
            cmd.Parameters.AddWithValue("@Cinsiyet", _vm.Cinsiyet);
            cmd.Parameters.AddWithValue("@KanGrubu", _vm.KanGrubu);
            cmd.Parameters.AddWithValue("@MedeniHal", _vm.MedeniHal);
            cmd.Parameters.AddWithValue("@Adres", _vm.Adres);
            cmd.Parameters.AddWithValue("@Telefon", _vm.Telefon);
            cmd.Parameters.AddWithValue("@Notlar", _vm.Notlar);
            cmd.Parameters.AddWithValue("@ResimYolu", _vm.ResimYolu);

            try
            {
                if (ConnectionHelper.Cnn.State != ConnectionState.Open)
                {
                    ConnectionHelper.Cnn.Open();
                }
                int ess=cmd.ExecuteNonQuery();
                Guncelledim();
                MessageBox.Show("Güncellem Başarılı");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata nedeniyle güncelleme işlemi tamamlanamadı.");
            }
            finally
            {
                ConnectionHelper.Cnn.Close();
            }
        }
        private void Patlatma()
        {

        }
    }
}
