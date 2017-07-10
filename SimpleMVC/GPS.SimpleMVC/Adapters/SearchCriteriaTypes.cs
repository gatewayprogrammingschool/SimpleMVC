namespace GPS.SimpleMVC.Adapters
{
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
}