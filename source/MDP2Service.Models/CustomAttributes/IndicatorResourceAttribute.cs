using System;

namespace ASE.MD.MDP2.Product.MDP2Service.Models.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class IndicatorRecourseAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        string mResourceName;

        // This is a positional argument
        public IndicatorRecourseAttribute(string resourceName)
        {
            mResourceName = resourceName;
        }

        public string ResourceName
        {
            get { return mResourceName; }
            private set { mResourceName = value; }
        }
    }
}