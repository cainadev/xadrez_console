﻿namespace board
{
    internal class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position(int linha, int coluna)
        {
            Line = linha;
            Column = coluna;
        }

        public override string ToString()
        {
            return $"{Line}, {Column}";
        }
    }
}
