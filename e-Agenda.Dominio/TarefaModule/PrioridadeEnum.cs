using System.ComponentModel;

namespace eAgenda.Dominio.TarefaModule
{
    public enum PrioridadeEnum : int
    {
        [Description("Baixa")]
        Baixa = 0,

        [Description("Normal")]
        Normal = 1,

        [Description("Alta")]
        Alta = 2,            
    }
}