using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;


public partial class Reportes : System.Web.UI.Page
{
    ReportesLogic reportesLogic = new ReportesLogic();
    ReportDocument crystalReport = new ReportDocument();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }

    protected void lblCursos_Click(object sender, EventArgs e)
    {
        dsCursos dsCursos = reportesLogic.GetDataCursos();
        if (dsCursos.cursos.Rows.Count > 0)
        {
            crystalReport.Load(Server.MapPath("~/ReporteCursos.rpt"));
            crystalReport.SetDataSource(dsCursos);
            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.ReportSource = crystalReport;
            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PersonDetails");
        }
    }
    protected void lblPlanes_Click(object sender, EventArgs e)
    {
        dsPlanes dsPlanes = reportesLogic.GetDataPlanes();
        if (dsPlanes.planes.Rows.Count > 0)
        {
            crystalReport.Load(Server.MapPath("~/ReportePlanes.rpt"));
            crystalReport.SetDataSource(dsPlanes);
            CrystalReportViewer1.RefreshReport();
            CrystalReportViewer1.ReportSource = crystalReport;
            crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "PersonDetails");
        }
    }
}