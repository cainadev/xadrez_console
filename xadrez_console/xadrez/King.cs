using board;

namespace xadrez
{
    internal class King : Piece
    {
        public King(Board board, Color color) : base(color, board) { }

        public override string ToString()
        {
            return "R";
        }
    }
}
