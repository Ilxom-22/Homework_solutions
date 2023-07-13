namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            char userSymbol;
            char computerSymbol;

            do
            {
                Console.Write("Choose X or O: ");
                answer = Console.ReadLine().ToLower().Trim();
            } while (answer != "x" && answer != "o");

            userSymbol = answer == "x" ? 'X': 'O';
            computerSymbol = answer == "x" ? 'O' : 'X';

            Console.WriteLine(userSymbol);

            var board = new Board(userSymbol, computerSymbol);

            while (true)
            {
                board.DrawBoard();
                board.Move();
                if (board.GameOver())
                    break;
            }

            Thread.Sleep(1000);
            Console.Clear();
            if (board.winner != string.Empty)
                Console.WriteLine($"{board.winner} has won!");
            else
                Console.WriteLine("Draw");
        
        }
    }
}