using Microsoft.AspNetCore.Mvc;
namespace LoanApplicationSystem.Api.Extensions
{
        public static class ResultExtensions
        {
            public static ActionResult ToActionResult(this Result result)
            {
                var apiResponse = ApiResponse.FromResult(result);

                return result.IsSuccess
                    ? new OkObjectResult(apiResponse)
                    : new BadRequestObjectResult(apiResponse);
            }

            public static ActionResult<ApiResponse<T>> ToActionResult<T>(this Result<T> result)
            {
                var apiResponse = ApiResponse<T>.FromResult(result);

                return result.IsSuccess
                    ? new OkObjectResult(apiResponse)
                    : new BadRequestObjectResult(apiResponse);
            }

            public static ActionResult<T> ToActionResultData<T>(this Result<T> result)
            {
                if (result.IsSuccess)
                    return new OkObjectResult(result.Data);

                var apiResponse = new
                {
                    Success = false,
                    Message = result.Message,
                    Errors = result.Errors
                };
                return new BadRequestObjectResult(apiResponse);
            }
        }
    }
