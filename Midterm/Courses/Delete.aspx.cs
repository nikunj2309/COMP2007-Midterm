﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Midterm.Models;

namespace Midterm.Courses
{
    public partial class Delete : System.Web.UI.Page
    {
		protected Midterm.Models.DefaultConnection _db = new Midterm.Models.DefaultConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Cours item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int CourseID)
        {
            using (_db)
            {
                var item = _db.Courses.Find(CourseID);

                if (item != null)
                {
                    _db.Courses.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Cours item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Midterm.Models.Cours GetItem([FriendlyUrlSegmentsAttribute(0)]int? CourseID)
        {
            if (CourseID == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Courses.Where(m => m.CourseID == CourseID).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}

