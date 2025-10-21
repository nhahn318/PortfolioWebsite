# Hướng dẫn Host Portfolio trên GitHub Pages

## Cách 1: Sử dụng GitHub Pages (Miễn phí)

### Bước 1: Tạo repository mới cho GitHub Pages
1. Tạo repository mới trên GitHub với tên: `nhahn318.github.io`
2. Clone repository về máy:
```bash
git clone https://github.com/nhahn318/nhahn318.github.io.git
cd nhahn318.github.io
```

### Bước 2: Copy files từ wwwroot
```bash
# Copy tất cả files từ wwwroot/ sang repository mới
cp -r PortfolioWebsite/wwwroot/* nhahn318.github.io/
```

### Bước 3: Push lên GitHub
```bash
cd nhahn318.github.io
git add .
git commit -m "Initial portfolio website"
git push origin main
```

### Bước 4: Enable GitHub Pages
1. Vào Settings của repository
2. Scroll xuống phần "Pages"
3. Source: Deploy from a branch
4. Branch: main
5. Folder: / (root)
6. Click Save

### Bước 5: Truy cập website
- URL: `https://nhahn318.github.io`
- Thời gian deploy: 5-10 phút

## Cách 2: Sử dụng subfolder (Giữ nguyên repository hiện tại)

### Bước 1: Tạo branch gh-pages
```bash
git checkout -b gh-pages
```

### Bước 2: Copy files wwwroot ra root
```bash
cp -r wwwroot/* .
```

### Bước 3: Commit và push
```bash
git add .
git commit -m "Setup GitHub Pages"
git push origin gh-pages
```

### Bước 4: Enable GitHub Pages
1. Vào Settings > Pages
2. Source: Deploy from a branch
3. Branch: gh-pages
4. Folder: / (root)

### Bước 5: Truy cập website
- URL: `https://nhahn318.github.io/PortfolioWebsite`

## Lưu ý quan trọng

### ✅ Những gì sẽ hoạt động:
- Website tĩnh (HTML, CSS, JS)
- Hình ảnh và assets
- Navigation và links
- Blog posts (nếu là static)

### ❌ Những gì KHÔNG hoạt động:
- ASP.NET Core backend
- Database connections
- API endpoints
- Server-side processing

### 🔧 Nếu cần backend:
- Sử dụng Vercel, Netlify, hoặc Azure Static Web Apps
- Hoặc deploy ASP.NET Core lên Azure, Heroku

## Khuyến nghị

**Cho portfolio đơn giản**: Sử dụng GitHub Pages (miễn phí, nhanh)
**Cho portfolio phức tạp**: Sử dụng Vercel/Netlify với backend
