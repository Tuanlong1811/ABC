using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT2.Models
{
    public class InfoPerSon:PerSon
    {
        [AllowHtml]
        public string Description { get; set; }
        public string Sex { get; set; }
    }
}