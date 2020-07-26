using Prism.Commands;
using SpotifyWebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotifyPractice
{
    public class TestViewModel :Prism.Mvvm.BindableBase
    {
        private string _req;
        public TestViewModel()
        {
            GetCommand = new DelegateCommand(SetValue);
            _req = "Nodata";
        }

        public string Response
        {
            get { return _req; }
            set { SetProperty(ref _req, value); }
        }

        public ICommand GetCommand { get;}
        private async Task<string> TestAsync()
        {
            var token = new AuthenticationToken()
            {
                AccessToken = "9cb526d767d249498e528ff995f7f20d",
                ExpiresOn = DateTime.Now.AddSeconds(3600),
                RefreshToken = "862fea0d84c94ccb9b2a9ce794dd328b",
                TokenType = "Bearer"
            };
            //var output = await SpotifyWebAPI.Track.Search("Ties that bind", "Blackbird", "Alter Bridge");

            //Console.WriteLine(output.Items[0].Name);
            var usr = await SpotifyWebAPI.User.GetCurrentUserProfile(token);
            var playlist = await usr.GetPlaylists(token);
            return playlist.ToString();
            //return output.Items[0].Name ;
        }

        private void SetValue()
        {
            var task = TestAsync();
            while(!task.IsCompleted)
            {
                task.Wait(3600);

            }
            _req = task.Result;
        }

    }
}
