using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DNTCms.DataLayer.Context;
using DNTCms.DomainClasses.Entities.Blog;
using DNTCms.ServiceLayer.Contracts.Blog;
using DNTCms.ViewModel.Administrator.Blog;

namespace DNTCms.ServiceLayer.EFServiecs.Blog
{
    public class DraftPostService : IDraftPostService
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<BlogDraft> _draftPosts;
        private readonly IMappingEngine _mappingEngine;

        #endregion

        #region Ctor

        public DraftPostService(IUnitOfWork unitOfWork,IMappingEngine mappingEngine)
        {
            _unitOfWork = unitOfWork;
            _draftPosts = _unitOfWork.Set<BlogDraft>();
            _mappingEngine = mappingEngine;
        }

        #endregion

        #region EditAsync
        public async Task EditAsync(EditDraftViewModel viewModel)
        {
            var inDbDraft =await _draftPosts.FirstAsync(a=>a.Id==viewModel.Id);
            _mappingEngine.Map(viewModel, inDbDraft);
            
            _unitOfWork.SaveChanges();
        }
        #endregion

    }
}
