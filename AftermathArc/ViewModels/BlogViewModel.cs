using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AftermathArc.Models;

namespace AftermathArc.ViewModels
{
    public class BlogViewModel
    {
        public string commentsView { get; set; }
        public Nullable<System.DateTime> commentDateView { get; set; }
        public string usernameView { get; set; }

    }
}