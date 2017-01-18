using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MatterSharp.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Uri uri = new Uri("");

        public MainWindow()
        {
            InitializeComponent();
            Browser.Navigated += BrowserOnNavigated;
            Browser.Navigate(uri);
        }

        private async void BrowserOnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            var container = CookieHelper.GetUriCookieContainer(uri);
            var cookie = container.GetCookies(uri);
            var token = cookie["MMAUTHTOKEN"].Value;
            await MainAction(token);
            Close();
        }

        private async Task MainAction(string token)
        {
            var client = new MattermostClient(uri, token);
            var user = await client.GetCurrentUserAsync();
            var teams = await client.GetAllTeamsAsync();
            var team = teams.First();
            var channels = await client.GetAllChannelsAsync(team.Id);
            var channel = channels.Find(c => c.DisplayName == "test");
            var posts = await client.GetPostsForChannelAsync(team.Id, channel.Id, 0, 100);
        }
    }
}
