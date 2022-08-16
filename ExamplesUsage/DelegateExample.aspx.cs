using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExamplesUsage
{
    public partial class DelegateExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
    public class Myclass
    {
        public void LongRunning()
        {
            for(int i=0;i<100;i++)
            {
                //does something
            }
        }
    }
}