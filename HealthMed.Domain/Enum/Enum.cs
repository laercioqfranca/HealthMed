namespace HealthMed.Domain.Enum
{
    public enum EnumTipoLog : short
    {
        LOGIN = 1,
        UPDATE,
        CREATE,
        DELETE
    }

    public enum EnumTipoPerfil : int
    {
        Medico = 1,
        Paciente = 2
    }

}