using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using BootstrapIntroduction.Models;

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
            actionName, new
            {
                sortField = sortField,
                sortOrder = (isCurrentSortField && queryOptions.sortOrder == SortOrder.ASC) ?
                SortOrder.DESC : SortOrder.ASC
            }),
                fieldName,
                BuildSortIcon(isCurrentSortField, queryOptions)
            ));
    }

    private static string BuildSortIcon(bool isCurrentSortField, QueryOptions queryOptions)
    {
        string sortIcon = "sort";

        if (isCurrentSortField)
        {
            sortIcon += "-by-alphabet";
            if (queryOptions.sortOrder == SortOrder.DESC)
            {
                sortIcon += "-alt";
            }
        }

        return string.Format("<span class=\"{0} {1}{2}\"></span>",
                "glyphicon", "glyphicon-", sortIcon);
    }

    public static MvcHtmlString BuildNextPreviousLinks(this HtmlHelper htmlHelper, QueryOptions queryOptions, string actionName)
    {
        var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

        return new MvcHtmlString(string.Format(
        @"
            <nav>
                <ul class='pager'>
                    <li class='previous {0}'>{1}</li>
                    <li class='previous {2}'>{3}</li>
                </ul>
            </nav>
        ", isPreviousDisabled(queryOptions),
        BuildPreviousLink(urlHelper, queryOptions, actionName),
        isNextDisabled(queryOptions),
        BuildNextLink(urlHelper, queryOptions, actionName)
        ));
    }

    private static string isPreviousDisabled(QueryOptions queryOptions)
    {
        return (queryOptions.currentPage == 1)
        ? "disabled" : string.Empty;
    }
    private static string isNextDisabled(QueryOptions queryOptions)
    {
        return (queryOptions.currentPage == queryOptions.totalPages)
        ? "disabled" : string.Empty;
    }
    private static string BuildPreviousLink(
        UrlHelper urlHelper, QueryOptions queryOptions, string actionName)
    {
        return string.Format(
        "<a href=\"{0}\"><span aria-hidden=\"true\">&larr;</span> Previous</a>",
        urlHelper.Action(actionName, new
        {
            SortOrder = queryOptions.sortOrder,
            SortField = queryOptions.sortField,
            CurrentPage = queryOptions.currentPage - 1,
            PageSize = queryOptions.pageSize
        }));
    }

    private static string BuildNextLink(
        UrlHelper urlHelper, QueryOptions queryOptions, string actionName)
    {
        return string.Format(
        "<a href=\"{0}\">Next <span aria-hidden=\"true\">&rarr;</span></a>",
        urlHelper.Action(actionName, new
        {
            SortOrder = queryOptions.sortOrder,
            SortField = queryOptions.sortField,
            CurrentPage = queryOptions.currentPage + 1,
            PageSize = queryOptions.pageSize
        }));
    }

}