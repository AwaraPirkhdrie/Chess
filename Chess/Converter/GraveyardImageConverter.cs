namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The GraveyardImageConverter class.
    /// </summary>
    public class GraveyardImageConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling som representerar schackpjäserna på kyrkogården.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<ChessPiece> graveyard = (ObservableCollection<ChessPiece>)value;
            ObservableCollection<string> result = new ObservableCollection<string>();
            string player = (string)parameter;

            if (player.Equals("white"))
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    result.Add($"Images/{graveyard[i]}_W.png");
                }

                for (int i = result.Count; i < 16; i++)
                {
                    result.Add(null);
                }
            }
            else if (player.Equals("black"))
            {
                for (int i = 0; i < graveyard.Count; i++)
                {
                    result.Add($"Images/{graveyard[i]}_B.png");
                }

                for (int i = result.Count; i < 16; i++)
                {
                    result.Add(null);
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
