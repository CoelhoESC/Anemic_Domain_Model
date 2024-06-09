using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Anemico
{
    internal class Program
    {
        public class Pedido
        {
            public int Id { get; set; }
            public string ClienteID { get; set; }
            public decimal Desconto { get; set; }
            public DateTime? DataPagamento { get; set; }
            public List<ItemPedido> items { get; set; }
        }

        public class PedidoService
        {
            public void AddItem(int id, ItemPedido item)
            {
                //Validação
            }
        }
        /* 
         * - Contem somente propriedades com get e set publicos
         * - Não possuem validaçoes nem comportamentos;
         * - A logica e manipulação da classe é colocada em outra classe (serviço)
         * - Não possuem gerenciamento de estado, permitindo que objetos com estado incosistente sejam criados
         * - Permitem que outros objetos criem instancias e modifiquem o dominio.
         * 
         * 
         * -- PROBLEMAS --
         * - O cliente precisa interpretar o objetivo e o uso da classe e a logica é enviada para outras classes, denominadas serviços
         * da classe dominio.
         * - Violação do encapsulamento;
         * - Dificuldade na manutenção;
         * - Logica de negocios duplicadas;
         * - Não é possivel garantir que as entidades no modelo estejam em um estado consistente.
         * - Baixa Coesão
         * 
         * 
         * -- Solucionando (Enriquecendo o modelo) --
         * - Usar propriedade com setters privados (e as classes como sealed)
         * - Validar estado da entidade
         * - Evitar Construtores sem paramentros
         * - Definir invariantes (id, nome...)                 
         * - Trazer as regras de comportamentos dos serviços para o modelo de dominio.
         * - Usar os Conceitos da POO
         * - Cuidado e atenção ao usar ferramentas ORM (EF Core)
         * 
         * 
         */

        // EXEMPLO

        public class Cliente_Anemic  // Dominio Anemico
        {
            public int id { get; set; }
            public string Nome { get; set; }
            public string Endereco { get; set; }

        }

        public sealed class CLiente_enrequicido // Solucionando o problema 
        {
            public int Id { get; private set; }
            public string Nome { get; private set; }
            public string Endereco { get; private set; }

            public CLiente_enrequicido(int id, string nome, string endereco)
            {
                Id = id;
                Nome = nome;
                Endereco = endereco;
                Validar(id, nome);

            }

            private void Validar(int id, string nome)
            {
                if (id < 0)
                {
                    throw new InvalidOperationException("O id tem que ser maior que 0");
                }

                if (string.IsNullOrEmpty(nome)) { throw new InvalidOperationException("O nome é requerido"); }

                if (nome.Length < 3) { throw new ArgumentException("O nome de ter no minimo 3 caracteres"); }

                if(nome.Length > 100) { throw new ArgumentException("O nome excedeu 100 caracteres"); }

            }

        }

        static void Main(string[] args)
        {
        }
    }
}
