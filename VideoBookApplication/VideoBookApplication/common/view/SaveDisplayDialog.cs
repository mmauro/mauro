using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;

namespace VideoBookApplication.common.view
{
    public class SaveDisplayDialog
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GlobalApplicationObject globalObject;

        public DialogResult dialogResult { get; private set; }

        public SaveDisplayDialog(ref GlobalApplicationObject globalObject) {
            this.globalObject = globalObject;
            display();
        }

        private void display()
        {
            if (globalObject.reportObject != null && globalObject.reportObject.filter != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = this.globalObject.reportObject.filter.dialogFilter;
                saveFileDialog1.Title = getTitleByFilter();
                saveFileDialog1.Title = "Salva Report";
                dialogResult = saveFileDialog1.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    //Scelta del nome File
                    if (saveFileDialog1.FileName != null && !saveFileDialog1.FileName.Equals(""))
                    {
                        log.Info("filename Selezionato = " + saveFileDialog1.FileName);
                        globalObject.reportObject.fileName = saveFileDialog1.FileName;
                    }
                }

            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.INVALID_VALUE);
            }
        }

        private String getTitleByFilter()
        {
            if (globalObject.reportObject.filter == FileFilterType.CSV_FILE)
            {
                return "Salvataggio File CSV";
            }
            if (globalObject.reportObject.filter == FileFilterType.EXCEL_FILE)
            {
                return "Salvataggio File Microsoft Excel";
            }
            if (globalObject.reportObject.filter == FileFilterType.WORD_FILE)
            {
                return "Salvataggio File Microsoft Word";
            }

            //Di qui non dovrebbe passare
            return "";

        }

    }
}
