using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.controls;


namespace VideoBookApplication.common.operations
{
    public class InitDatabase
    {
        public ApplicationErrorType initDatabase()
        {
            
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            //User
            UsersControl ucontrol = new UsersControl();
            status = ucontrol.writeUser("root", false, false, false, false, true);
            if (status == ApplicationErrorType.SUCCESS)
            {
                status = ucontrol.writeUser("mauro", true, true, true, true, false);
            }

            //Category
            if (status == ApplicationErrorType.SUCCESS)
            {
                CategoryControls ccontrol = new CategoryControls();
                status = ccontrol.write(Configurator.getInstsance().get("catpos.default.value"));
            }

            //Position
            if (status == ApplicationErrorType.SUCCESS)
            {
                PositionControls pcontrol = new PositionControls();
                status = pcontrol.write(Configurator.getInstsance().get("catpos.default.value"));
            }

            
            //Reserved
            if (status == ApplicationErrorType.SUCCESS)
            {
                ReservedControl rcontrol = new ReservedControl();
                string[] booksReservedWords = new string[] { "il", "lo", "la", "i", "gli", "le", "un", "una", "l", "nel", "nell", "nella", "in", "con", "del", "della", "dell",
											 "a", "al", "all", "alla", "vol", "volume", "di", "da", "sul", "sulla", "sull", "più" };
                foreach (string w in booksReservedWords) {
                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        status = rcontrol.writeReserved(w, ReservedType.TITLE_BOOK_RESERVED);
                    }
                }
            }
            return status;
        }
    }
}
