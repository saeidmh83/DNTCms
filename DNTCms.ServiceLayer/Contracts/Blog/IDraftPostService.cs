using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNTCms.ViewModel.Administrator.Blog;

namespace DNTCms.ServiceLayer.Contracts.Blog
{
    public interface IDraftPostService
    {
        Task EditAsync(EditDraftViewModel viewModel);
    }
}
