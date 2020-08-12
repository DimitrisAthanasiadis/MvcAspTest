using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using BootstrapIntroduction.Models;
using MvcAspTest.Models;

public static class HtmlHelperExtensions
{
    public static HtmlString HtmlConvertToJson(this HtmlHelper htmlHelper,
        object model)
    {
        var settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        return new HtmlString(JsonConvert.SerializeObject(model, settings));
    }

    public static MvcHtmlString BuildSortableLink(this HtmlHelper htmlHelper, string fieldName,
            string actionName, string sortField, QueryOptions queryOptions)
    {
        var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
        var isCurrentSortField = queryOptions.sortField == sortField;

        return new MvcHtmlString(string.Format("<a href=\"{0}\">{1} {2}</a>", urlHelper.Action(
            actionName, new { 
                sortField = sortField,
                sortOrder = (isCurrentSortField && queryOptions.sortOrder == SortOrder.ASC) ? 
                SortOrder.DESC : SortOrder.ASC
            }),
                fieldName,
                BuildSortIcon(isCurrentSortField, queryOptions)
            ));
    }

    public static BuildSortIcon(bool isCurrentSortField, QueryOptions queryOptions)
    {
        string sortIcon = "sort";

        if (isCurrentSortField)
        {
            sortIcon += "-by-alphabet";
            if(queryOptions.sortOrder == SortOrder.DESC)
            {
                sortIcon += "-alt";
            }
        }

        return string.Format("<span class=\"{0} {1}{2}\"></span>",
                "glyphicon", "glyphicon-", sortIcon);
    }
}