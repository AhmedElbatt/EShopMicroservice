namespace Catalog.API.Features.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // send request using mediatR
                var result = await sender.Send(request.Adapt<CreateProductCommand>());
                // Adapt the result
                var response = result.Adapt<CreateProductResponse>();
                // use results to create http response
                return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .WithDescription("The endpoint creates product")
            .WithSummary("The endpoint creates product")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
