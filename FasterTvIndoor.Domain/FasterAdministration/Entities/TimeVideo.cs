using FasterTvIndoor.Domain.FasterAdministration.Commands.TimeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class TimeVideo
    {
        public TimeVideo() { }
        public TimeVideo(int time)
        {
            this.Time = time;
        }
        public int IdTimeVideo { get; set; }
        public int Time { get; set; }
        public ICollection<Video> ListVideo { get; set; }

        public void Create(){
            if (!this.CreateTimeVideoScopeIsValid())
                return;
        }

        public void Update(UpdateTimeVideoCommand command)
        {
            if (!this.UpdateTimeVideoScopeIsValid(command))
                return;

            this.Time = command.Time;
        }

    }
}
