﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace UmbracoPublic.Logic.Controllers.Paging
{
    public class DefaultPagingController : PagingController
    {
        public override void Render(LinqIt.Utils.Web.HtmlWriter writer, int pageNumber, int firstPage, int lastPage, int pages, bool showEnds)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Div, "pagination");
            writer.RenderBeginTag(HtmlTextWriterTag.Ul);

            if (pageNumber > 1)
                RenderPageLink(writer, pageNumber - 1, "Prev", "", false);
            else
                RenderPageLink(writer, null, "Prev", "disabled", false);

            for (var i = firstPage; i <= lastPage; i++)
                RenderPageLink(writer, i == pageNumber ? (int?)null : i, i.ToString(), i == pageNumber ? "disabled" : null, false);

            if (pageNumber < pages)
                RenderPageLink(writer, pageNumber + 1, "Next", "", false);
            else
                RenderPageLink(writer, null, "Next", "disabled", false);

            writer.RenderEndTag(); // ul
            writer.RenderEndTag(); // div.pagination
        }
    }
}
