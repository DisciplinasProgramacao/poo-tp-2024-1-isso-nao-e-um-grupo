using POO.Classes;
using POO.Classes.Estabelecimentos;
using POO.Classes.NovaPasta;

namespace ProgramRestaurante;

public class Program
{
    private const string NomeRestaurante = "Isso Não é Um Restaurante";
    private const string NomeCafeteria = "Isso Não é Uma Cafeteria";

    private static Estabelecimento estabelecimento;

    public static void Main()
    {
        MenuGeral();
    }

    private static void CafeteriaPedidos()
    {
        var requisicao = FazerRequisicao();

        FazerPedidos(requisicao);
        FecharRequisicao();
    }

    #region Menus

    public static void MenuGeral()
    {
        string opcao;

        do
        {
            Console.Clear();
            Console.WriteLine($"Seja bem-vindo! Qual seu estabelecimento?");
            Console.WriteLine("1 - Restaurante");
            Console.WriteLine("2 - Cafeteria");
            Console.WriteLine("3 - Sair");
            Console.Write("Digite uma opção: ");

            opcao = Console.ReadLine() ?? "3";

            switch (opcao)
            {
                case "1":
                    estabelecimento = new Restaurante(NomeRestaurante);
                    MenuRestaurante();
                    break;
                case "2":
                    estabelecimento = new Cafeteria(NomeCafeteria);
                    MenuCafeteria();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        } while (opcao != "3");
    }

    public static void MenuCafeteria()
    {
        Console.Clear();
        Console.WriteLine($"Seja bem-vindo à Cafeteria - {NomeCafeteria}!");

        string opcao;

        do
        {
            Console.WriteLine("1 - Fazer Pedidos");
            Console.WriteLine("2 - Sair");
            Console.Write("Digite uma opção: ");

            opcao = Console.ReadLine() ?? "2";

            switch (opcao)
            {
                case "1":
                    CafeteriaPedidos();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        } while (opcao != "2");
    }

    public static void MenuRestaurante()
    {
        Console.Clear();
        Console.WriteLine($"Seja bem-vindo ao Restaurante - {NomeRestaurante}!");

        string opcao;

        do
        {
            Console.WriteLine("1 - Fazer Requisicao");
            Console.WriteLine("2 - Fechar Requisicao");
            Console.WriteLine("3 - Fazer Pedidos");
            Console.WriteLine("4 - Sair");
            Console.Write("Digite uma opção: ");

            opcao = Console.ReadLine() ?? "4";

            switch (opcao)
            {
                case "1":
                    FazerRequisicao();
                    break;
                case "2":
                    FecharRequisicao();
                    break;
                case "3":
                    FazerPedidos();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Opção inválida!\n");
                    break;
            }
        } while (opcao != "4");
    }

    #endregion 

    #region Abrir Requisicao

    public static Requisicao FazerRequisicao()
    {
        Requisicao requisicao;
        bool result;

        Console.WriteLine("\nSão quantas pessoas?");
        Console.Write("Informe a quantidade de pessoas: ");

        int quantidadePessoas;

        try
        {
            quantidadePessoas = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine() ?? "0";

            requisicao = new Requisicao(new Cliente(nome), quantidadePessoas);

            result = estabelecimento.AlocarMesa(requisicao);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();

            return null;
        }

        Console.Clear();

        return requisicao;
    }

    #endregion

    #region Remoção de Requisicao

    private static void FecharRequisicao()
    {
        try
        {
            Console.Clear();
            Console.Write(estabelecimento.RequisicoesAtivas());
            Console.Write("\nInforme o número da mesa: ");

            int numeroDaMesa = int.Parse(Console.ReadLine() ?? "0");
            var requisicao = estabelecimento.RegistrarSaida(numeroDaMesa);

            Console.WriteLine("Requisição fechada com sucesso! Abaixo o relatório! \n");
            Console.WriteLine(requisicao?.RelatorioConta());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    }

    #endregion

    #region Pedidos

    public static void FazerPedidos()
    {

        Pedido pedido = new Pedido();
        Requisicao? requisicao = null;

        try
        {
            pedido = AdicionarItemPedido();

            Console.WriteLine(estabelecimento.RequisicoesAtivas());
            Console.Write("\nInforme o número da mesa: ");

            int numeroDaMesa = int.Parse(Console.ReadLine() ?? "0");

            requisicao = estabelecimento.AdicionarPedido(numeroDaMesa, pedido);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();

            return;
        }

        Console.WriteLine(requisicao.RelatorioConta());
    }

    public static void FazerPedidos(Requisicao requisicao)
    {
        var pedido = new Pedido();

        try
        {
            pedido = AdicionarItemPedido();
            requisicao.DefinirPedido(pedido);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();

            return;
        }

        Console.WriteLine(requisicao.RelatorioConta());
    }

    private static Pedido AdicionarItemPedido()
    {
        string opcao = "";
        Pedido p = new Pedido();

        do
        {
            ExibirCardapio(estabelecimento);
            MenuPedido();

            opcao = Console.ReadLine() ?? "F";

            switch (opcao)
            {
                case "P":
                    p.AdicionarItem(AdicionarAoPedido());
                    break;
                default:
                    break;
            }
        } while (opcao != "F");

        return p;
    }
    private static ItemPedido AdicionarAoPedido()
    {
        Console.WriteLine("Informe o número do Item (O primeiro número do lado esquerdo)" +
         "insira 0 se quiser nada");

        int index = int.Parse(Console.ReadLine() ?? "0");

        if (index == 0)
            return null;

        var item = estabelecimento.EscolherItemPedido(index);
        Console.WriteLine("Comida adicionada com sucesso!");
        Console.Clear();
        return item;
    }

    #endregion

    #region Auxiliares

    private static void ExibirCardapio(Estabelecimento estabelecimento)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(estabelecimento.ExibirCardapio());
        Console.ResetColor();
    }

    private static void MenuPedido()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Qual o Pedido?\n" +
            "P . Para selecionar\n" +
            "F . Para fechar o pedido");
        Console.ResetColor();
    }

    #endregion
}