using System;
using System.Collections.Generic;
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

        public SaveDisplayDialog(ref GlobalApplicationObject globalObject) {
            this.globalObject = globalObject;
            display();
        }

        private void display()
        {
            if (globalObject.fileOperation != null && globalObject.fileOperation.filter != null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = this.globalObject.fileOperation.filter.dialogFilter;
                saveFileDialog1.Title = "Salva Report";
                saveFileDialog1.ShowDialog();
            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.INVALID_VALUE);
            }
        }

    }
}
