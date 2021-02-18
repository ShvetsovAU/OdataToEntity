using System.ComponentModel.DataAnnotations;
using ASE.MD.Platform.Utils.ModelsBase.Interfaces;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction
{
    /// <summary>
    /// Конфигурация сервиса
    /// </summary>
    public interface IRuntimeConfiguration : IConfigValidate
    {
        #region cache

        /// <summary>
        /// Тип кэширования данных
        /// </summary>
        string CacheType { get; set; }

        /// <summary>
        /// Адрес подключения к Redis
        /// </summary>
        string DistributedCacheConnectionString { get; set; }

        #endregion cache

        #region data base

        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        [Required(ErrorMessage = "ConnectionString: Необходимо указать подключение к серверу БД")]
        string DbConnectionString { get; set; }

        /// <summary>
        /// Таймаут подключения к БД
        /// </summary>
        int? DbDefaultConnectionTimeout { get; set; }

        #endregion data base
    }
}
