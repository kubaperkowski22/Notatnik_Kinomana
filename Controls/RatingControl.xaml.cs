using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Notatnik_Kinomana_v2.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy RatingControl.xaml
    /// </summary>
    public partial class RatingControl : UserControl
    {
        public RatingControl()
        {
            InitializeComponent();

            Rating = 1;
            RatingLabel.Content = "1";
        }

        public int Rating
        {
            get
            {
                if (_rating < 1 || _rating > 5)
                    return 1;

                return _rating;
            }
            set
            {
                _rating = value;

                RatingLabel.Content = _rating.ToString();
                SetGold(_rating);
            }
        }
        private int _rating;

        private void Star_MouseEnter(object sender, MouseEventArgs e)
        {
            var star = sender as FontAwesome.WPF.FontAwesome;
            
            bool isChecked;

            if(star.Foreground == Brushes.Gray)
                isChecked = true;
            else isChecked = false;
            
            switch(star.Name)
            {
                case "Star1":
                    SetColors(1, isChecked);
                    break;
                case "Star2":
                    SetColors(2, isChecked);
                    break;
                case "Star3":
                    SetColors(3, isChecked);
                    break;
                case "Star4":
                    SetColors(4, isChecked);
                    break;
                case "Star5":
                    SetColors(5, isChecked);
                    break;
            }
        }

        private void SetColors(int num, bool isChecked)
        {
            switch(isChecked)
            {
                case true:
                    SetGold(num);
                    break;
                case false:
                    SetGray(num);
                    break;
                default:
                    return;
            }
        }

        private void SetGold(int num)
        {
            switch (num)
            {
                case 1:
                    break;
                case 2:
                    Star1.Foreground = Brushes.Gold;
                    Star2.Foreground = Brushes.Gold;
                    break;
                case 3:
                    Star1.Foreground = Brushes.Gold;
                    Star2.Foreground = Brushes.Gold;
                    Star3.Foreground = Brushes.Gold;
                    break;
                case 4:
                    Star1.Foreground = Brushes.Gold;
                    Star2.Foreground = Brushes.Gold;
                    Star3.Foreground = Brushes.Gold;
                    Star4.Foreground = Brushes.Gold;
                    break;
                case 5:
                    Star1.Foreground = Brushes.Gold;
                    Star2.Foreground = Brushes.Gold;
                    Star3.Foreground = Brushes.Gold;
                    Star4.Foreground = Brushes.Gold;
                    Star5.Foreground = Brushes.Gold;
                    break;
                default:
                    return;
            }
        }
        private void SetGray(int num)
        {
            switch (num)
            {
                case 1:
                    Star2.Foreground = Brushes.Gray;
                    Star3.Foreground = Brushes.Gray;
                    Star4.Foreground = Brushes.Gray;
                    Star5.Foreground = Brushes.Gray;
                    break;
                case 2:
                    Star3.Foreground = Brushes.Gray;
                    Star4.Foreground = Brushes.Gray;
                    Star5.Foreground = Brushes.Gray;
                    break;
                case 3:
                    Star4.Foreground = Brushes.Gray;
                    Star5.Foreground = Brushes.Gray;
                    break;
                case 4:
                    Star5.Foreground = Brushes.Gray;
                    break;
                default:
                    return;
            }
        }

        private void Star_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var star = sender as FontAwesome.WPF.FontAwesome;

            switch (star.Name)
            {
                case "Star1":
                    RatingLabel.Content = "1";
                    Rating = 1;
                    break;
                case "Star2":
                    RatingLabel.Content = "2";
                    Rating = 2;
                    break;
                case "Star3":
                    RatingLabel.Content = "3";
                    Rating = 3;
                    break;
                case "Star4":
                    RatingLabel.Content = "4";
                    Rating = 4;
                    break;
                case "Star5":
                    RatingLabel.Content = "5";
                    Rating = 5;
                    break;
            }
        }

        public void SetDefault()
        {
            RatingLabel.Content = "1";

            Star2.Foreground = Brushes.Gray;
            Star3.Foreground = Brushes.Gray;
            Star4.Foreground = Brushes.Gray;
            Star5.Foreground = Brushes.Gray;
        }
    }
}
