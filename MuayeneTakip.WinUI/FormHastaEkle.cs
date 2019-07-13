using MuayeneTakip.WinUI.Enums;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuayeneTakip.WinUI
{
    
    public partial class FormHastaEkle : Form
    {       
        public event EventTipim KayitYapildi;
        public FormHastaEkle()
        {
            InitializeComponent();
            KayitYapildi += Patlatma;
            txtTcKimlikNo.KeyPress += Helper.OnlyNumber;
            pcbResim.DoubleClick += Helper.ResimYukle;

        }
        private void FormHastaEkle_Load(object sender, EventArgs e)
        {
            //Helper.ListControlDoldur<CinsiyetEnum>(cmbCinsiyet);
            //ListBox abc = new ListBox();
            //abc.ListControlDoldur<CinsiyetEnum>();
            cmbCinsiyet.ListControlDoldur<CinsiyetEnum>();
            cmbKanGrubu.ListControlDoldur<KanGrubuEnum>();
            cmbMedeniHal.ListControlDoldur<MedeniHalEnum>();
        }

        private void Alafortanfoni(object sender, EventArgs e)
        {            
            #region Validation
            string hataMesaji = "";
            if (string.IsNullOrWhiteSpace(txtTcKimlikNo.Text))
            {
                hataMesaji+="TC Kimlik Numarası boş geçilemez.\n";              
            }

            if (string.IsNullOrWhiteSpace(txtAd.Text))
            {
                hataMesaji += "Ad boş geçilemez.\n";
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                hataMesaji += "Soyad boş geçilemez.\n";           
            }

            if(hataMesaji.Length>0)
            {
                MessageBox.Show(hataMesaji);
                return;
            }
            #endregion

            #region OnayAl
            DialogResult result = MessageBox.Show(txtAd.Text+" "+txtSoyad.Text+" isimli hasta kaydedilecektir. Emin misiniz?","Dikkat",MessageBoxButtons.YesNo);
            if(result!=DialogResult.Yes)
            {
                return;
            }
            #endregion

            //todo: burada kaydetmeye yönelik kodları yazacağız. Farzedelimki kayıt başarılı oldu.
            SqlCommand cmd = new SqlCommand(
                "insert into Hasta values(@TcKimlikNo, @Ad, @Soyad, @DogumTarihi, @Cinsiyet, @KanGrubu, 0) " +
                "insert into HastaDetay values(@MedeniHal,@ResimYolu,@Notlar,Scope_Identity()) " +
                "insert into Iletisim values(@Telefon,@Adres,IDENT_CURRENT('Hasta'))"
                , ConnectionHelper.Cnn);
            cmd.Parameters.AddWithValue("@TcKimlikNo",txtTcKimlikNo.Text);
            cmd.Parameters.AddWithValue("@Ad",txtAd.Text);
            cmd.Parameters.AddWithValue("@Soyad",txtSoyad.Text);
            cmd.Parameters.AddWithValue("@DogumTarihi",dtpDogumTarihi.Value.Date);
            cmd.Parameters.AddWithValue("@Cinsiyet",(byte)(int)cmbCinsiyet.SelectedValue);
            cmd.Parameters.AddWithValue("@KanGrubu",(byte)(int)cmbKanGrubu.SelectedValue);
            cmd.Parameters.AddWithValue("@MedeniHal",(byte)(int)cmbMedeniHal.SelectedValue);

            if(pcbResim.ImageLocation!=null)
            {
                cmd.Parameters.AddWithValue("@ResimYolu", pcbResim.ImageLocation);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ResimYolu",  DBNull.Value);
            }
            
            cmd.Parameters.AddWithValue("@Notlar",txtNotlar.Text);
            cmd.Parameters.AddWithValue("@Telefon",txtTelefon.Text);
            cmd.Parameters.AddWithValue("@Adres",txtAdres.Text);

            if(ConnectionHelper.Cnn.State!=ConnectionState.Open)
            {
                ConnectionHelper.Cnn.Open();
            }
            var transaction= ConnectionHelper.Cnn.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                cmd.Transaction = transaction;
                int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                if(etkilenenSatirSayisi==0)
                {
                    throw new Exception("Herhangi kayıt işlemi gerçekleşmedi.");
                }
                transaction.Commit();
                KayitYapildi();
                MessageBox.Show("Kayıt Başarılı");
                this.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Herhangi hata nedeniyle kayıt işlemi gerçekleşmedi.");
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
