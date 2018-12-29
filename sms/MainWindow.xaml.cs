using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace sms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Find your Account Sid and Token at twilio.com/console
                const string accountSid = "AC86ca5782a21040854cf028e8f99c49b0";
                const string authToken = "your_auth_token";//your_auth_token

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: txt_msg.Text,
                    from: new Twilio.Types.PhoneNumber("+18632436154"),
                    to: new Twilio.Types.PhoneNumber(txt_no.Text)
                );

                // Console.WriteLine(message.Sid);
                MessageBox.Show("Message Sent Successfully");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_cls_Click(object sender, RoutedEventArgs e)
        {
            txt_no.Text = "";
            txt_msg.Text = "";
        }
    }
}
