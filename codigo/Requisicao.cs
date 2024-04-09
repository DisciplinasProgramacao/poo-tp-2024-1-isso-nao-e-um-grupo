using System;

public class  Requisicao
{
    private Guid proximoIdRequisicao;
    private Guid requisicaoId;
    private DateTime dataDeEntrada;
    private DateTime dataSaida;
    private Cliente dadosDosClientes;
    private bool status;
    private Mesa mesa;
    private int numeroDePessoas;


    public Requisicao(int numeroDePessoas, Mesa mesa)
    {
        dataDeEntrada = DateTime.Now;
        this.proximoIdRequisicao = new Guid();
        this.numeroDePessoas = numeroDePessoas;
        this.mesa = mesa;
    }

    public Requisicao()
    {
        dataDeEntrada = DateTime.Now;
        proximoIdRequisicao = Guid.NewGuid();
        mesa = null;
    }

    public Cliente GetCliente()
    {
        return dadosDosClientes;
    }

    public int GetQuantidadeDePessoas()
    {
        return numeroDePessoas;
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

    public bool OcuparMesa(Mesa mesa)
    {
        if (mesa.VerificarDisponibilidade(numeroDePessoas))
        {
            this.mesa = mesa;
            return true;
        }

        return false;
    }

    public void FecharRequisicao()
    {
        RegistrarDataDeSaida();
        this.status = true;
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
}
