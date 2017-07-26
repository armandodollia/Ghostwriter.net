using AutoMapper;
using Ghostwriter.Entities;
using Ghostwriter.Entities.Models;

namespace GhostWriter.Converters
{
    public class CommentViewToCommentConverter : AutoMapper.ITypeConverter<CommentViewModel, Comment>
    {
        public Comment Convert(CommentViewModel source, Comment destination, ResolutionContext context)
        {
            if (source == null || destination == null) return null;

            destination.CommentBody = source.Body;
            if (source.PostId.HasValue)
            {
                destination.PostId = source.PostId.Value;
            }

            return destination;
        }
    }
}