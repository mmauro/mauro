using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.view
{
    class DisplayManager
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void displayError(ApplicationErrorType value)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1}", value.code, value.message), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            log.Error(String.Format("Errore: {0} - {1}", value.code, value.message));
        }

        public static void displayError(ApplicationErrorType value, string message)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1} - {2}", value.code, value.message, message), "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            log.Error(String.Format("Errore: {0} - {1} / {2}", value.code, value.message, message));
        }

        public static void displayWarning(ApplicationErrorType value)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1}", value.code, value.message), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            log.Warn(String.Format("WARN: {0} - {1}", value.code, value.message));
        }

        public static void displayWarning(ApplicationErrorType value, string message)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1} - {2}", value.code, value.message, message), "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            log.Warn(String.Format("WARN: {0} - {1} / {2}", value.code, value.message, message));
        }

        public static void displayMessage(ApplicationErrorType value)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1}", value.code, value.message), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            log.Info(String.Format("INFO: {0} - {1}", value.code, value.message));
        }

        public static void displayMessage(ApplicationErrorType value, string message)
        {
            MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Message: {1} - {2}", value.code, value.message, message), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            log.Info(String.Format("INFO: {0} - {1} / {2}", value.code, value.message, message));
        }

    }
}
