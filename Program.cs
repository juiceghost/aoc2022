namespace aoc2022;

static class Helper
{
    public static IEnumerable<IList<T>> ChunksOf<T>(this IEnumerable<T> sequence, int size)
    {
        List<T> chunk = new List<T>(size);

        foreach (T element in sequence)
        {
            chunk.Add(element);
            if (chunk.Count == size)
            {
                yield return chunk;
                chunk = new List<T>(size);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Day 3 Part 2");
        String input = File.ReadAllText(@"data.txt");

        List<int> foundTypes = new List<int>();
        List<int> foundSubTypes = new List<int>();

        foreach (IList<string> chunk in input.Split('\n').ChunksOf(3))
        {
            //foundTypes.Clear();
            //System.Console.WriteLine("{0}\n{1}\n{2}\n\n", chunk[0], chunk[1], chunk[2]);
            string firstLine = chunk[0];
            string secondLine = chunk[1];
            string thirdLine = chunk[2];

            foreach (char flc in firstLine)
            {
                if (secondLine.Contains(flc))
                {
                    // match between first and second
                    foreach (char slc in secondLine)
                    {
                        if (thirdLine.Contains(slc) && firstLine.Contains(slc))
                        {
                            //System.Console.WriteLine("MATCH!");
                            foundSubTypes.Add(getItemType(slc));
                        }
                    }
                }
            }
            foundSubTypes = foundSubTypes.Distinct().ToList();
            foundTypes = foundTypes.Concat(foundSubTypes).ToList();
            foundSubTypes.Clear();
        }
        System.Console.WriteLine("sum: " + foundTypes.Sum());


    }

    static int getItemType(char item)
    {
        if ((int)item > 96 && (int)item < 123)
        {
            //Lowercase!
            return (int)item - 96;
        }
        else
        {
            return (int)item - 38;
        }
    }
    static void Day3Part1(string[] args)
    {
        Console.WriteLine("Day 3 Part 1");
        String input = File.ReadAllText(@"data.txt");
        System.Console.WriteLine((int)'a'); // 97 -96
        System.Console.WriteLine((int)'z'); // 122
        System.Console.WriteLine((int)'A'); // 65
        System.Console.WriteLine((int)'Z' - 38); // 90 (-38)
                                                 //Console.ReadLine();

        int sum = 0;
        bool found = false;
        List<int> foundTypes = new List<int>();
        List<int> foundSubTypes = new List<int>();
        foreach (var row in input.Split('\n'))
        {

            //var charArray = row.ToArray();
            var first = row.Substring(0, (int)(row.Length / 2));
            var last = row.Substring((int)(row.Length / 2), (int)(row.Length / 2));
            //System.Console.WriteLine("row: " + row);
            //System.Console.WriteLine("first: " + first);
            //System.Console.WriteLine("last: " + last);
            foundTypes.Clear();
            foreach (char fc in first)
            {
                if (last.Contains(fc))
                {
                    //System.Console.WriteLine("MATCH: " + fc + " prio: " + getItemType(fc));
                    //sum += getItemType(fc);
                    foundSubTypes.Add(getItemType(fc));
                    break;
                }
            }
            //foundSubTypes = foundSubTypes.Distinct().ToList();
            foundTypes = foundTypes.Concat(foundSubTypes).ToList();

        }
        /*  System.Console.WriteLine("Should be 1: " + getItemType('a'));
         System.Console.WriteLine("Should be 26: " + getItemType('z'));
         System.Console.WriteLine("Should be 27: " + getItemType('A'));
         System.Console.WriteLine("Should be 52: " + getItemType('Z'));
         System.Console.WriteLine("line count: " + input.Split('\n').Count());
         System.Console.WriteLine("foundTypes count: " + foundTypes.Count()); */
        System.Console.WriteLine("sum: " + foundTypes.Sum());
    }

    static void Day2Part2(string[] args)
    {
        Console.WriteLine("Hello, World!");
        String input = File.ReadAllText(@"data.txt");

        int playerScore = 0;
        int opponentScore = 0;
        int rockValue = 1;
        int paperValue = 2;
        int scissorValue = 3;

        // 0 for lost
        // 3 for draw
        // 6 if win

        // Opponent
        // A for rock
        // B for paper
        // C for scissors

        // Outcome
        // X you need to lose
        // Y you need draw
        // Z you need to win


        foreach (var row in input.Split('\n'))
        {
            string[] round = row.Split(' ');
            System.Console.WriteLine("Opponent will play {0} and you should play {1}", round[0], round[1]);
            if (round[0] == "A")
            {
                // Opponent played rock
                if (round[1] == "X")
                {
                    // You need to lose
                    playerScore += scissorValue;
                    playerScore += 0; // loss
                }
                if (round[1] == "Y")
                {
                    // You you need draw
                    playerScore += rockValue;
                    playerScore += 3; // draw
                }
                if (round[1] == "Z")
                {
                    playerScore += paperValue;
                    playerScore += 6; // win
                                      // You need to win

                }
            }
            if (round[0] == "B")
            {
                // Opponent played paper
                if (round[1] == "X")
                {
                    // You need to lose
                    playerScore += rockValue;
                    playerScore += 0; // loss

                }
                if (round[1] == "Y")
                {
                    // You you need draw
                    playerScore += paperValue;
                    playerScore += 3; // draw

                }
                if (round[1] == "Z")
                {
                    playerScore += scissorValue;
                    playerScore += 6; // win
                                      // You need to win

                }
            }
            if (round[0] == "C")
            {
                // Opponent played scissors
                if (round[1] == "X")
                {
                    // You need to lose
                    playerScore += paperValue;
                    playerScore += 0; // win


                }
                if (round[1] == "Y")
                {
                    // You you need draw
                    playerScore += scissorValue;
                    playerScore += 3; // loss

                }
                if (round[1] == "Z")
                {
                    // You need to win
                    playerScore += rockValue;
                    playerScore += 6; // draw



                }
            }
        }
        System.Console.WriteLine("score {0}", playerScore);
    }
    static void Day2Part1(string[] args)
    {
        Console.WriteLine("Hello, World!");
        String input = File.ReadAllText(@"data.txt");

        int playerScore = 0;
        int opponentScore = 0;
        int rockValue = 1;
        int paperValue = 2;
        int scissorValue = 3;

        // 0 for lost
        // 3 for draw
        // 6 if win

        // Opponent
        // A for rock
        // B for paper
        // C for scissors

        // You should play
        // X for Rock
        // Y for Paper
        // Z for Scissors


        foreach (var row in input.Split('\n'))
        {
            string[] round = row.Split(' ');
            System.Console.WriteLine("Opponent will play {0} and you should play {1}", round[0], round[1]);
            if (round[0] == "A")
            {
                // Opponent played rock
                if (round[1] == "X")
                {
                    // You should play rock
                    playerScore += rockValue;
                    playerScore += 3; // draw
                }
                if (round[1] == "Y")
                {
                    // You should play Paper
                    playerScore += paperValue;
                    playerScore += 6; // win
                }
                if (round[1] == "Z")
                {
                    playerScore += scissorValue;
                    playerScore += 0; // loss
                                      // You should play Scissors

                }
            }
            if (round[0] == "B")
            {
                // Opponent played paper
                if (round[1] == "X")
                {
                    // You should play rock
                    playerScore += rockValue;
                    playerScore += 0; // loss

                }
                if (round[1] == "Y")
                {
                    // You should play Paper
                    playerScore += paperValue;
                    playerScore += 3; // draw

                }
                if (round[1] == "Z")
                {
                    playerScore += scissorValue;
                    playerScore += 6; // win
                                      // You should play Scissors

                }
            }
            if (round[0] == "C")
            {
                // Opponent played scissors
                if (round[1] == "X")
                {
                    // You should play rock
                    playerScore += rockValue;
                    playerScore += 6; // win


                }
                if (round[1] == "Y")
                {
                    // You should play Paper
                    playerScore += paperValue;
                    playerScore += 0; // loss

                }
                if (round[1] == "Z")
                {
                    // You should play Scissors
                    playerScore += scissorValue;
                    playerScore += 3; // draw



                }
            }
        }
        System.Console.WriteLine("score {0}", playerScore);
    }
}
