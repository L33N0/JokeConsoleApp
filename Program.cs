using System.Net.Http.Json;
using System.Text.Json;

namespace JokeConsoleApp
{
    public struct Joke
    {
        public string setup { get; set; }
        public string punchline { get; set; }
    }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            Console.WriteLine("---Jokes App---");

            while (true)
            {
                Console.WriteLine("Wanna hear a joke?(Y/N)");

                ConsoleKeyInfo response = Console.ReadKey(true);

                if (response.Key == ConsoleKey.Y)
                {
                    var joke = await client.GetFromJsonAsync<Joke>("https://official-joke-api.appspot.com/random_joke");

                    Console.WriteLine($"\nSetup: {joke.setup}");

                    Console.WriteLine($"Punchline: {joke.punchline}\n");
                }
                else if (response.Key == ConsoleKey.N)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid Option\n");
                }

            }

            Console.WriteLine("\nExiting...");
        }
    }
}
