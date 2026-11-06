using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyect.Services;

namespace Proyect.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly FirebaseService _firebaseService;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool isBusy;

        public RegisterViewModel()
        {
            _firebaseService = new FirebaseService();
        }

        [RelayCommand]
        private async Task RegisterAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Shell.Current.DisplayAlert("Error", "Completa todos los campos.", "OK");
                return;
            }

            try
            {
                IsBusy = true;
                bool success = await _firebaseService.RegisterAsync(Email, Password);

                if (success)
                {
                    await Shell.Current.DisplayAlert("Éxito", "¡Cuenta creada correctamente! Ahora puedes iniciar sesión.", "OK");
                    await Shell.Current.GoToAsync(".."); // Regresar al Login
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "No se pudo registrar. Verifica que el correo sea válido o la contraseña tenga al menos 6 caracteres.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Excepción", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}