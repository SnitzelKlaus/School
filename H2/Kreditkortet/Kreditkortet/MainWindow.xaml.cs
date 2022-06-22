using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Kreditkortet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const char Separator = ',';

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cardReader_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<string> cards = new List<string>();

            cards.AddRange(cardReader.Text.Split(Separator));

            foreach (var card in cards)
            {

            }
        }
    }
}
