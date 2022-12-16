namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The King class.
    /// </summary>
    public class King : ChessPiece
    {
        /// <summary>
        /// Initierar en ny instans av King-klassen.
        /// </summary>
        public King(Player player) : base(player)
        {
        }

        /// <summary>
        /// Beräknar möjliga drag för denna schackpjäs.
        /// </summary>
        public override List<Koordinater> CalculatePossiblePlace(IMovement moveCalculator, GameState board, Koordinater coordinates)
        {
            return moveCalculator.CalculateLegalMoves(this, board, coordinates);
        }

        /// <summary>
        /// Returnerar en sträng som representerar det aktuella objektet.
        /// </summary>
        public override string ToString()
        {
            return "K";
        }
    }
}