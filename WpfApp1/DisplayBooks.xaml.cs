using ClassLibrary1;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DisplayBooks.xaml
    /// </summary>
    public partial class DisplayBooks : Page
    {
        public Library library;
        public DisplayBooks(Library library)
        {
            InitializeComponent();
            this.library = library;//gives program access to object parameter
            List<Book> availableBooks = new List<Book>();
            foreach (Book book in library.books)//adds available books to list
            {
                if (book.lended == false)
                {
                    availableBooks.Add(book);
                }
            }
            listView.ItemsSource = availableBooks;//binds data from available books list to listview grid

        }
        private void ReturnClick(object sender, RoutedEventArgs e) 
        {
            this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
        }
    }
}
