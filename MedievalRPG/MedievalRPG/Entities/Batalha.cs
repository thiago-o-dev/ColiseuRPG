using MedievalRPG.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedievalRPG.Entities;

public class Batalha
{
    private List<Personagem> TimeA { get; set; }
    private List<Personagem> TimeB { get; set; }
    private Queue<Personagem> OrdemDeTurno { get; set; }

    public bool BatalhaEmAndamento => TimeA.Any(p => p.EstaVivo) && TimeB.Any(p => p.EstaVivo);
    public bool TimeAVenceu => TimeA.Any(p => p.EstaVivo) && !TimeB.Any(p => p.EstaVivo);
    public bool TimeBVenceu => TimeB.Any(p => p.EstaVivo) && !TimeA.Any(p => p.EstaVivo);

    public Batalha(List<Personagem> timeA, List<Personagem> timeB)
    {
        TimeA = timeA;
        TimeB = timeB;
        OrdemDeTurno = new Queue<Personagem>();

        TimeA.ForEach(p => p.RestaurarVida());
        TimeB.ForEach(p => p.RestaurarVida());
    }

    public void IniciarBatalha()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("    --- INÍCIO DO COLISEU ---");
        Console.WriteLine("==================================");

        DefinirOrdemDeTurno();

        int turno = 1;
        while (BatalhaEmAndamento)
        {
            Console.WriteLine($"\n*** TURNO {turno} ***");
            ProcessarRound();
            turno++;
        }

        ExibirResultado();
    }

    private void DefinirOrdemDeTurno()
    {
        var todos = TimeA.Concat(TimeB).ToList();
        var ordemAleatoria = todos.OrderBy(p => Dado.Range(1, 100));

        foreach (var p in ordemAleatoria)
        {
            OrdemDeTurno.Enqueue(p);
        }
    }

    private void ProcessarRound()
    {
        var proximaOrdem = new List<Personagem>();
        int count = OrdemDeTurno.Count;

        for (int i = 0; i < count; i++)
        {
            if (!BatalhaEmAndamento) break;

            var atacante = OrdemDeTurno.Dequeue();

            if (atacante.EstaVivo)
            {
                RealizarAcao(atacante);
                proximaOrdem.Add(atacante);
            }
        }

        proximaOrdem.ForEach(p => OrdemDeTurno.Enqueue(p));

        Console.WriteLine("\n----------------------------------");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("STATUS ATUAL:");

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("TIME A:");
        foreach (Personagem personagem in TimeA.Where(p => p.EstaVivo))
        {
            Console.WriteLine($"- {personagem.Nome}: {personagem.VidaAtual}/{personagem.VidaMaxima}");
        }
        TimeA.Where(p => !p.EstaVivo).ToList().ForEach(p => Console.WriteLine($"- {p.Nome}: Derrotado"));

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("TIME B:");
        foreach (Personagem personagem in TimeB.Where(p => p.EstaVivo))
        {
            Console.WriteLine($"- {personagem.Nome}: {personagem.VidaAtual}/{personagem.VidaMaxima}");
        }
        TimeB.Where(p => !p.EstaVivo).ToList().ForEach(p => Console.WriteLine($"- {p.Nome}: Derrotado"));

        Console.ResetColor();

        Console.ReadLine();
    }

    private void RealizarAcao(Personagem atacante)
    {
        ConsoleColor corFundoTime = TimeA.Contains(atacante) ? ConsoleColor.DarkMagenta : ConsoleColor.DarkCyan;
        ConsoleColor corTextoTime = ConsoleColor.White;

        Console.BackgroundColor = corFundoTime;
        Console.ForegroundColor = corTextoTime;

        Console.Write($"\n-> Vez de [{atacante.Classe} {atacante.Nome}] agir.");

        Console.ResetColor();
        Console.WriteLine();

        var timeInimigo = TimeA.Contains(atacante) ? TimeB : TimeA;
        var alvosVivos = timeInimigo.Where(p => p.EstaVivo).ToList();

        if (alvosVivos.Count == 0) return;

        Personagem alvo = Dado.EscolherAleatoriamente(alvosVivos);

        AcaoDeBatalha acao = Dado.Chance(20) ? AcaoDeBatalha.PoderEspecial : AcaoDeBatalha.AtaqueBasico;

        switch (acao)
        {
            case AcaoDeBatalha.AtaqueBasico:
                Console.ForegroundColor = ConsoleColor.Gray;
                int dano = atacante.Atacar();
                alvo.ReceberDano(dano);
                break;

            case AcaoDeBatalha.PoderEspecial:
                atacante.UsarPoderEspecial(alvo);
                break;

            default:
                Console.WriteLine($"{atacante.Nome} hesitou e perdeu o turno.");
                break;
        }
        Console.ResetColor();

        if (!alvo.EstaVivo)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"!!! {alvo.Nome} foi derrotado e arremessado do COLISEU !!!");
            Console.ResetColor();
        }
    }

    private void ExibirResultado()
    {
        Console.WriteLine("\n==================================");
        Console.BackgroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("          FIM DA BATALHA          ");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("==================================");

        if (TimeAVenceu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O Time A é o VENCEDOR!");
            TimeA.ForEach(p => p.Vitorias++);
        }
        else if (TimeBVenceu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("O Time B é o VENCEDOR!");
            TimeB.ForEach(p => p.Vitorias++);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A batalha terminou em um empate sombrio.");
        }
        Console.ResetColor();

        Console.WriteLine("\n--- Status Final dos Personagens Vivos ---");
        TimeA.Where(p => p.EstaVivo).ToList().ForEach(p => Console.WriteLine($"[A] {p.Nome} | Vida: {p.VidaAtual}/{p.VidaMaxima} | Vits: {p.Vitorias}"));
        TimeB.Where(p => p.EstaVivo).ToList().ForEach(p => Console.WriteLine($"[B] {p.Nome} | Vida: {p.VidaAtual}/{p.VidaMaxima} | Vits: {p.Vitorias}"));
    }
}