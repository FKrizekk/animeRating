namespace animeRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Replace the original line with the following code
            string welcome = "Welcome to the Standardized Eastern-animation Rating Program.\n\n";
            ConsoleColor defaultColor = Console.ForegroundColor;
            foreach (char c in welcome)
            {
                if (char.IsUpper(c) && c != 'W')
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(c);
                    Console.ForegroundColor = defaultColor;
                }
                else
                {
                    Console.Write(c);
                }
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("⠀⠀⣠⣤⣄⣾⣿⡷⣠⣴⣶⣿⣿⣿⣿⣿⣿⣷⣶⣤⡀\r\n⠀⣼⠋⠀⣾⡟⣳⣾⣿⡿⣿⣿⣿⠟⣿⣿⣿⣿⣿⣿⣿⣷⣄\r\n⠀⡇⠀⠀⠉⢱⣿⣿⡿⢰⣿⣿⠃⢰⣿⣿⣿⣿⣿⡟⢿⣿⣿⣷\r\n⠀⠁⠀⠀⠀⣿⣿⣿⠇⣼⣿⠇⡀⢸⡿⣿⣿⣿⡿⠁⢸⣿⣿⣿⡇\r\n⠀⠀⠀⠀⢰⢰⣿⡿⢀⣸⣿⣤⣿⡈⡇⢿⣿⡿⢁⡎⢸⣿⡇⣿⣿\r\n⠀⠀⠀⠀⣼⢸⣿⡇⣸⣤⣶⣶⣤⣽⣷⣼⡯⠐⠿⢇⣿⡿⠀⣿⣿\r\n⠀⠀⠀⠀⣿⣿⣿⡇⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣹⡦⠂⣿⣿\r\n⠀⠀⠀⠀⣿⡁⣿⡇⠻⣿⣿⣿⣧⣙⠛⣛⣿⣿⣿⣿⣿⠡⠂⣿⡏\r\n⠀⠀⠀⠀⣿⣧⣙⡇⠲⢀⣉⠛⠛⠿⠿⠿⣿⣿⡿⠿⠋⣴⢀⣿⠃\r\n⠀⠀⠀⣸⣿⡿⣿⡟⢠⣿⣿⢷⣦⢠⣤⣤⣤⠰⣶⣶⣿⠃⣼⣡\r\n⠀⠀⢠⣿⡿⢠⣿⢡⣿⣿⠃⣾⡇⣸⢸⣿⣿⡇⡿⢿⣿⣿⣿⣿");
            Console.WriteLine("");
            Console.WriteLine(".M\"\"\"bgd    `7MM\"\"\"YMM     `7MM\"\"\"Mq.     `7MM\"\"\"Mq. \r\n,MI    \"Y      MM    `7       MM   `MM.      MM   `MM.\r\n`MMb.          MM   d         MM   ,M9       MM   ,M9 \r\n  `YMMNq.      MMmmMM         MMmmdM9        MMmmdM9  \r\n.     `MM      MM   Y  ,      MM  YM.        MM       \r\nMb     dM ,,   MM     ,M ,,   MM   `Mb. ,,   MM  ,,   \r\nP\"Ybmmd\"  db .JMMmmmmMMM db .JMML. .JMM.db .JMML.db   \r\n                                                      \r\n                                                      \r\n");

            var score = Rate();

            ConsoleColor color = GetColor(score);
            Console.ForegroundColor = color;
            Console.WriteLine($"\nCalculated score: {score}");

            string rating = score >= 10 ? "This anime is a masterpiece." :
                             score >= 9 ? "This anime is amazing." :
                             score >= 8 ? "This anime is very good." :
                             score >= 7 ? "This anime is good." :
                             score >= 6 ? "This anime is pretty mid." :
                             score == 0 ? "You didn't even finish the anime, why are you rating it???" :
                                          "This anime is bad.";

            Console.WriteLine(rating);
            Console.ResetColor();
        }

        static double Rate()
        {
            Console.ResetColor();
            Console.WriteLine("\nDid you finish the anime? (Y/N)");
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if(key.Key == ConsoleKey.Y || key.Key == ConsoleKey.N)
                {
                    if (key.Key == ConsoleKey.N)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("N");
                        return 0;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Y");
                        break;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Please press either Y or N");
            }
            Console.ResetColor();

            Console.WriteLine("\nRate the story (1-5):");
            int story = GetScore();
            Console.WriteLine("\nRate the characters (1-5):");
            int characters = GetScore();
            Console.WriteLine("\nRate the animation (1-5):");
            int animation = GetScore();
            Console.WriteLine("\nRate the music (1-5):");
            int music = GetScore();
            Console.WriteLine("\nRate the pacing (1-5):");
            int pacing = GetScore();
            Console.WriteLine("\nRate the emotional impact (1-5):");
            int emotionalImpact = GetScore();
            Console.WriteLine("\nRate the ending (1-5):");
            int ending = GetScore();

            double totalScore = story + characters + animation + music + pacing + emotionalImpact + ending;
            double normalized = (totalScore - 7) / (35 - 7); // maps 7–35 to 0–1

            if (normalized < 0) normalized = 0;
            if (normalized > 1) normalized = 1;

            var adjusted = -6 * Math.Pow(normalized, 2) + 15 * normalized + 1;

            return Math.Round(adjusted, 1);
        }

        static int GetScore()
        {
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (char.IsDigit(key.KeyChar))
                {
                    int score = key.KeyChar - '0';
                    if (score >= 1 && score <= 5)
                    {
                        // Set color based on score
                        ConsoleColor prevColor = Console.ForegroundColor;
                        Console.ForegroundColor = score switch
                        {
                            5 => ConsoleColor.Magenta,
                            4 => ConsoleColor.Cyan,
                            3 => ConsoleColor.Green,
                            2 => ConsoleColor.Yellow,
                            1 => ConsoleColor.Red,
                            _ => prevColor
                        };
                        Console.WriteLine(score);
                        Console.ForegroundColor = prevColor;
                        return score;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Please press a valid integer between 1 and 5");
                Console.ResetColor();
            }
        }

        static ConsoleColor GetColor(double score)
        {
            return score >= 10 ? ConsoleColor.Magenta :
                   score >= 9 ? ConsoleColor.Cyan :
                   score >= 8 ? ConsoleColor.Blue :
                   score >= 7 ? ConsoleColor.Green :
                   score >= 6 ? ConsoleColor.Yellow :
                   score > 0 ? ConsoleColor.Red :
                                ConsoleColor.DarkGray;
        }
    }
}
