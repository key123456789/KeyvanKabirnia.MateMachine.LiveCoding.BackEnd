using MateMachine.LiveCoding.BackEnd.Api.Domain;
using MateMachine.LiveCoding.BackEnd.Api.Repositories;

using MediatR;

namespace MateMachine.LiveCoding.BackEnd.Api.Commands;

public class GetCountryCommand : IRequest<Result>
{
    public int Id { get; set; }
}

public class GetCountryCommandHandler(ICountryRepository repository) : IRequestHandler<GetCountryCommand, Result>
{
    private readonly ICountryRepository _repository = repository;

    public async Task<Result> Handle(GetCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.Get(request.Id);

        if (country == null)
        {
            return Result.Fail("Country not found");
        }

        return Result.Ok(country);
    }
}