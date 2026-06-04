
namespace Dominio.Entidades;

public class ProdutoItem
{
    public Guid Id { get; set; }
    public string? Descricao { get; set; }
    public string? Categoria { get; set; }
    public decimal Valor { get; set; }
}
