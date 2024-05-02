namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumberMoves { get; set; }
        public Board Tab { get; protected set; }

        public Piece(Position position, Color color, Board tab)
        {
            Position = position;
            Color = color;
            Tab = tab;
            NumberMoves = 0;
        }
    }
}
