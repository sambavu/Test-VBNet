namespace MobileApp;

/// <summary>
/// Page d'accueil de l'application mobile
/// Requiert Microsoft.Maui.Controls
/// </summary>
public partial class MainPage
{
    int count = 0;

    public MainPage()
    {
        // InitializeComponent(); - Requis uniquement avec MAUI complet
    }

    public void OnCounterClicked(object sender, EventArgs e)
    {
        count++;
        System.Diagnostics.Debug.WriteLine($"Click count: {count}");
    }
}
