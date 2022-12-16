namespace Chess.View
{
    using Chess.ViewModel;
    using Microsoft.Win32;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows;

    /// <summary>
    /// Interaktionslogik för XAML MainWindow-filen.
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Initierar en ny instans av MainWindow-klassen.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ChessBoardButtons_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameHistoryVM saveGame;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            GameStateVM currentGame = (GameStateVM)DataContext;

            GameHistoryVM gameHistory = new GameHistoryVM();
            gameHistory.GameHistory = currentGame.GameHistory;

            saveFileDialog.Filter = "Chess Files | *.chess";
            saveFileDialog.DefaultExt = ".chess";
            saveFileDialog.FileName = "game";

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, gameHistory);
                    fs.Seek(0, SeekOrigin.Begin);
                    saveGame = (GameHistoryVM)formatter.Deserialize(fs);
                    fs.Close();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Chess Files | *.chess";

            GameHistoryVM loadedGame = null;
            if (openFileDialog.ShowDialog() == true)
            {
                IFormatter formatter = new BinaryFormatter();

                try
                {
                    using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                    {
                        loadedGame = (GameHistoryVM)formatter.Deserialize(fs);
                    }
                }
                catch
                {
                    MessageBox.Show("Could not load the .chess file.", "Chess", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                GameStateVM context = (GameStateVM)DataContext;
                context.GameHistory = loadedGame.GameHistory;
                this.DataContext = context;
            }
        }

        private void ChessBoardColumnBorder_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonSTOP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this system?",
               "Close", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Close the window  
                this.Close();
            }
            else
            {
                // Do not close the window  
            }
        }
    }
}