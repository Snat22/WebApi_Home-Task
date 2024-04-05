using System.Net;

namespace Domain.Response;

public class Responses<T>
{
    public int StatusCode { get; set; }
    public List<string> Description { get; set; } = new List<string>();

    public T? Data { get; set; }


    public Responses(HttpStatusCode statusCode,string messages,T data)
    {
        StatusCode = (int)statusCode;
        Description.Add(messages);
        Data = data;
    }

    public Responses(HttpStatusCode statusCode,List<string> messages,T data)
    {
        StatusCode = (int)statusCode;
        Description = messages;
        Data = data;
    }

    public Responses(HttpStatusCode statusCode,string messages)
    {
        StatusCode = (int)statusCode;
        Description.Add(messages);
    }

    public Responses(HttpStatusCode statusCode,List<string> messages)
    {
        StatusCode = (int)statusCode;
        Description = messages;
    }
    public Responses(T data)
    {
        StatusCode = 200;
        Data = data;
    }
}
