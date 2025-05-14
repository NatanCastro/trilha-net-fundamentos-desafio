namespace DesafioFundamentos.TUI;

using DesafioFundamentos.Domain.Models;

public class Menu
{
  public static void Run()
  {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.WriteLine(@"Seja bem vindo ao sistema de estacionamento!\n
Digite o preço inicial: ");

    decimal precoInicial = Convert.ToDecimal(Console.ReadLine());

    Console.WriteLine("Agora digite o preço por hora:");
    decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

    // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
    Estacionamento es = new(precoInicial, precoPorHora);

    string opcao = string.Empty;
    bool exibirMenu = true;

    while (exibirMenu)
    {
      Console.Clear();
      Console.WriteLine("Digite a sua opção:");
      Console.WriteLine("1 - Cadastrar veículo");
      Console.WriteLine("2 - Remover veículo");
      Console.WriteLine("3 - Listar veículos");
      Console.WriteLine("4 - Encerrar");

      opcao = Console.ReadLine() ?? string.Empty;

      switch (opcao)
      {
        case "1":
          Console.WriteLine("Digite a placa do veículo:");
          string placa_veiculo = Console.ReadLine() ?? string.Empty;
          if (placa_veiculo == string.Empty)
          {
            Console.WriteLine("Placa do veículo não pode ser vazia");
            break;
          }
          es.AdicionarVeiculo(placa_veiculo);
          break;
        case "2":
          Console.WriteLine("Digite a placa do veículo:");
          placa_veiculo = Console.ReadLine() ?? string.Empty;
          if (placa_veiculo == string.Empty)
          {
            Console.WriteLine("Placa do veículo não pode ser vazia");
            break;
          }
          Console.WriteLine("Digite a quantidade de horas:");
          int quantidade_horas = Convert.ToInt32(Console.ReadLine());
          decimal valor_pago = es.RemoverVeiculo(placa_veiculo, quantidade_horas);
          Console.WriteLine($"O valor pago é de R$ {valor_pago}");
          Console.WriteLine("Aperte ENTER para continuar");
          Console.ReadLine();
          break;
        case "3":
          Console.WriteLine("Veículos cadastrados:");
          foreach (string veiculo in es.GetVeiculos())
          {
            Console.WriteLine($" - {veiculo}");
          }
          break;
        case "4":
          Console.WriteLine("Encerrando...");
          exibirMenu = false;
          break;
        default:
          Console.WriteLine("Opção inválida");
          break;
      }
    }
  }
}