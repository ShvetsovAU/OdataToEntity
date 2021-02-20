using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.CustomAttributes
{
    /// <summary>
    /// Расширенная аннотация <seealso cref="ColumnAttribute"/>. Позволяет выставлять дополнительные св-ва для Column
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    [Serializable]
    public class ExtendedColumnAttribute : ColumnAttribute, ISerializable
    {
        #region .ctor
        public ExtendedColumnAttribute() { }
        #endregion

        //Дефолтные значения нужны, т.к. не сделать обнуляемыми
        /// <summary>
        /// Является ли колонка ROWGUIDCOL, применимо только для Guid (UNIQUEIDENTIFIER)
        /// </summary>
        public bool IsRowGuid;

        /// <summary>
        /// Identity seed
        /// </summary>
        public Int64 Seed = 1;

        /// <summary>
        /// Identity increment
        /// </summary>
        public Int64 Increment = 1;


        #region Serialization
        //Кастомная сериализация иначе сериализатор захватывает базовый класс
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsRowGuid", IsRowGuid, typeof(bool));
            info.AddValue("Seed", Seed, typeof(long));
            info.AddValue("Increment", Increment, typeof(long));

        }

        public ExtendedColumnAttribute(SerializationInfo info, StreamingContext context)
        {
            IsRowGuid = (bool)info.GetValue("IsRowGuid", IsRowGuid.GetType());
            Seed = (long)info.GetValue("Seed", Seed.GetType());
            Increment = (long)info.GetValue("Increment", Increment.GetType());
        }

        public override string ToString()
        {
            return $"IsRowGuid:{IsRowGuid},Seed:{Seed},Increment:{Increment}";
        }

        #endregion
    }
}
