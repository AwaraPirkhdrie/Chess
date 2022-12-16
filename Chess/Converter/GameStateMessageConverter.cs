namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Klassen GameStateMessageConverter.
    /// </summary>
    public class GameStateMessageConverter : IMultiValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till ett strängmeddelande.
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool whitePlayerWon = (bool)values[0];
            bool blackPlayerWon = (bool)values[1];
            GameState currentBoard = (GameState)values[3];

            if (whitePlayerWon && blackPlayerWon)
            {
                return "Draw!";
            }

            if (whitePlayerWon)
            {
                return "White Player Won!";
            }
            
            if (blackPlayerWon)
            {
                return "Black Player Won!";
            }

            ObservableCollection<GameState> gameHistory = (ObservableCollection<GameState>)values[2];

            if (gameHistory.IndexOf(currentBoard) % 2 == 0)
            {
                return "White Player's Turn";
            }

            return "Black Player's Turn";
        }

        /// <summary>
        /// Konverterar ett konverterat värde tillbaka till dess ursprungliga värde.
        /// </summary>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}