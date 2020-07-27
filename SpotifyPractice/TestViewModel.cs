using Prism.Commands;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpotifyPractice
{
    public class TestViewModel :Prism.Mvvm.BindableBase
    {
        private string _req;
        private static HttpClient client = new HttpClient();

        public TestViewModel()
        {
            GetCommand = new DelegateCommand(SetValue);
            client.Timeout = TimeSpan.FromMilliseconds(3000);
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
            string ret=string.Empty;
            try
            {
                var result = await client.GetAsync(@"http://www.google.com");
                ret = result.StatusCode.ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
                
            return ret;
        }


        private void SetValue()
        {
            var task = TestAsync();
            task.Wait();
            Response = task.Result;
        }

    }
}
