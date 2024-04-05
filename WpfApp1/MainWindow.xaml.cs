using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

    public partial class MainWindow : Window// two constructors for mainwindow, the one with a parameter is used when the program returns to main
    {
        Library library { get; set; } = new Library();
        public MainWindow()
        {
            InitializeComponent();
            frame.NavigationService.Navigate(new MenuPage(library)); // moves to line 26 in MenuPage.xaml.cs and takes the library object as a parameter
        }
    }
}
/*todo: fler pages -> vilken ordning? 
 * 
*/