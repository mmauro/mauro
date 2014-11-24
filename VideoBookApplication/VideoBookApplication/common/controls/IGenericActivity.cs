using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.common.controls
{
    public interface IGenericActivity
    {
        void openPanel(GlobalOperation operation);
        void closePanel();
        void closePanel(GlobalOperation operation);
        void closeMenu();
        void openMenu(GlobalOperation operation);


    }
}
