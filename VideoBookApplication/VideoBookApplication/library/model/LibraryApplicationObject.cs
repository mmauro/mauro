﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.model;

namespace VideoBookApplication.library.model
{
    public class LibraryApplicationObject : IApplicationObject
    {
        public InputLibraryApplicationObject libraryInput{get; set;}

        public TempLibraryModel tempModel { get; set; }

        private string mauro;

        public LibraryApplicationObject()
        {
            libraryInput = new InputLibraryApplicationObject();
            tempModel = new TempLibraryModel();
        }

        public void destroy()
        {
            libraryInput.destroy();
            libraryInput = new InputLibraryApplicationObject();

            tempModel.destroy();
            tempModel = new TempLibraryModel();
        }
    }
}