namespace Chess.View
{
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows;
    using System.Windows.Controls;
    using Chess.ViewModel;
    using Microsoft.Win32;

    /// <summary>
    /// Interaktionslogik för Meny XAML-fil.
    /// </summary>
    public partial class Menu : UserControl
    {
        /// <summary>
        /// Initierar en ny instans av klassen Meny.
        /// </summary>
        public Menu()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ChessTurns_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}