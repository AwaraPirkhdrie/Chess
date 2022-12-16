namespace Chess.ViewModel
{
    using System;
    using System.Linq;
    [Serializable]

    /// <summary>
    /// CommandLineHandler-klassen.
    /// </summary>
    public class CommandLineHandler
    {
        /// <summary>
        /// Representerar kommandoradsargumenten.
        /// </summary>
        private string[] args;

        /// <summary>
        /// Representerar bredden och höjden på schackbrädet.
        /// </summary>
        private int[] boardSize;

        /// <summary>
        /// Initierar en ny instans av CommandLineHandler-klassen.
        /// </summary>
        public CommandLineHandler()
        {
            this.args = Environment.GetCommandLineArgs();
            this.boardSize = this.AnalyseCommandLineArgs();
        }

        /// <summary>
        /// Får värdet av boardSize.
        /// </summary>
        public int[] BoardSize
        {
            get
            {
                return this.boardSize;
            }
        }

        /// <summary>
        /// Analyserar kommandoradsargumenten.
        /// </summary>
        private int[] AnalyseCommandLineArgs()
        {
            int[] result = { 8, 8 };

            if (this.args.Length < 4)
            {
                if (this.args.Length == 1)
                {
                    return result;
                }

                if (this.args[1].Equals("-size") && this.args.Length > 2)
                {
                    string[] size = this.GetBoardSizeArguments();

                    if (size != null)
                    {
                        result = this.ParseToIntArray(size);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Hämtar argumenten för brädstorlek från kommandoradsargumenten.
        /// </summary>
        private string[] GetBoardSizeArguments()
        {
            string[] size = null;

                if (this.args[2].Contains('X'))
                {
                    size = this.args[2].Split('X');
                }
                else if (this.args[2].Contains('x'))
                {
                    size = this.args[2].Split('x');
                }

            return size;
        }

        /// <summary>
        /// Analyserar en strängmatris till en heltalsmatris.
        /// </summary>
        private int[] ParseToIntArray(string[] size)
        {
            int[] result = { 8, 8 };

            if (size.Length < 3 && size.Length > 1)
            {
                bool parseSuccessful = false;

                for (int i = 0; i < size.Length; i++)
                {
                    int number;
                    parseSuccessful = int.TryParse(size[i], out number);

                    if (parseSuccessful && (number > 7 && number < 27))
                    {
                        result[i] = number;
                    }
                    else
                    {
                        result[i] = 8;
                    }
                }
            }

            return result;
        }
    }
}