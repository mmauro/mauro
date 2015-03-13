using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.view;
using VideoBookApplication.common.model;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.controls;
using System.Diagnostics;


namespace VideoBookApplication.common.view
{
    public partial class ExportReportMenu : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private LibraryActivityWindow parent;

        private static int numButton = 3;
        private GlobalApplicationObject globalObject;
        private SaveDisplayDialog dialog;
        private ReportControls controls = new ReportControls();

        public ExportReportMenu(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            dialog = null;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getMenuColor();
            this.Size = new Size(LayoutManager.menuHeight, (numButton*90)+(5*(numButton+1)));

            //Button new
            buttonReportCSV.Location = new Point(5, 5);
            this.Controls.Add(buttonReportCSV);

            //Button delete
            buttonReportExcel.Location = new Point(5, buttonReportCSV.Location.Y + buttonReportCSV.Size.Height + 5);
            this.Controls.Add(buttonReportExcel);

            //Button Modify
            buttonReportWord.Location = new Point(5, buttonReportExcel.Location.Y + buttonReportExcel.Size.Height + 5);
            this.Controls.Add(buttonReportWord);

            if (!controls.canSaveReport())
            {
                buttonReportCSV.Enabled = false;
                buttonReportExcel.Enabled = false;
                buttonReportWord.Enabled = false;
            }

            //toolTip
            toolTip1.SetToolTip(buttonReportExcel, "Crea Report in formato Excel");
            toolTip1.SetToolTip(buttonReportCSV, "Crea Report in formato CSV");
            toolTip1.SetToolTip(buttonReportWord, "Crea Report in formato Word");
        }

        private void buttonReportCSV_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            globalObject.reportObject = new ReportObject(FileFilterType.CSV_FILE, ReportType.CSV);
            getFileNameFromDiaolog();
        }

        private void buttonReportExcel_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            globalObject.reportObject = new ReportObject(FileFilterType.EXCEL_FILE, ReportType.EXCEL);
            getFileNameFromDiaolog();
            //DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonReportWord_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            globalObject.reportObject = new ReportObject(FileFilterType.WORD_FILE, ReportType.WORD);
            getFileNameFromDiaolog();
        }

        private void getFileNameFromDiaolog()
        {
            SaveDisplayDialog dialog = new SaveDisplayDialog(ref globalObject);
            if (dialog.dialogResult == DialogResult.OK)
            {
                
                ApplicationErrorType status = controls.saveReport(ref globalObject);
                if (status == ApplicationErrorType.SUCCESS)
                {
                    DisplayManager.displayMessage(ApplicationErrorType.SUCCESS);

                    //Apertura Folder...
                    try
                    {
                        Process.Start("explorer.exe", @FileUtility.getFolder(globalObject.reportObject.fileName));
                    }
                    catch (Exception e)
                    {
                        log.Error(e.Message);
                    }

                }
                else
                {
                    DisplayManager.displayError(status);
                }
            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.CANCEL_OPERATION);
            }
        }
    }
}
