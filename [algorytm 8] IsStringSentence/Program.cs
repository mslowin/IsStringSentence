namespace IsStringSentence
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine("Input a string to see if it is a sentance. Type q to quit.");
                var message = Console.ReadLine();
                if (message == "q")
                {
                    return;
                }
                if (message != null && message != "")
                {
                    Sentance testSentance = new(message);

                    if (testSentance.IsSentanceOk())
                    {
                        Console.WriteLine("String IS a sentance :)");
                    }
                    else
                    {
                        Console.WriteLine("String IS NOT a sentance :(");
                    }
                }
                else
                {
                    Console.WriteLine("Try again.");
                }
            }
        }
    }
}