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

        public Piece Pie(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool TherePie(Position pos) // Validar se existe uma peça na posição
        {
            ValidatePosition(pos);
            return Pie(pos) != null;
        }

        public void InsertPie(Piece p, Position pos) // Colocar Peça 
        {
            if (TherePie(pos))
            {
                throw new BoardException("Ja existe uma peça nessa posição");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePie(Position pos)
        {
            if (Pie(pos) == null)
            {
                return null;
            }
            Piece aux = Pie(pos);
            aux.Position = null;
            Pieces[pos.Line, pos.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position pos) // Saber se a posição é valida
        {
            if (pos.Line < 0 || pos.Line >= NumberLines || pos.Column < 0 || pos.Column >= NumberColumns)
            {
                return false;
            } 
            return true;
        }

        public void ValidatePosition(Position pos) // Validar uma Posição
        {
            if (!ValidPosition(pos))
            {
                throw new BoardException("Posição Invalida");
            }
        }

    }
}
