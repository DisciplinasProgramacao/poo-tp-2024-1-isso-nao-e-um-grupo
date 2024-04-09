using System;

public class Requisicao
{
    private static Guid proximoIdRequisicao => Guid.NewGuid();
    private Guid requisicaoId;
    private DateTime dataDeEntrada;
    private DateTime? dataSaida;
    private Cliente dadosDoCliente;
    private bool status;
    private Mesa? mesa;
    private int numeroDePessoas;


    public Requisicao(int numeroDePessoas, Mesa mesa, Cliente cliente)
    {
        requisicaoId = proximoIdRequisicao;
        dataDeEntrada = DateTime.Now;
        dadosDoCliente = cliente;
        status = true;
        this.mesa = mesa;
        this.numeroDePessoas = numeroDePessoas;
    }

    public Requisicao(int numeroDePessoas, Cliente cliente)
    {
        requisicaoId = proximoIdRequisicao;
        dataDeEntrada = DateTime.Now;
        dadosDoCliente = cliente;
        status = true;
        this.mesa = null;
        this.numeroDePessoas = numeroDePessoas;
    }
    public int GetQuantidadeDePessoas()
    {
        return numeroDePessoas;
    }

    public Cliente GetCliente()
    {
        return dadosDoCliente;
    }

    public bool OcuparMesa(Mesa mesa)
    {
        if (this.mesa == null)
        {
            this.mesa = mesa;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FecharRequisicao()
    {
        RegistrarDataDeSaida();
        this.status = false;
    }

    public bool AdicionarPessoas(int quantidade)
    {
        if (quantidade > 0)
        {
            this.numeroDePessoas += quantidade;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RetirarPessoas(int quantidade)
    {
        if (quantidade > 0 && this.numeroDePessoas - quantidade >= 0)
        {
            this.numeroDePessoas -= quantidade;
            return true;
        }
        else
        {
            return false;
        }
    }
    private void RegistrarDataDeSaida()
    {
        if (dataSaida == null)
        {
            dataSaida = DateTime.Now;
            Console.WriteLine("Data de saída registrada: " + dataSaida);
        }
        else
        {
            throw new InvalidOperationException("A requisição já foi fechada.");
        }
    }
}
