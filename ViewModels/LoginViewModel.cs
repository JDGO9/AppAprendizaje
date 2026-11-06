using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Views;
using System.Net.Http.Json;

namespace Proyect.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;

        // PEGA AQUÍ TU API KEY REAL DE FIREBASE
        private const string ApiKey = "AIzaSyBqRH-b2bDKgZEITyVzW37i1WyEP04l-ig";

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        public LoginViewModel()
        {
            _httpClient = new HttpClient();
        }

        [RelayCommand]
        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Por favor, ingresa tu correo y contraseña.", "OK");
                return;
            }

            try
            {
                IsBusy = true;

                var url = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={ApiKey}";
                var body = new { email = Email, password = Password, returnSecureToken = true };

                var response = await _httpClient.PostAsJsonAsync(url, body);

                if (response.IsSuccessStatusCode)
                {
                    await Shell.Current.DisplayAlert("Éxito", "¡Bienvenido!", "OK");
                    await Shell.Current.GoToAsync(nameof(DashboardPage));
                    
                }
                else
                {
                    await Shell.Current.DisplayAlert("Acceso denegado", "Correo o contraseña incorrectos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        private async Task GoToRegisterAsync()
        {
            // Navegar a la pantalla de registro
            await Shell.Current.GoToAsync(nameof(Views.RegisterPage));
        }
    }
}