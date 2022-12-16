namespace Chess.Model
{
    using System;

    [Serializable]

    /// <summary>
    /// Klassen ChessBoardCreator.
    /// </summary>
    public class ChessBoardCreator 
    {
        /// <summary>
        /// Skapar ett nytt schackbräde.
        /// </summary>
        public GameState CreateNewBoard(int width, int height, string name)
        {
            Tile[,] tileSet = new Tile[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0 || j == 7)
                        {
                           tileSet[i, j] = new Tile(true, new Rook(Player.BLACK));
                        }
                        else if (j == 1 || j == 6)
                        {
                            tileSet[i, j] = new Tile(true, new Knight(Player.BLACK));
                        }
                        else if (j == 2 || j == 5)
                        {
                            tileSet[i, j] = new Tile(true, new Bishop(Player.BLACK));
                        }
                        else if (j == 3)
                        {
                            tileSet[i, j] = new Tile(true, new Queen(Player.BLACK));
                        }
                        else if (j == 4)
                        {
                            tileSet[i, j] = new Tile(true, new King(Player.BLACK));
                        }
                        else
                        {
                            tileSet[i, j] = new Tile(false, null);
                        }
                    }
                    else if (i == 1)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                        {
                            tileSet[i, j] = new Tile(true, new Pawn(Player.BLACK));
                        }
                        else
                        {
                            tileSet[i, j] = new Tile(false, null);
                        }
                    }
                    else if (i == height - 1)
                    {
                        if (j == 0 || j == 7)
                        {
                            tileSet[i, j] = new Tile(true, new Rook(Player.WHITE));
                        }
                        else if (j == 1 || j == 6)
                        {
                            tileSet[i, j] = new Tile(true, new Knight(Player.WHITE));
                        }
                        else if (j == 2 || j == 5)
                        {
                            tileSet[i, j] = new Tile(true, new Bishop(Player.WHITE));
                        }
                        else if (j == 3)
                        {
                            tileSet[i, j] = new Tile(true, new Queen(Player.WHITE));
                        }
                        else if (j == 4)
                        {
                            tileSet[i, j] = new Tile(true, new King(Player.WHITE));
                        }
                        else
                        {
                            tileSet[i, j] = new Tile(false, null);
                        }
                    }
                    else if (i == height - 2)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5 || j == 6 || j == 7)
                        {
                            tileSet[i, j] = new Tile(true, new Pawn(Player.WHITE));
                        }
                        else
                        {
                            tileSet[i, j] = new Tile(false, null);
                        }
                    }
                    else
                    {
                        tileSet[i, j] = new Tile(false, null);
                    }
                }
            }

            GameState newBoard = new GameState(width, height, name, tileSet);
            return newBoard;
        }
    }
}