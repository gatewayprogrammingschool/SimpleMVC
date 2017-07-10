using System.Collections.Generic;

namespace GPS.SimpleMVC.Adapters
{
    public class SearchCriteria<T> : ISearchCriteria<T> where T : class
    {
        public SearchCriteriaTypes CriteriaType { get; set; }
        public List<object> CriteriaValues { get; set; }
    }
}