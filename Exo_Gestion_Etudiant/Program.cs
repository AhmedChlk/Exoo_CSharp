using System;
using System.Collections.Generic;

namespace Main{
    public class Livre{
        public string Titre { get; set; }
        public string Auteur { get; set; }
         public int AnneePublication { get; set; }
         public bool LivreEmprunter { get; set; }
        public Emprunter InfoEmprunter { get; set; }
        public Livre (string titre, string auteur, int anneepub, bool livreEmprunter, Emprunter infoEmprunter)
        {
        Titre = titre;
        Auteur = auteur;
        AnneePublication = anneepub;
        LivreEmprunter = livreEmprunter;
        InfoEmprunter = infoEmprunter;
        } 
    }
    public class Bibliotheque{
        public List<Livre> ListeLivres { get; } = new List<Livre>();
        public void AjouterLivre(Livre livre){
            ListeLivres.Add(livre);
        }
        public void afficherLivre (){
            Console.WriteLine("Voici les livres dispo dans la biblio : ");
            foreach (var livre in ListeLivres)
            {
                Console.WriteLine($"{livre.Titre} - {livre.Auteur} - {livre.AnneePublication}");
            }
        }
        public void EmprunterLivre (string NomLivre, Emprunter Client)
        {
            foreach (var livre in ListeLivres)
            {
                if (string.Equals(NomLivre,livre.Titre)&& !livre.LivreEmprunter)
                {
                    livre.InfoEmprunter = Client;
                    livre.LivreEmprunter = true;
                }
            }
        }
    }
    public struct Emprunter {
        public string Nom ;
        public string Prenom;
        public int DateEmprunt;

        public Emprunter (string nom, string prenom, int dateEmprunt)
        {
        Nom = nom;
        Prenom = prenom;
        DateEmprunt = dateEmprunt;
        }
    }

    

    class Program{
        static void Main(string[] args)
        {
                    Bibliotheque maBiblio = new Bibliotheque();

        Livre livre1 = new Livre("Titre1", "Auteur1", 2000, false, new Emprunter());
        Livre livre2 = new Livre("Titre2", "Auteur2", 2010, false, new Emprunter());

        maBiblio.AjouterLivre(livre1);
        maBiblio.AjouterLivre(livre2);

        maBiblio.afficherLivre();

        Emprunter client = new Emprunter("ClientNom", "ClientPrenom", 20220105);
        maBiblio.EmprunterLivre("Titre1", client);

        maBiblio.afficherLivre();
        }
    }
    
}