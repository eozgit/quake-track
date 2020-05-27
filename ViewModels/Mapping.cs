using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using QuakeTrack.Models;

namespace QuakeTrack.ViewModels
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom<ContributorsResolver>())
                .ReverseMap();
            CreateMap<Issue, IssueViewModel>()
                .ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>()
                .ReverseMap();
        }
    }

    public class ContributorsResolver : IValueResolver<Project, ProjectViewModel, ICollection<UserViewModel>>
    {
        private IMapper mapper;

        public ContributorsResolver(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public ICollection<UserViewModel> Resolve(Project source, ProjectViewModel destination, ICollection<UserViewModel> member, ResolutionContext context)
        {
            var users = source.UserProjects?.Where(link => link.Role == UserProjectRole.Contributor).Select(link => mapper.Map<UserViewModel>(link.User)).ToList();
            if (users != null) users.ForEach(user => user.Role = "contributor");
            return users;
        }
    }
}
