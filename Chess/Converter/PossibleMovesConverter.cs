namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media;
    using Chess.Model;

    /// <summary>
    /// Klassen PossibleMovesConverter.
    /// </summary>
    public class PossibleMovesConverter : IMultiValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling av SolidColorBrushes som representerar möjliga brickor.
        /// </summary>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<SolidColorBrush> result = new ObservableCollection<SolidColorBrush>();
            ObservableCollection<Koordinater> possibleMoves = (ObservableCollection<Koordinater>)values[0];
            GameState board = (GameState)values[1];

            for (int i = 0; i < board.Row; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    for (int k = 0; k < possibleMoves.Count; k++)
                    {
                        if (possibleMoves[k].X == i && possibleMoves[k].Y == j)
                        {
                            result.Add(Brushes.LightGreen);
                            break;
                        }
                        else
                        {
                            if (k == possibleMoves.Count - 1)
                            {
                                result.Add(null);
                            }
                        }
                    }
                }
            }

            return result;
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
