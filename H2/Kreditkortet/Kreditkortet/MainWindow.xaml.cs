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
using System.Threading;

namespace Kreditkortet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public CardManager CardManage = new CardManager();
        private const char Separator = ',';

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cardReader_TextChanged(object sender, TextChangedEventArgs e)
        {
            string Text = string.Concat(cardReader.Text.Where(c => !char.IsWhiteSpace(c)));
            string[] cardRead = Text.Split(Separator);

            List<Card> cards = new List<Card>();

            foreach (var card in cardRead)
            {
                cards.Add(new Card(card));
            }

            CardManage.Cards = cards;
        }

        private void Button_Check(object sender, RoutedEventArgs e)
        {
            int validCount = 0;
            List<string> s = new List<string>();

            foreach (Card card in CardManage.Cards)
            {
                card.IsValid = CardManage.ValidateCard(card);

                if (!card.IsValid)
                {
                    StackPanel stack = new StackPanel { Orientation = (Orientation.Horizontal) };
                    stack.Children.Add(new Label
                    {
                        Content = card.Number,                       
                    });

                    invalidCardsPanel.Children.Add(stack);

                    RandomSound();

                    Thread.Sleep(120);
                }
                else if (card.IsValid)
                {
                    validCount++;
                    s.Add(card.Number);
                }
            }
        }

        private void RandomSound()
        {
            Random random = new Random();

            System.Media.SoundPlayer player = new System.Media.SoundPlayer($"..\\..\\Sound\\Crunch\\{random.Next(1,6)}.wav");

            player.Play();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            
            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;

                MessageBox.Show($"Uploaded file: {filepath}");
            }

        }
    }
}
