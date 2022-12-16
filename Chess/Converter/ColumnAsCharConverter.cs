namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Klassen ColumnAsCharConverter.
    /// </summary>
    public class ColumnAsCharConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling bokstäver som innehåller schackbrädeskolumnen.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<char> result = new ObservableCollection<char>();

            for (char symbol = 'A'; symbol <= 'Z'; symbol++)
            {
                if (result.Count == chessBoard.Column)
                {
                    break;
                }

                result.Add(symbol);
            }

            return result;
        }

        /// <summary>
        /// Konverterar ett konverterat värde tillbaka till dess ursprungliga värde.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
