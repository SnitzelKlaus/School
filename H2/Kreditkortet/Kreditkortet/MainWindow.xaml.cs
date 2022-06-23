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
        public CardManager cardManager = new CardManager();
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

            cardManager.Cards = cards;
        }

        private void Button_Check(object sender, RoutedEventArgs e)
        {
            int validCount = 0;
            List<string> s = new List<string>();

            foreach (Card card in cardManager.Cards)
            {
                card.IsValid = cardManager.ValidateCard(card);

                if (!card.IsValid)
                {
                    StackPanel stack = new StackPanel { Orientation = (Orientation.Horizontal) };
                    stack.Children.Add(new Label
                    {
                        Content = card.Number
                    });

                    invalidCardsPanel.Children.Add(stack);

                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Code\School\H2\Kreditkortet\Kreditkortet\Sound\AirRaid.wav");
                    player.Play();
                }
                else if (card.IsValid)
                {
                    validCount++;
                    s.Add(card.Number);
                }
            }
        }
    }
}
