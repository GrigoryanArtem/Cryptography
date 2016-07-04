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

namespace Crypto.UI.Controls
{
    /// <summary>
    /// Логика взаимодействия для ComboBoxWithHeader.xaml
    /// </summary>
    public partial class ComboBoxWithHeader : UserControl
    {
        public ComboBoxWithHeader()
        {
            InitializeComponent();
            mLayoutRoot.DataContext = this;
        }

        #region Properties
        #region Header

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ComboBoxWithHeader));

        #endregion

        #region SelectedIndex

        public int SelectedIndex
        {
            get
            {
                return mComboBox.SelectedIndex;
            }
            set
            {
                mComboBox.SelectedIndex = value;
            }
        }

        #endregion

        #region Items

        public ItemCollection Items
        {
            get
            {
                return mComboBox.Items;
            }
        }

        #endregion

        #region SelectedItem

        public object SelectedItem
        {
            get
            {
                return mComboBox.SelectedItem;
            }
            set
            {
                mComboBox.SelectedItem = value;
            }
        }

        #endregion
        #endregion
    }
}
