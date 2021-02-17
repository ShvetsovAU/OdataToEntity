using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Enums
{
    public enum AuditEvent : byte
    {
        [Description("Вход в систему")]
        Login = 1,

        [Description("Выход из системы")]
        Logout = 2,

        [Description("Синхронизация")]
        Synchronization = 3
    }
}