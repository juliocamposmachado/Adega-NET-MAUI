using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AdegaRadioTatuape.Models;

namespace AdegaRadioTatuape.Services
{
    public class CardapioService
    {
        private static Cardapio? _cardapioCache;

        public async Task<Cardapio> CarregarCardapioAsync()
        {
            // Retorna do cache se já foi carregado
            if (_cardapioCache != null)
                return _cardapioCache;

            try
            {
                // Carrega o arquivo JSON embarcado
                using var stream = await FileSystem.OpenAppPackageFileAsync("cardapio.json");
                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();

                // Configura opções de serialização para case-insensitive
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                // Deserializa o JSON
                var cardapioData = JsonSerializer.Deserialize<CardapioJson>(json, options);
                
                if (cardapioData == null)
                    throw new Exception("Erro ao carregar o cardápio");

                // Converte para o modelo interno
                _cardapioCache = ConverterParaModelo(cardapioData);
                
                return _cardapioCache;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar cardápio: {ex.Message}");
                
                // Retorna um cardápio vazio em caso de erro
                return new Cardapio();
            }
        }

        private Cardapio ConverterParaModelo(CardapioJson json)
        {
            var cardapio = new Cardapio
            {
                Informacoes = new InformacoesAdega
                {
                    FormasPagamento = json.Informacoes.FormasPagamento,
                    HorarioFuncionamento = json.Informacoes.HorarioFuncionamento,
                    Entrega = new InfoEntrega
                    {
                        Tipo = json.Informacoes.Entrega.Tipo,
                        TempoMedio = json.Informacoes.Entrega.TempoMedio,
                        TaxaEntrega = json.Informacoes.Entrega.TaxaEntrega
                    },
                    Contato = new ContatoAdega
                    {
                        Whatsapp = json.Informacoes.Contato.Whatsapp,
                        Endereco = json.Informacoes.Contato.Endereco,
                        Cep = json.Informacoes.Contato.Cep
                    }
                }
            };

            // Converte categorias e produtos
            foreach (var cat in json.Categorias)
            {
                var categoria = new Categoria
                {
                    Id = cat.Id,
                    Nome = cat.Nome,
                    Icone = cat.Icone
                };

                foreach (var prod in cat.Produtos)
                {
                    categoria.Produtos.Add(new Produto
                    {
                        Id = prod.Id,
                        Nome = prod.Nome,
                        Preco = prod.Preco,
                        Volume = prod.Volume,
                        Imagem = prod.Imagem,
                        Estoque = prod.Estoque,
                        CategoriaId = cat.Id
                    });
                }

                cardapio.Categorias.Add(categoria);
            }

            return cardapio;
        }

        public void LimparCache()
        {
            _cardapioCache = null;
        }

        // Classes internas para deserialização JSON
        private class CardapioJson
        {
            public List<CategoriaJson> Categorias { get; set; } = new();
            public InformacoesJson Informacoes { get; set; } = new();
        }

        private class CategoriaJson
        {
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public string Icone { get; set; } = string.Empty;
            public List<ProdutoJson> Produtos { get; set; } = new();
        }

        private class ProdutoJson
        {
            public int Id { get; set; }
            public string Nome { get; set; } = string.Empty;
            public decimal Preco { get; set; }
            public string Volume { get; set; } = string.Empty;
            public string Imagem { get; set; } = string.Empty;
            public int Estoque { get; set; }
        }

        private class InformacoesJson
        {
            public List<string> FormasPagamento { get; set; } = new();
            public InfoEntregaJson Entrega { get; set; } = new();
            public string HorarioFuncionamento { get; set; } = string.Empty;
            public ContatoJson Contato { get; set; } = new();
        }

        private class InfoEntregaJson
        {
            public string Tipo { get; set; } = string.Empty;
            public string TempoMedio { get; set; } = string.Empty;
            public decimal TaxaEntrega { get; set; }
        }

        private class ContatoJson
        {
            public string Whatsapp { get; set; } = string.Empty;
            public string Endereco { get; set; } = string.Empty;
            public string Cep { get; set; } = string.Empty;
        }
    }
}

