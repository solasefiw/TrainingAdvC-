using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AsyncUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int _localOperationCounter = 0;
        int _webAPIOperationCounter = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AddListItem(string text)
        {
            ListViewItem listViewItem = new ListViewItem();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            listViewItem.Content = textBlock;
            lstview.Items.Add(listViewItem);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _localOperationCounter++;
            AddListItem($"Fast Local Operation Completed {_localOperationCounter}");
        }

        //  Async Operation
        //private async void Button_Click_1(object sender, RoutedEventArgs e)
        //{

        //    HttpClientHandler handler = new HttpClientHandler();
        //    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };
        //    HttpClient httpClient = new HttpClient(handler);

        //    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("https://localhost:7055/api/HughQuery");

        //    string result = await httpResponseMessage.Content.ReadAsStringAsync();

        //    _webAPIOperationCounter++;

        //    AddListItem($"{result} {_webAPIOperationCounter}");

        //}



        //  Sync Operation
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(handler);

            var httpResponseMessage = httpClient.GetAsync("https://localhost:7055/api/HughQuery").Result;

            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;

            _webAPIOperationCounter++;

            AddListItem($"{result} {_webAPIOperationCounter}");
        }
        bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // TODO: You can do custom validation here, or just return true to always accept the certificate.
            // DO NOT use custom validation logic in a production application as it is insecure.
            return true;
        }
    }
}
