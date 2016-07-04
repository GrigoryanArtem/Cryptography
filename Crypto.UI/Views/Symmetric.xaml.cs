using Crypto.UI.Models;
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
    /// Логика взаимодействия для Symmetric.xaml
    /// </summary>
    public partial class Symmetric : UserControl
    {
        public Symmetric()
        {
            InitializeComponent();
            InitializeAlghorithms();
            InitializeCipherModes();
            InitializeGenearatorModes();
        }

        public ICommand ClickTB
        {
            get
            {
                return new SimpleCommand
                {
                    CanExecuteDelegate = x => true,

                    ExecuteDelegate = x =>
                    {
                        MessageBox.Show("Hello World!");
                    }
                };
            }
        }

        public void InitializeAlghorithms()
        {
            mAlgorithm.Items.Add("AES 128");
            mAlgorithm.Items.Add("AES 192");
            mAlgorithm.Items.Add("AES 256");
            mAlgorithm.Items.Add("DES");
            mAlgorithm.SelectedIndex = 0;
        }

        public void InitializeCipherModes()
        {
            mCipherMode.Items.Add("Electronic code book");
            mCipherMode.Items.Add("Cipher block chaining");
            mCipherMode.SelectedIndex = 0;
        }

        public void InitializeGenearatorModes()
        {
            mGeneratorMode.Items.Add("Only symbols");
            mGeneratorMode.Items.Add("Only numerals");
            mGeneratorMode.Items.Add("Symbols and numerals");
            mGeneratorMode.SelectedIndex = 0;
        }
    }
}
