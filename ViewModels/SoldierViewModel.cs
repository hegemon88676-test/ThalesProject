using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SoldierMovementTracking.Models;
using SoldierMovementTracking.Services;

namespace SoldierMovementTracking.ViewModels
{
    public class SoldierViewModel
    {
        private readonly ISoldierService _soldierService;

        public ObservableCollection<Soldier> Soldiers { get; set; }

        public SoldierViewModel(ISoldierService soldierService)
        {
            _soldierService = soldierService;
            Soldiers = new ObservableCollection<Soldier>();
        }

        public async Task LoadSoldiersAsync()
        {
            var soldiers = await _soldierService.GetAllSoldiersAsync();
            Soldiers.Clear();
            foreach (var soldier in soldiers)
            {
                Soldiers.Add(soldier);
            }
        }
    }
}
