using MediatR;

namespace Notes.Application.Notes.Commands
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
