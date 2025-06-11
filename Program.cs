namespace animeRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to the Standardized Eastern-animation Rating Program.\n");
            Console.ResetColor();
            Console.WriteLine("⠄⣀⣾⣿⡿⣾⡿⣿⣿⡿⣼⠟⠁⢰⣿⡿⣿⣿⢿⣿⣿⠑⢹⣿⣿⣿⣦⣝⡷⡀\r\n⠿⢋⢟⢻⡇⠋⢠⣿⡿⠹⠏⡆⠄⠘⣿⠃⠸⣿⢇⠙⢿⡇⠈⡜⢿⣿⠻⣿⡇⡇\r\n⡞⣵⡇⡏⡄⠄⣿⠋⢀⣺⡖⠁⠄⠄⠁⠄⠄⢋⣾⣆⠈⠃⠄⢱⠈⣿⠄⠈⣇⠄\r\n⣾⣿⣷⣼⡇⠄⠇⠠⡟⣋⣭⢄⠘⢄⠄⠄⠄⢝⣆⡀⢄⠸⡄⢸⠄⠈⠄⠄⠸⠄\r\n⣿⡏⣿⣿⡇⠘⡴⡞⣰⣟⣫⡌⣷⣤⣦⣄⡈⠞⣹⣵⠌⣦⢙⡼⠄⠄⠄⠄⢠⠁\r\n⠹⣧⠘⣿⣿⠄⠈⢻⢝⡣⢈⢂⣽⣿⣿⣿⣿⣿⣅⣉⣒⣽⣶⠁⠄⠄⢀⣰⠁⠄\r\n⠄⠈⠄⠄⣍⢥⣄⣀⣁⢻⣿⣿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣛⣁⣠⣾⣫⣿⣿⠄⠄\r\n⠄⠄⠄⠄⡿⠓⣮⣁⢿⡞⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢯⢮⣽⡟⣿⣿⠄⠄\r\n⠄⠄⠄⠄⢳⠄⣿⡿⣯⡻⣮⢿⣿⣷⣶⣶⣶⣿⣿⣿⡿⣫⣿⢻⣿⡇⣿⣿⣇⠄\r\n⠄⠄⠄⠠⣸⠄⢿⢃⣿⣿⡇⠑⠘⢿⣿⣿⣿⣿⠟⡉⢀⢿⡿⢸⣿⣇⢿⣿⣿⣆");
            Console.WriteLine("\r\n                                                      \r\n .M\"\"\"bgd    `7MM\"\"\"YMM     `7MM\"\"\"Mq.     `7MM\"\"\"Mq. \r\n,MI    \"Y      MM    `7       MM   `MM.      MM   `MM.\r\n`MMb.          MM   d         MM   ,M9       MM   ,M9 \r\n  `YMMNq.      MMmmMM         MMmmdM9        MMmmdM9  \r\n.     `MM      MM   Y  ,      MM  YM.        MM       \r\nMb     dM ,,   MM     ,M ,,   MM   `Mb. ,,   MM  ,,   \r\nP\"Ybmmd\"  db .JMMmmmmMMM db .JMML. .JMM.db .JMML.db   \r\n                                                      \r\n                                                      \r\n");

            var score = Rate();

            ConsoleColor color = GetColor(score);
            Console.ForegroundColor = color;
            Console.WriteLine($"\nCalculated score: {score}");

            string rating = score >= 10 ? "This anime is a masterpiece." :
                             score >= 9 ? "This anime is amazing." :
                             score >= 8 ? "This anime is very good." :
                             score >= 7 ? "This anime is good." :
                             score >= 6 ? "This anime is pretty mid." :
                             score == 0 ? "You didn't finish the anime, why are you rating it???" :
                                          "This anime is bad.";

            Console.WriteLine(rating);
            Console.ResetColor();
        }

        static double Rate()
        {
            Console.ResetColor();
            Console.WriteLine("\nDid you finish the anime? (1 = No, 5 = Yes)");
            int finished = GetScore();
            if (finished == 1) return 0;

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
                if (int.TryParse(Console.ReadLine(), out int score) && score >= 1 && score <= 5)
                    return score;
                Console.WriteLine("Please enter a valid integer between 1 and 5");
            }
        }

        static ConsoleColor GetColor(double score)
        {
            return score >= 10 ? ConsoleColor.Magenta :
                   score >= 9 ? ConsoleColor.Cyan :
                   score >= 8 ? ConsoleColor.Green :
                   score >= 7 ? ConsoleColor.Blue :
                   score >= 6 ? ConsoleColor.Yellow :
                   score > 0 ? ConsoleColor.Red :
                                ConsoleColor.DarkGray;
        }
    }
}
