

using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace DNTCms.ViewModel.Common
{
    /// <summary>
    /// کلاس پایه برای اطلاعات لازم برای جستجو و مرتب سازی
    /// </summary>
    public class BaseSearchRequest
    {
        public BaseSearchRequest()
        {
            PageSize = 10;
            PageIndex = 1;
            SortDirection = SortDirectionMode.Desc;

            #region PageSizesList

            PageSizeList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = Common.PageSize.Count10.ToString(),
                    Text = "۱۰"
                },
                new SelectListItem
                {
                    Value = Common.PageSize.Count20.ToString(),
                    Text = "۲۰"
                },
                new SelectListItem
                {
                    Value = Common.PageSize.Count30.ToString(),
                    Text = "۳۰"
                },
                new SelectListItem
                {
                    Value = Common.PageSize.Count40.ToString(),
                    Text = "۴۰"
                },
                new SelectListItem
                {
                    Value = Common.PageSize.Count50.ToString(),
                    Text = "۵۰"
                },
                new SelectListItem
                {
                    Value = Common.PageSize.All.ToString(),
                    Text = "همه"
                }
            };

            #endregion

            #region SortOrderList
            SortOrderList = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = SortDirectionMode.Desc,
                    Text = "نزولی"

                }
                ,
                new SelectListItem
                {
                    Value = SortDirectionMode.Asc,
                    Text = "صعودی"
                }
            };
            #endregion
        }

        /// <summary>
        /// رشته جستجو
        /// </summary>
        [DisplayName("جستجو")]
        public string Term { get; set; }
        /// <summary>
        /// جهت مرتب سازی
        /// </summary>
        public string SortDirection { get; set; }
        /// <summary>
        /// تعداد کل داده ها
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// شماره صفحه
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// تعداد در صفحه
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// نام فیلد جاری برای مرتب سازی
        /// </summary>
        public string CurrentSort { get; set; }

        public IEnumerable<SelectListItem> PageSizeList  { get; set; }
        public IEnumerable<SelectListItem> SortOrderList { get; set; }
    }
}
