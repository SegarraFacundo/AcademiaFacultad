using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util.CustomException;
using Util;
public partial class RegistroNotas : System.Web.UI.Page
{
    private int SelectedID
    {
        get
        {
            if (this.ViewState["SelectedID"] != null)
            {
                return (int)this.ViewState["SelectedID"];
            }
            else
            {
                return 0;
            }
        }
        set
        {
            this.ViewState["SelectedID"] = value;
        }
    }
    private bool IsEntitySelected
    {
        get
        {
            return (this.SelectedID != 0);
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void dgvDocentesCursos_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.SelectedID = (int)this.dgvDocentesCursos.SelectedValue;
        if (IsEntitySelected)
        {
            Session["id_curso"] = dgvDocentesCursos.SelectedDataKey.Values["id_curso"];
        }

    }
}