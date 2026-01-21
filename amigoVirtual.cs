using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;



namespace Bot
{
    public class AmigoVirtual
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Olá eu sou Bia a sua amiga virtual!");
            Console.WriteLine("Vamos nos conhecer que tal me falar o seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine($"olá {nome} é um prazer te conhecer");
            Console.WriteLine("Como você está se sentindo? ");
            string reacao = Console.ReadLine().ToLower();
            using var cliente = new HttpClient();
            string URL = "https://type.fit/api/quotes";
            var list = await cliente.GetFromJsonAsync<Mensagem[]>(URL);
            Random random = new Random();
            int numeroAleatorio = random.Next(0,4); 
            var FraseBia = list[numeroAleatorio].text;

            if (reacao != null)
            {
             Console.WriteLine("tenho uma mensagem para você!");
             Console.WriteLine(FraseBia);
            }
            else
            {
                Console.WriteLine("Entendi! Independentemente de como você está, aqui vai algo para o seu dia:");
                Console.WriteLine(FraseBia);
            }
        }
        public class Mensagem
        {
            public string text { get; set; }
            public string author { get; set; }
        }
    }
}
