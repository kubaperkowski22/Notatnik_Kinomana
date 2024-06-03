using Microsoft.Win32;
using Newtonsoft.Json;
using Notatnik_Kinomana_v2.Models;
using Notatnik_Kinomana_v2.ViewModels;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Notatnik_Kinomana_v2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl, INotifyPropertyChanged
    {
        public SettingsPageVM ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }
        private SettingsPageVM _viewModel;
        public MainWindowVM MainWindowVM
        {
            get
            {
                return _mainWindowVM;
            }
            set
            {
                _mainWindowVM = value;

                OnPropertyChanged(nameof(MainWindowVM));
            }
        }
        private MainWindowVM _mainWindowVM;
        public SettingsPage(MainWindowVM mainWindowVM)
        {
            InitializeComponent();

            ViewModel = new SettingsPageVM(mainWindowVM.AllMovies, mainWindowVM.AllPremieres);
            MainWindowVM = mainWindowVM;
            this.DataContext = ViewModel;
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Zapisz dane do JSON",
                DefaultExt = "json",
                FileName = "MoviesData_" + DateTime.Now.ToString()
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                SerializeToJson(MainWindowVM, filePath);
                MessageBox.Show($"Pomyślnie zapisano plik w lokalizacji:\n{filePath}", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private static void SerializeToJson(MainWindowVM movieData, string filePath)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonString = JsonConvert.SerializeObject(movieData, settings);
            File.WriteAllText(filePath, jsonString);
        }
        private void OpenDataButton_Click(object sender, RoutedEventArgs e)
        {
            var movieData = DeserializeFromJsonFile();
            if (movieData != null)
            {
                if (MainWindowVM != null)
                {
                    MainWindowVM.AllMovies = movieData.AllMovies;
                    MainWindowVM.AllPremieres = movieData.AllPremieres;

                    OnPropertyChanged(nameof(MainWindowVM));
                }
                MessageBox.Show("Pomyślnie załadowano plik z danymi.", "Sukces!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public MainWindowVM DeserializeFromJsonFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Open JSON File"
            };

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;
                return DeserializeFromJson(filePath);
            }

            return null;
        }
        private MainWindowVM DeserializeFromJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<MainWindowVM>(jsonString);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
