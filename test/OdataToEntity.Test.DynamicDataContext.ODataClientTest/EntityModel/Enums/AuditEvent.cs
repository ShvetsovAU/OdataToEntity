using System.ComponentModel;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.EntityModel.Enums
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