namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using Chess.Model;

    /// <summary>
    /// Innehåller omvandlarlogiken för schackbrädesbakgrunden.
    /// </summary>
    public class ChessBoardBackgroundColorConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling av SolidColorBrushes.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;
            ObservableCollection<SolidColorBrush> result = new ObservableCollection<SolidColorBrush>();
            for (int i = 0; i < chessBoard.Row; i++)
            {
                for (int j = 0; j < chessBoard.Column; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        result.Add(Brushes.Tan);
                    }
                    else
                    {
                        result.Add(Brushes.Brown);
                    }
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