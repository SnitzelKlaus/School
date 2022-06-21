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
using System.Collections;
using System.Collections.ObjectModel;

namespace NormalizationWPF
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _list = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Increase(object sender, RoutedEventArgs e)
        {
            StackPanel stack = new StackPanel { Orientation = (Orientation.Horizontal) };
            Image image = new Image();

            Uri resourceUri = new Uri("/Images/Entities/Arrow.png", UriKind.Relative);
            image.Source = new BitmapImage(resourceUri);
            image.Width = 20;

            stack.Children.Add(new ComboBox
            {
                Width = 100,
                Margin = new Thickness(10),
                SelectedItem = new Binding(),
                ItemsSource = new Binding() { ElementName = "ComboBoxItems", Source =  }
            });

            //ComboBox cb = new ComboBox();
            //cb.ID = "cb1";
            //cb.DataSource = dt;
            //cb.DataTextField = "Id";
            //cb.DataValueField = "Name";
            //cb.DataBind();
            //PlaceHolder1.Controls.Add(cb);

            stack.Children.Add(image);
            
            stack.Children.Add(new ComboBox
            {
                Width = 100,
                Margin = new Thickness(10),
                SelectedItem = "{Binding SelectedItem}",
                ItemsSource = "{Binding ComboboxItems}"
            });

            dpcyPanel.Children.Add(stack);
        }

        
        
        private void Button_Decrease(object sender, RoutedEventArgs e)
        {
            if (dpcyPanel.Children.Count > 0)
                dpcyPanel.Children.RemoveAt(dpcyPanel.Children.Count - 1);
        }

        
        
        private ComboBox CreateNewComboBox(int width, int margin)
        {
            ComboBox comboBox = new ComboBox();

            for(int i = 0; i < dpcyPanel.Children.Count; i++)
            {
                for (int j = 0; j < dpcyPanel.Children[i].Count; j++)
                {
                    if (dpcyPanel.Children[i] is StackPanel)
                    {
                        StackPanel stack = (StackPanel)dpcyPanel.Children[i];
                        if (stack.Children[0] is ComboBox)
                        {
                            ComboBox cb = (ComboBox)stack.Children[0];
                            cb.Width = width;
                            cb.Margin = new Thickness(margin);
                        }
                    }
                }
            }
            
            foreach (string child in dpcyPanel.Children)
            {
                foreach (StackPanel s in dpcyPanel.Children)
                {

                }
            }

            comboBox.Name = "cb" + dpcyPanel.Children.Count;
            comboBox.Width = width;
            comboBox.Margin = new Thickness(margin);
            comboBox.SelectedItem = new Binding();
            comboBox.ItemsSource = new Binding() { ElementName = "ComboBoxItems", Source =  };

            //{
            //    Width = 100,
            //    Margin = new Thickness(10),
            //    SelectedItem = new Binding(),
            //    ItemsSource = new Binding() { ElementName = "ComboBoxItems", Source =  }
            //});

            return comboBox;
        }

        
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] text = txtBox.Text.Split(',');
            
            foreach (string t in text)
            {
                _list.Add(t);
            }
        }

        
        
    }
}
