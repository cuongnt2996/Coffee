# 🧭 HƯỚNG DẪN SỬ DỤNG GIT CHO DỰ ÁN ASP.NET MVC (.NET)

> Tài liệu này hướng dẫn quy trình làm việc với Git từ đầu đến khi đẩy code lên GitHub, dành cho dự án ASP.NET MVC hoặc .NET nói chung.

---

## 1️⃣ Cấu hình ban đầu

### Kiểm tra Git đã cài chưa:
```bash
git --version
```

Nếu chưa có, tải Git tại: [https://git-scm.com/downloads](https://git-scm.com/downloads)

---

## 2️⃣ Kết nối dự án với Git

### Khởi tạo Git trong thư mục dự án:
```bash
git init
```

### Thêm file `.gitignore` chuẩn cho .NET:
Tạo file `.gitignore` (nếu chưa có) rồi dán nội dung từ mẫu chính thức:
👉 [https://github.com/github/gitignore/blob/main/VisualStudio.gitignore](https://github.com/github/gitignore/blob/main/VisualStudio.gitignore)

---

## 3️⃣ Kết nối với GitHub

### Tạo repo mới trên GitHub:
- Vào GitHub → **New Repository** → nhập tên dự án
- Chọn **Private** hoặc **Public**
- KHÔNG chọn “Add README” (để tránh xung đột)

### Kết nối dự án local với repo:
```bash
git remote add origin https://github.com/<username>/<repo-name>.git
```

---

## 4️⃣ Quy trình commit và push code

### Kiểm tra trạng thái:
```bash
git status
```

### Thêm tất cả file thay đổi:
```bash
git add .
```

### Tạo commit:
```bash
git commit -m "Mô tả thay đổi (ví dụ: thêm User model)"
```

### Đẩy code lên GitHub:
```bash
git push origin main
```

> ⚠️ Nếu lỗi “no upstream branch”, dùng:
> ```bash
> git branch -M main
> git push -u origin main
> ```

---

## 5️⃣ Kiểm tra kết quả

Sau khi push xong:
- Mở GitHub repo của bạn
- Nếu thấy commit và folder xuất hiện → ✅ Thành công

---

## 6️⃣ Cập nhật code khi làm việc nhóm

### Lấy code mới nhất:
```bash
git pull origin main
```

### Nếu có xung đột:
- Mở file có ký hiệu:
  ```
  <<<<<<< HEAD
  (code của bạn)
  =======
  (code người khác)
  >>>>>>>
  ```
- Giữ đoạn đúng, xoá ký hiệu, rồi:
  ```bash
  git add .
  git commit -m "resolve conflict"
  git push
  ```

---

## 7️⃣ Làm việc với nhánh (branch)

### Tạo nhánh mới:
```bash
git checkout -b feature/add-user-page
```

### Chuyển nhánh:
```bash
git checkout main
```

### Gộp nhánh:
```bash
git merge feature/add-user-page
```

### Xóa nhánh sau khi merge:
```bash
git branch -d feature/add-user-page
```

---

## 8️⃣ Chuẩn commit chuyên nghiệp

| Loại commit | Mục đích | Ví dụ |
|--------------|-----------|--------|
| `feat:` | Thêm tính năng mới | `feat: thêm module quản lý nhân viên` |
| `fix:` | Sửa lỗi | `fix: lỗi không lưu được User` |
| `docs:` | Cập nhật tài liệu | `docs: thêm hướng dẫn Git` |
| `refactor:` | Tối ưu code | `refactor: tách logic ra service` |
| `chore:` | Cập nhật nhỏ (config, build, v.v.) | `chore: chỉnh sửa .gitignore` |

---

## 9️⃣ Các lệnh Git hữu ích

| Lệnh | Ý nghĩa |
|------|----------|
| `git log --oneline` | Xem lịch sử commit |
| `git diff` | So sánh thay đổi |
| `git restore <file>` | Hoàn tác thay đổi chưa commit |
| `git reset --hard HEAD~1` | Xóa commit cuối |
| `git rm --cached <file>` | Gỡ file khỏi Git nhưng vẫn giữ local |
| `git branch` | Xem nhánh hiện tại |
| `git remote -v` | Kiểm tra kết nối GitHub |

---

## 🔟 Kiểm tra `.gitignore` hoạt động tốt

```bash
git status
```

Nếu không thấy các thư mục `bin/`, `obj/`, `.vs/` → `.gitignore` đang hoạt động đúng ✅

---

## ✅ Quy trình làm việc hằng ngày

1. Lấy code mới nhất:
   ```bash
   git pull origin main
   ```
2. Chỉnh sửa code  
3. Thêm file mới hoặc thay đổi:
   ```bash
   git add .
   ```
4. Commit:
   ```bash
   git commit -m "feat: mô tả thay đổi"
   ```
5. Đẩy lên GitHub:
   ```bash
   git push origin main
   ```

---

## ✨ Dành cho Visual Studio / VS Code

Nếu bạn dùng VS hoặc VS Code:
- Dùng tab **Source Control (Ctrl + Shift + G)** để commit, push, pull.
- Thấy biểu tượng “U” (Untracked), “M” (Modified) trong danh sách file.
- Tất cả đều đồng bộ với các lệnh Git CLI.

---

## 📎 Thông tin
**Tác giả:** Nguyễn Tấn Cường  
**Dự án:** Coffee Management (ASP.NET MVC)  
**Cập nhật:** 30/10/2025  
