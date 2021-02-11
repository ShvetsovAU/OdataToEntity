using dbReverse.EntityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Csdl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace OdataToEntity.Test.DynamicDataContext.ODataClientTest.Controllers
{
    [Controller]
    public class TestController : ControllerBase
    {
        //[HttpPost("GetByOData")]
        [HttpPost("GetByOData")]
        public void GetByOData()
        {

            var oDataContext = new DataServiceContext(new Uri("http://localhost:5000/api"));//"https://localhost:5001"));
            oDataContext.Format.UseJson(); //TODO: это и по дефолту видимо так
            oDataContext.Format.LoadServiceModel = () => GetServiceModel(oDataContext.GetMetadataUri());
            var dataSet = oDataContext.CreateQuery<Project>("Projects");
            //var exists = dataSet.Any();
            //var res = dataSet.Where(i => i.ObjectId == 1).ToList();
            //var res2 = ((DataServiceQuery<Project>)dataSet.Include(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ToList();
            //var res3 = dataSet.Where(i => i.ObjectId == 308398).Include(f => f.CodeForBudgetNumber).ToList();
            var res3 = dataSet.Where(i => i.ObjectId == 308398).ToList();
            var res4 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).Execute();

            //var res5 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ExecuteAsync();

            //var res5 = ((DataServiceQuery<Project>)dataSet.Expand(f => f.CodeForBudgetNumber).Where(i => i.ObjectId == 308398)).ToList();
            //var proj2 = dataSet.Include(f => f.CodeForBudgetNumber).ToList();
            var count = dataSet.Count();
            var first = dataSet.First();
            var firstOrDefault = dataSet.FirstOrDefault();

            var where = dataSet.Where(i => i.ObjectId > 30000 && i.Name.Contains("UK")).ToList();
            var min = dataSet.Min(i => i.ObjectId);
            var max = dataSet.Max(i => i.ObjectId);


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
