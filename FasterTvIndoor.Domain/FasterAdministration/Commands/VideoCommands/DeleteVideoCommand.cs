using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FasterTvIndoor.Domain.FasterAdministration.Commands.VideoCommands
{
    public class DeleteVideoCommand
    {
        public DeleteVideoCommand(int idVideo)
        {
            this.IdVideo = idVideo;
        }
        public int IdVideo { get; private set; }
    }
}
