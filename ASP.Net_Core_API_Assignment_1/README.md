# ASP.NET Core API Assignment 2

## Giới thiệu
Đây là dự án API xây dựng bằng ASP.NET Core, được thiết kế để quản lý thông tin người dùng. API cung cấp các chức năng CRUD (Create, Read, Update, Delete) cho đối tượng Person.

## Công nghệ sử dụng
- ASP.NET Core
- Entity Framework Core
- AutoMapper
- Swagger/OpenAPI

## Cấu trúc dự án
Dự án được tổ chức theo kiến trúc Clean Architecture:

- **ASP.NET_Core_API_Assignment_1.Domain**: Chứa các entities và business logic
- **ASP.NET_Core_API_Assignment_1.Application**: Chứa các services, DTOs và mappings
- **ASP.NET_Core_API_Assignment_1.Infrastructure**: Chứa các implementations của repositories và services
- **ASP.NET_Core_API_Assignment_1.API**: Chứa controllers và cấu hình API

## Cài đặt và chạy dự án

### Yêu cầu
- .NET 9.0 SDK

### Các bước chạy dự án
1. Clone repository:
```bash
git clone https://github.com/vanchien2973/AssignmentRockie.git
cd ASP.NET_Core_API_Assignment_1
```

2. Cấu hình cơ sở dữ liệu:
   - Cập nhật chuỗi kết nối trong file `appsettings.json`

4. Biên dịch và chạy dự án:
```bash
dotnet build
dotnet run --project ASP.NET_Core_API_Assignment_1.Presentation
```

5. Truy cập API tại:
```
http://localhost:5237/swagger
```

## API Endpoints

### Person API
- `GET /api/persons` - Lấy danh sách tất cả người dùng
- `GET /api/persons/{id}` - Lấy thông tin chi tiết của một người dùng
- `POST /api/persons` - Tạo người dùng mới
- `PUT /api/persons/{id}` - Cập nhật thông tin người dùng
- `DELETE /api/persons/{id}` - Xóa người dùng
