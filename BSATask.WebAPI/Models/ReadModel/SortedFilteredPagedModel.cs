using CollectionsAndLinq.BL.Models.Projects;

namespace BSATask.WebAPI.Models.ReadModel
{
    public class SortedFilteredPagedModel
    {
        public PageModel? PageModel { get; set; }
        public FilterModel? FilterModel { get; set; } 
        public SortingModel? SortingModel { get; set; } 
    }
}
