# Script tự động setup GitHub Pages
# Chạy: .\setup_github_pages.ps1

Write-Host "🚀 Setting up GitHub Pages for Portfolio..." -ForegroundColor Green

# Tạo branch gh-pages nếu chưa có
Write-Host "📝 Creating gh-pages branch..." -ForegroundColor Yellow
git checkout -b gh-pages 2>$null

# Copy files từ wwwroot ra root
Write-Host "📁 Copying files from wwwroot..." -ForegroundColor Yellow
Copy-Item -Path "wwwroot\*" -Destination "." -Recurse -Force

# Xóa các file không cần thiết cho GitHub Pages
Write-Host "🧹 Cleaning up unnecessary files..." -ForegroundColor Yellow
Remove-Item -Path "*.csproj" -Force -ErrorAction SilentlyContinue
Remove-Item -Path "*.sln" -Force -ErrorAction SilentlyContinue
Remove-Item -Path "Controllers" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "Data" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "Models" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "Migrations" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "bin" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "obj" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "Program.cs" -Force -ErrorAction SilentlyContinue
Remove-Item -Path "appsettings.json" -Force -ErrorAction SilentlyContinue
Remove-Item -Path "*.backup" -Force -ErrorAction SilentlyContinue

# Tạo file .nojekyll để GitHub Pages không xử lý Jekyll
Write-Host "📄 Creating .nojekyll file..." -ForegroundColor Yellow
New-Item -Path ".nojekyll" -ItemType File -Force

# Add và commit
Write-Host "💾 Committing changes..." -ForegroundColor Yellow
git add .
git commit -m "Setup GitHub Pages - Static portfolio website"

# Push lên GitHub
Write-Host "🚀 Pushing to GitHub..." -ForegroundColor Yellow
git push origin gh-pages

Write-Host "✅ Setup complete!" -ForegroundColor Green
Write-Host "🌐 Your website will be available at: https://nhahn318.github.io/PortfolioWebsite" -ForegroundColor Cyan
Write-Host "⏰ Please wait 5-10 minutes for GitHub Pages to deploy" -ForegroundColor Yellow
Write-Host ""
Write-Host "📋 Next steps:" -ForegroundColor White
Write-Host "1. Go to your repository Settings" -ForegroundColor White
Write-Host "2. Scroll to 'Pages' section" -ForegroundColor White
Write-Host "3. Source: Deploy from a branch" -ForegroundColor White
Write-Host "4. Branch: gh-pages" -ForegroundColor White
Write-Host "5. Folder: / (root)" -ForegroundColor White
Write-Host "6. Click Save" -ForegroundColor White