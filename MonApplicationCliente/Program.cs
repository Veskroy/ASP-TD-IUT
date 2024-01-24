namespace MonApplicationCliente
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5292");

            HttpResponseMessage messageretour = await client.GetAsync("/Home/Index");

            if (messageretour.IsSuccessStatusCode)
            {
                Console.WriteLine(messageretour.ToString());
                Console.WriteLine(await messageretour.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(messageretour.ToString());
            }
            Console.ReadKey();
        }
    }
}