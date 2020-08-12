using Blogger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Blogger.Core.Helpers.Filtering
{
    public class FilterBuilder
    {
        private IFilterParameter filterParameter;
        public FilterBuilder() : this(new FilterParameter()) { }
        public FilterBuilder(IFilterParameter _filterParameter)
        {
            filterParameter = _filterParameter;
        }

        public FilterBuilder SetName(string name)
        {
            filterParameter.Title = name;
            return this;
        }

        public FilterBuilder SetStartDate(string startDate)
        {
            filterParameter.StartDate = startDate;
            return this;
        }

        public FilterBuilder SetEndDate(string endDate)
        {
            filterParameter.EndDate = endDate;
            return this;
        }

        public FilterBuilder SetDate(string date)
        {
            filterParameter.Date = date;
            return this;
        }

        public IEnumerable<Post> Build(IEnumerable<Post> posts)
        {
            List<Post> filteredPosts = posts.ToList();

            if (!string.IsNullOrEmpty(filterParameter.Title))
            {
                filteredPosts = filteredPosts.Where(e => e.Title.ToLower().Contains(filterParameter.Title.Trim().ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(filterParameter.StartDate))
            {
                var date = DateTime.ParseExact(filterParameter.StartDate, "MMddyyyy", CultureInfo.InvariantCulture);
                filteredPosts = filteredPosts.Where(e => e.PublishDate.Date >= date).ToList();
            }

            if (!string.IsNullOrEmpty(filterParameter.EndDate))
            {
                var date = DateTime.ParseExact(filterParameter.EndDate, "MMddyyyy", CultureInfo.InvariantCulture);
                filteredPosts = filteredPosts.Where(e => e.PublishDate.Date <= date).ToList();
            }

            if (!string.IsNullOrEmpty(filterParameter.Date))
            {
                var date = DateTime.ParseExact(filterParameter.Date, "MMddyyyy", CultureInfo.InvariantCulture);
                filteredPosts = filteredPosts.Where(e => e.PublishDate.Date == date).ToList();
            }

            return filteredPosts;
        }
    }
}
