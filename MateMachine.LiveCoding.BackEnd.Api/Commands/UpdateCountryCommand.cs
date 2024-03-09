using MateMachine.LiveCoding.BackEnd.Api.Domain;
using MateMachine.LiveCoding.BackEnd.Api.Repositories;

using MediatR;

namespace MateMachine.LiveCoding.BackEnd.Api.Commands;

public class UpdateCountryCommand : IRequest<Result>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string DefaultCurrency { get; set; }
    public string DefaultLocale { get; set; }
}

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Result>
{
    private readonly ICountryRepository _repository;

    public UpdateCountryCommandHandler(ICountryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _repository.Get(request.Id);

        if (country == null)
        {
            return Result.Fail("Country not found");
        }

        country.Name = request.Name;
        country.Code = request.Code;
        country.DefaultCurrency = request.DefaultCurrency;
        country.DefaultLocale = request.DefaultLocale;

        await _repository.Update(country);

        return Result.Ok();
    }
}
