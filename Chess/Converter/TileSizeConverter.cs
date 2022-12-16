namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// The TileSizeConverter class.
    /// </summary>
    public class TileSizeConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar chessBoard Tile2D-arraystorleken och konverterar den till bricka en storlek.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GameState chessBoard = (GameState)value;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                return 80;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                return 60;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                return 40;
            }

            return 30;
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
