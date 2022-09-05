using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApplication_Zach
{
    public class Helper
    {
        public void TextBoxChanged(TextBox txt, Label label)
        {
            if (txt.Text.Equals(""))
            {
                label.Visibility = Visibility.Visible;
            }
            else
            {
                label.Visibility = Visibility.Hidden;
            }
        }

    }
}
