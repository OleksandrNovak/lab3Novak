using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Lab3.Data;

namespace Lab3
{
    public partial class Task2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            if (!(IsPostBack || IsCrossPagePostBack))
            {
                HashSet<String> shop = new HashSet<String>();
                Dictionary<String, String> sum = new Dictionary<String, String>();
                foreach (var work in Workers)
                {
                    shop.Add(work.Value.posada);
                }
                int count = 0;
                foreach (var elem in shop)
                {
                    foreach (var work in Workers)
                    {
                        if (work.Value.posada.Equals(elem))
                        {
                                count += int.Parse(work.Value.salary);
                                foreach (var prem in Premiums)
                                {
                                    if (work.Value.id.Equals(prem.Value.id))
                                    {
                                        count += int.Parse(prem.Value.prem);
                                    }
                                }
                        }
                    }
                    sum.Add(elem, count.ToString());
                    count = 0;
                }



                task2_result.DataSource = sum.Select(elem => new
                {
                    Посада = elem.Key,
                    Зарплата = elem.Value,
                }); ;
                task2_result.DataBind();
                
            }
        }
    }
}