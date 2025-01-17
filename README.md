# 📝 Excersise 3: Minimal API with ASP.NET Core

## 📄 Mô tả bài tập
Bài tập này xây dựng một **Minimal API** sử dụng **ASP.NET Core** để quản lý danh sách các công việc (to-do items). Minimal API giúp tạo HTTP API với các phụ thuộc tối thiểu, phù hợp cho microservices và các ứng dụng nhỏ gọn.

## ✅ Kết quả đạt được
### 🛠️ API được triển khai
Dưới đây là các endpoint API được xây dựng:

| HTTP Method | Endpoint                | Mô tả                              | Request Body   | Response Body |
|-------------|-------------------------|-------------------------------------|----------------|---------------|
| GET         | `/todoitems`            | Lấy tất cả các công việc            | None           | Mảng công việc|
| GET         | `/todoitems/complete`   | Lấy các công việc đã hoàn thành     | None           | Mảng công việc|
| GET         | `/todoitems/{id}`       | Lấy công việc theo ID               | None           | Công việc      |
| POST        | `/todoitems`            | Thêm một công việc mới              | Công việc      | Công việc      |
| PUT         | `/todoitems/{id}`       | Cập nhật một công việc hiện có      | Công việc      | None          |
| DELETE      | `/todoitems/{id}`       | Xóa một công việc                   | None           | None          |

### 📋 Các bước triển khai
1. **Khởi tạo dự án:**
   - Tạo dự án ASP.NET Core sử dụng mẫu **Empty Project**.
   - Sử dụng .NET 9.

2. **Thêm các thư viện NuGet:**
   - **Microsoft.EntityFrameworkCore.InMemory**: Để quản lý cơ sở dữ liệu trong bộ nhớ.
   - **Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore**: Để xử lý lỗi liên quan đến cơ sở dữ liệu.

3. **Xây dựng các lớp:**
   - **Model (`Todo.cs`)**: Đại diện cho dữ liệu công việc.
   - **Database Context (`TodoDb.cs`)**: Quản lý các thao tác với cơ sở dữ liệu.

4. **Tạo các endpoint trong `Program.cs`:**
   - Cung cấp các API để thêm, sửa, xóa, và truy vấn công việc.

5. **Kiểm thử API:**
   - Sử dụng công cụ như Postman hoặc Visual Studio để gửi các yêu cầu đến các endpoint.
   - Đảm bảo tất cả endpoint hoạt động đúng chức năng.

## 🚀 Hướng dẫn chạy
1. Clone repository này:
   ```bash
   git clone https://github.com/soa-ueh-thanhlam/Excersie3.git
   ```
2. Điều hướng vào thư mục dự án:
   ```bash
   cd Excersie3
   ```
3. Chạy ứng dụng:
   ```bash
   dotnet run
   ```
4. Kiểm tra ứng dụng tại:
   - HTTP: `http://localhost:7090`
   - HTTPS: `https://localhost:7091`

## 🔄 Ví dụ yêu cầu API
### ➕ Thêm một công việc mới:
**Endpoint:**
```http
POST https://localhost:7090/todoitems
```

**Request Body:**
```json
{
  "name": "walk dog",
  "isComplete": true
}
```

**Response Body:**
```json
{
  "id": 1,
  "name": "walk dog",
  "isComplete": true
}
```

### ✏️ Cập nhật công việc:
**Endpoint:**
```http
PUT https://localhost:7090/todoitems/1
```

**Request Body:**
```json
{
  "name": "feed fish",
  "isComplete": false
}
```

## 📚 Tài liệu tham khảo
- [Microsoft Docs: Minimal APIs in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)
