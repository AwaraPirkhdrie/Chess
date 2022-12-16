namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Klassen ChessBoardObservableCollectionConverter.
    /// </summary>
    public class ChessBoardObservableCollectionConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar 2D-arrayen av plattorna till en observerbar samling som innehåller koordinatinformationen.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState board = (GameState)value;
            ObservableCollection<string> result = new ObservableCollection<string>();  
            
            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    result.Add($"{i} {j}");
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
