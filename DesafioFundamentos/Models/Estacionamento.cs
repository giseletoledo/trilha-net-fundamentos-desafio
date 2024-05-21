using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            // Validação da placa usando regex
            string pattern = @"^[A-Z]{3}-\d{4}$"; // Exemplo de padrão para placas AAA-1234
            if (Regex.IsMatch(placa, pattern))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado.");
            }
            else
            {
                Console.WriteLine("Placa de veículo inválida. Por favor, digite uma placa no formato AAA-1234.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                // Inicializa as variáveis
                int horas = 0;
                decimal valorTotal = 0;

                // Valida a entrada do usuário para horas
                if (int.TryParse(Console.ReadLine(), out horas) && horas > 0)
                {
                    // Realiza o cálculo do valor total
                    valorTotal = precoInicial + precoPorHora * horas;

                    // Remove a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Por favor, tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
