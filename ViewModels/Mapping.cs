using System;
using AutoMapper;
using QuakeTrack.Models;

namespace QuakeTrack.ViewModels
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Project, ProjectViewModel>()
                .ReverseMap();
            CreateMap<Issue, IssueViewModel>()
                .ReverseMap();
            CreateMap<ApplicationUser, UserViewModel>()
                .ReverseMap();
        }
    }
}
