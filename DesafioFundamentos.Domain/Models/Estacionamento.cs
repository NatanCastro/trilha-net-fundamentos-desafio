namespace DesafioFundamentos.Domain.Models;

public class Estacionamento
{
    private readonly decimal precoInicial = 0;
    private readonly decimal precoPorHora = 0;
    private List<string> veiculos { get; }

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        this.precoInicial = precoInicial;
        this.precoPorHora = precoPorHora;
        veiculos = new();
    }

    public void AdicionarVeiculo(string placa_veiculo)
    {
        veiculos.Add(placa_veiculo);
    }

    public decimal RemoverVeiculo(string placa_veiculo, int quantidade_horas)
    {
        if (!veiculos.Any(x => x.ToUpper() == placa_veiculo.ToUpper()))
            return 0;

        veiculos.Remove(placa_veiculo);
        return precoInicial + precoPorHora * quantidade_horas;
    }

    public List<string> GetVeiculos()
    {
        return veiculos;
    }
}