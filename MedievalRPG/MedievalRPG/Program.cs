using MedievalRPG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedievalRPG;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Title = "COLISEU RPG - Simulação de Épicas Batalhas";
        MostrarMenu();
    }

    private static void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("======================================");
            Console.WriteLine("===+ BEM-VINDO AO REINO MEDIEVAL! +===");
            Console.WriteLine("======================================");
            Console.WriteLine("\nEscolha a Batalha Lendária para começar:");

            Console.WriteLine("\n--- BATALHAS ÉPICAS ---");
            Console.WriteLine("[1] A Queda da Ponte (Hobbit & Cavaleiro vs Balrog)");
            Console.WriteLine("[2] Assalto à Torre (Ladino & Arqueiro vs Balrog)");
            Console.WriteLine("[3] Batalha Campal (Hobbit, Ladino & Cavaleiro vs 2 Arqueiros)");
            Console.WriteLine("[4] Duelo de Furtividade (Hobbit & Ladino vs Arqueiro & Cavaleiro)");
            Console.WriteLine("[5] A Vingança dos Hobbits (3 Hobbits vs Balrog)");
            Console.WriteLine("[6] Cerco do Desespero (2 Cavaleiros & Ladino vs Arqueiro & Balrog)");
            Console.WriteLine("[7] Emboscada Noturna (3 Ladinos vs Cavaleiro & Arqueiro)");
            Console.WriteLine("[8] Última Flecha (2 Arqueiros vs Ladino & Cavaleiro)");
            Console.WriteLine("[9] O Despertar do Balrog (Cavaleiro vs Balrog)");
            Console.WriteLine("[10] Confronto de Ranks (Arqueiro, Ladino, Hobbit vs Cavaleiro, Balrog)");

            Console.WriteLine("\n--- OPÇÕES DE JOGO ---");
            Console.WriteLine("[11] Batalha Aleatória (Times e Nomes gerados)");
            Console.WriteLine("[0] Sair");
            Console.Write("\nOpção: ");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                if (escolha == 0) break;

                ExecutarBatalha(escolha);

                Console.WriteLine("\n** Pressione qualquer tecla para voltar ao Menu... **");
                Console.ReadKey();
            }
        }
        Console.WriteLine("\nFim do jogo. Adeus!");
    }

    private static void ExecutarBatalha(int escolha)
    {
        List<Personagem> time1 = new List<Personagem>();
        List<Personagem> time2 = new List<Personagem>();

        switch (escolha)
        {
            case 1:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: A Queda da Ponte ---");
                time1.Add(new Hobbit("Frodo"));
                time1.Add(new Cavaleiro("Gimli"));
                time2.Add(new Balrog("Durin's Bane"));
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Assalto à Torre ---");
                time1.Add(new Ladino("Sombra"));
                time1.Add(new Arqueiro("Legolas"));
                time2.Add(new Balrog("Gothmog"));
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Batalha Campal ---");
                time1.Add(new Hobbit("Pippin"));
                time1.Add(new Ladino("Gollum"));
                time1.Add(new Cavaleiro("Aragorn"));
                time2.Add(new Arqueiro("Falcão"));
                time2.Add(new Arqueiro("Flecheiro"));
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Duelo de Furtividade ---");
                time1.Add(new Hobbit("Samwise"));
                time1.Add(new Ladino("Bilbo"));
                time2.Add(new Arqueiro("Guardião"));
                time2.Add(new Cavaleiro("Protetor"));
                break;

            case 5:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: A Vingança dos Hobbits ---");
                time1.Add(new Hobbit("Mestre Pipo"));
                time1.Add(new Hobbit("Tuk"));
                time1.Add(new Hobbit("Bolger"));
                time2.Add(new Balrog("Ceifador"));
                break;

            case 6:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Cerco do Desespero ---");
                time1.Add(new Cavaleiro("Sentinela"));
                time1.Add(new Cavaleiro("Lanceiro"));
                time1.Add(new Ladino("Adaga"));
                time2.Add(new Arqueiro("Sagitário"));
                time2.Add(new Balrog("Lorde do Fogo"));
                break;

            case 7:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Emboscada Noturna ---");
                time1.Add(new Ladino("Assassino"));
                time1.Add(new Ladino("Silêncio"));
                time1.Add(new Ladino("Corvo"));
                time2.Add(new Cavaleiro("Balista"));
                time2.Add(new Arqueiro("Elfo Arqueiro"));
                break;

            case 8:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Última Flecha ---");
                time1.Add(new Arqueiro("Longbow"));
                time1.Add(new Arqueiro("Recurvo"));
                time2.Add(new Ladino("Viperina"));
                time2.Add(new Cavaleiro("Tanque"));
                break;

            case 9:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: O Despertar do Balrog ---");
                time1.Add(new Cavaleiro("Lancelot"));
                time2.Add(new Balrog("Flama Negra"));
                break;

            case 10:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Confronto de Ranks ---");
                time1.Add(new Arqueiro("Ranger"));
                time1.Add(new Ladino("Agilidade"));
                time1.Add(new Hobbit("Tímido"));
                time2.Add(new Cavaleiro("Cruzado"));
                time2.Add(new Balrog("Asas Sombrias"));
                break;

            case 11:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Batalha Aleatória ---");
                (time1, time2) = GerarBatalhaAleatoria();
                break;

            case 12:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n--- INICIANDO: Confronto de Ranks ---");
                time1.Add(new Arqueiro("Navarro"));
                time1.Add(new Ladino("César"));
                time1.Add(new Cavaleiro("Cristovão"));
                time2.Add(new Arqueiro("Caio"));
                time2.Add(new Cavaleiro("Douglas"));
                time2.Add(new Ladino("Ettore"));
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida! Tente novamente.");
                return;
        }
        Console.ResetColor();

        if (time1.Count > 0 && time2.Count > 0)
        {
            Batalha batalha = new Batalha(time1, time2);
            batalha.IniciarBatalha();
        }
    }

    // --- Lógica para Batalha Aleatória ---
    private static (List<Personagem>, List<Personagem>) GerarBatalhaAleatoria()
    {
        List<Personagem> time1 = new List<Personagem>();
        List<Personagem> time2 = new List<Personagem>();

        Type[] classes = { typeof(Hobbit), typeof(Ladino), typeof(Arqueiro), typeof(Cavaleiro), typeof(Balrog) };
        string[] nomes = {
            "Kael", "Lyra", "Zane", "Mira", "Oskar", "Seraph", "Grim", "Zara", "Torvin", "Roric",
            "Aragorn", "Gandalf", "Elara", "Gimli", "Frodo", "Sauron", "Legolas", "Gothmog", "Arwen", "Galadriel",
            "Merlin", "Arthur", "Morgana", "Lancelot", "Guinevere", "Perceval", "Gawain", "Nimue",
            "Beethoven", "Mozart", "Chopin", "Bach", "Hendrix", "Madonna", "Elvis", "Beyonce",
            "Picasso", "Van Gogh", "Monet", "Leonardo", "Donatello", "Raphael", "Michelangelo",
            "Tesla", "Newton", "Einstein", "Curie", "Galileu", "Platão", "Sócrates", "Aristóteles",
            "Aethelred", "Boudicca", "Ragnar", "Bjorn", "Ivar", "Floki", "Lagertha", "Geralt",
            "Mestre K", "Professor X", "Dumbledore", "Snape", "Yoda", "Obi-Wan", "Palpatine", "Leia",
            "Marcos", "REGO", "Pedro", "Navas (navarrão)", "César", "Cristovão", "Caio", "Douglas", "Ettore"
        };

        int numTime1 = Dado.Range(1, 4); // 1 a 4 membros
        int numTime2 = Dado.Range(1, 4); // 1 a 4 membros

        for (int i = 0; i < numTime1; i++)
        {
            Type classe = Dado.EscolherAleatoriamente(classes.ToList());
            string nome = Dado.EscolherAleatoriamente(nomes.ToList());

            time1.Add((Personagem)Activator.CreateInstance(classe, new object[] { nome }));
        }

        for (int i = 0; i < numTime2; i++)
        {
            Type classe = Dado.EscolherAleatoriamente(classes.ToList());
            string nome = Dado.EscolherAleatoriamente(nomes.ToList());

            if (classe == typeof(Balrog) && time2.Count == 0)
            {
                time2.Add((Personagem)Activator.CreateInstance(classe, new object[] { nome }));
                break; // Balrog sozinho, Time 2 está completo.
            }
            else if (classe == typeof(Balrog) && time2.Count > 0)
            {
                i--;
                continue;
            }

            time2.Add((Personagem)Activator.CreateInstance(classe, new object[] { nome }));
        }

        if (time2.Count == 0)
        {
            Type classe = Dado.EscolherAleatoriamente(classes.Where(c => c != typeof(Balrog)).ToList());
            string nome = Dado.EscolherAleatoriamente(nomes.ToList()) + Dado.Range(1, 99).ToString();
            time2.Add((Personagem)Activator.CreateInstance(classe, new object[] { nome }));
        }

        Console.WriteLine($"\nTime A ({time1.Count} combatentes): {string.Join(", ", time1.Select(p => $"{p.Nome} ({p.Classe})"))}");
        Console.WriteLine($"Time B ({time2.Count} combatentes): {string.Join(", ", time2.Select(p => $"{p.Nome} ({p.Classe})"))}");

        return (time1, time2);
    }
}