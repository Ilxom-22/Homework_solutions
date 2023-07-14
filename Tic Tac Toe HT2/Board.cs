namespace TicTacToe
{
    public class Board
    {
        private char _userSymbol;
        private char _computerSymbol;
        private char[,] _mainBoard = new char[3,3];
        private bool _turn = true;
        public string winner = string.Empty;

        public Board(char userSymbol, char computerSymbol)
        {
            _userSymbol = userSymbol;
            _computerSymbol = computerSymbol;
        }

        public void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("-------------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 3; j++)
                {
                    char symbol = _mainBoard[i,j] == default ? ' ' : _mainBoard[i,j];
                    Console.Write($" {symbol} |");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        public void Move()
        {
            if (_turn)
            {
                ComputerMove();
            }
            else
            {
                int row;
                int col;
                do
                {
                    row = UserMove("Row");
                    col = UserMove("Column");
                } while (_mainBoard[row, col] != default);

                _mainBoard[row, col] = _userSymbol;
            }
            _turn = !_turn;
            Thread.Sleep(1000);
        }


        private int UserMove(string coordinate)
        {
            int ans;
            bool convert;
            do
            {
                Console.Write($"Input the {coordinate}: ");
                convert = int.TryParse(Console.ReadLine(), out ans);
            } while (!convert || ans > 3);

            return ans-1;
        }

        private void ComputerMove()
        {
            var rd = new Random();
            int row;
            int col;

            do
            {
                row = rd.Next(3);
                col = rd.Next(3);
            } while (_mainBoard[row,col] != default);

            _mainBoard[row, col] = _computerSymbol;
        }


        public bool GameOver()
        {
            {
                for (int row = 0; row < 3; row++)
                {
                    if (_mainBoard[row, 0] != default)
                    {
                        if (_mainBoard[row, 0] == _mainBoard[row, 1] && _mainBoard[row, 1] == _mainBoard[row, 2])
                        {
                            winner = _mainBoard[row, 0] == _userSymbol ? "User" : "Computer";
                            return true;
                        }
                    }
                }

                for (int col = 0; col < 3; col++)
                {
                    if (_mainBoard[0, col] != default)
                    {
                        if (_mainBoard[0, col] == _mainBoard[1, col] && _mainBoard[1, col] == _mainBoard[2, col])
                        {
                            winner = _mainBoard[0, col] == _userSymbol ? "User" : "Computer";
                            return true;
                        }
                    }
                }

                if (_mainBoard[1, 1] != default)
                {
                    if ((_mainBoard[0, 0] == _mainBoard[1, 1] && _mainBoard[1, 1] == _mainBoard[2, 2]) ||
                        (_mainBoard[0, 2] == _mainBoard[1, 1] && _mainBoard[1, 1] == _mainBoard[2, 0]))
                    {
                        winner = _mainBoard[1, 1] == _userSymbol ? "User" : "Computer";
                        return true;
                    }
                }

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                        if (_mainBoard[row, col] == default)
                            return false;
                }
            }
            return true;
        }
    }
}

