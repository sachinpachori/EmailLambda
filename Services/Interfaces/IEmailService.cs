using System;
using System.Threading.Tasks;

namespace Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail();
    }
}
