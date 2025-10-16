using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<BlogPost>> GetBlogPosts()
        {
            var posts = GetStaticBlogPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(int id)
        {
            var posts = GetStaticBlogPosts();
            var post = posts.FirstOrDefault(p => p.Id == id);

            if (post == null || !post.IsPublished)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet("featured")]
        public ActionResult<IEnumerable<BlogPost>> GetFeaturedPosts()
        {
            var posts = GetStaticBlogPosts()
                .OrderByDescending(p => p.ViewCount)
                .Take(3)
                .ToList();

            return Ok(posts);
        }

        [HttpGet("category/{category}")]
        public ActionResult<IEnumerable<BlogPost>> GetPostsByCategory(string category)
        {
            var posts = GetStaticBlogPosts()
                .Where(p => p.IsPublished && p.Category.ToLower() == category.ToLower())
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

            return Ok(posts);
        }

        private List<BlogPost> GetStaticBlogPosts()
        {
            return new List<BlogPost>
            {
                new BlogPost
                {
                    Id = 1,
                    Title = "Java Fundamentals và Lập Trình Hướng Đối Tượng: Hướng Dẫn Toàn Diện",
                    Content = "# Java Fundamentals và Lập Trình Hướng Đối Tượng: Hướng Dẫn Toàn Diện\n\n## Giới thiệu về Java\n\nJava là một ngôn ngữ lập trình mạnh mẽ, được thiết kế để có thể chạy trên bất kỳ nền tảng nào thông qua Java Virtual Machine (JVM). Được phát triển bởi Sun Microsystems vào năm 1995, Java đã trở thành một trong những ngôn ngữ lập trình phổ biến nhất thế giới.\n\n### Đặc điểm nổi bật của Java:\n\n1. **Write Once, Run Anywhere (WORA)**: Code Java có thể chạy trên bất kỳ hệ điều hành nào có JVM\n2. **Object-Oriented**: Hoàn toàn hướng đối tượng\n3. **Platform Independent**: Độc lập với nền tảng\n4. **Secure**: Có hệ thống bảo mật mạnh mẽ\n5. **Multithreaded**: Hỗ trợ đa luồng\n6. **Dynamic**: Có thể tải class động",
                    Excerpt = "Khám phá những kiến thức cơ bản và nâng cao về Java, từ cú pháp cơ bản đến lập trình hướng đối tượng. Hướng dẫn toàn diện với ví dụ thực tế và best practices.",
                    Author = "TRAN NHAN",
                    Category = "Java",
                    Tags = new List<string> { "Java", "OOP", "Programming", "Fundamentals" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Java+Programming",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-01-15T10:00:00Z"),
                    UpdatedDate = DateTime.Parse("2024-01-15T10:00:00Z"),
                    ViewCount = 1250
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "React.js: Xây Dựng Ứng Dụng Web Hiện Đại",
                    Content = "# React.js: Xây Dựng Ứng Dụng Web Hiện Đại\n\n## Giới thiệu về React\n\nReact là một thư viện JavaScript được phát triển bởi Facebook để xây dựng giao diện người dùng, đặc biệt là cho các ứng dụng web đơn trang (SPA).\n\n### Tại sao nên sử dụng React?\n\n1. **Component-based**: Xây dựng UI từ các component tái sử dụng\n2. **Virtual DOM**: Hiệu suất cao nhờ Virtual DOM\n3. **One-way data flow**: Dữ liệu chảy một chiều, dễ debug\n4. **Ecosystem phong phú**: Nhiều thư viện và tool hỗ trợ\n5. **Community lớn**: Cộng đồng phát triển mạnh",
                    Excerpt = "Tìm hiểu cách xây dựng ứng dụng web hiện đại với React.js. Từ component cơ bản đến state management và best practices.",
                    Author = "TRAN NHAN",
                    Category = "Web Development",
                    Tags = new List<string> { "React", "JavaScript", "Frontend", "Web Development" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=React+JS",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-01-20T14:30:00Z"),
                    UpdatedDate = DateTime.Parse("2024-01-20T14:30:00Z"),
                    ViewCount = 980
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "Node.js và Express: Xây Dựng Backend API",
                    Content = "# Node.js và Express: Xây Dựng Backend API\n\n## Giới thiệu về Node.js\n\nNode.js là một runtime environment cho JavaScript, cho phép chạy JavaScript trên server-side. Được xây dựng trên V8 JavaScript engine của Chrome.\n\n### Ưu điểm của Node.js\n\n1. **JavaScript everywhere**: Sử dụng cùng ngôn ngữ cho frontend và backend\n2. **Non-blocking I/O**: Xử lý bất đồng bộ hiệu quả\n3. **NPM ecosystem**: Hệ sinh thái package phong phú\n4. **Scalable**: Dễ dàng scale ứng dụng\n5. **Fast development**: Phát triển nhanh chóng",
                    Excerpt = "Học cách xây dựng backend API với Node.js và Express. Từ server cơ bản đến RESTful API và middleware.",
                    Author = "TRAN NHAN",
                    Category = "Backend",
                    Tags = new List<string> { "Node.js", "Express", "Backend", "API" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Node.js+Express",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-01-25T09:15:00Z"),
                    UpdatedDate = DateTime.Parse("2024-01-25T09:15:00Z"),
                    ViewCount = 756
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Python Django: Framework Web Mạnh Mẽ",
                    Content = "# Python Django: Framework Web Mạnh Mẽ\n\n## Giới thiệu về Django\n\nDjango là một web framework Python mạnh mẽ và phổ biến, được thiết kế để giúp developers xây dựng ứng dụng web nhanh chóng và an toàn.\n\n### Tại sao chọn Django?\n\n1. **Batteries included**: Có sẵn nhiều tính năng\n2. **Security**: Bảo mật cao, chống các lỗ hổng phổ biến\n3. **Scalable**: Có thể scale cho các ứng dụng lớn\n4. **Admin interface**: Giao diện admin tự động\n5. **ORM**: Object-Relational Mapping mạnh mẽ",
                    Excerpt = "Khám phá Django framework - một trong những web framework Python mạnh mẽ nhất. Từ models, views đến templates.",
                    Author = "TRAN NHAN",
                    Category = "Backend",
                    Tags = new List<string> { "Python", "Django", "Web Framework", "Backend" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Python+Django",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-01T11:45:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-01T11:45:00Z"),
                    ViewCount = 892
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "Vue.js: Progressive JavaScript Framework",
                    Content = "# Vue.js: Progressive JavaScript Framework\n\n## Giới thiệu về Vue.js\n\nVue.js là một progressive JavaScript framework được thiết kế để xây dựng giao diện người dùng. Vue được tạo ra bởi Evan You và được phát hành lần đầu vào năm 2014.\n\n### Đặc điểm nổi bật\n\n1. **Progressive**: Có thể tích hợp từng phần\n2. **Reactive**: Hệ thống reactivity mạnh mẽ\n3. **Component-based**: Kiến trúc component\n4. **Easy to learn**: Dễ học và sử dụng\n5. **Flexible**: Linh hoạt trong cách sử dụng",
                    Excerpt = "Tìm hiểu Vue.js - progressive JavaScript framework. Từ cú pháp cơ bản đến components và routing.",
                    Author = "TRAN NHAN",
                    Category = "Frontend",
                    Tags = new List<string> { "Vue.js", "JavaScript", "Frontend", "Framework" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Vue.js",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-05T16:20:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-05T16:20:00Z"),
                    ViewCount = 634
                },
                new BlogPost
                {
                    Id = 6,
                    Title = "MongoDB: NoSQL Database Hiện Đại",
                    Content = "# MongoDB: NoSQL Database Hiện Đại\n\n## Giới thiệu về MongoDB\n\nMongoDB là một NoSQL database document-oriented, được thiết kế để lưu trữ dữ liệu dạng JSON-like documents. MongoDB cung cấp hiệu suất cao và khả năng mở rộng tốt.\n\n### Ưu điểm của MongoDB\n\n1. **Flexible schema**: Schema linh hoạt\n2. **Horizontal scaling**: Mở rộng theo chiều ngang\n3. **Rich queries**: Hỗ trợ query phức tạp\n4. **Indexing**: Hệ thống index mạnh mẽ\n5. **Aggregation**: Pipeline aggregation",
                    Excerpt = "Khám phá MongoDB - NoSQL database hiện đại. Từ CRUD operations đến aggregation pipeline và best practices.",
                    Author = "TRAN NHAN",
                    Category = "Database",
                    Tags = new List<string> { "MongoDB", "NoSQL", "Database", "Document" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=MongoDB",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-10T13:10:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-10T13:10:00Z"),
                    ViewCount = 567
                },
                new BlogPost
                {
                    Id = 7,
                    Title = "Git và GitHub: Quản Lý Code Hiệu Quả",
                    Content = "# Git và GitHub: Quản Lý Code Hiệu Quả\n\n## Giới thiệu về Git\n\nGit là một hệ thống quản lý phiên bản phân tán (Distributed Version Control System), được tạo ra bởi Linus Torvalds vào năm 2005.\n\n### Tại sao cần Git?\n\n1. **Version control**: Theo dõi thay đổi code\n2. **Collaboration**: Làm việc nhóm hiệu quả\n3. **Backup**: Sao lưu code an toàn\n4. **Branching**: Tạo nhánh phát triển\n5. **History**: Lịch sử thay đổi chi tiết",
                    Excerpt = "Học cách sử dụng Git và GitHub để quản lý code hiệu quả. Từ các lệnh cơ bản đến branching và collaboration.",
                    Author = "TRAN NHAN",
                    Category = "Tools",
                    Tags = new List<string> { "Git", "GitHub", "Version Control", "Collaboration" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Git+GitHub",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-15T08:30:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-15T08:30:00Z"),
                    ViewCount = 1123
                },
                new BlogPost
                {
                    Id = 8,
                    Title = "Docker: Containerization Platform",
                    Content = "# Docker: Containerization Platform\n\n## Giới thiệu về Docker\n\nDocker là một platform cho phép đóng gói ứng dụng và dependencies của nó vào trong một container nhẹ, có thể chạy trên bất kỳ môi trường nào.\n\n### Lợi ích của Docker\n\n1. **Consistency**: Môi trường nhất quán\n2. **Portability**: Dễ dàng di chuyển\n3. **Scalability**: Mở rộng dễ dàng\n4. **Isolation**: Cô lập ứng dụng\n5. **Efficiency**: Sử dụng tài nguyên hiệu quả",
                    Excerpt = "Tìm hiểu Docker - platform containerization hàng đầu. Từ Dockerfile đến Docker Compose và best practices.",
                    Author = "TRAN NHAN",
                    Category = "DevOps",
                    Tags = new List<string> { "Docker", "Containerization", "DevOps", "Deployment" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=Docker",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-20T12:00:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-20T12:00:00Z"),
                    ViewCount = 445
                },
                new BlogPost
                {
                    Id = 9,
                    Title = "AWS Cloud Services: Triển Khai Ứng Dụng Lên Cloud",
                    Content = "# AWS Cloud Services: Triển Khai Ứng Dụng Lên Cloud\n\n## Giới thiệu về AWS\n\nAmazon Web Services (AWS) là một nền tảng cloud computing toàn diện, cung cấp hơn 200 dịch vụ từ data centers trên toàn thế giới.\n\n### Các dịch vụ AWS phổ biến\n\n1. **EC2**: Elastic Compute Cloud\n2. **S3**: Simple Storage Service\n3. **RDS**: Relational Database Service\n4. **Lambda**: Serverless Computing\n5. **CloudFront**: Content Delivery Network",
                    Excerpt = "Khám phá AWS Cloud Services - nền tảng cloud computing hàng đầu. Từ EC2, S3 đến Lambda và best practices.",
                    Author = "TRAN NHAN",
                    Category = "Cloud",
                    Tags = new List<string> { "AWS", "Cloud", "DevOps", "Infrastructure" },
                    FeaturedImageUrl = "https://via.placeholder.com/400x250?text=AWS+Cloud",
                    IsPublished = true,
                    CreatedDate = DateTime.Parse("2024-02-25T15:45:00Z"),
                    UpdatedDate = DateTime.Parse("2024-02-25T15:45:00Z"),
                    ViewCount = 678
                }
            };
        }

    }
}
