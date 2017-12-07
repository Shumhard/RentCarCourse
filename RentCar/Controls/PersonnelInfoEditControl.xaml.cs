using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RentCar.Controls
{
    /// <summary>
    /// Логика взаимодействия для PersonnelInfoEdit.xaml
    /// </summary>
    public partial class PersonnelInfoEditControl : UserControl
    {
        public event EventHandler EditEnded;

        public PersonnelInfoEditControl()
        {
            InitializeComponent();
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Close()
        {
            if(EditEnded != null)
            {
                EditEnded(this, new EventArgs());
            }
        }
    }
}
