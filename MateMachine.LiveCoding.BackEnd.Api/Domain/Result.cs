namespace MateMachine.LiveCoding.BackEnd.Api.Domain;

public class Result
{
    public bool Success { get; set; }
    public string Error { get; set; }
    public Country Value { get; set; }

    public static Result Fail(string error) => new Result { Success = false, Error = error };
    public static Result Ok(Country value = null) => new Result { Success = true, Value = value };
}