namespace board
{
    internal class Board
    {
        public int NumberLines { get; set; }
        public int NumberColumns { get; set; }
        private Piece[,] Pieces;

        public Board(int numberLines, int numberColumns)
        {
            NumberLines = numberLines;
            NumberColumns = numberColumns;
            Pieces = new Piece[NumberLines,NumberColumns];
        }

        public Piece Pie(int line, int column)
        {
            return Pieces[line, column];
        }
    }
}
