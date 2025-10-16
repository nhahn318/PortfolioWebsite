# PowerShell script to add Java blog posts
$posts = Get-Content -Path "java_blog_posts.json" -Raw | ConvertFrom-Json

foreach ($post in $posts) {
    $body = @{
        title = $post.title
        content = $post.content
        excerpt = $post.excerpt
        author = $post.author
        category = $post.category
        tags = $post.tags
        featuredImageUrl = $post.featuredImageUrl
        isPublished = $post.isPublished
    } | ConvertTo-Json -Depth 10

    try {
        $response = Invoke-RestMethod -Uri "http://localhost:5000/api/blog" -Method POST -Body $body -ContentType "application/json"
        Write-Host "Added post: $($post.title)" -ForegroundColor Green
    }
    catch {
        Write-Host "Error adding post: $($post.title)" -ForegroundColor Red
        Write-Host $_.Exception.Message
    }
}
