using Microsoft.AspNetCore.Mvc;

namespace Krola.Authorization.Api.Presenters
{
  public sealed class JsonContentResult : ContentResult
  {
    public JsonContentResult()
    {
      ContentType = "application/json";
    }
  }
}
