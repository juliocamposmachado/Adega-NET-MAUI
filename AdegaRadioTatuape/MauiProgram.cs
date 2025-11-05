using Microsoft.Extensions.Logging;
using AdegaRadioTatuape.Services;

namespace AdegaRadioTatuape;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		// Registrar serviços
		builder.Services.AddSingleton<CardapioService>();
		
		// Registrar páginas
		builder.Services.AddTransient<MainPage>();

		return builder.Build();
	}
}
