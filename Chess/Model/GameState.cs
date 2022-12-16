namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// GameState-klassen som representerar ett schackbräde.
    /// </summary>
    public class GameState 
    {
        /// <summary>
        /// The Tile 2D Array på schackbrädet.
        /// </summary>
        private Tile[,] chessBoard;

        /// <summary>
        /// Namnet på denna ChessBoard-instans.
        /// </summary>
        private string name;

        /// <summary>
        /// Representerar antalet kolumner.
        /// </summary>
        private int column;

        /// <summary>
        /// Representerar värdet på rader.
        /// </summary>
        private int row;

        /// <summary>
        /// En lista som innehåller schackpjäserna på den vita kyrkogården.
        /// </summary>
        private List<ChessPiece> whiteGraveyard;

        /// <summary>
        /// En lista som innehåller schackpjäserna på den svarta kyrkogården.
        /// </summary>
        private List<ChessPiece> blackGraveyard;

        /// <summary>
        /// Initierar en ny instans av GameState-klassen.
        /// </summary>
        public GameState(int width, int height, string name, Tile[,] board)
        {
            this.blackGraveyard = new List<ChessPiece>();
            this.whiteGraveyard = new List<ChessPiece>();
            this.column = width;
            this.row = height;
            this.name = name;
            this.chessBoard = board;
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på whiteGraveYard.
        /// </summary>
        public List<ChessPiece> WhiteGraveyard
        {
            get
            {
                return this.whiteGraveyard;
            }

            set
            {
                this.whiteGraveyard = value;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på blackGraveyard.
        /// </summary>
        public List<ChessPiece> BlackGraveyard
        {
            get
            {
                return this.blackGraveyard;
            }

            set
            {
                this.blackGraveyard = value;
            }
        }

        /// <summary>
        /// Hämtar kolumnsvärdet.
        /// </summary>
        public int Column
        {
            get
            {
                return this.column;
            }
        }

        /// <summary>
        /// Får värdet av rad.
        /// </summary>
        public int Row
        {
            get
            {
                return this.row;
            }
        }

        /// <summary>
        /// Får namnets värde.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Får värdet av bräda.
        /// </summary>
        public Tile[,] ChessBoard
        {
            get
            {
                return this.chessBoard;
            }
        }
    }
}