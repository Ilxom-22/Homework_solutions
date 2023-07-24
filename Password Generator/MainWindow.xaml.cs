using System;
using System.Windows;
using System.Windows.Controls;

namespace Password_Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RangeBase_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)sender;
            sliderValue.Content = Math.Round(slider.Value);
        }
    }
} 
