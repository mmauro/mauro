using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.operations;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.model;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.operations
{
    public class FilterBook
    {
        private FilterType type;

        public FilterBook(FilterType type)
        {
            this.type = type;
        }

        public List<BookModel> filter (List<BookModel> listElement, int numMinElement) {
            switch (type) {
                case FilterType.FILTER_AND:
                    return filterAnd(listElement, numMinElement);
                case FilterType.FILTER_OR:
                    return filterOr(listElement);
                default:
                    throw new VideoBookException(ApplicationErrorType.INVALID_VALUE);
            }
        }

        public List<BookModel> filterAnd (List<BookModel> listElement, int numMinElement) {
            List<BookModel> filterList = new List<BookModel>();
            Dictionary<Int32, FilterBookCustomObject> dictionaryList = new Dictionary<int, FilterBookCustomObject>();

            foreach (BookModel model in listElement)
            {
                int hashCode = model.GetHashCode();
                if (dictionaryList.ContainsKey(hashCode))
                {
                    dictionaryList[hashCode].increment();
                }
                else
                {
                    dictionaryList.Add(hashCode, new FilterBookCustomObject(model));
                }
            }

            if (dictionaryList.Count > 0)
            {
                foreach (KeyValuePair<Int32, FilterBookCustomObject> kvp in dictionaryList)
                {
                    if (kvp.Value.value >= numMinElement)
                    {
                        filterList.Add(kvp.Value.model);
                    }
                }
            }

            return filterList;
        }

        public List<BookModel> filterOr (List<BookModel> listElement) {
            List<BookModel> filterList = new List<BookModel>();
            List<int> dictionaryList = new List<int>();

            foreach (BookModel model in listElement)
            {
                int hashCode = model.GetHashCode();
                if (!dictionaryList.Contains(hashCode)) {
                    filterList.Add(model);
                    dictionaryList.Add(hashCode);
                }
            }

            return filterList;
        }
    }
}
