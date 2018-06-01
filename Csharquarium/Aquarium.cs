using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharquarium
{
    public class Aquarium
    {
        int jourActuel = 1;
        int nbAlgues = 0;
        int nbPoissons = 0;
        List<Poisson> listePoissons = new List<Poisson>();
        List<Algue> listeAlgues = new List<Algue>();
        List<Poisson> listeBebesPoissons = new List<Poisson>();
        List<Algue> listeNewAlgues = new List<Algue>();

        public void AjouterPoisson(string nom, string sexe)
        {
            switch (GenererAlea.LancerDe())
            {
                case 1:
                    Poisson merou = new Merou(nom, sexe);
                    listePoissons.Add(merou);
                    nbPoissons++;
                    break;
                case 2:
                    Poisson thon = new Thon(nom, sexe);
                    listePoissons.Add(thon);
                    nbPoissons++;
                    break;
                case 3:
                    Poisson poissonClown = new PoissonClown(nom, sexe);
                    listePoissons.Add(poissonClown);
                    nbPoissons++;
                    break;
                case 4:
                    Poisson sole = new Sole(nom, sexe);
                    listePoissons.Add(sole);
                    nbPoissons++;
                    break;
                case 5:
                    Poisson bar = new Bar(nom, sexe);
                    listePoissons.Add(bar);
                    nbPoissons++;
                    break;
                case 6:
                    Poisson carpe = new Carpe(nom, sexe);
                    listePoissons.Add(carpe);
                    nbPoissons++;
                    break;
            }
        }

        public void AjouterAlgue()
        {
            Algue algue = new Algue();
            listeAlgues.Add(algue);
            nbAlgues++;
        }

        public void AcheterPoissons()
        {
            Console.Write("Combien? ");
            int nombre = int.Parse(Console.ReadLine());
            for (int i = 0; i < nombre; i++)
            {
                Console.Write("Quel poisson ajouter? (0 pour afficher la liste) ");
                string choix = Console.ReadLine();
                while (choix != "0" && choix != "1" && choix != "2" && choix != "3" && choix != "4" && choix != "5" && choix != "6")
                {
                    Console.Write("Pas dans la liste... Quel poisson ajouter? (0 pour afficher la liste) ");
                    choix = Console.ReadLine();
                }
                if (choix == "0")
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Ajouter un Mérou\n2. Ajouter un Thon\n3. Ajouter un Poisson-Clown\n4. Ajouter une Sole\n5. Ajouter un Bar\n6. Ajouter une Carpe");
                    i--;
                }
                else
                {
                    Console.Write("Quel nom pour votre nouveau poisson? ");
                    string nom = Console.ReadLine();
                    Console.Write("Sexe du Poisson (1 -> Femelle | 2 -> Mâle): ");
                    string choix2 = Console.ReadLine();
                    string sexe;
                    while (choix2 != "1" && choix2 != "2")
                    {
                        Console.Write("Entrée Invalide... Sexe du Poisson (1 -> Femelle | 2 -> Mâle): ");
                        choix2 = Console.ReadLine();
                    }
                    switch (choix2)
                    {
                        case "1":
                            sexe = "Femelle";
                            break;
                        default:
                            sexe = "Mâle";
                            break;
                    }
                    int age = GenererAlea.AutreAlea(19);
                    if (choix == "1")
                    {
                        Poisson merou = new Merou(nom, sexe, age);
                        listePoissons.Add(merou);
                        nbPoissons++;
                    }
                    else if (choix == "2")
                    {
                        Poisson thon = new Thon(nom, sexe, age);
                        listePoissons.Add(thon);
                        nbPoissons++;
                    }
                    else if (choix == "3")
                    {
                        Poisson poissonClown = new PoissonClown(nom, sexe, age);
                        listePoissons.Add(poissonClown);
                        nbPoissons++;
                    }
                    else if (choix == "4")
                    {
                        Poisson sole = new Sole(nom, sexe, age);
                        listePoissons.Add(sole);
                        nbPoissons++;
                    }
                    else if (choix == "5")
                    {
                        Poisson bar = new Bar(nom, sexe, age);
                        listePoissons.Add(bar);
                        nbPoissons++;
                    }
                    else
                    {
                        Poisson carpe = new Carpe(nom, sexe, age);
                        listePoissons.Add(carpe);
                        nbPoissons++;
                    }
                }
                Console.WriteLine();
            }
        }

        public void AcheterAlgues()
        {
            Console.Write("Combien? ");
            int nombre = int.Parse(Console.ReadLine());
            for (int i = 0; i < nombre; i++)
            {
                Algue algue = new Algue(GenererAlea.AutreAlea(20));
                listeAlgues.Add(algue);
                nbAlgues++;
            }
        }

        public void PasserJournee()
        {
            Console.WriteLine($"Jour {jourActuel}:");
            Console.WriteLine();
            foreach (Poisson poisson in listePoissons)
            {
                Console.WriteLine($"    - {poisson.nom}, est un(e) {poisson.race} de sexe {poisson.sexe}, agé(e) de {poisson.age} jours. PV: {poisson.pv}.");
            }
            Console.WriteLine();
            Console.WriteLine($"Il y a {nbAlgues} algues dans l'aquarium.");

            Console.ReadKey();

            Console.WriteLine();

            foreach (Poisson poisson in listePoissons)
            {
                if (poisson.pv <= 5)
                {
                    if (poisson is Carnivore)
                    {
                        int indicePoissonMange = GenererAlea.AutreAlea(nbPoissons);
                        Poisson poissonMange = listePoissons[indicePoissonMange - 1];

                        while (!poissonMange.estVivant)
                        {
                            indicePoissonMange = GenererAlea.AutreAlea(nbPoissons);
                            poissonMange = listePoissons[indicePoissonMange - 1];
                        }

                        if (poisson == poissonMange)
                        {
                            Console.WriteLine($"- {poisson.nom} ne peut pas se manger...");
                        }

                        else if (poisson is Merou && poissonMange is Merou)
                        {
                            Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                        }

                        else if (poisson is Thon && poissonMange is Thon)
                        {
                            Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                        }

                        else if (poisson is PoissonClown && poissonMange is PoissonClown)
                        {
                            Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                        }

                        else if (poisson.estVivant && nbPoissons > 1)
                        {
                            poisson.Manger(poissonMange);
                            int poissonMangeMauvais = GenererAlea.AutreAlea(70);
                            if (poissonMangeMauvais == 35)
                            {
                                Console.WriteLine($"    - {poissonMange.nom} n'a pas été digéré... {poisson.nom} perd la vie...");
                                poisson.estVivant = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"- {poisson.nom} est mort...");
                        }
                    }
                    else
                    {
                        if (nbAlgues > 0 && poisson.estVivant)
                        {
                            int indiceAlgueMangee = GenererAlea.AutreAlea(nbAlgues);
                            Algue algueMangee = listeAlgues[indiceAlgueMangee - 1];
                            while (!algueMangee.estVivant)
                            {
                                indiceAlgueMangee = GenererAlea.AutreAlea(nbAlgues);
                                algueMangee = listeAlgues[indiceAlgueMangee - 1];
                            }
                            poisson.Manger(algueMangee);
                            int algueMauvaise = GenererAlea.AutreAlea(100);
                            if (algueMauvaise == 50)
                            {
                                Console.WriteLine($"    - L'algue n'a pas été digérée... {poisson.nom} perd la vie...");
                                poisson.estVivant = false;
                            }
                        }
                        else if (nbAlgues > 0 && !poisson.estVivant)
                        {
                            Console.WriteLine($"- {poisson.nom} est mort...");
                        }
                        else
                        {
                            Console.WriteLine($"- {poisson.nom} n'a pas pu manger (plus d'algue).");
                        }
                    }
                }
                else if (poisson.pv > 5)
                {
                    int faimAlea = GenererAlea.AutreAlea(3);
                    if (faimAlea == 1)
                    {
                        if (poisson is Carnivore)
                        {
                            int indicePoissonMange = GenererAlea.AutreAlea(nbPoissons);
                            Poisson poissonMange = listePoissons[indicePoissonMange - 1];

                            while (!poissonMange.estVivant)
                            {
                                indicePoissonMange = GenererAlea.AutreAlea(nbPoissons);
                                poissonMange = listePoissons[indicePoissonMange - 1];
                            }

                            if (poisson == poissonMange)
                            {
                                Console.WriteLine($"- {poisson.nom} ne peut pas se manger...");
                            }

                            else if (poisson is Merou && poissonMange is Merou)
                            {
                                Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                            }

                            else if (poisson is Thon && poissonMange is Thon)
                            {
                                Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                            }

                            else if (poisson is PoissonClown && poissonMange is PoissonClown)
                            {
                                Console.WriteLine($"- {poisson.nom} ne peut pas manger un poisson de son espèce.");
                            }

                            else if (poisson.estVivant && nbPoissons > 1)
                            {
                                poisson.Manger(poissonMange);
                                int poissonMangeMauvais = GenererAlea.AutreAlea(70);
                                if (poissonMangeMauvais == 35)
                                {
                                    Console.WriteLine($"    - {poissonMange.nom} n'a pas été digéré... {poisson.nom} perd 9 PV...");
                                    poisson.pv -= 9;
                                }
                                Console.WriteLine($"    {poisson.nom} n'avait pas trop faim, il perd 1 PV.");
                                poisson.pv--;
                            }
                            else
                            {
                                Console.WriteLine($"- {poisson.nom} est mort...");
                            }
                        }
                        else
                        {
                            if (nbAlgues > 0 && poisson.estVivant)
                            {
                                int indiceAlgueMangee = GenererAlea.AutreAlea(nbAlgues);
                                Algue algueMangee = listeAlgues[indiceAlgueMangee - 1];
                                while (!algueMangee.estVivant)
                                {
                                    indiceAlgueMangee = GenererAlea.AutreAlea(nbAlgues);
                                    algueMangee = listeAlgues[indiceAlgueMangee - 1];
                                }
                                poisson.Manger(algueMangee);
                                int algueMauvaise = GenererAlea.AutreAlea(100);
                                if (algueMauvaise == 50)
                                {
                                    Console.WriteLine($"    - L'algue n'a pas été digérée... {poisson.nom} perd 7 PV...");
                                    poisson.pv -= 7;
                                }
                                Console.WriteLine($"    - {poisson.nom} a mangé alors qu'il n'avait plus faim. Il perd 1 PV.");
                                poisson.pv--;
                            }
                            else if (nbAlgues > 0 && !poisson.estVivant)
                            {
                                Console.WriteLine($"- {poisson.nom} est mort...");
                            }
                            else
                            {
                                Console.WriteLine($"- {poisson.nom} n'a pas pu manger (plus d'algue).");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"- {poisson.nom} n'a pas faim.");
                    }
                }
                else
                {
                    Console.WriteLine($"- {poisson.nom} n'a pas faim.");
                }

                int aleaPoissonRepro = GenererAlea.AutreAlea(nbPoissons);
                Poisson poissonRepro = listePoissons[aleaPoissonRepro - 1];
                if (poisson == poissonRepro)
                {
                    Console.WriteLine($"    - {poisson.nom} n'a pas pu se reproduire.");
                }
                else
                {
                    int chanceRepro = GenererAlea.AutreAlea(2);
                    if (chanceRepro == 1)
                    {
                        bool oeuf = poisson.SeReproduire(poissonRepro);
                        if (oeuf)
                        {
                            int nbBebesPoissons = GenererAlea.AutreAlea(5);
                            Console.WriteLine($"    - {poisson.nom} s'est reproduit avec {poissonRepro.nom} et a eu {nbBebesPoissons} petits.");
                            for (int i = 0; i < nbBebesPoissons; i++)
                            {
                                if (poisson.race == "Bar")
                                {
                                    Poisson bebe = new Bar("bar");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                                else if (poisson.race == "Carpe")
                                {
                                    Poisson bebe = new Bar("Carpe");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                                else if (poisson.race == "Merou")
                                {
                                    Poisson bebe = new Bar("Merou");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                                else if (poisson.race == "Poisson-Clown")
                                {
                                    Poisson bebe = new Bar("Poisson-Clown");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                                else if (poisson.race == "Sole")
                                {
                                    Poisson bebe = new Bar("Sole");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                                else
                                {
                                    Poisson bebe = new Thon("Thon");
                                    listeBebesPoissons.Add(bebe);
                                    Console.Write($"- Nommez votre nouveau {bebe.race} qui est un(e) {bebe.sexe}: ");
                                    string nomBebe = Console.ReadLine();
                                    bebe.NommerPoisson(nomBebe);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"    - {poisson.nom} n'a pas pu se reproduire avec {poissonRepro.nom}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"    - {poisson.nom} n'a pas réussi à se reproduire avec {poissonRepro.nom}.");
                    }
                }
            }

            foreach (Poisson poisson in listePoissons)
            {
                poisson.pv--;
                poisson.Mourir();

                if (!poisson.estVivant)
                {
                    nbPoissons--;
                }
                else
                {
                    poisson.age++;
                    poisson.jourDerniereRepro++;
                }
            }
            foreach (Algue algue in listeAlgues)
            {
                algue.Mourir();
                if (!algue.estVivant)
                {
                    nbAlgues--;
                }
                else
                {
                    if (jourActuel % 2 == 0)
                    {
                        algue.Grandir();
                    }
                    algue.age++;
                    bool algueRepro = algue.SeReproduire();
                    if (algueRepro == true)
                    {
                        algue.pv = (algue.pv / 2);
                        Algue newAlgue = new Algue() { pv = algue.pv };
                        listeNewAlgues.Add(newAlgue);
                    }
                }
            }

            listePoissons.RemoveAll(poisson => !poisson.estVivant);
            listeAlgues.RemoveAll(algue => !algue.estVivant);

            int nbNewPoissons = 0;
            foreach (Poisson bebe in listeBebesPoissons)
            {
                listePoissons.Add(bebe);
                nbPoissons++;
                nbNewPoissons++;
            }

            listeBebesPoissons.RemoveAll(poisson => poisson.estVivant);

            int nbNewAlgues = 0;
            foreach (Algue nouvelleAlgue in listeNewAlgues)
            {
                listeAlgues.Add(nouvelleAlgue);
                nbAlgues++;
                nbNewAlgues++;
            }

            listeNewAlgues.RemoveAll(algue => algue.estVivant);

            Console.WriteLine();

            foreach (Poisson poisson in listePoissons)
            {
                if ((poisson.race == "Bar" || poisson.race == "Merou") && poisson.age >= 10)
                {
                    poisson.sexe = "Femelle";
                    Console.WriteLine($"        - {poisson.nom} a changé de sexe.");
                }
            }

            Console.WriteLine();

            Console.WriteLine($"En fin de journée, il y a eu {nbNewPoissons} petit(s) et {nbNewAlgues} nouvelle(s) algue(s).");

            Console.WriteLine();

            Console.Write("Souhaitez-vous acheter des poissons? (0: Oui - Autre entrée: Non) ");
            string choix = Console.ReadLine();
            if (choix == "0")
            {
                AcheterPoissons();
            }
            Console.WriteLine();
            Console.Write("Souhaitez-vous acheter des algues? (0: Oui - Autre entrée: Non) ");
            string choix2 = Console.ReadLine();
            if (choix2 == "0")
            {
                AcheterAlgues();
            }
            Console.WriteLine();

            Console.Write("Souhaitez-vous voir l'état de vos algues? (0: Oui - Autre entrée: Non) ");
            string choix3 = Console.ReadLine();
            if (choix3 == "0")
            {
                Console.WriteLine();
                int i = 1;
                foreach (Algue algue in listeAlgues)
                {
                    Console.WriteLine($"            - Algues n°{i} - Age: {algue.age}, Pv restant(s): {algue.pv}.");
                    i++;
                }
            }
            Console.WriteLine();

            jourActuel++;

            Console.ReadKey();

            Console.Clear();
        }

        public void DemarrerAquarium()
        {
            int aleaPoissons = GenererAlea.AleaCinqA30();
            int aleaAlgues = GenererAlea.AleaCinqA30();
            Console.Write("Combien de jours doit durer votre Aquarium? ");
            int nbJours = int.Parse(Console.ReadLine());
            Console.WriteLine();
            nbPoissons = 0;
            nbAlgues = 0;

            for (int i = 0; i < aleaPoissons; i++)
            {
                Console.Write("Nom du Poisson: ");
                string nom = Console.ReadLine();
                Console.Write("Sexe du Poisson (1 -> Femelle | 2 -> Mâle): ");
                string choix = Console.ReadLine();
                string sexe;
                while (choix != "1" && choix != "2")
                {
                    Console.Write("Entrée Invalide... Sexe du Poisson (1 -> Femelle | 2 -> Mâle): ");
                    choix = Console.ReadLine();
                }
                switch (choix)
                {
                    case "1":
                        sexe = "Femelle";
                        break;
                    default:
                        sexe = "Mâle";
                        break;
                }
                AjouterPoisson(nom, sexe);
                Console.WriteLine();
            }
            for (int i = 0; i < aleaAlgues; i++)
            {
                AjouterAlgue();
            }

            Console.Clear();

            for (int i = 0; i < nbJours+1; i++)
            {
                PasserJournee();
            }
        }
    }
}
