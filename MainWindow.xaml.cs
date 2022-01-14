using System.Collections.Generic;
using System.Text;
using System.Windows;

using ScaleFactory;

namespace ScaleTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCMajor(object sender, RoutedEventArgs e)
        {
            List<Scale> scale = ScaleFactory.ScaleFactory.MakeScales(Scale.C, Code.Major);
            Show(scale);
        }

        private void ShowEMajor(object sender, RoutedEventArgs e)
        {
            List<Scale> scale = ScaleFactory.ScaleFactory.MakeScales(Scale.E, Code.Major);
            Show(scale);
        }

        private void ShowCMinor(object sender, RoutedEventArgs e)
        {
            List<Scale> scale = ScaleFactory.ScaleFactory.MakeScales(Scale.C, Code.Minor);
            Show(scale);
        }

        private void ShowEMinor(object sender, RoutedEventArgs e)
        {
            List<Scale> scale = ScaleFactory.ScaleFactory.MakeScales(Scale.E, Code.Minor);
            Show(scale);
        }
        private void Show(List<ScaleFactory.Scale> scale)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < scale.Count; i++)
            {
                sb.Append(scale[i].ToString());
                sb.Append(" ");
            }
            label.Content = sb.ToString().Trim();

        }

    }
}
