using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Dtos.Requests.Email;

namespace WebUI.Controllers;

public class EmailsController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(SendEmailRequest request)
    {
        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Rezervasyon Bilgileri", "aaltanaanay@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", request.Receiver);
        mimeMessage.To.Add(mailboxAddressTo);

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = request.Content;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = request.Subject;

        SmtpClient client = new SmtpClient();
        client.Connect("smtp.gmail.com", 587, false);
        client.Authenticate("aaltanaanay@gmail.com", "doyt hnlf fnyk lqqb");

        client.Send(mimeMessage);
        client.Disconnect(true);

        return RedirectToAction("Index", "Category");
    }

}