using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.model
{
    public class ItemCombo
    {
        public string text { get; set; }
        public int value { get; set; }

        public ItemCombo(string text, int value)
        {
            this.text = text;
            this.value = value;
        }
        public override string ToString()
        {
            return text;
        }

    }
}
