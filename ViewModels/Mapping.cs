using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using QuakeTrack.Data;
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
                .ForMember(dest => dest.AssigneeId, opt => opt.MapFrom<AssigneeToTsResolver>())
                .ReverseMap()
                .ForMember(dest => dest.Assignee, opt => opt.MapFrom<AssigneeToCsResolver>());

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
            var users = source.UserProjects?.Select(link =>
            {
                var model = mapper.Map<UserViewModel>(link.User);
                model.Role = link.Role.ToString();
                return model;
            }).ToList();
            return users;
        }
    }

    public class AssigneeToTsResolver : IValueResolver<Issue, IssueViewModel, string>
    {
        public string Resolve(Issue source, IssueViewModel destination, string member, ResolutionContext context)
        {
            return source.AssigneeId;
        }
    }

    public class AssigneeToCsResolver : IValueResolver<IssueViewModel, Issue, ApplicationUser>
    {
        private ApplicationDbContext db;

        public AssigneeToCsResolver(ApplicationDbContext _db)
        {
            db = _db;
        }

        public ApplicationUser Resolve(IssueViewModel source, Issue destination, ApplicationUser member, ResolutionContext context)
        {
            return db.Users.Find(source.AssigneeId);
        }
    }
}
