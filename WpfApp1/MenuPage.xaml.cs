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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        public Library library;
        public MenuPage(Library library)
        {
            InitializeComponent();
            this.library = library;
        }
        private void ShClick(object sender, RoutedEventArgs e)//Save history button method
        {
            library.SaveHistory();
        }
        private void DlClick(object sender, RoutedEventArgs e)//Display lenders button method
        {
            this.NavigationService.Navigate(new DisplayLenders(library));//moves to line 24 in DisplayLenders.xaml.cs and takes the library object as a parameter
        }
        private void DbClick(object sender, RoutedEventArgs e)//Display books button method
        {
            this.NavigationService.Navigate(new DisplayBooks(library));//moves to line 24 in DisplayBooks.xaml.cs and takes the library object as a parameter
        }
        private void AlClick(object sender, RoutedEventArgs e)//Add lender button method

        {
            this.NavigationService.Navigate(new NewLender(library));//moves to line 25 in NewLender.xaml.cs and takes the library object as a parameter

        }
        private void AbClick(object sender, RoutedEventArgs e) //Add book button method
        {
            this.NavigationService.Navigate(new NewBook(library));//moves to line 25 in NewBook.xaml.cs and takes the library object as a parameter
        }
        private void LbClick(object sender, RoutedEventArgs e)//Lend book button method
        {
            this.NavigationService.Navigate(new LendBook(library));//moves to line 25 in LendBook.xaml.cs and takes the library object as a parameter
        }
        private void RbClick(object sender, RoutedEventArgs e)//Return book button method
        {
            this.NavigationService.Navigate(new ReturnBook(library));//moves to line 24 in ReturnBook.xaml.cs and takes the library object as a parameter
        }
    }
}

