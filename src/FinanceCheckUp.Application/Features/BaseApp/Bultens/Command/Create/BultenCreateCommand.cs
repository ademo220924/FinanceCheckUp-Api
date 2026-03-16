using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Create;

public class BultenCreateCommand : IUserIdAssignable , IRequest<GenericResult<BultenCreateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public string SubTitle { get; set; }
    public string Kapsam { get; set; }
    public DateTime YururlulukTarih { get; set; }
    public string DuzenleyenKurum { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedUser { get; set; }
    public string Title { get; set; }
    private string titleShort { get; set; }
    public string? TitleShort
    {
        get =>
            !string.IsNullOrEmpty(Title)
                ? Title is { Length: > 25 } ? Title[..24] : Title
                : string.Empty;
        init { }
    }
}