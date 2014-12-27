using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.dao;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;

namespace VideoBookApplication.common.operations
{
    class Indexer
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IndexerType indexerType;
        public string value { get; private set; }

        public List<String> words { get; private set; }

        public ApplicationErrorType status { get; private set; }

        private List<String> reserved = new List<string>();
        private ReservedControl controls = new ReservedControl();
        private Stemmer stemmer;

        public Indexer(string value, IndexerType indexerType)
        {
            status = ApplicationErrorType.SUCCESS;
            this.indexerType = indexerType;
            this.value = value;

            words = new List<string>();

            if (this.indexerType.reserved != null)
            {
                try
                {
                    reserved = controls.readReserved(this.indexerType.reserved);
                    log.Info("Reserved Load: " + reserved.Count);
                }
                catch (VideoBookException e)
                {
                    status = ApplicationErrorType.LOAD_RESERVED_ERROR;
                }
            }

            if (status == ApplicationErrorType.SUCCESS && this.indexerType.useStemmer)
            {
                stemmer = new Stemmer();
                status = stemmer.status;
            }

        }



    }
}
