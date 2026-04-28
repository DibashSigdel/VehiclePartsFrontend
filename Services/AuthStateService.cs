using VehiclePartsFrontend.Models.Auth;

namespace VehiclePartsFrontend.Services;

public class AuthStateService
{
    public AuthResponseDto? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser is not null && !string.IsNullOrWhiteSpace(CurrentUser.Token);

    public event Action? StateChanged;

    public void SetUser(AuthResponseDto user)
    {
        CurrentUser = user;
        StateChanged?.Invoke();
    }

    public void Logout()
    {
        CurrentUser = null;
        StateChanged?.Invoke();
    }
}
