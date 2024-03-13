namespace MonApplicationWebMVC.Models
{
    public class Pays
    {

        public string Nom { get; set; }
        public string Continent { get; set; }
        public int Population { get; set; }
        public string Drapeaux { get; set; }
        public float Superficie { get; set; }

        public IFormFile ImportDrapeau { get; set; }

        

        public enum list_Continent
        { 
            Europe,
            Asie,
            Amerique_Nord,
            Amerique_Sud,
            Afrique,
            Océanie
        }


        public static List<Pays> TousLesPays()
        {
            return new List<Pays>
            {
                new Pays{Nom="France",Superficie=672051,Continent="Europe",Population=68042591,Drapeaux="France.png" },
            new Pays { Nom = "Mozambique", Superficie =8547404, Continent = "Afrique", Population =215002523, Drapeaux = "Mozambique.png" },
            new Pays { Nom = "Brésil", Superficie = 8547404, Continent = "Amérique", Population =215002523, Drapeaux = "Brazil.png" },
                new Pays{Nom="Allemagne",Superficie= 357588,Continent="Europe",Population=84358845,Drapeaux="Allemagne.png" },
            };


        }

     

    }
}
