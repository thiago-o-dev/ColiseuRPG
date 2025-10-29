using MedievalRPG.Entities;

namespace MedievalRPG.Entities;

public class Balrog: Personagem
{
    public Balrog(string nome) : base(nome, Dado.Range(250, 800), Dado.Range(15, 40), Enums.Classe.Balrog) { }

    public override void UsarPoderEspecial(Personagem alvo)
    {
        if (Dado.Chance(10))
        { 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"(ESPECIAL) {Nome} recupera-se por meio do CHAMA DE UDUN, recuperando sua vida em percentual!");
            Console.ResetColor();
            Curar(VidaAtual / 100 * Dado.Range(5, 25));
        }
        if (Dado.Chance(20))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"(ESPECIAL) {Nome} usa AMARRAS INFERNAIS, trazendo o fogo do inferno para o reino dos mortais!");
            Console.ResetColor();
            alvo.ReceberDano(DanoBase + Dado.Range(15, 40));
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"(ESPECIAL) {Nome} usa INVOCAÇÃO INFERNO, invocando almas infernais que atacam!");
            Console.ResetColor();
            alvo.ReceberDano(DanoBase + Dado.Range(5, 15));
        }
    }
}
