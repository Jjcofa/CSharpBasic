string choice, day;
Console.WriteLine("Введите номер дня недели:");
choice = Console.ReadLine();

if (choice == "1")
    day = "Понедельник";
else if (choice == "2")
    day = "Вторник";
else if (choice == "3")
    day = "Среда";
else if (choice == "4")
    day = "Четверг";
else if (choice == "5")
    day = "Пятница";
else if (choice == "6")
    day = "Суббота";
else if (choice == "7")
    day = "Воскресенье";
else
    day = "Неверное число! (1-7)";

Console.WriteLine($"Ваш день: {day}");