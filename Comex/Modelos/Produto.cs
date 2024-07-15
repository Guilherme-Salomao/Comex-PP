using System.Text.Json.Serialization;

namespace Comex.Modelos;

public class Produto
{
    public Produto(string nome)
    {
        Nome = nome;
    }
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Nome { get; set; }
    [JsonPropertyName("description")]
    public string Descricao { get; set; }
    [JsonPropertyName("price")]
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}
