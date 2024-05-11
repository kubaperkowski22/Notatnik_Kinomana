using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notatnik_Kinomana_v2.ViewModels
{
    public class MainWindowVM
    {

        public MainWindowVM()
        {

        }

        public void ShowMessage()
        {
            MessageBox.Show("to jest wiadomosc","hejka", MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
