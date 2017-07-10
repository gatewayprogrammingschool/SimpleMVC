using System.Collections.Generic;

namespace GPS.SimpleMVC.Adapters
{
    public class SearchNode<T> : ISearchNode<T> where T : class
    {
        public SearchConnectors SearchConnector { get; set; }
        public ISearchCriteria<object> SearchCriteria { get; set; }
        public List<ISearchNode<object>> SearchNodes { get; set; }
    }
}