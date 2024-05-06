using board;

namespace xadrez
{
    internal class Rook : Piece
    {
        public Rook(Board board, Color color) : base(color, board) { }


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

            return mat;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
