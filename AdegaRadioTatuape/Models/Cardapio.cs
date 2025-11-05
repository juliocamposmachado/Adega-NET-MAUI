using System.Collections.Generic;

namespace AdegaRadioTatuape.Models
{
    public class Cardapio
    {
        public List<Categoria> Categorias { get; set; } = new List<Categoria>();
        public InformacoesAdega Informacoes { get; set; } = new InformacoesAdega();
    }

    public class InformacoesAdega
    {
        public List<string> FormasPagamento { get; set; } = new List<string>();
        public InfoEntrega Entrega { get; set; } = new InfoEntrega();
        public string HorarioFuncionamento { get; set; } = string.Empty;
        public ContatoAdega Contato { get; set; } = new ContatoAdega();
    }

    public class InfoEntrega
    {
        public string Tipo { get; set; } = string.Empty;
        public string TempoMedio { get; set; } = string.Empty;
        public decimal TaxaEntrega { get; set; }
        
        public string DescricaoCompleta => $"{Tipo} • {TempoMedio}";
        public string TaxaFormatada => $"R$ {TaxaEntrega:F2}";
    }

    public class ContatoAdega
    {
        public string Whatsapp { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        
        public string WhatsappFormatado
        {
            get
            {
                if (string.IsNullOrEmpty(Whatsapp) || Whatsapp.Length != 11)
                    return Whatsapp;
                
                return $"({Whatsapp.Substring(0, 2)}) {Whatsapp.Substring(2, 5)}-{Whatsapp.Substring(7)}";
            }
        }
        
        public string EnderecoCompleto => $"{Endereco}, CEP {Cep}";
    }
}

