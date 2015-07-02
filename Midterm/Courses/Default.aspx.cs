using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Midterm.Models;

namespace Midterm.Courses
{
    public partial class Default : System.Web.UI.Page
    {
		protected Midterm.Models.DefaultConnection _db = new Midterm.Models.DefaultConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Cours entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Midterm.Models.Cours> GetData()
        {
            return _db.Courses;
        }
    }
}

