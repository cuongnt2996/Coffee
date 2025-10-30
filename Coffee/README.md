# Coffee Project Documentation

## Project Overview
Đây là một ứng dụng web ASP.NET Core MVC quản lý nhân viên, sử dụng SQL Server làm database và Dapper làm ORM. Project tuân thủ kiến trúc **Layered Architecture** với **MVC pattern**, **Dependency Injection**, và **Repository Pattern**.

## Cấu trúc thư mục

### Controllers/ - Tầng Presentation (Giao diện)
- **Mục đích**: Xử lý HTTP requests, điều phối giữa View và Service layer.
- **Files chính**:
  - `BaseController.cs`: Base class cho tất cả controllers (có thể chứa logic chung như error handling).
  - `EmployeesController.cs`: Controller quản lý CRUD operations cho nhân viên.
  - `HomeController.cs`: Controller cho trang chủ và các trang tĩnh.
- **Đánh giá**: ✅ Tốt - Tuân thủ MVC, tách biệt rõ ràng.

### Models/ - Tầng Domain/Data Models
- **Mục đích**: Định nghĩa các entity và DTOs đại diện cho dữ liệu.
- **Subfolders**:
  - `DTOs/`: Chứa Data Transfer Objects (EmployeeDto.cs) - tách biệt request/response.
- **Files chính**:
  - `Employee.cs`: Entity model cho database.
  - `ErrorViewModel.cs`: Model cho trang lỗi.
- **Đánh giá**: ✅ Tốt - Tách biệt entity và DTOs, giúp bảo mật và linh hoạt.

### Services/ - Tầng Business Logic
- **Mục đích**: Chứa business rules, validation, và orchestration.
- **Files chính**:
  - `EmployeeService.cs` & `IEmployeeService.cs`: Service cho logic nhân viên.
  - `ISiteProvider.cs` & `SiteProvider.cs`: Có thể cung cấp thông tin site-wide (như settings).
- **Đánh giá**: ✅ Tốt - Tách biệt business logic khỏi data access và presentation.

### Repositories/ - Tầng Data Access
- **Mục đích**: Xử lý truy cập database, ORM operations.
- **Files chính**:
  - `BaseRepository.cs` & `IRepository.cs`: Generic repository pattern.
  - `EmployeeRepository.cs` & `IEmployeeRepository.cs`: Repository cụ thể cho Employee.
  - `SqlBuilder.cs`: Utility cho việc build SQL queries.
- **Đánh giá**: ✅ Tốt - Sử dụng Repository pattern, dễ test và maintain.

### Data/ - Tầng Database Configuration
- **Mục đích**: Quản lý kết nối database và scripts.
- **Files chính**:
  - `DbConnectionFactory.cs` & `IDbConnectionFactory.cs`: Factory pattern cho database connections.
  - `Scripts/001_CreateEmployeesTable.sql`: Database migration scripts.
- **Đánh giá**: ✅ Tốt - Tách biệt connection logic, dễ config cho multiple environments.

### Views/ - Tầng Presentation (UI)
- **Mục đích**: Chứa Razor views cho MVC.
- **Subfolders**:
  - `Employees/`: Views cho employee management (Index, Create, Edit, etc.).
  - `Home/`: Views cho trang chủ.
  - `Shared/`: Shared layouts và partials (_Layout.cshtml, _ValidationScriptsPartial.cshtml).
- **Đánh giá**: ✅ Tốt - Tổ chức theo controller, tuân thủ MVC conventions.

### Extensions/ - Utility Extensions
- **Mục đích**: Chứa extension methods cho Dependency Injection và services.
- **Files chính**:
  - `ServiceCollectionExtensions.cs`: Extension methods để register services vào DI container.
- **Đánh giá**: ✅ Tốt - Giúp clean code trong Program.cs.

### wwwroot/ - Static Assets
- **Mục đích**: Chứa CSS, JS, images, và third-party libraries (Bootstrap, jQuery).
- **Đánh giá**: ✅ Chuẩn - ASP.NET Core convention.

### Properties/ - Project Properties
- **Mục đích**: Cấu hình launch settings cho development.
- **Files chính**:
  - `launchSettings.json`: IIS Express, Kestrel settings.
- **Đánh giá**: ✅ Chuẩn - Auto-generated.

### bin/ & obj/ - Build Artifacts
- **Mục đích**: Chứa compiled assemblies và build intermediates.
- **Đánh giá**: ⚠️ Không cần commit vào Git - nên add vào .gitignore.

### appsettings.json & appsettings.Development.json - Configuration
- **Mục đích**: Cấu hình ứng dụng (connection strings, logging, etc.).
- **Đánh giá**: ✅ Tốt - Environment-specific configs.

### Program.cs & Coffee.csproj - Entry Point & Project File
- **Mục đích**: Bootstrap ứng dụng và định nghĩa dependencies.
- **Đánh giá**: ✅ Tốt - Minimal API setup với DI.

## Tổng kết đánh giá
- **Strengths**: Kiến trúc rõ ràng, tuân thủ SOLID principles, dễ maintain và test.
- **Improvements**: Có thể thêm Unit Tests folder, API versioning nếu cần, và .gitignore cho bin/obj.
- **Overall**: ⭐⭐⭐⭐⭐ (5/5) - Professional ASP.NET Core project structure.

## Cách chạy project
1. Đảm bảo có .NET 9.0 SDK.
2. Cấu hình connection string trong `appsettings.json`.
3. Chạy database script trong `Data/Scripts/`.
4. `dotnet run` hoặc chạy từ Visual Studio.

## Technologies Used
- ASP.NET Core MVC
- Dapper (ORM)
- SQL Server
- Bootstrap (UI)
- Dependency Injection
