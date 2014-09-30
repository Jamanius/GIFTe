using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace ClientSideApp.Models
{
    public class GiftViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Comments { get; set; }
        
    }
}