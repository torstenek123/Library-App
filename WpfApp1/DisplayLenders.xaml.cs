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
    /// Interaction logic for DisplayLenders.xaml
    /// </summary>
    public partial class DisplayLenders : Page
    {
        public Library library;
        public DisplayLenders(Library library)
        {
            InitializeComponent();
            this.library = library;
            comboBox.ItemsSource = library.lenders;//binds data from library objects lender list to combobox
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Lender selectedLender = comboBox.SelectedItem as Lender;//binds selected item in combobox to lender object
            listView.ItemsSource = selectedLender.lendedBooks;//changes listview to the selected lenders lended books list
        }
        private void ReturnClick(object sender, RoutedEventArgs e)//return button
        {
            this.NavigationService.Navigate(new MenuPage(library));//moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter 
        }
    }
}
