using Classwork.Models;
using Classwork.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Services
{
   public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
