using Services.Models;
using System;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using static Amazon.Internal.RegionEndpointProviderV2;
using System.Collections.Generic;

namespace Services
{
    public class EmailService
    {
        public EmailService()
        {

        }

        public async Task SendEmail(EmailModel email)
        {
            // Replace sender@example.com with your "From" address.
            // This address must be verified with Amazon SES.
            string senderAddress = "sender@example.com";

            // Replace recipient@example.com with a "To" address. If your account
            // is still in the sandbox, this address must be verified.
            string receiverAddress = "recipient@example.com";

            // The configuration set to use for this email. If you do not want to use a
            // configuration set, comment out the following property and the
            // ConfigurationSetName = configSet argument below. 
            string configSet = "ConfigSet";

            // The subject line for the email.
            string subject = "Amazon SES test (AWS SDK for .NET)";

            // The email body for recipients with non-HTML email clients.
            string textBody = "Amazon SES Test (.NET)\r\n"
                                            + "This email was sent through Amazon SES "
                                            + "using the AWS SDK for .NET.";

            // The HTML body of the email.
            string htmlBody = @"<html> <head></head><body> <h1>Amazon SES Test (AWS SDK for .NET)</h1> <p>This email was sent with
                                <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
                                <a href='https://aws.amazon.com/sdk-for-net/'>
                                  AWS SDK for .NET</a>.</p>
                            </body>
                            </html>";

            // Replace USWest2 with the AWS Region you're using for Amazon SES.
            // Acceptable values are EUWest1, USEast1, and USWest2.
            using (var client = new AmazonSimpleEmailServiceClient(Amazon.RegionEndpoint.USWest2))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    // If you are not using a configuration set, comment
                    // or remove the following line 
                    ConfigurationSetName = configSet
                };
                try
                {
                    Console.WriteLine("Sending email using Amazon SES...");
                    var response = client.SendEmailAsync(sendRequest);
                    Console.WriteLine("The email was sent successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The email was not sent.");
                    Console.WriteLine("Error message: " + ex.Message);

                }
            }                       
        }
    }
}
