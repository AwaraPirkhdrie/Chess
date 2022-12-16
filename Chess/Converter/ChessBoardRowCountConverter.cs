namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Klassen ChessBoardRowCountConverter.
    /// </summary>
    public class ChessBoardRowCountConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling radnummer.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<string> result = new ObservableCollection<string>();

            for (int i = chessBoard.Row; i > 0; i--)
            {
                if (i < 10)
                {
                    result.Add("0" + i.ToString());
                }
                else
                {
                    result.Add(i.ToString());
                }
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
