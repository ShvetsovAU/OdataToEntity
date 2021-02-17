using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASE.MD.MDP2.Product.MDP2Service.Infrastructure.Abstraction
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        //TODO: пока не будем светить контекст
        //DbContext Context { get; }

        /// <summary>
        /// Созвращает IQueryable всех сущностей, соотвествующих репозиторию
        /// </summary>
        IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        void ExecuteSql(string sqlCommand, params object[] parameters);

        /// <summary>
        /// Проверить существование сущности в БД
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Проверить существование сущности в БД асинхронно
        /// </summary>
        /// <param name="condition">Условие поиска</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// Поиск данных по условию
        /// </summary>
        /// <param name="condition">Условие отбора сущностей</param>
        /// <param name="take">Число элементов, которое необходимо выбрать</param>
        /// <param name="skip">Число элементов, которое необходимо пропустить перед выборкой</param>
        /// <param name="includes">Список полей, которые нужно "подгрузить" в выбираемых сущностях</param>
        /// <returns></returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> condition, int? take = null, int skip = 0, string[] includes = null);

        /// <summary>
        /// Поиск данных по условию в асинхронном режиме
        /// </summary>
        /// <param name="condition">Условие отбора сущностей</param>
        /// <param name="take">Число элементов, которое необходимо выбрать</param>
        /// <param name="skip">Число элементов, которое необходимо пропустить перед выборкой</param>
        /// <param name="includes">Список полей, которые нужно "подгрузить" в выбираемых сущностях</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> condition, int? take = null, int skip = 0, string[] includes = null);

        /// <summary>
        /// Сохранение существующих изменений контекста в БД
        /// </summary>
        void Flush();

        /// <summary>
        /// Сохранение существующих изменений контекста в БД асинхронно
        /// </summary>
        Task FlushAsync();

        /// <summary>
        /// Получение сущности по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// Вставка сущности в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// Вставка списка сущностей в БД
        /// </summary>
        /// <param name="entities">Список сущностей</param>
        void BulkInsert(TEntity[] entities);

        /// <summary>
        /// Обновление сущности в БД
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="updateAction">Функция модификации данных</param>
        /// <returns></returns>
        TEntity Update(int id, Action<TEntity> updateAction);

        /// <summary>
        /// Обновление сущности в БД
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Update(TEntity entity);

        ///// <summary>
        ///// Добавить/обновить сущность в БД
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //TEntity InsertOrUpdate(TEntity entity);

        ///// <summary>
        ///// Добавить/обновить сущности в БД
        ///// </summary>
        ///// <returns></returns>
        //IEnumerable<TEntity> InsertOrUpdateList(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удаляет сущность из базы данных
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Удаляет сущности из базы данных
        /// </summary>
        /// <param name="entity"></param>
        void Remove(IEnumerable<TEntity> entity);

        /// <summary>
        /// Удаляет сущность из базы данных по идентификатору
        /// </summary>
        void RemoveById(object id);

        /// <summary>
        /// Удаление всех данных
        /// </summary>
        void RemoveAll();
    }
}