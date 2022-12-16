namespace Chess.Model
{
    using System;
    [Serializable]

    /// <summary>
    /// Kakelklassen. Representerar en cell i ett schackbräde.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Representerar om brickan är upptagen.
        /// </summary>
        private bool isOccupied;

        /// <summary>
        /// Representerar vilken schackpjäs denna bricka har.
        /// </summary>
        private ChessPiece piece;

        /// <summary>
        /// Initierar en ny instans av Tile-klassen.
        /// </summary>
        public Tile(bool isOccupied, ChessPiece piece)
        {
            this.isOccupied = isOccupied;
            this.piece = piece;
        }

        /// <summary>
        /// Hämtar eller ställer in ett värde som anger om objektet är aktiverat.
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return this.isOccupied;
            }

            set
            {
                this.isOccupied = value;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på bit.
        /// </summary>
        public ChessPiece Piece
        {
            get
            {
                return this.piece;
            }

            set
            {
                this.piece = value;
            }
        }
    }
}