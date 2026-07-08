using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class about : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        Page.Title = "Learn About Furniture Mart | Quality,Innovation, Style";
        Page.MetaDescription = "Furniture Mart is committed to excellence in school and office furniture. Explore our story,\r\nvalues, and passion for functional design.\r\n";
        base.OnLoad(e);
    }

}