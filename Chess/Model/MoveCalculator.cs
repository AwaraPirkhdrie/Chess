namespace Chess.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Klassen MoveCalculator.
    /// </summary>
    [Serializable]
    public class MoveCalculator : IMovement
    {
        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(Bishop bishop, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();
            this.CalculateDiagonalMoves(result, bishop, chessBoard, coordinates);
            return result;
        }

        /// <summary>
        /// Returnerar en lista med koordinater.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(King king, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();
            this.CalculateKingUpMoves(king, chessBoard, coordinates, result);
            this.CalculateKingDownMoves(king, chessBoard, coordinates, result);
            this.CalculateKingSideMoves(king, chessBoard, coordinates, result);

            return result;
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(Rook rook, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();
            this.CalculateVerticalMoves(result, rook, chessBoard, coordinates);
            this.CalculateHorizontalMoves(result, rook, chessBoard, coordinates);

            return result;
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(Queen queen, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();
            this.CalculateVerticalMoves(result, queen, chessBoard, coordinates);
            this.CalculateHorizontalMoves(result, queen, chessBoard, coordinates);
            this.CalculateDiagonalMoves(result, queen, chessBoard, coordinates);

            return result;
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(Knight knight, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();
            this.CalculateDownKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateUpKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateRightKnightMoves(knight, chessBoard, coordinates, result);
            this.CalculateLeftKnightMoves(knight, chessBoard, coordinates, result);

            return result;
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        public List<Koordinater> CalculateLegalMoves(Pawn pawn, GameState chessBoard, Koordinater coordinates)
        {
            List<Koordinater> result = new List<Koordinater>();           
            if (pawn.Player == Player.WHITE)
            {
                if (coordinates.X > 0 && !chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].IsOccupied)
                {
                    result.Add(new Koordinater(coordinates.X - 1, coordinates.Y));
                }

                this.CalculatePawnUpAttackMoves(pawn, chessBoard, coordinates, result);
            }
            else if (pawn.Player == Player.BLACK)
            {
                if (coordinates.X < chessBoard.Row - 1)
                {
                    if (!chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].IsOccupied)
                    {
                        result.Add(new Koordinater(coordinates.X + 1, coordinates.Y));
                    }
                }
                this.CalculatePawnDownAttackMoves(pawn, chessBoard, coordinates, result);
            }

            return result;
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDiagonalDownLeftMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X + i == chessBoard.Row || coordinates.Y - i == -1)
                    {
                        break;
                    }
                    if (!chessBoard.ChessBoard[coordinates.X + i, coordinates.Y - i].IsOccupied)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + i, coordinates.Y - i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X + i, coordinates.Y - i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + i, coordinates.Y - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDiagonalMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            this.CalculateDiagonalDownLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalDownRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalUpRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateDiagonalUpLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDiagonalUpLeftMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y - i == -1)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X - i, coordinates.Y - i].IsOccupied)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - i, coordinates.Y - i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X - i, coordinates.Y - i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - i, coordinates.Y - i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDiagonalUpRightMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X - i == -1 || coordinates.Y + i == chessBoard.Column)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X - i, coordinates.Y + i].IsOccupied)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - i, coordinates.Y + i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X - i, coordinates.Y + i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - i, coordinates.Y + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDiagonalDownRightMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y < chessBoard.Column - 1)
            {
                for (int i = 1; i < chessBoard.Row; i++)
                {
                    if (coordinates.X + i == chessBoard.Row || coordinates.Y + i == chessBoard.Column)
                    {
                        break;
                    }

                    if (!chessBoard.ChessBoard[coordinates.X + i, coordinates.Y + i].IsOccupied)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + i, coordinates.Y + i));
                    }
                    else
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X + i, coordinates.Y + i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + i, coordinates.Y + i));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculatePawnDownAttackMoves(Pawn pawn, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].Piece.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X < chessBoard.Row - 1 && coordinates.Y > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].Piece.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculatePawnUpAttackMoves(Pawn pawn, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X > 0 && coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].Piece.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X > 0 && coordinates.Y > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].IsOccupied)
                {
                    if (pawn.Player != chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].Piece.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateVerticalDownMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X < chessBoard.Row - 1)
            {
                for (int i = coordinates.X + 1; i < chessBoard.Row; i++)
                {
                    if (chessBoard.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(i, coordinates.Y));
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(i, coordinates.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateVerticalUpMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.X > 0)
            {
                for (int i = coordinates.X; i >= 0; i--)
                {
                    if (chessBoard.ChessBoard[i, coordinates.Y].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[i, coordinates.Y].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(i, coordinates.Y));
                            break;
                        }
                        else
                        {
                            if (i != coordinates.X)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(i, coordinates.Y));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateHorizontalMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            this.CalculateHorizontalRightMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateHorizontalLeftMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateHorizontalLeftMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            if (coordinates.Y > 0)
            {
                for (int i = coordinates.Y; i >= 0; i--)
                {
                    if (chessBoard.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X, i));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateHorizontalRightMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
           if (coordinates.Y < chessBoard.Column - 1)
            {
                for (int i = coordinates.Y; i < chessBoard.Column; i++)
                {
                    if (chessBoard.ChessBoard[coordinates.X, i].IsOccupied)
                    {
                        if (chessPiece.Player != chessBoard.ChessBoard[coordinates.X, i].Piece.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X, i));
                            break;
                        }
                        else
                        {
                            if (coordinates.Y != i)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X, i));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateVerticalMoves(List<Koordinater> possibleMoves, ChessPiece chessPiece, GameState chessBoard, Koordinater coordinates)
        {
            this.CalculateVerticalDownMoves(possibleMoves, chessPiece, chessBoard, coordinates);
            this.CalculateVerticalUpMoves(possibleMoves, chessPiece, chessBoard, coordinates);
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateLeftKnightMoves(Knight knight, GameState chessBoard, Koordinater coordinates, List<Koordinater> result)
        {
            if (coordinates.X + 1 < chessBoard.Row)
            {
                if (coordinates.Y + 2 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 2].Piece.Player != knight.Player)
                        {
                            result.Add(new Koordinater(coordinates.X + 1, coordinates.Y + 2));
                        }
                    }
                    else
                    {
                        result.Add(new Koordinater(coordinates.X + 1, coordinates.Y + 2));
                    }
                }
            }

            if (coordinates.X + 1 < chessBoard.Row)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 2].Piece.Player != knight.Player)
                        {
                            result.Add(new Koordinater(coordinates.X + 1, coordinates.Y - 2));
                        }
                    }
                    else
                    {
                        result.Add(new Koordinater(coordinates.X + 1, coordinates.Y - 2));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateRightKnightMoves(Knight knight, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y + 2 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 2].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y + 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y + 2));
                    }
                }
            }

            if (coordinates.X - 1 >= 0)
            {
                if (coordinates.Y - 2 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 2].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 2].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y - 2));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y - 2));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateUpKnightMoves(Knight knight, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y + 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 2, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 2, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X - 2 >= 0)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 2, coordinates.Y - 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 2, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 2, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateDownKnightMoves(Knight knight, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X + 2 < chessBoard.Row)
            {
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y + 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + 2, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 2, coordinates.Y + 1));
                    }
                }
            }

            if (coordinates.X + 2 < chessBoard.Row)
            {
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 2, coordinates.Y - 1].Piece.Player != knight.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + 2, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 2, coordinates.Y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateKingSideMoves(King king, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.Y - 1 >= 0)
            {
                if (chessBoard.ChessBoard[coordinates.X, coordinates.Y - 1].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X, coordinates.Y - 1].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X, coordinates.Y - 1));
                    }
                }
                else
                {
                    possibleMoves.Add(new Koordinater(coordinates.X, coordinates.Y - 1));
                }
            }

            if (coordinates.Y < chessBoard.Column - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X, coordinates.Y + 1].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X, coordinates.Y + 1].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X, coordinates.Y + 1));
                    }
                }
                else
                {
                    possibleMoves.Add(new Koordinater(coordinates.X, coordinates.Y + 1));
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateKingDownMoves(King king, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X < chessBoard.Row - 1)
            {
                if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y));
                    }
                }
                else
                {
                    possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y));
                }
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y - 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y - 1));
                    }
                }
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X + 1, coordinates.Y + 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X + 1, coordinates.Y + 1));
                    }
                }
            }
        }

        /// <summary>
        /// Beräknar de möjliga drag den valda schackpjäsen kan göra.
        /// </summary>
        private void CalculateKingUpMoves(King king, GameState chessBoard, Koordinater coordinates, List<Koordinater> possibleMoves)
        {
            if (coordinates.X > 0)
            {
                if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].IsOccupied)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y].Piece.Player != king.Player)
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y));
                    }
                }
                else
                {
                    possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y));
                }
                if (coordinates.Y - 1 >= 0)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y - 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y - 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y - 1));
                    }
                }
                if (coordinates.Y + 1 < chessBoard.Column)
                {
                    if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].IsOccupied)
                    {
                        if (chessBoard.ChessBoard[coordinates.X - 1, coordinates.Y + 1].Piece.Player != king.Player)
                        {
                            possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y + 1));
                        }
                    }
                    else
                    {
                        possibleMoves.Add(new Koordinater(coordinates.X - 1, coordinates.Y + 1));
                    }
                }
            }
        }
    }
}