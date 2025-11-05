using AdegaRadioTatuape.Services;
using AdegaRadioTatuape.Models;

namespace AdegaRadioTatuape;

public partial class MainPage : ContentPage
{
	private readonly CardapioService _cardapioService;

	public MainPage(CardapioService cardapioService)
	{
		InitializeComponent();
		_cardapioService = cardapioService;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await CarregarCardapio();
	}

	private async Task CarregarCardapio()
	{
		try
		{
			// Mostra loading
			LoadingIndicator.IsVisible = true;
			LoadingIndicator.IsRunning = true;
			ErrorLabel.IsVisible = false;
			CategoriasCollectionView.IsVisible = false;
			FooterInfo.IsVisible = false;

			// Carrega o cardápio
			var cardapio = await _cardapioService.CarregarCardapioAsync();

			if (cardapio != null && cardapio.Categorias.Any())
			{
				// Exibe as categorias
				CategoriasCollectionView.ItemsSource = cardapio.Categorias;
				CategoriasCollectionView.IsVisible = true;
				FooterInfo.IsVisible = true;

				// Log de sucesso
				System.Diagnostics.Debug.WriteLine($"Cardápio carregado: {cardapio.Categorias.Count} categorias");
			}
			else
			{
				// Exibe mensagem de erro
				ErrorLabel.Text = "Nenhum produto disponível no momento";
				ErrorLabel.IsVisible = true;
			}
		}
		catch (Exception ex)
		{
			// Exibe mensagem de erro
			ErrorLabel.Text = $"Erro ao carregar cardápio: {ex.Message}";
			ErrorLabel.IsVisible = true;
			System.Diagnostics.Debug.WriteLine($"Erro: {ex}");
		}
		finally
		{
			// Esconde loading
			LoadingIndicator.IsVisible = false;
			LoadingIndicator.IsRunning = false;
		}
	}
}
