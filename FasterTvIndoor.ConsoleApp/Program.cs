using FasterTvIndoor.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            VideoEquipment video = new VideoEquipment();
            video.UpdateStatusVideoEquipment();
            SendEmail send = new SendEmail();
            send.SendEmailFromWebSite("webjob UpdateStatusVideo","Status da lista de vídeos atualizado as " +DateTime.Now,"jonathanguilhermesouza@gmail.com","9999999999","Jonathan");

        }
    }
}
