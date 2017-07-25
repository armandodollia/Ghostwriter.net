using AutoMapper;
using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;

namespace GhostWriter.Converters
{
    public class PostEditToPostConverter : AutoMapper.ITypeConverter<PostEditViewModel, Post>
    {
        public Post Convert(PostEditViewModel source, Post destination, ResolutionContext context)
        {
            if (source == null || destination == null) return null;

            destination.Title = source.Title;
            destination.PostBody = source.Body;

            return destination;
        }
    }
}