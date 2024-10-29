using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Project_chess.Validation;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Project_chess.Models;


namespace Project_chess
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {


        private ChessModel[,] ChessBoard = new ChessModel[8, 8];
        private ChessModel selectedPiece;
        private int selectedX, selectedY;
        private ColorPiece currentTurn = ColorPiece.White; //Нехай спочатку починають білі

        public GameWindow()
        {         
            InitializeComponent();
            InitializeChessPieces();
            UpdateBoardUI();
            InitializeBorder();

        }




        private void InitializeBorder()
        {

         
            // Додаємо ліву рамку
            for (int i = 1; i < 9; i++) 
            {
                StackPanel stackPanel = new StackPanel() { Background = Brushes.Brown, Width = 50 }; 

                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(), // лівий ряд
                    FontSize = 20,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Grid.SetRow(stackPanel, i);
                Grid.SetColumn(stackPanel, 0); // Рамка зліва

                stackPanel.Children.Add(textBlock);
                BoardGrid.Children.Add(stackPanel);
            }

            // Додаємо праву рамку
            for (int i = 1; i < 9; i++)
            {
                StackPanel stackPanel = new StackPanel() { Background = Brushes.Brown, Width = 50 };

                TextBlock textBlock = new TextBlock()
                {
                    Text = i.ToString(), //Правий ряд
                    FontSize = 20,
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left
                };

                Grid.SetRow(stackPanel, i);
                Grid.SetColumn(stackPanel, 9); // Рамка зправа 

                stackPanel.Children.Add(textBlock);
                BoardGrid.Children.Add(stackPanel);
            }
        }



        private void UpdateBoardUI()
        {       
     
      
            for (int row = 0; row < 8; row++)
            {
                for (int column = 0; column < 8; column++)
                {
                 
                    Rectangle rect = new Rectangle
                    {
                        Fill = (row + column) % 2 == 0 ? Brushes.Wheat : Brushes.SandyBrown
                    };

                 
                    Grid.SetRow(rect, row+1); 
                    Grid.SetColumn(rect, column + 1); 
                    BoardGrid.Children.Add(rect);

                    // Якщо там є фігура 
                    if (ChessBoard[row, column] != null)
                    {
                        Image pieceImage = new Image
                        {
                            Source = new BitmapImage(new Uri(ChessBoard[row, column].ImageSource, UriKind.Relative))
                        };


                        Grid.SetRow(pieceImage, row + 1);
                        Grid.SetColumn(pieceImage, column + 1);
                        BoardGrid.Children.Add(pieceImage);

                   
                        Button button = new Button
                        {
                            Background = Brushes.Transparent,
                            BorderBrush = Brushes.Transparent
                        };
                        button.Click += OnCellClick;

                     
                        Grid.SetRow(button, row + 1);
                        Grid.SetColumn(button, column + 1);
                        BoardGrid.Children.Add(button);
                    }

                    //Якщо на цій клітинці немає фігури
                    else
                    {
                     
                        Button button = new Button
                        {
                            Background = Brushes.Transparent,
                            BorderBrush = Brushes.Transparent
                        };
                        button.Click += OnCellClick;

                 
                        Grid.SetRow(button, row + 1);
                        Grid.SetColumn(button, column + 1);
                        BoardGrid.Children.Add(button);
                    }


                }
            }
        }

        

        private void InitializeChessPieces()
        {
            //  білі фігури
            ChessBoard[7, 0] = new Rook(ColorPiece.White, PieceType.Rook, "/FigureImages/RookWhite.png");
            ChessBoard[7, 1] = new Knight(ColorPiece.White, PieceType.Knight, "/FigureImages/NightWhite.png");
            ChessBoard[7, 2] = new Bishop(ColorPiece.White, PieceType.Bishop, "/FigureImages/BishopWhite.png");
            ChessBoard[7, 3] = new Queen(ColorPiece.White, PieceType.Queen, "/FigureImages/QueenWhite.png");
            ChessBoard[7, 4] = new King(ColorPiece.White, PieceType.King, "/FigureImages/KingWhite.png");
            ChessBoard[7, 5] = new Bishop(ColorPiece.White, PieceType.Bishop, "/FigureImages/BishopWhite.png");
            ChessBoard[7, 6] = new Knight(ColorPiece.White, PieceType.Knight, "/FigureImages/NightWhite.png");
            ChessBoard[7, 7] = new Rook(ColorPiece.White, PieceType.Rook, "/FigureImages/RookWhite.png");

            // чорні фігури
            ChessBoard[0, 0] = new Rook(ColorPiece.Black, PieceType.Rook, "/FigureImages/RookBlack.png");
            ChessBoard[0, 1] = new Knight(ColorPiece.Black, PieceType.Knight, "/FigureImages/NightBlack.png");
            ChessBoard[0, 2] = new Bishop(ColorPiece.Black, PieceType.Bishop, "/FigureImages/BishopBlack.png");
            ChessBoard[0, 3] = new Queen(ColorPiece.Black, PieceType.Queen, "/FigureImages/QueenBlack.png");
            ChessBoard[0, 4] = new King(ColorPiece.Black, PieceType.King, "/FigureImages/KingBlack.png");
            ChessBoard[0, 5] = new Bishop(ColorPiece.Black, PieceType.Bishop, "/FigureImages/BishopBlack.png");
            ChessBoard[0, 6] = new Knight(ColorPiece.Black, PieceType.Knight, "/FigureImages/NightBlack.png");
            ChessBoard[0, 7] = new Rook(ColorPiece.Black, PieceType.Rook, "/FigureImages/RookBlack.png");

            //  пішаки білі та чорні
            for (int i = 0; i < 8; i++)
            {
                ChessBoard[6, i] = new Pawn(ColorPiece.White, PieceType.Pawn, "/FigureImages/PawnWhite.png");
                ChessBoard[1, i] = new Pawn(ColorPiece.Black, PieceType.Pawn, "/FigureImages/PawnBlack.png");
            }
      
        }

       
   
        private void OnCellClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int x = Grid.GetRow(clickedButton);
            int y = Grid.GetColumn(clickedButton);

            LogicClick(x, y); 
            InitializeBorder();
        }


        private void LogicClick(int x, int y)
        {
    
            x = x - 1; 
            y = y - 1; 

            if (selectedPiece == null) 
            {
                if (ChessBoard[x, y] != null) // Якщо клітинка не порожня (є фігура)
                {
                    if (ChessBoard[x, y].Color != currentTurn)
                    {
                        MessageBox.Show("Зараз хід іншого гравця");
                        return;
                    }

               //Перевірка

               //     MessageBox.Show($"Вибрано фігуру: {ChessBoard[x, y].GetType().Name}");




                    selectedPiece = ChessBoard[x, y];
                    selectedX = x;
                    selectedY = y;
                }
            }


            else // Якщо фігура вже вибрана
            {
               
                if (ChessBoard[x, y] != null && ChessBoard[x, y].Color == selectedPiece.Color)
                {
                    selectedPiece = null;
                    return;
                }


             // Перевірка 1

            //    MessageBox.Show($"Спроба переміщення {selectedPiece.GetType().Name} з ({selectedX}, {selectedY}) на ({x}, {y})");




               
                if (selectedPiece.IsValidMove(selectedX, selectedY, x, y, ChessBoard))
                {
              
                    ChessBoard[x, y] = selectedPiece;
                    ChessBoard[selectedX, selectedY] = null; 

                    if (selectedPiece is Pawn && (x == 0 || x == 7)) // Для білих - 0 горизонталь, для чорних - 7 горизонталь
                    {
                        NewFigure(x, y);
                    }

                   
                    UpdateBoardUI();
                    selectedPiece = null;

                    currentTurn = (currentTurn == ColorPiece.White) ? ColorPiece.Black : ColorPiece.White;
                    WinnerIs();

                }

                else
                {
                    MessageBox.Show("Некоректний хід"); 
                    selectedPiece = null;
                }

            }
        }


        private void NewFigure(int x, int y)
        {

             MessageBoxResult  dialogResult  =   MessageBox.Show("Ти хочеш замінити пішака на Ферзь?", "info", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {


                if (selectedPiece.Color == ColorPiece.Black)
                {

                    ChessModel newPiece = new Queen(selectedPiece.Color, PieceType.Queen, "/FigureImages/QueenBlack.png");
                    ChessBoard[x, y] = newPiece;

                }

                else if (selectedPiece.Color == ColorPiece.White)
                {

                    ChessModel newPiece = new Queen(selectedPiece.Color, PieceType.Queen, "/FigureImages/QueenWhite.png");
                    ChessBoard[x, y] = newPiece;

                }

            }

            else if (dialogResult == MessageBoxResult.No)
            {

                MessageBoxResult dialogResult_1 = MessageBox.Show("Ти хочеш замінити пішака на Туру?", "info", MessageBoxButton.YesNo);
                if (dialogResult_1 == MessageBoxResult.Yes)
                {


                    if (selectedPiece.Color == ColorPiece.Black)
                    {

                        ChessModel newPiece = new Rook(selectedPiece.Color, PieceType.Queen, "/FigureImages/RookBlack.png");
                        ChessBoard[x, y] = newPiece;

                    }

                    else if (selectedPiece.Color == ColorPiece.White)
                    {

                        ChessModel newPiece = new Rook(selectedPiece.Color, PieceType.Queen, "/FigureImages/RookWhite.png");
                        ChessBoard[x, y] = newPiece;

                    }

                }

                else if (dialogResult_1 == MessageBoxResult.No)
                {


                    MessageBoxResult dialogResult_2 = MessageBox.Show("Ти хочеш замінити пішака на Слона?", "info", MessageBoxButton.YesNo);
                    if (dialogResult_2 == MessageBoxResult.Yes)
                    {


                        if (selectedPiece.Color == ColorPiece.Black)
                        {

                            ChessModel newPiece = new Bishop(selectedPiece.Color, PieceType.Bishop, "/FigureImages/BishopBlack.png");
                            ChessBoard[x, y] = newPiece;

                        }

                        else if (selectedPiece.Color == ColorPiece.White)
                        {

                            ChessModel newPiece = new Bishop(selectedPiece.Color, PieceType.Bishop, "/FigureImages/BishopWhite.png");
                            ChessBoard[x, y] = newPiece;

                        }


                    }
                    else if (dialogResult_2 == MessageBoxResult.No)
                    {
                        MessageBoxResult dialogResult_3 = MessageBox.Show("Ти хочеш замінити пішака на Коня?", "info", MessageBoxButton.YesNo);
                        if (dialogResult_3 == MessageBoxResult.Yes)
                        {
                            if (selectedPiece.Color == ColorPiece.Black)
                            {

                                ChessModel newPiece = new Knight(selectedPiece.Color, PieceType.Knight, "/FigureImages/NightBlack.png");
                                ChessBoard[x, y] = newPiece;

                            }

                            else if (selectedPiece.Color == ColorPiece.White)
                            {

                                ChessModel newPiece = new Knight(selectedPiece.Color, PieceType.Knight, "/FigureImages/NightWhite.png");
                                ChessBoard[x, y] = newPiece;

                            }
                        } 

                    }

              }

            }

      }

       


        private void WinnerIs()
        {
            if(!HasFigures(ColorPiece.Black) && !HasFigures(ColorPiece.White))
            {
                MessageBox.Show("Нічия");
            }

            else if (HasFigures(ColorPiece.Black) && !HasFigures(ColorPiece.White))
            {
                MessageBox.Show("Перемогли  шахи чорного кольору");
            }

            else if(!HasFigures(ColorPiece.Black) && HasFigures(ColorPiece.White))
            {
                MessageBox.Show("Перемогли шахи білого кольору");
            }
        }



        private bool HasFigures(ColorPiece color)
        {
            foreach (var figure in ChessBoard)
            {
                if (figure != null && figure.Color == color)
                {
                    return true; 
                }

            }
            return false;
        }







    }
}
