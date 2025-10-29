using MedievalRPG.Entities.Enums;

namespace MedievalRPG.Entities;

public abstract class Personagem
{
    public string Nome { get; private set; }
    public int VidaAtual { get; protected set; }
    public int VidaMaxima { get; private set; }
    public int DanoBase { get; private set; }
    public Classe Classe { get; protected set; }
    public int Vitorias { get; set; }

    public bool EstaVivo => VidaAtual > 0;

    public Personagem(string nome, int vida, int danoBase, Classe classe)
    {
        Nome = nome;
        VidaMaxima = vida;
        VidaAtual = vida;
        DanoBase = danoBase;
        Classe = classe;
        Vitorias = 0;
    }

    public virtual int Atacar()
    {
        int dano = DanoBase + Dado.Rolar(6);
        Console.WriteLine($"[{Classe} {Nome}] ataca com dano base de {dano}.");
        return dano;
    }

    public abstract void UsarPoderEspecial(Personagem alvo);

    public void ReceberDano(int dano)
    {
        VidaAtual -= dano;
        if (VidaAtual < 0)
        {
            VidaAtual = 0;
        }
        Console.WriteLine($"[{Classe} {Nome}] recebeu {dano} de dano. Vida restante: {VidaAtual}/{VidaMaxima}.");
    }

    public void Curar(int quantidade)
    {
        VidaAtual += quantidade;
        if (VidaAtual > VidaMaxima)
        {
            VidaAtual = VidaMaxima;
        }
        Console.WriteLine($"[{Classe} {Nome}] se cura em {quantidade}. Vida atual: {VidaAtual}/{VidaMaxima}.");
    }

    public void RestaurarVida()
    {
        VidaAtual = VidaMaxima;
    }
}
