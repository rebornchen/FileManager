using GalaSoft.MvvmLight;
using CL.UI.WPF.Model;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Input;
using MahApps.Metro;
using System.Windows;
using System.Linq;
using GalaSoft.MvvmLight.Command;

namespace CL.UI.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region 示例部分
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }
        #endregion


        #region 界面主题
        /// <summary>
        /// The <see cref="AppThemes" /> property's name.
        /// </summary>
        public const string AppThemesPropertyName = "AppThemes";

        private List<AppThemeMenuData> _appThemes = ThemeManager.AppThemes
                                           .Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                                           .ToList();

        /// <summary>
        /// Sets and gets the _app property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<AppThemeMenuData> AppThemes
        {
            get
            {
                return _appThemes;
            }

            set
            {
                if (_appThemes == value)
                {
                    return;
                }

                _appThemes = value;
                RaisePropertyChanged(() => _appThemes);
            }
        }
        #endregion


        #region 界面颜色
        /// <summary>
        /// The <see cref="AccentColors" /> property's name.
        /// </summary>
        public const string AccentColorsPropertyName = "AccentColors";

        private List<AccentColorMenuData> _accentColors = ThemeManager.Accents
                                            .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();

        /// <summary>
        /// Sets and gets the AccentColors property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<AccentColorMenuData> AccentColors
        {
            get
            {
                return _accentColors;
            }

            set
            {
                if (_accentColors == value)
                {
                    return;
                }

                _accentColors = value;
                RaisePropertyChanged(() => AccentColors);
            }
        }
        #endregion

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }

    #region Themes bind classes
    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new RelayCommand<object>(
                    x =>
                    {
                        DoChangeTheme(x);
                    }));
            }
        }

        protected virtual void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }
    #endregion
}