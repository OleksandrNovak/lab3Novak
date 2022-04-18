using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Lab3.Data;

namespace Lab3
{
    public partial class Zavod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("Login.aspx");
            if (!(IsPostBack || IsCrossPagePostBack))
            {
                var DataDir = Server.MapPath(@"~/Workers/");
                //const string DataDir = @"c:\Programs\SampleData\";
                ReadData(DataDir);
                data_workers.DataSource = Workers.Values
                    .Select(workers => new { Код = workers.id, Прізвище = workers.last_name, Стать = workers.stat, Цех = workers.shop, Посада = workers.posada, Стаж = workers.stazh, Оклад = workers.salary });
                data_workers.DataBind();
                data_prem.DataSource = Premiums.Values
                    .Select(prem => new { Код = prem.id, Премія = prem.prem, Рік = prem.year });
                data_prem.DataBind();
            }
        }

        protected void Task1_Click(object sender, EventArgs e)
        {
            HashSet<String> count = new HashSet<String>();
            foreach (var prem in Premiums)
            {
                foreach (var work in Workers)
                {
                    if (prem.Value.id.Equals(work.Value.id) && work.Value.stat.Equals("ч") && !prem.Value.year.Equals("2022"))
                    {
                        if (!count.Contains(work.Value.shop))
                        {
                            count.Add(work.Value.shop);
                        }
                    }
                }

            }
     
            task1_result.Text = string.Join(" ", count.ToArray());
        }
        protected void Task2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task2.aspx");
        }

    }
}