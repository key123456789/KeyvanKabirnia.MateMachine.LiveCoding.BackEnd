using MateMachine.LiveCoding.BackEnd.Api.Domain;
using MateMachine.LiveCoding.BackEnd.Api.Repositories;

using MediatR;

namespace MateMachine.LiveCoding.BackEnd.Api.Commands;

public class CreateCountryCommand : IRequest<Result>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string DefaultCurrency { get; set; }
    public string DefaultLocale { get; set; }
}

public class CreateCountryCommandHandler(ICountryRepository countryRepository) : IRequestHandler<CreateCountryCommand, Result>
{
    private readonly ICountryRepository _repository = countryRepository;

    public async Task<Result> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = new Country
        {
            Name = request.Name,
            Code = request.Code,
            DefaultCurrency = request.DefaultCurrency,
            DefaultLocale = request.DefaultLocale
        };

        var id = await _repository.Add(country);

        if (id > 0)
        {
            return Result.Ok(country);
        }
        else
        {
            return Result.Fail("Failed to create country");
        }
    }
}
