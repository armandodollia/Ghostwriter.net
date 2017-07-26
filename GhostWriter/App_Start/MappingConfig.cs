using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;
using GhostWriter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GhostWriter
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Post, PostEditViewModel>()
                .ForMember(dest => dest.Body,
                           opt => opt.MapFrom(src => src.PostBody));

                config.CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.Body,
                           opt => opt.MapFrom(src => src.PostBody));

                config.CreateMap<Post, PostDetailViewModel>()
                .ForMember(dest => dest.Body,
                           opt => opt.MapFrom(src => src.PostBody));

                config.CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Body,
                           opt => opt.MapFrom(src => src.CommentBody));

                config.CreateMap<PostEditViewModel, Post>()
                .ConvertUsing<PostEditToPostConverter>();

                config.CreateMap<CommentViewModel, Comment>()
                .ConvertUsing<CommentViewToCommentConverter>();
            });
        }
    }
}