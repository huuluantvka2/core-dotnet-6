using Microsoft.AspNetCore.Http;

namespace Sercurity
{
    public class DatabaseAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseAccessMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Kiểm tra quyền truy cập của người dùng
            if (!context.User.Identity.IsAuthenticated)
            {
                // Người dùng không xác thực, trả về lỗi hoặc chuyển hướng đến trang đăng nhập
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            // Kiểm tra các quyền truy cập cụ thể của người dùng vào cơ sở dữ liệu
            if (!HasDatabaseAccessPermission(context.User.Identity.Name))
            {
                // Người dùng không có quyền truy cập, trả về lỗi hoặc chuyển hướng đến trang cần thiết
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                return;
            }

            // Cho phép yêu cầu tiếp theo
            await _next(context);
        }

        private bool HasDatabaseAccessPermission(string username)
        {
            // Kiểm tra quyền truy cập của người dùng dựa trên username
            // ... Triển khai logic kiểm tra quyền truy cập cơ sở dữ liệu ...

            return true; // True nếu có quyền truy cập, False nếu không
        }
    }

}
