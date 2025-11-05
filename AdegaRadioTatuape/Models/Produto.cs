namespace AdegaRadioTatuape.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Volume { get; set; } = string.Empty;
        public string Imagem { get; set; } = string.Empty;
        public int Estoque { get; set; }
        public int CategoriaId { get; set; }

        // Propriedade computada para exibição de preço formatado
        public string PrecoFormatado => $"R$ {Preco:F2}";

        // Propriedade para disponibilidade
        public bool Disponivel => Estoque > 0;

        // Propriedade para status de estoque
        public string StatusEstoque
        {
            get
            {
                if (Estoque == 0)
                    return "Indisponível";
                else if (Estoque < 10)
                    return $"Últimas {Estoque} unidades!";
                else
                    return $"{Estoque} disponíveis";
            }
        }
    }
}

