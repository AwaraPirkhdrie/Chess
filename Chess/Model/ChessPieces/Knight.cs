namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The Knight class.
    /// </summary>
    public class Knight : ChessPiece
    {
        /// <summary>
        /// Initierar en ny instans av riddarklassen.
        /// </summary>
        public Knight(Player player) : base(player)
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
            return "S";
        }
    }
}