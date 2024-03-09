namespace MateMachine.LiveCoding.BackEnd.Api.Domain;

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string DefaultCurrency { get; set; }
    public string DefaultLocale { get; set; }
}
