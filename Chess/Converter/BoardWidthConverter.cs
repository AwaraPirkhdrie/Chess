namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Innehåller omvandlarlogiken för tegelbredden.
    /// </summary>
    public class BoardWidthConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till ett heltal som representerar brädets bredd.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int columnSizeWidth = 30;

            GameState chessBoard = (GameState)value;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                columnSizeWidth = 80;
                return chessBoard.Column * columnSizeWidth;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                columnSizeWidth = 60;
                return chessBoard.Column * columnSizeWidth;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                columnSizeWidth = 40;
                return chessBoard.Column * columnSizeWidth;
            }

            return chessBoard.Column * columnSizeWidth;
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