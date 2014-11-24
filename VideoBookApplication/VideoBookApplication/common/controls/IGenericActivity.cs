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
        public void openPanel(GlobalOperation operation);
        public void closePanel();
        public void closePanel(GlobalOperation operation);
        public void closeMenu();
        public void openMenu(GlobalOperation operation);


    }
}
