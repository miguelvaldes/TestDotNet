using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class OperatorRequestObject
    {
        string shortcode;

        public string Shortcode
        {
            get { return shortcode; }
            set { shortcode = value; }
        }

    }
}
