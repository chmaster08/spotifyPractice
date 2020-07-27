using System.Windows;

namespace SpotifyPractice
{
    /// <summary>
    /// testwindow.xaml の相互作用ロジック
    /// </summary>
    public partial class testwindow : Window
    {
        public testwindow(TestViewModel vm)
        {
            InitializeComponent();
            this.DataContext = vm;
        }
    }
}
