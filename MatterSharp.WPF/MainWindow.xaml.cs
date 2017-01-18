using System;
using System.Linq;
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

        private void BrowserOnNavigated(object sender, NavigationEventArgs navigationEventArgs)
        {
            var container = CookieHelper.GetUriCookieContainer(uri);
            var cookie = container.GetCookies(uri);
            var token = cookie["MMAUTHTOKEN"].Value;
            MainAction(token);
            Close();
        }

        private void MainAction(string token)
        {
            var client = new MattermostRestClient(uri, token);
            var teams = client.GetAllTeams();
            var team = teams.First().Value;
            var channels = client.GetAllChannels(team.Id);
            var channel = channels.Channels.Find(c => c.DisplayName == "test");
            var posts = client.GetPostsForAChannel(team.Id, channel.Id, 0, 100);
        }
    }
}
