using MateMachine.LiveCoding.BackEnd.Api.Domain;
using MateMachine.LiveCoding.BackEnd.Api.Repositories;

using MediatR;

namespace MateMachine.LiveCoding.BackEnd.Api.Commands;


public class DeleteCountryCommand : IRequest<Result>
{
    public int Id { get; set; }
}

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result>
{
    private readonly ICountryRepository _repository;

    public DeleteCountryCommandHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.Get(request.Id);

        if (country == null)
        {
            return Result.Fail("Country not found");
        }

        await _repository.Delete(request.Id);

        return Result.Ok(country);
    }
}

