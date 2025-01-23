using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Common.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="sortField"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<T> SortList<T>(this List<T> list, string sortField, string sortOrder)
        {
            if (list == null || list.Count <= 1 || string.IsNullOrWhiteSpace(sortField))
                return list;

            // 反射属性名
            PropertyInfo propertyInfo = typeof(T).GetProperty(sortField);
            if (propertyInfo == null)
                throw new ArgumentException("无效的排序字段");

            // 确定排序方向
            bool isAscending = string.Equals(sortOrder, "asc", StringComparison.OrdinalIgnoreCase);

            // 排序
            var sortedQuery = isAscending
                ? list.OrderBy(item => propertyInfo.GetValue(item, null))
                : list.OrderByDescending(item => propertyInfo.GetValue(item, null));

            return sortedQuery.ToList();
        }

        /// <summary>
        /// 判空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Boolean IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }
    }
}
