namespace Chess.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using Chess.Model;

    /// <summary>
    /// The GameHistoryVM class.
    /// </summary>
    [Serializable]
    public class GameHistoryVM
    {
        /// <summary>
        /// En observerbar samling som innehåller GamState-objekt.
        /// </summary>
        private ObservableCollection<GameState> gameHistory;

        /// <summary>
        /// Initierar en ny instans av GameHistoryVM-klassen.
        /// </summary>
        public GameHistoryVM()
        {
            this.gameHistory = new ObservableCollection<GameState>();
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på gameHistory.
        /// </summary>
        public ObservableCollection<GameState> GameHistory
        {
            get
            {
                return this.gameHistory;
            }

            set
            {
                this.gameHistory = value;
            }
        }
    }
}
