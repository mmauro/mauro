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
    public class FilterAuthor
    {
        private FilterType type;

        public FilterAuthor(FilterType type)
        {
            this.type = type;
        }

        public List<AuthorModel> filter (List<AuthorModel> listElement, int numMinElement) {
            switch (type) {
                case FilterType.FILTER_AND:
                    return filterAnd(listElement, numMinElement);
                case FilterType.FILTER_OR:
                    return filterOr(listElement);
                default:
                    throw new VideoBookException(ApplicationErrorType.INVALID_TYPE);
            }
        }

        public List<AuthorModel> filterAnd (List<AuthorModel> listElement, int numMinElement) {
            List<AuthorModel> filterList = new List<AuthorModel>();
            Dictionary<Int32, FilterAuthorCustomObject> dictionaryList = new Dictionary<int, FilterAuthorCustomObject>();

            foreach (AuthorModel model in listElement)
            {
                int hashCode = model.GetHashCode();
                if (dictionaryList.ContainsKey(hashCode))
                {
                    dictionaryList[hashCode].increment();
                }
                else
                {
                    dictionaryList.Add(hashCode, new FilterAuthorCustomObject(model));
                }
            }

            if (dictionaryList.Count > 0)
            {
                foreach (KeyValuePair<Int32, FilterAuthorCustomObject> kvp in dictionaryList)
                {
                    if (kvp.Value.value >= numMinElement)
                    {
                        filterList.Add(kvp.Value.model);
                    }
                }
            }

            return filterList;
        }

        public List<AuthorModel> filterOr (List<AuthorModel> listElement) {
            List<AuthorModel> filterList = new List<AuthorModel>();
            List<int> dictionaryList = new List<int>();

            foreach (AuthorModel model in listElement)
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
