﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.library.model.database
{
    public class BookInfoModel
    {
        public int idInfoLibro { get; set; }
        public string image { get; set; }
        public string publisher { get; set; }
        public string isbn { get; set; }
        public string trama { get; set; }
        public string year { get; set; }
        public string urlScheda { get; set; }
        public string titleOrig { get; set; }       //Questo non deve essere scritto su db;

        public bool isValid()
        {
            if (idInfoLibro > 0)
            {
                return true;
            }
            else
            {
                return ((trama != null && trama.Length > 0) || (image != null && image.Length > 0) || (publisher != null && publisher.Length > 0) || (isbn != null && isbn.Length > 0) || (year != null && year.Length > 0));
            }
        }

    }
}
