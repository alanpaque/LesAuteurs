using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using les_auteurs.BO;

namespace les_auteurs
{
    public class Program
    {
        static void Main(string[] args)
        {
            InitialiserDatas();

            //DEBUT prenom commencant par G
            var listPrenomG = ListeAuteurs.Where(a => a.Nom.ToUpper().StartsWith("G")).Select(a => a.Prenom);
            Console.WriteLine("Prénoms commencant par G : ");
            foreach (var prenomG in listPrenomG) {
                Console.WriteLine(prenomG);
            }
            //FIN prenom commencant par G

            Console.WriteLine();

            //DEBUT auteur avec le plus de livre
            var auteurMaxLivre = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(l => l.Count()).FirstOrDefault().Key;
            Console.WriteLine($"L'auteur avec le plus de livre est : {auteurMaxLivre.Prenom} {auteurMaxLivre.Nom}");
            //FIN auteur avec le plus de livre

            Console.WriteLine();

            //DEBUT nombre moyen page par auteur 
            var ListeLivresParAuteur = ListeLivres.GroupBy(l => l.Auteur);
            Console.WriteLine("Nombre moyens de page par auteur : ");
            foreach (var listeLivres in ListeLivresParAuteur) {
                var nbPage = listeLivres.Average(l => l.NbPages);
                Console.WriteLine($"{listeLivres.Key.Prenom} {listeLivres.Key.Nom} a une moyennes de page de {nbPage}");
            }
            //FIN nombre moyen page par auteur 

            Console.WriteLine();

            //DEBUT Livre avec le plus de page
            var livreMaxPage = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine($"Le livre avec le plus de page est : {livreMaxPage.Titre}");
            //FIN Livre avec le plus de page

            Console.WriteLine();

            //DEBUT Moyenne des factures auteurs
            var moyenne = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine($"La moyenne est de : {moyenne}");
            //FIN Moyenne des factures auteurs

            Console.WriteLine();

            //DEBUT Auteurs et leurs livres
            Console.WriteLine("Les auteurs et leurs livres : ");
            foreach (var listeLivres in ListeLivresParAuteur) {
                Console.WriteLine($"{listeLivres.Key.Prenom} {listeLivres.Key.Nom} :");
                foreach (var livre in listeLivres) {
                    Console.WriteLine($"    -  {livre.Titre}");
                }
            }
            //FIN Auteurs et leurs livres

            Console.WriteLine();

            //DEBUT Livres par ordre alphabétique
            Console.WriteLine("Livres par ordre alphabétique : ");
            var listeLivreOrdre = ListeLivres.Select(l => l.Titre).OrderBy(t => t);
            foreach ( var livre  in listeLivreOrdre) {
                Console.WriteLine($"    -  {livre}");
            }
            //FIN Livres par ordre alphabétique

            Console.WriteLine();

            //DEBUT Livre nombre page > moyenne
            Console.WriteLine("Livre nombre page > moyenne :");
            var moyennePages = ListeLivres.Average(l => l.NbPages);
            var livresSuppMoyenne = ListeLivres.Where(l => l.NbPages > moyennePages);
            foreach (var livre in livresSuppMoyenne) {
                Console.WriteLine($"    -  {livre.Titre}");
            }
            //FIN Livre nombre page > moyenne

            Console.WriteLine();

            //DEBUT Auteur avec le moins de livre
            var auteurMoinsLivre = ListeLivres.GroupBy(l => l.Auteur).OrderBy(l => l.Count()).FirstOrDefault().Key;
            Console.WriteLine($"L'auteur avec le moins de livre est : {auteurMoinsLivre.Prenom} {auteurMoinsLivre.Nom}");
            //FIN Auteur avec le moins de livre

            Console.ReadKey();
        }

        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }

    }
}
