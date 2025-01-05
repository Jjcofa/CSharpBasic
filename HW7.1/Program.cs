char[] gameBoard = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
char player = 'X';
bool gameRun = true;

while (gameRun)
{
    Console.Clear();
    Console.WriteLine(" ");
    Console.WriteLine($" {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");
    Console.WriteLine("-----------");
    Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
    Console.WriteLine("-----------");
    Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} ");
    Console.WriteLine(" ");

    Console.WriteLine($"Ход игрока {player} (1-9)");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int move) && move >= 1 && move <= 9 && gameBoard[move - 1] != 'X' && gameBoard[move - 1] != 'O')
    {
        gameBoard[move - 1] = player;

        int[,] winCombos= {
                    { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                    { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                    { 0, 4, 8 }, { 2, 4, 6 }
                };

        bool win = false;
        for (int i = 0; i < winCombos.GetLength(0); i++)
        {
            if (gameBoard[winCombos[i, 0]] == gameBoard[winCombos[i, 1]] &&
                gameBoard[winCombos[i, 1]] == gameBoard[winCombos[i, 2]])
            {
                win = true;
            }
        }

        if (win)
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine($" {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} ");
            Console.WriteLine(" ");
            Console.WriteLine($"Игрок {player} выиграл!");
            gameRun = false;
        }
        else if (Array.TrueForAll(gameBoard, c => c == 'X' || c == 'O'))
        {
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine($" {gameBoard[0]} | {gameBoard[1]} | {gameBoard[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {gameBoard[3]} | {gameBoard[4]} | {gameBoard[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {gameBoard[6]} | {gameBoard[7]} | {gameBoard[8]} ");
            Console.WriteLine(" ");
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