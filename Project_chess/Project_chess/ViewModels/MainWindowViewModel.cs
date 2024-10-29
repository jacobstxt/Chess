using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Project_chess.Command;

namespace Project_chess.ViewModels
{
    public class MainWindowViewModel
    {
        public ICommand StartGameCommand { get; }
        public GameWindow _GameWindow;

        public MainWindowViewModel()
        {    
            StartGameCommand = new CustomCommand(OpenGameWindow);
        }

        private void OpenGameWindow(object paremetr)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();   
        }

      

    }
}
