namespace Chess.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// IMOveCalculator-gränssnittet.
    /// </summary>
    public interface IMovement
    {
        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(Bishop bishop, GameState chessBoard, Koordinater coordinates);

        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(Pawn pawn, GameState chessBoard, Koordinater coordinates);

        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(Rook rook, GameState chessBoard, Koordinater coordinates);

        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(Queen queen, GameState chessBoard, Koordinater coordinates);

        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(Knight knight, GameState chessBoard, Koordinater coordinates);

        /// <summary>
        /// En lista med koordinater som innehåller möjliga drag för en vald schackpjäs.
        /// </summary>
        List<Koordinater> CalculateLegalMoves(King king, GameState chessBoard, Koordinater coordinates);
    }
}