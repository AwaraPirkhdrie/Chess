namespace Chess.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Chess.Commands;
    using Chess.Model;

    /// <summary>
    /// The GameSessionVM class.
    /// </summary>
    public class GameStateVM : INotifyPropertyChanged
    {
        /// <summary>
        /// En observerbar samling av GameState. Representerar spelets historia.
        /// </summary>
        private ObservableCollection<GameState> gameHistory;

        /// <summary>
        /// En instans av klassen ChessBoardHandler.
        /// </summary>
        private ChessBoardCreator chessBoardHandler;

        /// <summary>
        /// En instans av klassen CommandLineHandler.
        /// </summary>
        private CommandLineHandler commandLineHandler;

        /// <summary>
        /// En observerbar samling schackpjäser som representerar den vita kyrkogården.
        /// </summary>
        private ObservableCollection<ChessPiece> whiteGraveyard;

        /// <summary>
        /// En observerbar samling schackpjäser som representerar den svarta kyrkogården.
        /// </summary>
        private ObservableCollection<ChessPiece> blackGraveyard;

        /// <summary>
        /// En instans av klassen touchCalculator.
        /// </summary>
        private MoveCalculator touchCalculator;

        /// <summary>
        /// En instans av GameState-klassen.
        /// </summary>
        private GameState currentBoard;

        /// <summary>
        /// Representerar antalet kolumner.
        /// </summary>
        private int column;

        /// <summary>
        /// Representerar antalet rader.
        /// </summary>
        private int row;

        /// <summary>
        /// En instans av klassen KingInCheckCalculator.
        /// </summary>
        private KingInCheckCalculator CheckCalculator;
             
        /// <summary>
        /// En observerbar samling som representerar de möjliga rörelserna.
        /// </summary>
        private ObservableCollection<Koordinater> possibleMoves;

        /// <summary>
        /// En boolean som representerar värdet av whiteKingCheck.
        /// </summary>
        private bool whiteKingCheck;

        /// <summary>
        /// En boolean som representerar värdet av blackKingCheck.
        /// </summary>
        private bool blackKingCheck;

        /// <summary>
        /// Initierar en ny instans av GameStateVM-klassen.
        /// </summary>
        public GameStateVM()
        {
            this.touchCalculator = new MoveCalculator();
            this.possibleMoves = new ObservableCollection<Koordinater>();
            this.blackGraveyard = new ObservableCollection<ChessPiece>();
            this.whiteGraveyard = new ObservableCollection<ChessPiece>();
            this.commandLineHandler = new CommandLineHandler();
            this.chessBoardHandler = new ChessBoardCreator();
            this.CheckCalculator = new KingInCheckCalculator();
            this.gameHistory = new ObservableCollection<GameState>();
            this.whiteKingCheck = false;
            this.blackKingCheck = false;
            this.column = this.commandLineHandler.BoardSize[0];
            this.row = this.commandLineHandler.BoardSize[1];
            this.SelectedTile = null;
            this.StartNewGame();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Hämtar eller ställer in värdet för SelectedTile.
        /// </summary>
        public Koordinater SelectedTile
        {
            get;
            set;
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på CurrentBoard.
        /// </summary>
        public GameState CurrentBoard
        {
            get
            {
                return this.currentBoard;
            }

            set
            {
                this.currentBoard = value;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på möjliga drag.
        /// </summary>
        public ObservableCollection<Koordinater> PossibleMoves
        {
            get
            {
                return this.possibleMoves;
            }

            set
            {
                this.possibleMoves = value;
            }
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

        /// <summary>
        /// Hämtar eller ställer in värdet på whiteGraveyard.
        /// </summary>
        public ObservableCollection<ChessPiece> WhiteGraveyard
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
        /// Hämtar eller ställer in ett värde som anger om objektet är aktiverat.
        /// </summary>
        public bool BlackPlayerWon
        {
            get
            {
                if (this.gameHistory.IndexOf(this.CurrentBoard) % 2 != 0 && this.whiteKingCheck)
                {
                       return true;
                }

                return false;
            }

            set
            {
                this.BlackPlayerWon = value;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in ett värde som anger om objektet är aktiverat.
        /// </summary>
        public bool WhitePlayerWon
        {
            get
            {
                if (this.gameHistory.IndexOf(this.CurrentBoard) % 2 == 0 && this.blackKingCheck)
                {
                        return true;
                }

                return false;
            }

            set
            {
                this.WhitePlayerWon = value;
            }
        }

        /// <summary>
        /// Får ett värde som anger om objektet är aktiverat.
        /// </summary>
        public bool WhiteKingInCheck
        {
            get
            {
                return this.whiteKingCheck;
            }
        }

        /// <summary>
        /// Får ett värde som anger om objektet är aktiverat.
        /// </summary>
        public bool BlackKingInCheck
        {
            get
            {
                return this.blackKingCheck;
            }
        }

        /// <summary>
        /// Hämtar eller ställer in värdet på blackGraveyard.
        /// </summary>
        public ObservableCollection<ChessPiece> BlackGraveyard
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
        /// Får värdet av LoadTurn.
        /// </summary>
        public ICommand LoadTurn
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    int index = (int)obj;

                    if (index != -1)
                    {
                        try
                        {
                            this.currentBoard = this.gameHistory[index];
                            this.WhiteGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.WhiteGraveyard);
                            this.BlackGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.BlackGraveyard);
                            this.UpdateVM();
                        }
                        catch
                        {
                            this.UpdateVM();
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Får värdet av NotifyVM.
        /// </summary>
        public ICommand NotifyVM
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.currentBoard = this.gameHistory[this.gameHistory.Count - 1];
                    this.row = this.currentBoard.Row;
                    this.column = this.currentBoard.Column;
                    this.WhiteGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.WhiteGraveyard);
                    this.BlackGraveyard = new ObservableCollection<ChessPiece>(this.currentBoard.BlackGraveyard);
                    this.UpdateVM();
                });
            }
        }

        /// <summary>
        /// Får värdet av StartNewGameSession.
        /// </summary>
        public ICommand StartNewGameSession
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    this.StartNewGame();
                    this.UpdateVM();
                });
            }
        }

        /// <summary>
        /// Får värdet av SelectTile.
        /// </summary>
        public ICommand SelectTile
        {
            get
            {
                return new GenericCommand(obj =>
                {
                    if (!this.WhitePlayerWon && !BlackPlayerWon)
                    {
                        if (this.SelectedTile != null)
                        {
                            this.TryToMovePiece(obj);
                            this.FirePropertyChanged("PossibleMoves");
                            this.FirePropertyChanged("WhitePlayerWon");
                            this.FirePropertyChanged("BlackPlayerWon");
                            return;
                        }

                        this.SelectPiece(obj);
                        this.FirePropertyChanged("PossibleMoves");
                    }
                });
            }
        }

        /// <summary>
        /// Får brädnamnet på ett bräde baserat på de flyttade schackpjäserna.
        /// </summary>
        public string GetChessBoardName(Koordinater oldCoordinates, Koordinater newCoordinates, int rowCount)
        {
            string oldPosition = this.IntToStringConverter(oldCoordinates.Y) + this.IntToRowConverter(oldCoordinates.X, rowCount);
            string newPosition = this.IntToStringConverter(newCoordinates.Y) + this.IntToRowConverter(newCoordinates.X, rowCount);

            return oldPosition + " -> " + newPosition;
        }

        /// <summary>
        /// Konverterar ett heltal till radvärdet.
        /// </summary>
        public string IntToRowConverter(int i, int rowCount)
        {
            return (rowCount - i).ToString();
        }

        /// <summary>
        /// Får koordinaterna för en utvald schackpjäs.
        /// </summary>
        public int[] GetCoordinates(object obj)
        {
            string[] input = obj.ToString().Split(' ');
            int[] result = new int[2];
            result[0] = int.Parse(input[0]);
            result[1] = int.Parse(input[1]);
            return result;
        }

        /// <summary>
        /// Utlöser händelsen PropertyChanged.
        /// </summary>
        protected virtual void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Konverterar heltalsvärden till teckenvärden.
        /// </summary>
        private string IntToStringConverter(int i)
        { 
            switch (i)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
                case 10:
                    return "K";
                case 11:
                    return "L";
                case 12:
                    return "M";
                case 13:
                    return "N";
                case 14:
                    return "O";
                case 15:
                    return "P";
                case 16:
                    return "Q";
                case 17:
                    return "R";
                case 18:
                    return "S";
                case 19:
                    return "T";
                case 20:
                    return "U";
                case 21:
                    return "V";
                case 22:
                    return "W";
                case 23:
                    return "X";
                case 24:
                    return "Y";
                case 25:
                    return "Z";
                default: return string.Empty;
            }
        }

        /// <summary>
        /// Skapar en ny GameState baserat på den flyttade schackpjäsen.
        /// </summary>
        private GameState CreateNextGameState(Koordinater oldKoordinater, Koordinater newKoordinater)
        {
            Tile[,] newBoard = new Tile[this.currentBoard.Row, this.currentBoard.Column];
            for (int i = 0; i < this.currentBoard.Row; i++)
            {
                for (int j = 0; j < this.currentBoard.Column; j++)
                {
                    newBoard[i, j] = new Tile(this.currentBoard.ChessBoard[i, j].IsOccupied, this.currentBoard.ChessBoard[i, j].Piece);
                }
            }

            ChessPiece movingChessPiece = newBoard[oldKoordinater.X, oldKoordinater.Y].Piece;
            ChessPiece deadChessPiece = null;
            bool chessPieceDied = this.CheckIfChessPieceDied(newBoard, newKoordinater);           
            if (chessPieceDied)
            {
                deadChessPiece = newBoard[newKoordinater.X, newKoordinater.Y].Piece;
            }
            newBoard[newKoordinater.X, newKoordinater.Y].Piece = movingChessPiece;
            newBoard[newKoordinater.X, newKoordinater.Y].IsOccupied = true;
            newBoard[oldKoordinater.X, oldKoordinater.Y].IsOccupied = false;
            string moveName = this.GetChessBoardName(oldKoordinater, newKoordinater, this.currentBoard.Row);
            GameState result = new GameState(this.currentBoard.Column, this.currentBoard.Row, moveName, newBoard);
            if (chessPieceDied)
            {
                this.KillChessPiece(deadChessPiece);
            }

            return result;
        }

        /// <summary>
        /// Kontrollerar om en schackpjäs dött av ett schackdrag.
        /// </summary>
        private bool CheckIfChessPieceDied(Tile[,] board, Koordinater coordinates)
        {
            if (board[coordinates.X, coordinates.Y].IsOccupied)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lägger till en schackpjäs till en kyrkogård.
        /// </summary>
        /// <param name="deadChessPiece">Tar ett ChessPiece-objekt som indata.</param>
        private void KillChessPiece(ChessPiece deadChessPiece)
        {
            if (deadChessPiece.Player == Player.WHITE)
            {
                this.WhiteGraveyard.Add(deadChessPiece);
                this.FirePropertyChanged("WhiteGraveyard");
            }
            else if (deadChessPiece.Player == Player.BLACK)
            {
                this.BlackGraveyard.Add(deadChessPiece);
                this.FirePropertyChanged("BlackGraveyard");
            }
        }

        /// <summary>
        /// Försöker flytta en schackpjäs till dess målbricka.
        /// </summary>
        private void TryToMovePiece(object obj)
        {
            int[] oldCoordinates = this.GetCoordinates(obj);
            Koordinater moveCoordinates = new Koordinater(oldCoordinates[0], oldCoordinates[1]);
            foreach (Koordinater possibleCoordinates in this.possibleMoves)
            {
                if (moveCoordinates.X == possibleCoordinates.X && moveCoordinates.Y == possibleCoordinates.Y)
                {
                    GameState newGameState = this.CreateNextGameState(this.SelectedTile, moveCoordinates);

                    if (this.currentBoard != this.gameHistory[this.gameHistory.Count - 1])
                    {
                        while (this.currentBoard != this.gameHistory[this.gameHistory.Count - 1])
                        {
                            this.gameHistory.Remove(this.gameHistory[this.gameHistory.Count - 1]);
                        }
                    }
                    this.CopyGraveyards(newGameState);
                    this.gameHistory.Add(newGameState);
                    this.currentBoard = newGameState;
                    this.possibleMoves.Clear();
                    this.FinishMove();
                    break;
                }
            }

            this.SelectPiece(obj);
        }

        /// <summary>
        /// Kopior över gårdstillstånden från den nuvarande GameState till den nya GameState.
        /// </summary>
        private void CopyGraveyards(GameState newChessBoard)
        {
            foreach (ChessPiece chessPiece in this.WhiteGraveyard)
            {
                newChessBoard.WhiteGraveyard.Add(chessPiece);
            }

            foreach (ChessPiece chesspiece in this.BlackGraveyard)
            {
                newChessBoard.BlackGraveyard.Add(chesspiece);
            }
        }

        /// <summary>
        /// Updates the GameSessionVM.
        /// </summary>
        private void FinishMove()
        {
            this.blackKingCheck = this.CheckCalculator.kingCheck(Player.BLACK, this.CurrentBoard);
            this.whiteKingCheck = this.CheckCalculator.kingCheck(Player.WHITE, this.CurrentBoard);
            this.FirePropertyChanged("WhiteKingInCheck");
            this.FirePropertyChanged("BlackKingInCheck");
            this.FirePropertyChanged("WhieGraveyard");
            this.FirePropertyChanged("BlackGraveyard");
            this.possibleMoves.Clear();
            this.FirePropertyChanged("CurrentBoard");
            this.FirePropertyChanged("PossibleMoves");
            this.SelectedTile = null;
        }

        /// <summary>
        /// Väljer ett ChessPiece-objekt om möjligt.
        /// </summary>
        private void SelectPiece(object obj)
        {
            int[] selectedTile = this.GetCoordinates(obj);

            Koordinater selectedPieceCoordinates = new Koordinater(selectedTile[0], selectedTile[1]);
          
            if (this.currentBoard.ChessBoard[selectedPieceCoordinates.X, selectedPieceCoordinates.Y].IsOccupied)
            {
                ChessPiece piece = this.currentBoard.ChessBoard[selectedPieceCoordinates.X, selectedPieceCoordinates.Y].Piece;

                if (this.gameHistory.IndexOf(this.currentBoard) % 2 == 0)
                {
                    if (piece.Player == Player.WHITE)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
                else
                {
                    if (piece.Player == Player.BLACK)
                    {
                        this.GetPossibleMoves(selectedPieceCoordinates);
                    }
                }
            }
        }

        /// <summary>
        /// Får de möjliga dragen av en schackpjäs.
        /// </summary>
        private void GetPossibleMoves(Koordinater selectedPiece)
        {
            List<Koordinater> list;

            if (this.currentBoard.ChessBoard[selectedPiece.X, selectedPiece.Y].IsOccupied)
            {
                list = this.currentBoard.ChessBoard[selectedPiece.X, selectedPiece.Y].Piece.CalculatePossiblePlace(this.touchCalculator, this.currentBoard, selectedPiece);
            }
            else
            {
                return;
            }

            ObservableCollection<Koordinater> collection = new ObservableCollection<Koordinater>(list);
            this.possibleMoves = collection;
            this.SelectedTile = selectedPiece;
        }

        /// <summary>
        /// Updates the GameStateVM.
        /// </summary>
        private void UpdateVM()
        {
            this.blackKingCheck = this.CheckCalculator.kingCheck(Player.BLACK, this.CurrentBoard);
            this.whiteKingCheck = this.CheckCalculator.kingCheck(Player.WHITE, this.CurrentBoard);
            this.FirePropertyChanged("WhiteGraveyard");
            this.FirePropertyChanged("BlackGraveyard");
            this.FirePropertyChanged("GameHistory");
            this.FirePropertyChanged("CurrentBoard");
            this.FirePropertyChanged("WhitePlayerWon");
            this.FirePropertyChanged("BlackPlayerWon");
            this.FirePropertyChanged("WhiteKingInCheck");
            this.FirePropertyChanged("BlackKingInCheck");
        }

        /// <summary>
        /// Startar ett nytt parti schack.
        /// </summary>
        private void StartNewGame()
        {
            GameState chessBoard = this.chessBoardHandler.CreateNewBoard(this.column, this.row, "Start");
            this.gameHistory.Clear();
            this.gameHistory.Add(chessBoard);
            this.possibleMoves.Clear();
            this.blackGraveyard.Clear();
            this.whiteGraveyard.Clear();
            this.currentBoard = chessBoard;
        }
    }
}