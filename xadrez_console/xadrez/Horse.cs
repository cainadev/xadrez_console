using board;

namespace xadrez
{
    internal class Horse : Piece
    {
        public Horse(Board tab, Color color) : base(color, tab) { }

        public override string ToString()
        {
            return "C";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Tab.Pie(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Tab.NumberLines, Tab.NumberColumns];

            Position pos = new Position(0, 0);

           pos.DefineValue(Position.Line - 1, Position.Column - 2);
           if (Tab.ValidPosition(pos) && CanMove(pos))
           {
                mat[pos.Line, pos.Column] = true;
           }
            pos.DefineValue(Position.Line - 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line - 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line - 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line + 1, Position.Column + 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line + 2, Position.Column + 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line + 2, Position.Column - 1);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.DefineValue(Position.Line + 1, Position.Column - 2);
            if (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
