using board;

namespace xadrez
{
    internal class Queen : Piece
    {
        public Queen(Board tab, Color color) : base(color, tab) { }

        public override string ToString()
        {
            return "D";
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

            // Acima
            pos.DefineValue(Position.Line - 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) != null && Tab.Pie(pos).Color != Color) { break; }
                pos.Line--;
            }

            //abaixo
            pos.DefineValue(Position.Line + 1, Position.Column);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) != null && Tab.Pie(pos).Color != Color) { break; }
                pos.Line++;
            }

            // Direita
            pos.DefineValue(Position.Line, Position.Column + 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) != null && Tab.Pie(pos).Color != Color) { break; }
                pos.Column++;
            }

            // Esquerda
            pos.DefineValue(Position.Line, Position.Column - 1);
            while (Tab.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Tab.Pie(pos) != null && Tab.Pie(pos).Color != Color) { break; }
                pos.Column--;
            }

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
