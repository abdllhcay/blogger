namespace Blogger.Core.Helpers.Filtering
{
    public class FilterParameter : IFilterParameter
    {
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Date { get; set; }

        public FilterParameter()
        {
            Title = "";
            StartDate = "";
            EndDate = "";
            Date = "";
        }
    }
}
