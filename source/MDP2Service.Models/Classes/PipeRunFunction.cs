using System.Collections.Generic;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.Classes
{
    public class PipeRunFunction
    {
        public string KeyAttribute { get; set; }
        public string P3dbAttribute { get; set; }

        public List<string> CorrectValues { get; set; }

        public string Description { get { return "PipeRun"; } }

        public PipeRunFunction()
        {
            CorrectValues = new List<string>();
        }

        public PipeRunFunction(string attribute, List<string> values)
        {
            P3dbAttribute = attribute;
            CorrectValues = values;
        }
    }
}
