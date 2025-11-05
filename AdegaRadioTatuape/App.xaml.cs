namespace AdegaRadioTatuape;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// Obter a MainPage via Service Provider
		var mainPage = Handler?.MauiContext?.Services.GetService<MainPage>();
		
		if (mainPage == null)
		{
			// Fallback: criar manualmente se DI falhar
			var cardapioService = Handler?.MauiContext?.Services.GetService<Services.CardapioService>();
			if (cardapioService != null)
			{
				mainPage = new MainPage(cardapioService);
			}
			else
			{
				// Último fallback
				mainPage = new MainPage(new Services.CardapioService());
			}
		}
		
		return new Window(mainPage);
	}
}
