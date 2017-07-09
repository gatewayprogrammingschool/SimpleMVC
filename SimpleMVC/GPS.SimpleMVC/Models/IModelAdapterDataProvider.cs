using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleMVC.Models
{
    public interface IModelAdapterDataProvider<T> where T: ModelBase
    {
        Task<T> LoadModel(Guid uid);
        Task<T> LoadModel(int id);
        Task<T> LoadModel(long id);

        Task<List<T>> LoadModels(SearchBy<T> root);
        Task<long> SaveModels(List<T> models);
        Task<bool> DeleteModel(T model);
    }

    public delegate List<T> SearchBy<T>(SearchNode<object> root);

    public enum SearchCriteriaTypes
    {
        IsEquals,
        IsNotEquals,
        IsNull,
        IsNotNull,
        IsLessThan,
        IsGreaterThan,
        IsNotLessThan,
        IsNotGreaterThan,
        IsEqualOrLessThan,
        IsEqualOrIsGreaterThan,
        IsEqualOrIsNotLessThan,
        IsEqualOrIsNotGreaterThan,
        Contains,
        NotContains,
        StartsWith,
        NotStartsWith,
        EndsWith,
        NotEndsWith,
        PatternMatch,
        NotPatternMatch,
    }

    public enum SearchConnectors
    {
        And,
        Or,
    }

    public interface ISearchCriteria<out T> where T: class
    {
        SearchCriteriaTypes CriteriaType { get; set; }
        List<object> CriteriaValues { get; set; }
    }

    public class SearchCriteria<T> : ISearchCriteria<T> where T : class
    {
        public SearchCriteriaTypes CriteriaType { get; set; }
        public List<object> CriteriaValues { get; set; }
    }

    public class SearchNode<T> : ISearchNode<T> where T : class
    {
        public SearchConnectors SearchConnector { get; set; }
        public ISearchCriteria<object> SearchCriteria { get; set; }
        public List<ISearchNode<object>> SearchNodes { get; set; }
    }
}
