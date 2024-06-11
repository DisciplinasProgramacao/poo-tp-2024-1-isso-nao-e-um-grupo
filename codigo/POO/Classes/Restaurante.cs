using System.Collections.Generic;
using System;
using System;
using System.Collections.Generic;
using POO.Classes;

namespace POO.Classes
{
    public class Restaurante
    {
        #region Constantes

        private const int NUMERO_DE_MESAS = 10;

        #endregion

        #region Atributos

        private List<Requisicao> requisicoes;
        private List<Mesa> mesas;
        private Queue<Requisicao> filaDeEspera;
        private Cardapio cardapio;
        public string Nome { get; }

        #endregion

        #region Construtor

        public Restaurante(string nome)
        {
            requisicoes = new List<Requisicao>();
            mesas = Mesa.GerarMesas();
            filaDeEspera = new Queue<Requisicao>();
            Nome = nome;
            cardapio = new Cardapio();
        }
        
        #endregion

        #region Métodos Públicos

        public bool AlocarMesa(Requisicao requisicao)
        {
            Mesa mesa;
              
            if (!VerificarNumeroDePessoas(requisicao.GetQuantidadeDePessoas()))
            {
                throw new InvalidOperationException("Não há mesas para essa quantidade de pessoas!");
            }

            if (VerificarExistenciaMesasDisponiveis())
            {
                mesa = ObterMesasDisponiveis(requisicao.GetQuantidadeDePessoas());
           
                requisicoes.Add(requisicao);
                mesa.OcuparMesa();
            }
            else
            {
                    filaDeEspera.Enqueue(requisicao);
                    return false;    
            }

            return true;
        }

        public bool RegistrarSaida(Cliente client)
        {
            Requisicao? requisicao = requisicoes.Find(r => r.GetCliente().GetIdCliente() == client.GetIdCliente());

            if (requisicao == null)
            {
                return false;
            }

            requisicao.FecharRequisicao();
            ProcurarMesaParaRequisicao();
            return true;
        }

        public Cardapio GetCardapio() => cardapio;

        #endregion

        #region Métodos Privados

        private void ProcurarMesaParaRequisicao()
        {
            if (!filaDeEspera.Any())
                return;

            List<Guid> idsAtendidos = new List<Guid>();

            foreach (var requisicao in filaDeEspera.ToArray())
            {
                Mesa? mesaDisponivel = ObterMesasDisponiveis(requisicao.GetQuantidadeDePessoas());
                if (mesaDisponivel != null)
                {
                    requisicao.OcuparMesa(mesaDisponivel);
                    requisicoes.Add(requisicao);
                    idsAtendidos.Add(requisicao.GetCliente().GetIdCliente());
                }
            }

            Queue<Requisicao> filaAuxiliar = new Queue<Requisicao>();

            while (filaDeEspera.Count > 0)
            {
                Requisicao requisicao = filaDeEspera.Dequeue();
                if (!idsAtendidos.Contains(requisicao.GetCliente().GetIdCliente()))
                {
                    filaAuxiliar.Enqueue(requisicao);
                }
            }

            while (filaAuxiliar.Count > 0)
            {
                filaDeEspera.Enqueue(filaAuxiliar.Dequeue());
            }
        }

        private bool VerificarNumeroDePessoas(int quantidadePessoas)
        {
            return quantidadePessoas > 0 && quantidadePessoas <= 10;
        }

        private bool VerificarExistenciaMesasDisponiveis()
        {
            return mesas.Find(m => m.GetDisponibilidade()) != null;
        }

        private Mesa ObterMesasDisponiveis(int quantidadePessoas)
        {
            return mesas.Find(m => m.VerificarDisponibilidade(quantidadePessoas));
        }

        #endregion
    }
}