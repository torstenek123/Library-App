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
    /// Interaction logic for ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : Page
    {
        public Library library;
        public ReturnBook(Library library)
        {
            InitializeComponent();
            this.library = library;//gives program access to object parameter
        }
        private void RegClick(object sender, RoutedEventArgs e) 
        {
            int i;
            if (!int.TryParse(IdBox.Text, out i))
            {
                MessageBox.Show("Invalid format");
            }
            else
            {
                if (library.ReturnBook(NameBox.Text, int.Parse(IdBox.Text), TitleBox.Text, AuthorBox.Text)) //calls ReturnBook method on library object, with the textboxes as parameters
                {
                    MessageBox.Show("Returned " + TitleBox.Text);
                }
                else 
                {
                    MessageBox.Show("Book not lended by " + NameBox.Text);
                }

                this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
            }

        }
    }
}
