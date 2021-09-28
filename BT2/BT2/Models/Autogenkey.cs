using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT2.Models
{
    public class Autogenkey
    {
       public string GenKey (string text, string id)
        {
            int AutoKey = Convert.ToInt32(id.Substring(2))+1;
            string strkey = "";
            if (id == null)
            {
                strkey = text + "01";
            }           
            else
            {                
                if(AutoKey.ToString().Length > 1)
                {
                    strkey = AutoKey.ToString();
                }else
                {
                    strkey = text+ "0" + AutoKey.ToString();
                }
            }
            return strkey;
        }

    }
}