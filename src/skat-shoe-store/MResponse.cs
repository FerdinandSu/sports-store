using System.Text.Json.Serialization;

namespace Dsc.Web.Models;

public record MResponse
{
    public MResponse(){}
    public MResponse(string Status, int Code, Dictionary<string, object> ValueMap)
    {
        this.Status = Status;
        this.Code = Code;
        this.ValueMap = ValueMap;
    }

    public const int SuccessCode = 0;
    public const int FailedCode = 1;
    [JsonPropertyName("status")]
    public string Status { get; init; }
    [JsonPropertyName("code")]
    public int Code { get; init; }
    [JsonPropertyName("valueMap")]
    public Dictionary<string, object> ValueMap { get; init; }

    public static MResponse Successful<T>(T value)
        where T : notnull
    {
        return new MResponse("success", SuccessCode, new Dictionary<string, object>
        {
            {"data", value}
        });
    }

    public static MResponse Failed(string message)
    {
        return new MResponse(message, FailedCode, new Dictionary<string, object>());
    }

    public void Deconstruct(out string Status, out int Code, out Dictionary<string, object> ValueMap)
    {
        Status = this.Status;
        Code = this.Code;
        ValueMap = this.ValueMap;
    }
}