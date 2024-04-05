using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for NewBook.xaml
    /// </summary>
    public partial class NewBook : Page
    {
        public Library library;
        public NewBook(Library library)
        {
            InitializeComponent();
            this.library = library;//gives program access to object parameter
        }
        private void RegClick(object sender, RoutedEventArgs e) //add new lender to list and returns to mainwindow
        {
            if (library.AddBook(TitleBox.Text, AuthorBox.Text))//adds book to library objects books list, uses textboxes as parameters
            {
                MessageBox.Show($"Added {TitleBox.Text} written by {AuthorBox.Text} to the library");
                this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
            }
            else
            {
                MessageBox.Show($"{TitleBox.Text} written by {AuthorBox.Text} already exists");
            }


        }
    }
}
