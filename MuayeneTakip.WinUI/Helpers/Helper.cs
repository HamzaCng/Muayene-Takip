using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MuayeneTakip.WinUI
{
    public delegate void EventTipim();
    static class Helper
    {
       public static List<ListItem> EnumToListItems<T>()
        {
           return ((T[])Enum.GetValues(typeof(T))).Select(e => new ListItem
            {
                Text = e.ToString(),
                Value = Convert.ToInt32(e)
            }).ToList();           
        }
        public static void ListControlDoldur<TEnum>(this ListControl listControl)
        {
            var listItems = EnumToListItems<TEnum>();
            listControl.DisplayMember = "Text";
            listControl.ValueMember = "Value";
            listControl.DataSource = listItems;
            listControl.SelectedIndex = -1;
        }
        public static void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        public static void OnlyLetter(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        public static void ResimYukle(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Resim Dosyaları|*.jpeg;*.png;*.gif;*.jpg|Tüm Dosyalar|*.*";
            DialogResult result = fd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }
            PictureBox pcb = sender as PictureBox;
            pcb.SizeMode = PictureBoxSizeMode.StretchImage;
            //resmi resim sunucusuna taşı ve resmin boyutunu adını değiştir.
            pcb.ImageLocation = fd.FileName;
        }
        public static void ControlTemizle(Control control)
        {
            if(control is TextBox)
            {
                control.Text = null;
            }
            else if(control is ComboBox)
            {
                ComboBox cmb = ((ComboBox)control);
                cmb.SelectedIndex = -1;
            }
            else if(control.Controls.Count>0)
            {
                foreach (Control childControl in control.Controls)
                {
                    ControlTemizle(childControl);
                }
            }
        }
    }
}
