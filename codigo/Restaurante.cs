using System;
using System.Collections.Generic;

namespace POO
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

        #endregion

        #region Construtor

        public Restaurante()
        {
            requisicoes = new List<Requisicao>();
            mesas = new List<Mesa>()
            {

            };
            filaDeEspera = new Queue<Requisicao>();
        }

        #endregion

        #region Métodos Públicos

        public bool AlocarMesa(Cliente cliente, int quantidadePessoas)
        {
            Mesa? mesa;

            if (!VerificarNumeroDePessoas(quantidadePessoas))
            {
                throw new InvalidOperationException("Não há mesas para essa quantidade de pessoas!");
            }

            if (VerificarExistenciaMesasDisponiveis())
            {
                mesa = ObterMesasDisponiveis(quantidadePessoas);

                if (mesa == null)
                {
                    filaDeEspera.Enqueue(new Requisicao(cliente, quantidadePessoas));
                    return false;
                }

                requisicoes.Add(new Requisicao(cliente, quantidadePessoas, mesa));
                mesa.OcuparMesa();
            }

            return true;
        }

        public bool RegistrarSaida(Guid idCliente)
        {
            Requisicao? requisicao = requisicoes.Find(r => r.GetCliente().GetIdCliente() == idCliente);

            if (requisicao == null)
            {
                return false;
            }

            requisicao.FecharRequisicao();
            ProcurarMesaParaRequisicao();
            return true;
        }

        #endregion

        #region Métodos Privados

        private void ProcurarMesaParaRequisicao()
        {
            Requisicao requisicao = filaDeEspera.Dequeue();
            Mesa mesa = ObterMesasDisponiveis(requisicao.GetQuantidadeDePessoas());
            if (mesa != null)
            {
                requisicoes.Add(new Requisicao(requisicao.GetCliente(), requisicao.GetQuantidadeDePessoas(), mesa));
                mesa.OcuparMesa();
            }
            else
            {
                filaDeEspera.Enqueue(requisicao);
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

        private Mesa? ObterMesasDisponiveis(int quantidadePessoas)
        {
            return mesas.Find(m => m.VerificarDisponibilidade(quantidadePessoas));
        }

        #endregion
    }
}
