﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.dao;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.controls
{
    class CategoryControls
    {

        private CategoryDao categoryDao = new CategoryDao();

        public ApplicationErrorType write(string cat)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (cat != null && !cat.Trim().Equals(""))
            {
                try
                {
                    if (read(cat) == null)
                    {
                        CategoryModel model = new CategoryModel();
                        model.category = cat.Trim().ToLower();
                        categoryDao.write(model);
                    }
                    else
                    {
                        status = ApplicationErrorType.CATEGORY_PRESENT;
                    }
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_CATEGORY;
            }

            return status;
        }

        public CategoryModel read(string category)
        {
            if (category != null && category.Trim().Length > 0)
            {
                try
                {
                    CategoryModel model = categoryDao.readOne(category.Trim().ToLower());
                    return model;
                }
                catch (VideoBookException e)
                {
                    throw e;
                }

            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.EMPTY_CATEGORY);
            }
        }

        public List<CategoryModel> getAllCategory(bool keepDefaultValue)
        {
            try
            {
                List<CategoryModel> arrayCategory = null;
                arrayCategory = (List<CategoryModel>)categoryDao.readAll();

                if (arrayCategory != null && arrayCategory.Count >0 && !keepDefaultValue)
                {
                    List<CategoryModel> tmpListCat = arrayCategory.ToList();
                    arrayCategory.Clear();
                    foreach (CategoryModel model in tmpListCat)
                    {
                        if (!model.category.Equals(Configurator.getInstsance().get("catpos.default.value")))
                        {
                            arrayCategory.Add(model);
                        }
                    }
                }

                return arrayCategory;
            }
            catch (VideoBookException e)
            {
                throw e;
            }
        }

    }
}
