using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Extensions;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace erp.fwk
{
    public class XMLManager
    {
        public static List<menu> GetListMenu(string strIdUser,string strIdActor ,string strIdLanguage)
        {
            
            XmlDocument docX = new XmlDocument();
            docX.Load(HttpContext.Current.Server.MapPath(Global.AdminApplicationDirectory +"/Languages/"+ strIdLanguage + "/menu.xml"));
            List<menu> list = new List<menu>();
            foreach (XmlNode xn in docX)
            {
                if (xn.FirstChild.Name == "sa")
                {
                    foreach (XmlNode x in xn.FirstChild)
                    {
                        string ic = string.Empty;
                        string lk = string.Empty;

                        if (x.Attributes.GetNamedItem("icon") != null)
                            ic = x.Attributes.GetNamedItem("icon").Value;
                        if (x.Attributes.GetNamedItem("link") != null)
                            lk = erp.fwk.Global.AdminApplicationDirectory + x.Attributes.GetNamedItem("link").Value;

                        menu m = new menu
                        {
                            id = x.Attributes.GetNamedItem("id").Value,
                            title = x.Attributes.GetNamedItem("text").Value,
                            icon = ic,
                            link = lk,
                            isPrincipal = Convert.ToBoolean(x.Attributes.GetNamedItem("principal").Value)

                        };

                        list.Add(m);
                    }

                    menu.listM = list;
                   
                }
            }
            return list;
        }
    }
}
