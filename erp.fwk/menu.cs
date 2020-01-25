using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erp.fwk
{
    public class menu
    {
        public string id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string link { get; set; }
        public bool isPrincipal { get; set; }
        
        public static List<menu> listM = null;

     
      
    }
}