namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// Biskopsklassen.
    /// </summary>
    public class Bishop : ChessPiece
    {
        /// <summary>
        /// Initierar en ny instans av Bishop-klassen.
        /// </summary>
        public Bishop(Player player) : base(player)
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
            return "L";
        }
    }
}