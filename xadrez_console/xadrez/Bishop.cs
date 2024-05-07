using board;

namespace xadrez
{
    internal class Bishop : Piece
    {
        public Bishop(Board tab, Color color) : base(color, tab) { }

        public override string ToString()
        {
            return "B";
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

            // NO
            pos.DefineValue(Position.Line - 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) == null && Tab.Pie(pos).Color != Color) 
                {
                    break;
                }
                pos.DefineValue(pos.Line - 1, pos.Column - 1);
            }
            // NE
            pos.DefineValue(Position.Line - 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) == null && Tab.Pie(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValue(pos.Line - 1, pos.Column + 1);
            }
            // SE
            pos.DefineValue(Position.Line + 1, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) == null && Tab.Pie(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValue(pos.Line + 1, pos.Column + 1);
            }
            // SO
            pos.DefineValue(Position.Line + 1, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) == null && Tab.Pie(pos).Color != Color)
                {
                    break;
                }
                pos.DefineValue(pos.Line + 1, pos.Column - 1);
            }

            return mat;
        }
    }
}
