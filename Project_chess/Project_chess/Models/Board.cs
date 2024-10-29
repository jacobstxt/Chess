using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_chess.Models
{
    internal class Board
    {

        public ChessModel[,] ChessBoard { get; private set; }

        public Board()
        {
            ChessBoard = new ChessModel[8, 8]; 
        }

    }
}
