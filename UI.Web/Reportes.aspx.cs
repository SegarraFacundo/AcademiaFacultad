using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using Data.Database;



public partial class Reportes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void linkReporteCursos_Click(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/CrystalReport.rpt"));
        dsCursos dsCursos = new dsCursos();


        
        

        
    }
    protected void linkReportePlanes_Click(object sender, EventArgs e)
    {

    }

    private dsCursos GetData(string query)
    {

        


        return null;
    }

}