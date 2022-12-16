namespace Chess.Converter
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows.Data;
    using Chess.Model;

    /// <summary>
    /// Innehåller omvandlarlogiken för ChessPiece-bilderna.
    /// </summary>
    public class ChessPieceImageConverter : IValueConverter
    {
        /// <summary>
        /// Konverterar ett värde till en observerbar samling schackpjäsbilder.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<string> chessPieceImages = new ObservableCollection<string>();

                GameState chessBoard = (GameState)value;

                for (int i = 0; i < chessBoard.Row; i++)
                {
                    for (int j = 0; j < chessBoard.Column; j++)
                    {
                        if (chessBoard.ChessBoard[i, j].IsOccupied)
                        {
                            if (chessBoard.ChessBoard[i, j].Piece.Player == Player.BLACK)
                            {
                                chessPieceImages.Add($"Images/{chessBoard.ChessBoard[i, j].Piece}_B.png");
                            }
                            else if (chessBoard.ChessBoard[i, j].Piece.Player == Player.WHITE)
                            {
                                chessPieceImages.Add($"Images/{chessBoard.ChessBoard[i, j].Piece}_W.png");
                            }
                        }
                        else
                        {
                            chessPieceImages.Add(null);
                        }
                    }
                }

                return chessPieceImages;
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
