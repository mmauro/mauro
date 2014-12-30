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
            Dictionary<AuthorModel, int> dictionaryList = new Dictionary<AuthorModel, int>();

            foreach (AuthorModel model in listElement)
            {
                int value = 1;
                if (dictionaryList.ContainsKey(model))
                {
                    value += dictionaryList[model];
                }
                dictionaryList.Add(model, value);
            }

            if (dictionaryList.Count > 0)
            {
                foreach (KeyValuePair<AuthorModel, int> kvp in dictionaryList)
                {
                    if (kvp.Value >= numMinElement)
                    {
                        filterList.Add(kvp.Key);
                    }
                }
            }

            return filterList;
        }

        public List<AuthorModel> filterOr (List<AuthorModel> listElement) {
            List<AuthorModel> filterList = new List<AuthorModel>();

            foreach (AuthorModel model in listElement)
            {
                if (!filterList.Contains(model))
                {
                    filterList.Add(model);
                }
            }

            return filterList;
        }
    }
}
