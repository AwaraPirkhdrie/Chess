namespace Chess.Model
{
    using System;
    using System.Collections.Generic;
    [Serializable]

    /// <summary>
    /// The Pawn class.
    /// </summary>
    public class Pawn : ChessPiece
    {
        /// <summary>
        /// Initierar en ny instans av klassen Pawn.
        /// </summary>
        public Pawn(Player player) : base(player)
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
            return "B";
        }
    }
}