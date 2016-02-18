using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DNTCms.ViewModel.Common
{
    public static class BaseSortByMode
    {
        public const string RequestsCount = nameof(RequestsCount);
        public const string CreateDate = nameof(CreateDate);
        public const string LastModifiedDate = nameof(LastModifiedDate);
        public const string SeuccessResponsesCount = nameof(SeuccessResponsesCount);
        public const string FailResponsesCount = nameof(FailResponsesCount);
    }
}
