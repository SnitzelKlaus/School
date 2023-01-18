namespace ConsoleBrowser
{
    class Program
    {
        HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetPage("https://www.google.com/finance/");
        }

        private async Task GetPage(string uri)
        {
            string data = await client.GetStringAsync(uri);
            Console.WriteLine(data);
        }
    }
}