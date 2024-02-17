using System;

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

            listeContacts.AddContact(contact1);
            listeContacts.AddContact(contact2);

            listeContacts.RechercherContact("Smith");

             listeContacts.AfficherContact();
            listeContacts.SuppContact("Smith");
            listeContacts.AfficherContact();
        }
    }
}
