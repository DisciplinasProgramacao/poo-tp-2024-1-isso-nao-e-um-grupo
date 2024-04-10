using System;
using System.Collections.Generic;

namespace POO
{
    public class Restaurante
    {
        private const NUMERO_DE_MESAS = 10;
        private List<Requisicao> requisicoes;
        private Mesa[] mesas = new Mesa[NUMERO_DE_MESAS];
        private Queue<Requisicao> filaDeEspera;

        private bool VerificarClienteValido(Cliente cliente)
        {

        }

        private Requisicao CriarRequisicao(Cliente cliente)
        {

        }

        private bool VerificarDisponibilidade(int numeroMesa) 
        {
            
        }

        private int VerificarMesaDisponivel()
        {

        }

        public bool RegistrarSaida(Guid idRequisicao)
        {

        }

        public bool AlocarMesa(Cliente cliente)
        {

        }
    }
}
