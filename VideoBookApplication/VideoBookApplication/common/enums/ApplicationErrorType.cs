using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.enums
{
    public class ApplicationErrorType
    {
        public int code { get; private set; }
        public string message { get; private set; }

        private ApplicationErrorType(int code, string message)
        {
            this.code = code;
            this.message = message;
        }

        /** SUCCESSO */
        public static ApplicationErrorType SUCCESS = new ApplicationErrorType(0, "Success");

        /** COMMON ERROR 1 - 30 */
        public static ApplicationErrorType FAILURE = new ApplicationErrorType(1, "Generic Failure");
        public static ApplicationErrorType NOT_IMPLEMENTED = new ApplicationErrorType(2, "Not Implemented");
        public static ApplicationErrorType INVALID_TYPE = new ApplicationErrorType(3, "Type is Invalid");
        public static ApplicationErrorType INVALID_INIT = new ApplicationErrorType(4, "Application not Properly Initialized");
        public static ApplicationErrorType EMPTY_RESERVED = new ApplicationErrorType(5, "Reserved can't be Null or Empty");
        public static ApplicationErrorType NOT_ALLOWED = new ApplicationErrorType(6, "Operation is not Allowed");
        public static ApplicationErrorType ERROR_RESERVED = new ApplicationErrorType(7, "Error Get Reserved");
        public static ApplicationErrorType OPEN_PANEL_ERROR = new ApplicationErrorType(8, "Error Open Panel");

        /** DATABASE ERROR 31 - 50 */
        public static ApplicationErrorType CONNECTION_ERROR = new ApplicationErrorType(31, "Failure Connection to Database");
        public static ApplicationErrorType DB_WRITE_ERROR = new ApplicationErrorType(32, "Falure Write Object to Database");
        public static ApplicationErrorType DB_READ_ERROR = new ApplicationErrorType(33, "Falure Read Object from Database");

        /** COMMON OPERATION ERROR 51 - 100*/
        public static ApplicationErrorType EMPTY_USERNAME = new ApplicationErrorType(51, "Username can't be Null or Empty");
        public static ApplicationErrorType USER_NOT_FOUND = new ApplicationErrorType(52, "User not Found");

        /** LIBRARY OPERATION ERROR 101 - 200 */
        public static ApplicationErrorType EMPTY_CATEGORY = new ApplicationErrorType(101, "Category can't be Null or Empty");
        public static ApplicationErrorType EMPTY_POSITION = new ApplicationErrorType(102, "Position can't be Null or Empty");
        public static ApplicationErrorType CATEGORY_PRESENT = new ApplicationErrorType(103, "Category Already Present");
        public static ApplicationErrorType POSITION_PRESENT = new ApplicationErrorType(104, "Position Already Present");

        /** WARNING 1001 */
        public static ApplicationErrorType NOT_INIT_WARN = new ApplicationErrorType(1001, "Warning Not Intialized");
    }
}
