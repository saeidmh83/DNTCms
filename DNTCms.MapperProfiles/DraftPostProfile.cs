using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DNTCms.DomainClasses.Entities.Blog;
using DNTCms.MapperProfiles.Extentions;
using DNTCms.ViewModel.Administrator.Blog;

namespace DNTCms.MapperProfiles
{
  public  class DraftPostProfile:Profile
    {
      protected override void Configure()
      {
          CreateMap<EditDraftViewModel, BlogDraft>().IgnoreAllNonExisting();

      }
    }
}
