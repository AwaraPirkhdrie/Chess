namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// Klassen ChessPiece.
    /// </summary>
    public abstract class ChessPiece
    {
        /// <summary>
        /// Spelarens uppräkning.
        /// </summary>
        private Player player;

        /// <summary>
        /// Initierar en ny instans av klassen ChessPiece.
        /// </summary>
        public ChessPiece(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Får värdet av spelaren.
        /// </summary>
        public Player Player
        {
            get
            {
                return this.player;
            }
        }

        /// <summary>
        /// Beräknar möjliga drag för denna schackpjäs.
        /// </summary>
        public abstract List<Koordinater> CalculatePossiblePlace(IMovement moveCalculator, GameState board, Koordinater coordinates);
    }
}