using System.Collections.Generic;

namespace GPS.SimpleMVC.Adapters
{
    public interface ISearchCriteria<out T> where T : class
    {
        SearchCriteriaTypes CriteriaType { get; set; }
        List<object> CriteriaValues { get; set; }
    }
}