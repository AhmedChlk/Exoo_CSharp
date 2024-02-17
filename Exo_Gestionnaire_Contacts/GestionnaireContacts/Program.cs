using System;
using System.Collections.Generic;

namespace GestionDeContacts
{
    class Contact
    {
        private string nom;
        private string prenom;
        private string adresse;

        public string Nom
        {
            get { return nom; }
            set { if (!string.IsNullOrEmpty(value)) nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { if (!string.IsNullOrEmpty(value)) prenom = value; }
        }
        public string Adresse
        {
            get { return adresse; }
            set { if (!string.IsNullOrEmpty(value)) adresse = value; }
        }
        public Contact(string nom, string prenom, string adresse)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
        }
    }
    class ListeContacts
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
        public void SuppContact(string nom)
{
    bool find = false;
    for (int i = contacts.Count - 1; i >= 0; i--)
    {
        var contact = contacts[i];
        if (String.Equals(nom, contact.Nom))
        {
            contacts.Remove(contact);
            Console.WriteLine("Contact supprimé");
            find = true;
        }
    }
    if (!find)
    {
        Console.WriteLine("Contact inexistant");
    }
}



public void RechercherContact(string search)
{
    bool find = false;
    foreach (var contact in contacts)
    {
        if (String.Equals(search, contact.Nom) || String.Equals(search, contact.Prenom) || String.Equals(search, contact.Adresse))
        {
            Console.WriteLine($"Contact Trouvé Nom : {contact.Nom} prenom : {contact.Prenom} adresse : {contact.Adresse}");
            find = true;
        }
    }
    if (!find)
    {
        Console.WriteLine("Conctact inexistant");
    }

}
        public void AfficherContact ()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Nom: {contact.Nom}, Prénom: {contact.Prenom}, Adresse: {contact.Adresse}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listeContacts = new ListeContacts();

            var contact1 = new Contact("Doe", "John", "123 Main St");
            var contact2 = new Contact("Smith", "Jane", "456 Elm St");
            var contact3 = new Contact("ahmed", "choulak", "6444 Elm St");

            listeContacts.AddContact(contact1);
            listeContacts.AddContact(contact2);
            listeContacts.AddContact(contact3);

            Console.WriteLine("1. Ajouter un contact");
            Console.WriteLine("2. Afficher la liste des contacts");
            Console.WriteLine("3. Supprimer un contact");
            Console.WriteLine("4. Rechercher un contact");
            Console.WriteLine("5. Quitter");

            bool continuer = true;

            while (continuer)
            {
                Console.Write("Votre choix: ");
                int choix = Convert.ToInt32(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Console.Write("Nom: ");
                        string nom = Console.ReadLine();
                        Console.Write("Prenom: ");
                        string prenom = Console.ReadLine();
                        Console.Write("Adresse: ");
                        string adresse = Console.ReadLine();
                        var nouveauContact = new Contact(nom, prenom, adresse);
                        listeContacts.AddContact(nouveauContact);
                        break;
                    case 2:
                        listeContacts.AfficherContact();
                        break;
                    case 3:
                        Console.Write("Nom du contact à supprimer: ");
                        string nomSupprimer = Console.ReadLine();
                        listeContacts.SuppContact(nomSupprimer);
                        break;
                    case 4:
                        Console.Write("Rechercher: ");
                        string recherche = Console.ReadLine();
                        listeContacts.RechercherContact(recherche);
                        break;
                    case 5:
                        continuer = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
        }
    }
}
