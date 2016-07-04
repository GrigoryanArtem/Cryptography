using System;
using System.Collections.Generic;
using System.Globalization;
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
using MahApps.Metro.Controls;
using Crypto.UI.Views;
using Crypto.UI.Models;

namespace Crypto.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeLocalization();
        }

        #region Localization methods

        private void InitializeLocalization()
        {
            App.LanguageChanged += LanguageChanged;
            App.Language = Properties.Settings.Default.DefaultLanguage;

            FillMenuItems();
        }

        private void FillMenuItems()
        {
            CultureInfo currentLanguage = App.Language;
            mLanguageMenu.Items.Clear();

            foreach (var language in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Header = language.DisplayName;
                menuLang.Tag = language;
                menuLang.IsChecked = language.Equals(currentLanguage);
                menuLang.Click += ChangeLanguage_Click;
                mLanguageMenu.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currentLanguage = App.Language;

            foreach (MenuItem menuItem in mLanguageMenu.Items)
            {
                CultureInfo cultureInfo = menuItem.Tag as CultureInfo;
                menuItem.IsChecked = cultureInfo != null && cultureInfo.Equals(currentLanguage);
            }
        }

        private void ChangeLanguage_Click(Object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem != null)
            {
                CultureInfo language = menuItem.Tag as CultureInfo;

                if (language != null)
                    App.Language = language;
            }
        }

        #endregion
    }
}
