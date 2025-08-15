using Microsoft.Extensions.Logging;

namespace WorkoutTimerApp;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddLogging(logging => logging.AddDebug());
#endif

		// Register services for dependency injection
		// builder.Services.AddSingleton<IGoogleSheetsService, GoogleSheetsService>();
		// builder.Services.AddSingleton<IAudioService, AudioService>();
		// builder.Services.AddSingleton<IWorkoutTimerService, WorkoutTimerService>();
		// builder.Services.AddDbContext<WorkoutContext>();

		// Register ViewModels
		// builder.Services.AddTransient<MainViewModel>();
		// builder.Services.AddTransient<WorkoutSessionViewModel>();
		// builder.Services.AddTransient<SettingsViewModel>();

		return builder.Build();
	}
}