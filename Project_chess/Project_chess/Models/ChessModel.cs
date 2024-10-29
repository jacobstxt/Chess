using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project_chess.Models
{
    public  abstract class ChessModel
    {

        public string ImageSource { get; set; }
        public ColorPiece Color {  get;private set; }
        public PieceType pieceType { get;private set; }



        public ChessModel(ColorPiece _color, PieceType _pieceType, string image)
        {
            Color = _color;
            pieceType = _pieceType;
            ImageSource = image;
        }


        public abstract bool IsValidMove(int startX, int startY, int endX, int endY, ChessModel[,] board);

    }

    public enum ColorPiece
    {
        White,//Біла Фігура
        Black//Чорна Фігура
    }

    public enum PieceType
    {
        Pawn,//Пішак
        Rook,//Тура
        Knight,//Кінь
        Bishop,//Слон
        Queen,//Королева
        King//Король
    }











}
