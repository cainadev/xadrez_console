namespace board
{
    class Piece
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
    }
}
