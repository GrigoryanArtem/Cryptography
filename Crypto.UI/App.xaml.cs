﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto.UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Members

        private static List<CultureInfo> mLanguages = new List<CultureInfo>();

        public static event EventHandler LanguageChanged;

        #endregion

        #region Properties

        public static List<CultureInfo> Languages
        {
            get
            {
                return mLanguages;
            }
        }

        public static CultureInfo Language
        {
            get
            {
                return System.Threading.Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (value == System.Threading.Thread.CurrentThread.CurrentUICulture)
                    return;

                System.Threading.Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new ResourceDictionary();
                switch (value.Name)
                {
                    case "ru-RU":
                        dict.Source = new Uri(String.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative);
                        break;
                    default:
                        dict.Source = new Uri("Resources/lang.xaml", UriKind.Relative);
                        break;
                }

                ResourceDictionary oldDict = (from d in Application.Current.Resources.MergedDictionaries
                                              where d.Source != null && d.Source.OriginalString.StartsWith("Resources/lang.")
                                              select d).First();
                if (oldDict != null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
                else
                {
                    Application.Current.Resources.MergedDictionaries.Add(dict);
                }

                LanguageChanged(Application.Current, new EventArgs());
            }
        }

        #endregion

        public App()
        {
            LanguageChanged += Application_LanguageChanged;
            InitializeLanguages();      
        }

        #region Private methods

        private void InitializeLanguages()
        {
            mLanguages.Clear();
            mLanguages.Add(new CultureInfo("en-US"));
            mLanguages.Add(new CultureInfo("ru-RU"));    
        }

        private void Application_LanguageChanged(Object sender, EventArgs e)
        {
            UI.Properties.Settings.Default.DefaultLanguage = Language;
            UI.Properties.Settings.Default.Save();
        }

        #endregion
    }
}