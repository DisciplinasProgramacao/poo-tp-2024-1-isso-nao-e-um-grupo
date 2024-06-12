using POO.Classes;

namespace ProgramRestaurante;

public class Program
{
    public const string NomeRestaurante = "Isso Não é Um Restaurante";
    internal static Restaurante restaurante { get; set; } = new Restaurante(NomeRestaurante);
    internal static List<Conta> contas;
    public static void Main()
    {
        contas = new List<Conta>();
        Menu();
    }

    public static void Menu() 
    {
        Console.WriteLine($"Seja bem-vindo ao Restaurante - {NomeRestaurante}!");
        while (true)
        {
            Console.WriteLine("1 - Abrir Conta");
            Console.WriteLine("2 - Fechar Conta");
            Console.WriteLine("3 - Fazer Pedidos");
            Console.WriteLine("4 - Sair");

            string opcao = Console.ReadLine()??"4";

            switch (opcao)
            {
                case "1":
                    AbrirConta();
                    break;
                case "2":
                    FecharConta();
                    break;
                case "3":
                    FazerPedidos();
                    break;
                case "4":
                   
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }       
        }
    }
    #region Abrir Contas
    public static void AbrirConta()
    {
        var conta = new Conta();
        Requisicao requisicao;

        Console.WriteLine("Para se abrir uma Conta, antes deve-se fazer uma requisição de mesa.");
        Console.WriteLine("Informe a quantidade de pessoas: ");
        int quantidadePessoas = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Informe o nome do Cliente:");
        string nome= Console.ReadLine() ?? "0";

        
        requisicao = new Requisicao(new Cliente(nome),quantidadePessoas);

        restaurante.AlocarMesa(requisicao);
        Console.WriteLine("Mesa alocada com sucesso!\n" + "Agora pode-se selecionar a conta e fazer os pedidos!!!\n");
        
        conta.SetRequisicao(requisicao);
        contas.Add(conta);

        Console.WriteLine($"Conta aberta com sucesso! Número da conta: {conta.GetContaId()}");
    }
    #endregion

    #region Remoção de Conta
    private static Conta RemoverConta(int index)
    {
        var conta = contas.ElementAt(index - 1);
        restaurante.RegistrarSaida(conta.DadosCliente());
        conta.FecharConta();
        return conta;
    }

    private static void FecharConta()
    {
        Conta contafechada;

        if (VerificarContasAbertas())
        {
            Console.WriteLine("Não há contas abertas!");
            return;
        };
        int index = SelecionarIndexConta();
        if (index == 0)return;

        try
        {
            contafechada = RemoverConta(index);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        Console.WriteLine("Conta fechada com sucesso!\n" + $"Conta fechada: {contafechada?.ToString()}");
        return;
    }
    #endregion

    #region Pedidos
    public static void FazerPedidos()
    {
        Pedido pedido;

        if (VerificarContasAbertas())
        {
            Console.WriteLine("Não há contas abertas!");
            return;
        };

        int index = SelecionarIndexConta();
        if (index == 0) return;

        var conta = SelecionarConta(index);
      
        if (conta.GetPedido() != null)
        {
            AdicionarItemPedido(conta.GetPedido());
        }
        else
        {
            pedido = new Pedido();
            AdicionarItemPedido(pedido);
            conta.SetPedido(pedido);
        }

        Console.WriteLine(conta.GerarRelatorio());
    }
    private static void AdicionarItemPedido(Pedido pedido)
    {
        string opcao;
        bool loop = true;

        ExibirCardapio();
        while (loop)
        {
            MenuPedido();
            opcao = Console.ReadLine() ?? "F";
            switch (opcao)
            {
                case "C":
                    AdicionarComida(pedido);
                    break;
                case "B":
                    AdicionarBebida(pedido);
                    break;
                case "F":
                    loop = false;
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
    private static void AdicionarComida(Pedido pedido)
    {
        Console.WriteLine("Informe o número da comida (O primeiro número do lado esquerdo)," +
         "insira 0 se quiser nada");

        int index = int.Parse(Console.ReadLine() ?? "0");
        if (index == 0) return;

        pedido.AdicionarItem(restaurante.PegarBebida(index));
        Console.WriteLine("Comida adicionada com sucesso!");
    }

    private static void AdicionarBebida(Pedido pedido)
    {
        Console.WriteLine("Informe o número da bebida (O primeiro número do lado esquerdo)," +
         "insira 0 se quiser nada");

        int index = int.Parse(Console.ReadLine() ?? "0");
        if (index == 0) return;

        pedido.AdicionarItem(restaurante.PegarBebida(index));
        Console.WriteLine("Bebida adicionada com sucesso!");
    }
    #endregion

    #region Auxiliares

    private static void ExibirContas()
    {
        int i = 1;
        foreach (var conta in contas)
        {
            if (conta.Aberta)
            {
                Console.WriteLine($"{i} - {conta.ToString()}");
                i++;
            }
        }
    }
    private static int SelecionarIndexConta()
    {
        ExibirContas();
        Console.WriteLine("Informe o número da conta (O primeiro número do lado esquerdo)," +
           "insira 0 senão existir a conta correspondente");
        return int.Parse(Console.ReadLine() ?? "0");
    }

    private static Conta SelecionarConta(int index)
    {
        return contas.ElementAt(index - 1);
    }

    private static bool VerificarContasAbertas()
    {
        return contas.FirstOrDefault(c => c.Aberta == true) == null;
    }
    private static void ExibirCardapio()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(restaurante.GerarCardapio());
        Console.ResetColor();
    }   

    private static void MenuPedido()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Deseja bebida ou comida?\n" +
            "C . Para comida\n" +
            "B . Para bebida\n" +
            "F . Para fechar o pedido\n");
        Console.ResetColor();
    }
    #endregion
}