
using System.ComponentModel;
namespace FasterTvIndoor.Domain.FasterAdministration.Enum
{
    public enum EStatusEquipment
    {
        [Description("Disponível")]
        Disponível = 1,
        Emprestado = 2,
        Manutenção = 3,
        Desabilitado = 4
    }
}
