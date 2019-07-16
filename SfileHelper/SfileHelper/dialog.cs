using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfileHelper
{
   public class dialog : Window1
    {

        public string ResponseText
        {
            get { return L_quata_name.Text + L_quta_quantity.Text;}
            set { L_quata_name.Text = value; }
        }

  

    }
}


