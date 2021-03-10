using GraphQL.Types;
using Microsoft.OData.Edm;
using System.Collections.Generic;

namespace OdataToEntity.GraphQL
{
    /// <summary>
    /// Создание схемы GraphQL
    /// </summary>
    public readonly struct OeSchemaBuilder
    {
        private readonly IEdmModel _edmModel;
        private readonly OeGraphTypeBuilder _graphTypeBuilder;

        public OeSchemaBuilder(IEdmModel edmModel)
        {
            _edmModel = edmModel;
            _graphTypeBuilder = new OeGraphTypeBuilder(edmModel);
        }

        /// <summary>
        /// Построение схемы GraphQL
        /// </summary>
        /// <returns></returns>
        public Schema Build()
        {
            return new Schema
            {
                //Запросы
                Query = CreateQuery(), 
                
                ////Мутации
                //Mutation = CreateMutation(),
                
                ////Подписки
                //Subscription = CreateSubscription()
            };
        }

        /// <summary>
        /// Создание полей GraphQL по edm модели данных.
        /// </summary>
        /// <param name="edmModel">edm модель</param>
        /// <param name="graphTypeBuilder"></param>
        /// <returns></returns>
        private static List<FieldType> CreateEntityFields(IEdmModel edmModel, OeGraphTypeBuilder graphTypeBuilder)
        {
            Db.OeDataAdapter dataAdapter = edmModel.GetDataAdapter(edmModel.EntityContainer);
            var entityFields = new List<FieldType>(dataAdapter.EntitySetAdapters.Count);
            foreach (Db.OeEntitySetAdapter entitySetAdapter in dataAdapter.EntitySetAdapters)
            {
                //Создание запроса (тип возвращаемого значения - список (List<>))
                FieldType entityField = new FieldType
                {
                    //Название поля
                    Name = entitySetAdapter.EntitySetName,
                    
                    //Описание запроса
                    Description = $"Returns a list of {entitySetAdapter.EntityType.Name}",
                    
                    //Resolver для обработки запроса
                    Resolver = new OeEntitySetResolver(edmModel),
                    
                    //Тип данных возвращаемых запросом
                    ResolvedType = graphTypeBuilder.CreateListGraphType(entitySetAdapter.EntityType)
                };

                entityFields.Add(entityField);
            }
            
            return entityFields;
        }

        ///// <summary>
        ///// Создание мутаций данных по EDM модели БД
        ///// </summary>
        ///// <returns></returns>
        //private ObjectGraphType CreateMutation()
        //{

        //}

        ///// <summary>
        ///// Создание подписок на изменение данных по EDM модели БД
        ///// </summary>
        ///// <returns></returns>
        //private ObjectGraphType CreateSubscription()
        //{

        //}

        /// <summary>
        /// Создание возможных вариантов запросов к данным по EDM модели БД
        /// </summary>
        /// <returns></returns>
        private ObjectGraphType CreateQuery()
        {
            var entityFields = new List<FieldType>(CreateEntityFields(_edmModel, _graphTypeBuilder));
            foreach (IEdmModel refModel in _edmModel.ReferencedModels)
                if (refModel.EntityContainer != null)
                    entityFields.AddRange(CreateEntityFields(refModel, _graphTypeBuilder));

            var query = new ObjectGraphType();
            foreach (FieldType entityField in entityFields)
            {
                _graphTypeBuilder.AddNavigationProperties(entityField);
                query.AddField(entityField);
            }
            
            return query;
        }
    }
}
