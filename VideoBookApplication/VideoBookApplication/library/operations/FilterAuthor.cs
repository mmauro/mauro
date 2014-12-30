using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.operations;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.operations
{
    public class FilterAuthor
    {

        private FilterType type;

        public FilterAuthor(FilterType type)
        {
            this.type = type;
        }

        public IEnumerable<AuthorModel> filter(IEnumerable<AuthorModel> inputValue, int maxValueFilter)
        {
            switch (type)
            {
                case FilterType.FILTER_AND:
                    return filterAnd(inputValue, maxValueFilter);
                case FilterType.FILTER_OR:
                    return filterOr(inputValue);
                default:
                    throw new VideoBookException(ApplicationErrorType.INVALID_TYPE);
            }
        }

        public IEnumerable<AuthorModel> filterOr(IEnumerable<AuthorModel> inputValue)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorModel> filterAnd(IEnumerable<AuthorModel> inputValue, int maxValueFilter)
        {
            throw new NotImplementedException();
        }
    }
}
