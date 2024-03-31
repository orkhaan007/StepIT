using System.Net;
using System.Net.Mail;

var fromEmail = "orkhanm07@gmail.com";
var fromPassword = "zupf xugi xdqi vxnm";

var smtpEmail = new SmtpClient("smtp.gmail.com", 587);
smtpEmail.EnableSsl = true;
smtpEmail.Credentials = new NetworkCredential(fromEmail, fromPassword);

var listener = new HttpListener();

listener.Prefixes.Add("http://localhost:27001/");
listener.Start();

Console.WriteLine("Listening ...");

while (true)
{
    var context = listener.GetContext();

    var request = context.Request;
    var response = context.Response;

    var querystring = request.QueryString;
    using var writer = new StreamWriter(response.OutputStream);


    if(querystring.Count == 0)
    {
        var text = File.ReadAllText("index.html");
        writer.Write(text);
    }
    else
    {
        Console.WriteLine("Testtt");
        var toEmail = querystring["toEmail"];
        var subject = querystring["subject"];
        var body = querystring["body"];

        if(toEmail is not null && subject is not null && body is not null)
        {
            var mail = new MailMessage(fromEmail, toEmail);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtpEmail.Send(mail);
            response.StatusCode = 200;
            writer.Write("Mail sent successfully!");
        }
        else
        {
            response.StatusCode = 400;
            writer.Write("Invalid request!");
        }
    }
}