using AspNetCoreDDD.API.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDDD.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {

        }

        public override OkObjectResult Ok(object result)
        {
            if (!(result is BaseResponse))
            {
                return base.Ok(result.AsSuccessResponse());
            }

            return base.Ok(result);
        }

        public override UnprocessableEntityObjectResult UnprocessableEntity(object error)
        {
            if (!(error is BaseResponse))
            {
                return base.UnprocessableEntity(error.AsUnprocessableResponse());
            }
            return base.UnprocessableEntity(error);
        }
    }
}
