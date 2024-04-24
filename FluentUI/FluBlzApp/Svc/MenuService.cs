using Microsoft.FluentUI.AspNetCore.Components;

namespace FluBlzApp.Svc;

public class MenuItem
{
    public string Title { get; set; }
    public string Link { get; set; }
    public Icon Iconne { get; set; }
    public List<MenuItem> SubItems { get; set; } = new List<MenuItem>();
    public string Role { get; set; }
    public bool IsDefault { get; set; }

}
public interface IMenuService
{
    Task<List<MenuItem>> GetMenuItemsAsync();
}

public class MenuService : IMenuService
{
    public Task<List<MenuItem>> GetMenuItemsAsync()
    {
        var items = new List<MenuItem>
        {
            new MenuItem { Title = "Home", Link = "/", Iconne = new Icons.Regular.Size20.Home()},
            new MenuItem { Title = "Counter", Link = "counter", Iconne = new Icons.Regular.Size16.Timer() },
            new MenuItem { Title = "Weather", Link = "weather", Iconne = new Icons.Regular.Size16.WeatherMoon() },

            new MenuItem
            {
                Iconne = new Icons.Regular.Size16.ArrowCircleDown(),
                Title = "Services",
                SubItems = new List<MenuItem>
                {
                    new MenuItem { Title = "Web Development", Link = "https://google.com", Iconne = new Icons.Regular.Size16.WebAsset() },
                    new MenuItem { Title = "Mobile Development", Link = "https://yahoo.com", Iconne = new Icons.Regular.Size16.WebAsset() }
                }
            }
        };

        return Task.FromResult(items);
    }
}