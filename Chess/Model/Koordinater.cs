namespace Chess.Model
{
    using System;

    /// <summary>
    /// Koordinaterklassen.
    /// </summary>
    [Serializable]
    public class Koordinater
    {
        /// <summary>
        /// Representerar x-koordinaten.
        /// </summary>
        private int x;

        /// <summary>
        /// Representerar y-koordinaten.
        /// </summary>
        private int y;

        /// <summary>
        /// Initierar en ny instans av klassen Koordinater.
        /// </summary>
        public Koordinater(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Får värdet på x.
        /// </summary>
        public int X 
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Får värdet av y.
        /// </summary>
        public int Y
        {
            get
            {
                return this.y;
            }
        }
    }
}