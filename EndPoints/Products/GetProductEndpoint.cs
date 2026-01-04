using FastEndpoint.Interface;
using FastEndpoint.Model;
using FastEndpoints;

namespace FastEndpoint.EndPoints.Products
{
    public class GetProductEndpoint:EndpointWithoutRequest<List<Product>>
    {
        private readonly IProductService _productService;
        public GetProductEndpoint(IProductService productService)
        {
            _productService = productService;
        }
        public override void Configure()
        {
            Get("/api/products");
            AllowAnonymous();
        }
        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = await _productService.GetAll();
            await Send.OkAsync(result); 
        }

    }
}
