using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ClassLibrary1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewLender.xaml
    /// </summary>
    public partial class NewLender : Page
    {
        public Library library;
        public NewLender(Library library)
        {
            InitializeComponent();
            this.library = library;//gives program access to object parameter

        }
        private void RegClick(object sender, RoutedEventArgs e) //add new lender to list and returns to mainwindow
        {
            int i;
            if (!int.TryParse(IdBox.Text, out i))
            {
                MessageBox.Show("Invalid format");
            }
            else
            {
                if (library.AddLender(NameBox.Text, int.Parse(IdBox.Text)))//adds lender to library objects lenders list, uses textboxes as parameters
                {
                    MessageBox.Show($"Added {NameBox.Text} to the library");
                    this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
                }
                else
                {
                    MessageBox.Show($"Id number: {IdBox.Text} already exists");
                }
            }
        }
    }
}
