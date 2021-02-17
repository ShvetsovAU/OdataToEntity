using System.ComponentModel;

namespace ASE.MD.MDP2.Product.MDP2Service.Localization
{
    public class LocalizedDescription : DescriptionAttribute
    {
        private static string Localize(string key)
        {
#warning Поправить или переделать!
            
            //TODO: пока не понятно, как будет осуществляться локализация
            //var value = Telerik.Windows.Controls.LocalizationManager.GetString(key);
            string value = null;
            return string.IsNullOrEmpty(value) ? key : value;
        }

        public LocalizedDescription(string key)
            : base(Localize(key))
        { }
    }
}
