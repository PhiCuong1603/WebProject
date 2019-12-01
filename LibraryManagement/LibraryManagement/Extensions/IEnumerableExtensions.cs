using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListAuthor<T>(this IEnumerable<T> items,int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("AuthorName"),
                       Value = item.GetPropertyValue("AuthorID"),
                       Selected = item.GetPropertyValue("AuthorID").Equals(selectedValue.ToString())
                   };
        }

        public static IEnumerable<SelectListItem> ToSelectListCategory<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("CategoryName"),
                       Value = item.GetPropertyValue("CategoryID"),
                       Selected = item.GetPropertyValue("CategoryID").Equals(selectedValue.ToString())
                   };
        }       
    }
}
