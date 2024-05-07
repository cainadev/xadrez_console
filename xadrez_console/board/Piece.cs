namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMoves { get; set; }
        public Board Tab { get; protected set; }

        public Piece(Color color, Board tab)
        {
            Position = null;
            Color = color;
            Tab = tab;
            NumberMoves = 0;
        }

        public void AddMoves()
        {
            NumberMoves++;
        }

        public void RemoveMoves()
        {
            NumberMoves--;
        }

        public bool TherePossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i< Tab.NumberLines; i++)
            {
                for (int j = 0; j < Tab.NumberColumns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveFor(Position pos)
        {
            return PossibleMoves()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMoves();
    }
}
