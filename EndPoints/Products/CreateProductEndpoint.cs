using FastEndpoint.Interface;
using FastEndpoint.Model;
using FastEndpoints;

namespace FastEndpoint.EndPoints.Products
{
    public class CreateProductEndpoint:Endpoint<Product,int>
    {
        private readonly IProductService _productService;
        public CreateProductEndpoint(IProductService productService)
        {
            _productService = productService;
        }
        public override void Configure()
        {
            Post("/api/products");
            AllowAnonymous();
        }
        public override async Task HandleAsync(Product req, CancellationToken ct)
        {
            int  result = await _productService.Create(req);
            await Send.OkAsync(result,ct);

            //await SendOkAsync(result);
            // await SendAsync(result,201,ct);
            //await SendAsync(result, 201);
            // object value = await SendAsync(result, 200, ct);

        }


    }
}
