using System.ComponentModel;

namespace DogGo.Models.ViewModels
{
    public class DeleteWalksViewModel
    {
        public List<Walk> Walks { get; set; }

        [DisplayName("Walks")]
        public List<int> SelectedWalkIds { get; set; }
    }
}
