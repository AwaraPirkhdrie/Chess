namespace Chess.Model
{
    /// <summary>
    /// Klassen KingInCheckCalculator.
    /// </summary>
    public class KingInCheckCalculator
    {
        /// <summary>
        /// Kontrollerar om en kung är i schack.
        /// </summary>
        public bool kingCheck(Player player, GameState gameState)
        {
            for (int i = 0; i < gameState.Row; i++)
            {
                for (int j = 0; j < gameState.Column; j++)
                {
                    if (gameState.ChessBoard[i, j].IsOccupied)
                    {
                        if (gameState.ChessBoard[i, j].Piece is King && gameState.ChessBoard[i, j].Piece.Player == player)
                        {
                            Koordinater coordinates = new Koordinater(i, j);
                            bool kingInCheck = this.CheckIsKingInCheck(player, gameState, coordinates);
                            return kingInCheck;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack.
        /// </summary>
        private bool CheckIsKingInCheck(Player player, GameState gameState, Koordinater coordinates)
        {
            bool kingInCheck = this.CheckHorizontalLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckHorizontalRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckVerticalUpTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckVerticalDownTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckKnightTiles(player, gameState, coordinates);

            return kingInCheck;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonala brickorna.
        /// </summary>
        private bool CheckDiagonalTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            bool kingInCheck = this.CheckDiagonalUpLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalUpRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalDownRightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDiagonalDownLeftTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar riddarbrickorna.
        /// </summary>
        private bool CheckKnightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            bool kingInCheck = this.CheckLeftKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckRightKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckUpKnightTiles(player, gameState, coordinates);

            if (kingInCheck)
            {
                return kingInCheck;
            }

            kingInCheck = this.CheckDownKnightTiles(player, gameState, coordinates);

            return kingInCheck;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar ner riddarbrickorna.
        /// </summary>
        private bool CheckDownKnightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X + 2 < gameState.Row)
            {
                if (coordinates.Y + 1 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece.Player != player && gameState.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X + 2 < gameState.Row)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece.Player != player && gameState.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar upp riddarbrickorna.
        /// </summary>
        private bool CheckUpKnightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y + 1 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece.Player != player && gameState.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece.Player != player && gameState.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de rätta riddarbrickorna.
        /// </summary>
        private bool CheckRightKnightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y + 2 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece.Player != player && gameState.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece.Player != player && gameState.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de vänstra riddarbrickorna.
        /// </summary>
        private bool CheckLeftKnightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X + 1 < gameState.Row)
            {
                if (coordinates.Y + 2 < gameState.Column)
                {
                    if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece.Player != player && gameState.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            if (coordinates.X + 1 < gameState.Row)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece.Player != player && gameState.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece is Knight)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonalt nedåt vänstra brickorna.
        /// </summary>
        private bool CheckDiagonalDownLeftTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X < gameState.Row - 1 && coordinates.Y > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X + i == gameState.Row || coordinates.Y - i == -1)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                        {
                            if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                            {
                                if (player == Player.BLACK && (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Pawn) && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is King && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Queen || gameState.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece is Bishop)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonala nedåt högra brickorna.
        /// </summary>
        private bool CheckDiagonalDownRightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X < gameState.Row - 1 && coordinates.Y < gameState.Column - 1)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X + i == gameState.Row || coordinates.Y + i == gameState.Column)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                        {
                            if (player != gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                            {
                                if (player == Player.BLACK && (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Pawn) && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is King && i == 1)
                                {
                                    return true;
                                }

                                if (gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Queen || gameState.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece is Bishop)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de lodräta brickorna.
        /// </summary>
        private bool CheckVerticalDownTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X < gameState.Row - 1)
            {
                for (int i = coordinates.X + 1; i < gameState.Row; i++)
                {
                    if (gameState.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            if (gameState.ChessBoard[i, coordinates.Y].Piece is King && i == coordinates.X + 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[i, coordinates.Y].Piece is Queen || gameState.ChessBoard[i, coordinates.Y].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonala lodräta brickorna.
        /// </summary>
        private bool CheckVerticalUpTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = coordinates.X; i >= 0; i--)
                {
                    if (gameState.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            if (gameState.ChessBoard[i, coordinates.Y].Piece is King && i == coordinates.X - 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[i, coordinates.Y].Piece is Queen || gameState.ChessBoard[i, coordinates.Y].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de horisontella högra brickorna.
        /// </summary>
        private bool CheckHorizontalRightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.Y < gameState.Column - 1)
            {
                for (int i = coordinates.Y; i < gameState.Column; i++)
                {
                    if (gameState.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            if (gameState.ChessBoard[coordinates.X, i].Piece is King && i == coordinates.Y + 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X, i].Piece is Queen || gameState.ChessBoard[coordinates.X, i].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de horisontella vänstra brickorna.
        /// </summary>
        private bool CheckHorizontalLeftTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.Y > 0)
            {
                for (int i = coordinates.Y; i >= 0; i--)
                {
                    if (gameState.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            if (gameState.ChessBoard[coordinates.X, i].Piece is King && i == coordinates.Y - 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X, i].Piece is Queen || gameState.ChessBoard[coordinates.X, i].Piece is Rook)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonala brickorna uppåt.
        /// </summary>
        private bool CheckDiagonalUpRightTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y + i == gameState.Column)
                    {
                        break;
                    }

                    if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece.Player)
                        {
                            if (player == Player.WHITE && (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Pawn) && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is King && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Queen || gameState.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece is Bishop)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Kontrollerar om King är i schack. Skannar de diagonala brickorna till vänster upp.
        /// </summary>
        private bool CheckDiagonalUpLeftTiles(Player player, GameState gameState, Koordinater coordinates)
        {
            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                for (int i = 1; i < gameState.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y - i == -1)
                    {
                        return false;
                    }

                    if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].IsOccupied)
                    {
                        if (player != gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece.Player)
                        {
                            if (player == Player.WHITE && (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Pawn) && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is King && i == 1)
                            {
                                return true;
                            }

                            if (gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Queen || gameState.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece is Bishop)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }
    }
}
