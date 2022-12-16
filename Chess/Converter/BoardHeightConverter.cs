namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Innehåller omvandlarlogiken för kakelhöjden.
    /// </summary>
    public class BoardHeightConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value to an integer representing the board height.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rowSizeHeight = 30;

            GameState chessBoard = (GameState)value;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                rowSizeHeight = 80;
                return chessBoard.Row * rowSizeHeight;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                rowSizeHeight = 60;
                return chessBoard.Row * rowSizeHeight;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                rowSizeHeight = 40;
                return chessBoard.Row * rowSizeHeight;
            }

            return chessBoard.Row * rowSizeHeight;
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
