using FasterTvIndoor.Domain.FasterAdministration.Commands.TypeVideoCoomands;
using FasterTvIndoor.Domain.FasterAdministration.Scopes;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class TypeVideo
    {
        public TypeVideo(){}
        public TypeVideo(string type)
        {
            this.Type = type;
        }
        public int IdTypeVideo { get; private set; }    
        public string Type { get; private set; }
        public ICollection<Video> ListVideo { get; set; }

        public void Create()
        {
            if (!this.CreateTypeVideoScopeIsValid())
                return;
        }

        public void Update(UpdateTypeVideoCommand command)
        {
            if (!this.UpdateTypeVideoScopeIsValid(command))
                return;

            this.Type = command.Type;
        }
    }
}
