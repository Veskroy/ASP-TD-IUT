using System.Net.Mime;
using System.Text;

namespace MinimalWebAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }


        public static void HealthCkeck()
        { throw new Exception("Une erreur est survenue"); }
        
        public static IResult RetournerUneChaine()
        { return Results.Text("Bonjour,Minimal API en .NetCore"); }

        static public Task RetournerUneChaineDeCaractèreUtf8(HttpContext httpContext)
        {
            string uneChaineDeCaractèreUtf8 = "Une chaine de caractère UTF8";
            UTF8Encoding utf8 = new UTF8Encoding();
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = MediaTypeNames.Text.Plain;
            httpContext.Response.ContentLength = Encoding.UTF8.GetByteCount(uneChaineDeCaractèreUtf8);
            return httpContext.Response.WriteAsync(uneChaineDeCaractèreUtf8, UTF8Encoding.UTF8) ;
        }
        public class  UnObjectDeRetour
        {
            public  int Code { get; set; }
            public string Message { get; set; }
            public string Criticité {get; set; }

            public static IResult RetournerUnObjectJson()
            {
                UnObjectDeRetour unObject = new UnObjectDeRetour()
                { Code = 45, Message = "Traitement effectué", Criticité = "Elevée" };
                return Results.Json(unObject);
            }

        }
        public static IResult RetourneLeDouble(int unNombre)
        {
            return Results.Text($"Le double de {unNombre} est " + (unNombre * 2).ToString());
        }

        public static IResult RetournerDivision(float dividende,float diviseur)
        {
            return Results.Text($" {dividende}/{diviseur} = " + (dividende/diviseur).ToString());
        }
        /*
        public static IResult TraitementAvecBeaucoupDeParamètres(HttpRequest request)
        {
            var id = request.RouteValues["id"];
            var page= request.Query["page"];
            var customHeader = request.Headers["X-CUSTOM-HEADER"];
        }
        */
    }
}