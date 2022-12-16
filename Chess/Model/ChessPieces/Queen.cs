namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The Queen class.
    /// </summary>
    public class Queen : ChessPiece
    {
        /// <summary>
        /// Initierar en ny instans av Queen-klassen.
        /// </summary>
        public Queen(Player player) : base(player)
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
            return "D";
        }
    }
}
