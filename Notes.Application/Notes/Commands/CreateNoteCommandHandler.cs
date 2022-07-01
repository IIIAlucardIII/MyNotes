using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Domain;

namespace Notes.Application.Notes.Commands
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {

        public readonly DbContext _dbContext;
        public CreateNoteCommandHandler (DbContext dbContext) => 
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Title = request.Title,
                Description = request.Description,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.Id;
        }
    }
}
