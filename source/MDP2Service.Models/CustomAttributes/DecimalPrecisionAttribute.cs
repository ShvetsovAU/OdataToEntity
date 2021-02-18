using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes
{
    /// <summary>
    /// Вывставляем пресижн для децимала
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalPrecisionAttribute : Attribute
    {
        public DecimalPrecisionAttribute(byte precision, byte scale)
        {
            Precision = precision;
            Scale = scale;
        }
        
        public byte Precision { get; set; }
        
        public byte Scale { get; set; }
    }

    ////TODO: Конвенции в EF.Core пока то ли не доделаны, то ли стали иначе использоваться...в общем с EF 6.x не дружат...
    ////https://github.com/dotnet/efcore/issues/214
    //public class DecimalPrecisionAttributeConvention
    //    : PrimitivePropertyAttributeConfigurationConvention<DecimalPrecisionAttribute>
    //{
    //    public override void Apply(ConventionPrimitivePropertyConfiguration configuration,
    //        DecimalPrecisionAttribute attribute)
    //    {
    //        if (attribute.Precision < 1 || attribute.Precision > 38)
    //        {
    //            throw new InvalidOperationException("Precision must be between 1 and 38.");
    //        }

    //        if (attribute.Scale < 0 || attribute.Scale > attribute.Precision)
    //        {
    //            throw new InvalidOperationException("Scale must be between 0 and the Precision value.");
    //        }

    //        configuration.HasPrecision(attribute.Precision, attribute.Scale);
    //    }
    // }
}