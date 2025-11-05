using System.Collections.Generic;

namespace AdegaRadioTatuape.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Icone { get; set; } = string.Empty;
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        // Propriedade computada para contagem de produtos
        public int QuantidadeProdutos => Produtos?.Count ?? 0;

        // Propriedade para exibir no header
        public string TituloComIcone => $"{Icone} {Nome}";
    }
}

