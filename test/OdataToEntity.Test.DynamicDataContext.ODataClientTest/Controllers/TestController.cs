using dbReverse.EntityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Csdl;
using System;
using System.Linq;
using System.Net;
using System.Xml;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Controllers
{
    [ApiController]
    [Route("api/Test")]
    public class TestController : ControllerBase
    {
        [HttpPost("GetByOData")]
        public void GetByOData()
        {
            var dataServerUrl = "http://localhost:5005/api";
            var oDataContext = new DataServiceContext(new Uri(dataServerUrl));
            
            //oDataContext.Format.UseJson(); //TODO: это и по дефолту видимо так
            //oDataContext.Format.LoadServiceModel = () => GetServiceModel(oDataContext.GetMetadataUri());
            
            var dataSet = oDataContext.CreateQuery<Project>("Projects");
            //var exists = dataSet.Any();
            //var res = dataSet.Where(i => i.ObjectId == 1).ToList();
            //var res2 = ((DataServiceQuery<Project>)dataSet.Include(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ToList();
            //var res3 = dataSet.Where(i => i.ObjectId == 308398).Include(f => f.CodeForBudgetNumber).ToList();
            
            //TODO: нормально, без Nv prop
            var res3 = dataSet.Where(i => i.ObjectId == 308398).ToList();

            //TODO: нормально, Nv prop не проставляется!
            //var res6 = dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398).ToList(); //TODO: так не работает The expression 'f => f.CodeForBudgetNumber' is not a valid expression for navigation path. The only supported operations inside the lambda expression body are MemberAccess and TypeAs. The expression must contain at least one MemberAccess and it cannot end with TypeAs.
            var res6 = dataSet.Expand("CodeForBudgetNumber").Where(i => i.ObjectId == 308398).ToList();
            
            
            var res8 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).Execute();

            //TODO: working
            var res5 = dataSet.Expand("CodeForBudgetNumber").Where(i => i.ObjectId == 308398).ToList();
            //TODO: not working, error https://github.com/OData/odata.net/issues/1247. Зависит от способа описания класса модели
            //var res6 = dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398);
            //TODO: working
            var res7 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).Execute();
            //TODO: not working
            var res4 = ((DataServiceQuery<Project>)dataSet.Expand("CodeForBudgetNumber").Where(i => i.ObjectId == 308398)).Execute();
                        

            //var res5 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ExecuteAsync();

            //var res5 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ToList();
            //var proj2 = dataSet.Include(f => f.CodeForBudgetNumber).ToList();

            //TODO: нормально
            var count = dataSet.Count();

            //TODO: нормально
            var first = dataSet.First();

            //TODO: нормально
            var firstOrDefault = dataSet.FirstOrDefault();

            //TODO: нормально
            var where = dataSet.Where(i => i.ObjectId > 30000 && i.Name.Contains("UK")).ToList();
            
            //var min = dataSet.Min(i => i.ObjectId);
            var minByOrder = dataSet.OrderBy(i => i.ObjectId).Take(1);
            var minByOrder2 = ((DataServiceQuery<Project>)dataSet.OrderBy(i => i.ObjectId)).Take(1);


            //var max = dataSet.Max(i => i.ObjectId);
            var maxByOrder = dataSet.OrderByDescending(i => i.ObjectId).Take(1);
            var maxByOrder2 = ((DataServiceQuery<Project>)dataSet.OrderByDescending(i => i.ObjectId)).Take(1);

            int j = 0;

            #region not supported

            //var all = dataSet.All(i => i.ObjectId > 5); //TODO: Не поддерживается
            //var last = dataSet.Last(); //TODO: Не поддерживается
            //var lastOrDefault = dataSet.LastOrDefault();//TODO: Не поддерживается
            //var contains = dataSet.Contains(first); //TODO: Не поддерживается
            //var any = dataSet.Any(i => i.ObjectId == 308398); //TODO:Не поддерживается

            #endregion not supported
        }

        private IEdmModel GetServiceModel(Uri metadataUri)
        {
            var request = WebRequest.CreateHttp(metadataUri);

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = XmlReader.Create(stream))
            {
                return CsdlReader.Parse(reader);
            }
        }
    }
}
