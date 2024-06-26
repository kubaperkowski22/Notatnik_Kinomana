﻿using Notatnik_Kinomana_v2.Models;
using Notatnik_Kinomana_v2.ViewModels.ViewsVM;
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

namespace Notatnik_Kinomana_v2.Views
{
    /// <summary>
    /// Logika interakcji dla klasy StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : UserControl
    {
        public StatisticsPageVM ViewModel
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
        private StatisticsPageVM _viewModel;

        public StatisticsPage(AllMovies movies, AllPremieres premieres)
        {
            InitializeComponent();

            ViewModel = new StatisticsPageVM(movies, premieres);
            this.DataContext = ViewModel;
        }
    }
}
