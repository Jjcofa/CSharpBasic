char[,] gameBoard = {
    { '1', '2', '3' },
    { '4', '5', '6' },
    { '7', '8', '9' }
};

char player = 'X';
bool gameRun = true;

while (gameRun)
{
    Console.Clear();

    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine($" {gameBoard[i, 0]} | {gameBoard[i, 1]} | {gameBoard[i, 2]} ");
        if (i < 2) Console.WriteLine("-----------");
    }

    Console.WriteLine($"Ход игрока {player} (1-9):");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int move) && move >= 1 && move <= 9)
    {
        int row = (move - 1) / 3;
        int col = (move - 1) % 3;

        if (gameBoard[row, col] != 'X' && gameBoard[row, col] != 'O')
        {
            gameBoard[row, col] = player;

            bool win = false;

            for (int r = 0; r < 3; r++)
            {
                if (gameBoard[r, 0] == player &&
                    gameBoard[r, 1] == player &&
                    gameBoard[r, 2] == player)
                {
                    win = true;
                }
            }

            for (int c = 0; c < 3; c++)
            {
                if (gameBoard[0, c] == player &&
                    gameBoard[1, c] == player &&
                    gameBoard[2, c] == player)
                {
                    win = true;
                }
            }

            if ((gameBoard[0, 0] == player && gameBoard[1, 1] == player && gameBoard[2, 2] == player) ||
                (gameBoard[0, 2] == player && gameBoard[1, 1] == player && gameBoard[2, 0] == player))
            {
                win = true;
            }

            if (win)
            {
                Console.Clear();

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine($" {gameBoard[i, 0]} | {gameBoard[i, 1]} | {gameBoard[i, 2]} ");
                    if (i < 2) Console.WriteLine("-----------");
                }

                Console.WriteLine($"Игрок {player} выиграл!");
                gameRun = false;
            }
            else
            {

                bool isDraw = true;
                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (gameBoard[r, c] != 'X' && gameBoard[r, c] != 'O')
                        {
                            isDraw = false;
                        }
                    }
                }

                if (isDraw)
                {
                    Console.Clear();

                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine($" {gameBoard[i, 0]} | {gameBoard[i, 1]} | {gameBoard[i, 2]} ");
                        if (i < 2) Console.WriteLine("-----------");
                    }

                    Console.WriteLine("Ничья");
                    gameRun = false;
                }
                else
                {
                    if (player == 'X')
                    {
                        player = 'O';
                    }
                    else
                    {
                        player = 'X';
                    }
                }
            }
        }
    }
}
