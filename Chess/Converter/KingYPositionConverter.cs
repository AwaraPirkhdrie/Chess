namespace Chess.Converter
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Klassen KingYPositionConverter.
    /// </summary>
    public class KingYPositionConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till ett heltalsvärde som innehåller kungens Y-koordinat.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int x = 0;
            Player player = (Player)Enum.Parse(typeof(Player), (string)parameter);

            GameState gameState = (GameState)value;
            int tileWidth = this.GetTileWidth(gameState);

            for (int i = 0; i < gameState.Row; i++)
            {
                for (int j = 0; j < gameState.Column; j++)
                {
                    if (gameState.ChessBoard[i, j].IsOccupied)
                    {
                        if (gameState.ChessBoard[i, j].Piece is King)
                        {
                            if (gameState.ChessBoard[i, j].Piece.Player == player)
                            {
                                return (double)(tileWidth * i);
                            }
                        }
                    }
                }
            }

            return x;
        }

        /// <summary>
        /// Konverterar ett konverterat värde tillbaka till dess ursprungliga värde.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the tile width.
        /// </summary>
        private int GetTileWidth(GameState chessBoard)
        {
            int columnSize = 30;

            if (chessBoard.Row < 11 && chessBoard.Column < 11)
            {
                columnSize = 80;
                return columnSize;
            }

            if (chessBoard.Row < 15 && chessBoard.Column < 15)
            {
                columnSize = 60;
                return columnSize;
            }

            if (chessBoard.Row < 19 && chessBoard.Column < 19)
            {
                columnSize = 40;
                return columnSize;
            }

            return columnSize;
        }
    }
}
