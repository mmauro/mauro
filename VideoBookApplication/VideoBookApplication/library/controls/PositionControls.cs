﻿using System;
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
    class PositionControls
    {

        private PositionDao positionDao = new PositionDao();

        public ApplicationErrorType write(string position)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (position != null && !position.Trim().Equals(""))
            {
                try
                {
                    if (read(position) == null)
                    {
                        PositionModel model = new PositionModel();
                        model.position = position.Trim().ToLower();
                        positionDao.write(model);
                    }
                    else
                    {
                        status = ApplicationErrorType.POSITION_PRESENT;
                    }
                }
                catch (VideoBookException e)
                {
                    status = e.errorType;
                }
            }
            else
            {
                status = ApplicationErrorType.EMPTY_POSITION;
            }

            return status;
        }

        public PositionModel read(string position)
        {
            if (position != null && !position.Trim().Equals(""))
            {
                try
                {
                    PositionModel model = positionDao.readOne(position.Trim().ToLower());
                    return model;
                }
                catch (VideoBookException e)
                {
                    throw e;
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.EMPTY_POSITION);
            }
        }

        public PositionModel read(int position)
        {
            if (position != Configurator.getInstsance().getInt("notfound.value"))
            {
                try
                {
                    PositionModel model = positionDao.readOne(position);
                    return model;
                }
                catch (VideoBookException e)
                {
                    throw e;
                }
            }
            else
            {
                throw new VideoBookException(ApplicationErrorType.EMPTY_POSITION);
            }
        }

        public List<PositionModel> getAllPosition(bool keepDefaultValue)
        {
            try
            {
                List<PositionModel> arrayPosition = null;
                arrayPosition = (List<PositionModel>)positionDao.readAll();

                if (arrayPosition != null && arrayPosition.Count > 0 && !keepDefaultValue)
                {
                    List<PositionModel> tmpListCat = arrayPosition.ToList();
                    arrayPosition.Clear();
                    foreach (PositionModel model in tmpListCat)
                    {
                        if (!model.position.Equals(Configurator.getInstsance().get("catpos.default.value")))
                        {
                            arrayPosition.Add(model);
                        }
                    }
                }

                return arrayPosition;
            }
            catch (VideoBookException e)
            {
                throw e;
            }
        }

        public ApplicationErrorType updatePosition(PositionModel oldCat, string newPosValue)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (oldCat != null)
            {
                if (newPosValue != null && !newPosValue.Trim().Equals(""))
                {
                    try
                    {
                        if (!newPosValue.Trim().ToLower().Equals(oldCat.position))
                        {
                            PositionModel testModel = positionDao.readOne(newPosValue.Trim().ToLower());
                            if (testModel != null)
                            {
                                status = ApplicationErrorType.POSITION_PRESENT;
                            }
                        }
                        else
                        {
                            status = ApplicationErrorType.POSITION_EQUALS_VALUE;
                        }
                    }
                    catch (VideoBookException e)
                    {
                        status = e.errorType;
                    }

                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        //Posso salvare la categoria
                        oldCat.position = newPosValue.Trim().ToLower();
                        try
                        {
                            positionDao.update(oldCat);
                        }
                        catch (VideoBookException e)
                        {
                            status = e.errorType;
                        }
                    }
                }
                else
                {
                    status = ApplicationErrorType.EMPTY_POSITION;
                }
            }
            else
            {
                status = ApplicationErrorType.POSITION_NOT_FOUND;
            }




            return status;
        }
    }


}
