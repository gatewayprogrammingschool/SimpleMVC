using System.Collections.Generic;

namespace GPS.SimpleMVC.Models
{
    public interface ISearchNode<out T> where T : class
    {
        SearchConnectors SearchConnector { get; set; }
        ISearchCriteria<object> SearchCriteria { get; set; }
        List<ISearchNode<object>> SearchNodes { get; set; }
    }
}