using ClassLibrary1;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LendBook.xaml
    /// </summary>
    public partial class LendBook : Page
    {
        public Library library;
        public LendBook(Library library)
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
                if (library.LendBook(NameBox.Text, int.Parse(IdBox.Text), TitleBox.Text, AuthorBox.Text)) //calls LendBook method on library object, with the textboxes as parameters
                {
                    MessageBox.Show($"Lended {TitleBox.Text} to {NameBox.Text}");
                }
                else
                {
                    MessageBox.Show($"Did not lend {TitleBox.Text} to {NameBox.Text}");
                }

                this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
            }

        }
    }
}
