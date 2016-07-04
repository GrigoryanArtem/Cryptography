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

namespace Crypto.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для Asymmetric.xaml
    /// </summary>
    public partial class Asymmetric : UserControl
    {
        public Asymmetric()
        {
            InitializeComponent();
            InitializeAlghorithms();
            InitializeKeyLength();
        }

        public void InitializeAlghorithms()
        {
            mAlgorithm.Items.Add("RSA");
            mAlgorithm.Items.Add("El Gamal");;
            mAlgorithm.SelectedIndex = 0;
        }

        public void InitializeKeyLength()
        {
            for(int i = 32; i <= 8192; i *= 2)
                mKeyLength.Items.Add(i);

            mKeyLength.SelectedItem = 1024;
        }
    }
}
