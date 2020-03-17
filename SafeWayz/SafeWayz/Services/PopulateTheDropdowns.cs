using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SafeWayz
{
    public class PopulateThePickers
    {
        public ObservableCollection<string> GetTheAreasAndAddToList(ObservableCollection<string> listToPopulate)
        {
            string[] areasArray;
            areasArray = new string[7] { "Eerste River", "KuilsRiver", "Mitchells Plain", "Hanover Park", "SilverSands", "Blue Downs", "Conifers" };
            listToPopulate = new ObservableCollection<string>();

            for (int i = 0; i < areasArray.Length; i++)
            {
                listToPopulate.Add(areasArray[i]);
            }

            return listToPopulate;
        }

        public ObservableCollection<string> GetTheIncidentsAndAddToList(ObservableCollection<string> listToPopulate)
        {
            string[] incidentsArray;
            incidentsArray = new string[7] { "Stabbing", "Shooting", "Kidnapping", "Drug Dealing", "Robbery", "Gun Fight", "Sketchy Noises" };
            listToPopulate = new ObservableCollection<string>();

            for (int i = 0; i < incidentsArray.Length; i++)
            {
                listToPopulate.Add(incidentsArray[i]);
            }

            return listToPopulate;
        }
    }
}
