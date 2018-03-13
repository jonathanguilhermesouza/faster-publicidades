using FasterTvIndoor.Domain.FasterAdministration.Commands.YearCommands;
using System.Collections.Generic;

namespace FasterTvIndoor.Domain.FasterAdministration.Entities
{
    public class Year
    {
        public Year(){}
        public Year(int number)
        {
            this.Number = number;
        }        
        public int IdYear { get; set; }
        public int Number { get; set; }
        public void Create()
        {

        }
        public void Update(UpdateYearCommand command)
        {

        }
    }
}
