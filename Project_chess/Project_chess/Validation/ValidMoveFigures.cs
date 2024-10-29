using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_chess.Models;
using System.Windows.Media;

namespace Project_chess.Validation
{
    

        public class Knight : ChessModel
        {
            public Knight(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.Knight, image) { }

            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int dx = Math.Abs(endX - startX);
                int dy = Math.Abs(endY - startY);
                return (dx == 2 && dy == 1) || (dx == 1 && dy == 2);

            }
        }

        public class Pawn : ChessModel
        {
            public Pawn(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.Pawn, image) { }


            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int direction = (Color == ColorPiece.White) ? -1 : 1; // Напрямок руху якщо біла то вона йде вверх , якщо чорна , то вниз


                if (startX == (Color == ColorPiece.White ? 6 : 1) && startX + 2 * direction == endX && startY == endY)
                {

                    if (board[startX + direction, startY] == null && board[endX, endY] == null)
                    {
                        return true;
                    }
                }



                if (startX + direction == endX && startY == endY && board[endX, endY] == null)
                {
                    return true;
                }

                // Чи може побити по діагоналі фігуру
                if (startX + direction == endX && Math.Abs(endY - startY) == 1 && board[endX, endY] != null && board[endX, endY].Color != Color)
                {
                    return true;
                }



                return false;
            }









        }

        public class Rook : ChessModel
        {
            public Rook(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.Rook, image) { }

            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                if (startX != endX && startY != endY) return false; // Рух тільки по лінії
                return IsPathClear(startX, startY, endX, endY, board);
            }

            private bool IsPathClear(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int stepX = (endX == startX) ? 0 : (endX > startX ? 1 : -1);
                int stepY = (endY == startY) ? 0 : (endY > startY ? 1 : -1);
                int x = startX + stepX;
                int y = startY + stepY;

                while (x != endX || y != endY)
                {
                    if (board[x, y] != null) return false; // Якщо на шляху є фігура
                    x += stepX;
                    y += stepY;
                }
                return true;
            }
        }

        public class Bishop : ChessModel
        {
            public Bishop(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.Bishop, image) { }

            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                if (Math.Abs(endX - startX) != Math.Abs(endY - startY)) return false; // Рух  по діагоналі
                return IsPathClear(startX, startY, endX, endY, board);
            }

            private bool IsPathClear(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int stepX = (endX > startX) ? 1 : -1;
                int stepY = (endY > startY) ? 1 : -1;
                int x = startX + stepX;
                int y = startY + stepY;

                while (x != endX && y != endY)
                {
                    if (board[x, y] != null) return false;
                    x += stepX;
                    y += stepY;
                }
                return true; // Шлях чистий
            }
        }

        public class King : ChessModel
        {
            public King(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.King, image) { }

            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int dx = Math.Abs(endX - startX);
                int dy = Math.Abs(endY - startY);
                return (dx <= 1 && dy <= 1);
            }
        }

        public class Queen : ChessModel
        {
            public Queen(ColorPiece color, PieceType pieceType, string image) : base(color, PieceType.Queen, image) { }

            public override bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int dx = Math.Abs(endX - startX);
                int dy = Math.Abs(endY - startY);
                if (dx == dy || startX == endX || startY == endY)
                {
                    if (dx == dy) // Діагональний рух
                    {
                        return IsPathClear(startX, startY, endX, endY, board);
                    }
                    else // Вертикальний чи горизонтальний рух
                    {
                        return IsPathClear(startX, startY, endX, endY, board);
                    }
                }
                return false; // Неправильний рух
            }

            private bool IsPathClear(int startX, int startY, int endX, int endY, ChessModel[,] board)
            {
                int stepX = (endX == startX) ? 0 : (endX > startX ? 1 : -1);
                int stepY = (endY == startY) ? 0 : (endY > startY ? 1 : -1);
                int x = startX + stepX;
                int y = startY + stepY;

                while (x != endX || y != endY)
                {
                    if (board[x, y] != null) return false; // Якщо на шляху є фігура
                    x += stepX;
                    y += stepY;
                }
                return true; // Шлях чистий
            }
        }
  
}
