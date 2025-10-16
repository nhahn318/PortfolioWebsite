using Microsoft.EntityFrameworkCore;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<PortfolioData> PortfolioData { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure owned/value objects and ignored properties for relational provider
            modelBuilder.Entity<PortfolioData>().OwnsOne(p => p.Contact);
            modelBuilder.Entity<PortfolioData>().Ignore(p => p.MusicPlayer);

            modelBuilder.Entity<PortfolioData>().HasData(
                new PortfolioData
                {
                    Id = 1,
                    Name = "TRAN NHAN",
                    Quote = "WORK HARD\nIN SILENCE\nLET SUCCESS\nMAKE NOISE",
                    BackgroundImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?ixlib=rb-4.0.3&auto=format&fit=crop&w=2070&q=80",
                    ProfileImageUrl = "https://images.unsplash.com/photo-1494790108755-2616b612b786?ixlib=rb-4.0.3&auto=format&fit=crop&w=687&q=80",
                    About = "Passionate developer with a love for clean code and innovative solutions.",
                    Resume = "/documents/resume.pdf",
                }
            );

            // Seed owned ContactInfo for PortfolioData (use shadow FK PortfolioDataId)
            modelBuilder.Entity<PortfolioData>().OwnsOne(p => p.Contact).HasData(
                new
                {
                    PortfolioDataId = 1,
                    Email = "xuan.dang@email.com",
                    Phone = "+1 (555) 123-4567",
                    LinkedIn = "https://linkedin.com/in/xuandang",
                    GitHub = "https://github.com/xuandang",
                    Location = "New York, NY"
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "E-Commerce Platform",
                    Description = "Full-stack e-commerce solution with payment integration",
                    ImageUrl = "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    Technologies = "ASP.NET Core, React, SQL Server, Azure",
                    ProjectUrl = "https://github.com/xuandang/ecommerce"
                },
                new Project
                {
                    Id = 2,
                    Title = "Task Management App",
                    Description = "Collaborative task management with real-time updates",
                    ImageUrl = "https://images.unsplash.com/photo-1611224923853-80b023f02d71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    Technologies = "ASP.NET Core, SignalR, Entity Framework",
                    ProjectUrl = "https://github.com/xuandang/taskmanager"
                },
                new Project
                {
                    Id = 3,
                    Title = "Portfolio Website",
                    Description = "Modern responsive portfolio website with API integration",
                    ImageUrl = "https://images.unsplash.com/photo-1467232004584-a241de8bcf5d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    Technologies = "ASP.NET Core, HTML5, CSS3, JavaScript",
                    ProjectUrl = "https://github.com/xuandang/portfolio"
                }
            );

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Id = 1,
                    Title = "Java vs JavaScript: So sánh hai ngôn ngữ lập trình phổ biến",
                    Content = @"<h2>Giới thiệu</h2>
<p>Java và JavaScript là hai ngôn ngữ lập trình rất phổ biến trong thế giới công nghệ hiện tại. Mặc dù có tên gọi tương tự nhau, nhưng chúng có những đặc điểm và mục đích sử dụng hoàn toàn khác nhau.</p>

<h2>Java - Ngôn ngữ lập trình hướng đối tượng</h2>
<p>Java là ngôn ngữ lập trình hướng đối tượng, được biên dịch thành bytecode và chạy trên JVM. Java có hiệu suất cao, bảo mật tốt và phù hợp cho các ứng dụng enterprise.</p>

<h2>JavaScript - Ngôn ngữ lập trình đa nền tảng</h2>
<p>JavaScript là ngôn ngữ interpreted, chạy trên trình duyệt và có thể phát triển full-stack với Node.js. JavaScript dễ học, phát triển nhanh và có ecosystem phong phú.</p>

<h2>Kết luận</h2>
<p>Việc lựa chọn ngôn ngữ phụ thuộc vào mục đích sử dụng, quy mô dự án và yêu cầu hiệu suất. Cả hai đều có ưu điểm riêng và phù hợp cho các tình huống khác nhau.</p>",
                    Excerpt = "So sánh chi tiết giữa Java và JavaScript - hai ngôn ngữ lập trình phổ biến nhất hiện nay.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    UpdatedDate = DateTime.Now.AddDays(-1),
                    Category = "Lập trình",
                    Tags = new List<string> { "Java", "JavaScript", "Lập trình", "So sánh" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 1250
                },
                new BlogPost
                {
                    Id = 2,
                    Title = "Học Java từ cơ bản đến nâng cao: Hướng dẫn chi tiết",
                    Content = @"<h2>Giới thiệu về Java</h2>
<p>Java là một trong những ngôn ngữ lập trình phổ biến nhất thế giới, được sử dụng rộng rãi trong phát triển ứng dụng web, mobile và enterprise.</p>

<h2>Cài đặt môi trường phát triển</h2>
<p>Để bắt đầu học Java, bạn cần cài đặt JDK (Java Development Kit) và một IDE như IntelliJ IDEA hoặc Eclipse.</p>

<h2>Cú pháp cơ bản</h2>
<p>Java có cú pháp rõ ràng và dễ hiểu. Mọi chương trình Java đều bắt đầu từ phương thức main().</p>

<h2>Hướng dẫn thực hành</h2>
<p>Học Java cần thực hành nhiều. Bắt đầu với các bài tập đơn giản và dần dần nâng cao độ khó.</p>",
                    Excerpt = "Hướng dẫn học Java từ cơ bản đến nâng cao với các ví dụ thực tế và bài tập thực hành.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-4),
                    UpdatedDate = DateTime.Now.AddDays(-2),
                    Category = "Java",
                    Tags = new List<string> { "Java", "Học lập trình", "Cơ bản", "Hướng dẫn" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1522202176988-66273c2fd55f?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 980
                },
                new BlogPost
                {
                    Id = 3,
                    Title = "JavaScript ES6+: Những tính năng mới bạn cần biết",
                    Content = @"<h2>Giới thiệu ES6+</h2>
<p>ES6 (ECMAScript 2015) đã mang đến nhiều tính năng mới mạnh mẽ cho JavaScript, làm cho việc lập trình trở nên dễ dàng và hiệu quả hơn.</p>

<h2>Arrow Functions</h2>
<p>Arrow functions cung cấp cú pháp ngắn gọn hơn cho việc viết functions và tự động bind this.</p>

<h2>Template Literals</h2>
<p>Template literals cho phép nhúng biến vào chuỗi một cách dễ dàng với cú pháp ${}.</p>

<h2>Destructuring</h2>
<p>Destructuring assignment cho phép trích xuất dữ liệu từ arrays và objects một cách nhanh chóng.</p>

<h2>Classes</h2>
<p>ES6 giới thiệu cú pháp class giúp việc lập trình hướng đối tượng trong JavaScript trở nên rõ ràng hơn.</p>",
                    Excerpt = "Khám phá những tính năng mới của JavaScript ES6+ và cách sử dụng chúng trong dự án thực tế.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-3),
                    UpdatedDate = DateTime.Now.AddDays(-1),
                    Category = "JavaScript",
                    Tags = new List<string> { "JavaScript", "ES6", "Tính năng mới", "Web Development" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 1100
                },
                new BlogPost
                {
                    Id = 4,
                    Title = "Spring Boot: Xây dựng REST API với Java",
                    Content = @"<h2>Giới thiệu Spring Boot</h2>
<p>Spring Boot là framework phổ biến nhất để phát triển ứng dụng Java, giúp tạo ra các ứng dụng web và microservices một cách nhanh chóng.</p>

<h2>Tạo dự án Spring Boot</h2>
<p>Sử dụng Spring Initializr để tạo dự án Spring Boot với các dependencies cần thiết.</p>

<h2>Xây dựng REST API</h2>
<p>Spring Boot cung cấp các annotation như @RestController, @RequestMapping để tạo REST API dễ dàng.</p>

<h2>Kết nối Database</h2>
<p>Spring Data JPA giúp kết nối và thao tác với database một cách đơn giản.</p>

<h2>Deploy ứng dụng</h2>
<p>Spring Boot hỗ trợ nhiều cách deploy từ JAR file đến Docker container.</p>",
                    Excerpt = "Hướng dẫn xây dựng REST API với Spring Boot - framework Java phổ biến nhất hiện nay.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    UpdatedDate = DateTime.Now,
                    Category = "Java",
                    Tags = new List<string> { "Spring Boot", "Java", "REST API", "Backend" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1555066931-4365d14bab8c?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 850
                },
                new BlogPost
                {
                    Id = 5,
                    Title = "React.js: Xây dựng giao diện người dùng hiện đại",
                    Content = @"<h2>Giới thiệu React.js</h2>
<p>React.js là thư viện JavaScript phổ biến nhất để xây dựng giao diện người dùng, được phát triển bởi Facebook.</p>

<h2>Components và JSX</h2>
<p>React sử dụng components để chia nhỏ giao diện thành các phần có thể tái sử dụng. JSX cho phép viết HTML trong JavaScript.</p>

<h2>State và Props</h2>
<p>State quản lý dữ liệu nội bộ của component, trong khi Props truyền dữ liệu từ component cha xuống component con.</p>

<h2>Hooks</h2>
<p>React Hooks cho phép sử dụng state và lifecycle methods trong functional components.</p>

<h2>Ecosystem phong phú</h2>
<p>React có ecosystem rất phong phú với nhiều thư viện hỗ trợ như Redux, React Router, Material-UI.</p>",
                    Excerpt = "Học React.js từ cơ bản đến nâng cao để xây dựng giao diện người dùng hiện đại và tương tác.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    UpdatedDate = DateTime.Now,
                    Category = "JavaScript",
                    Tags = new List<string> { "React", "JavaScript", "Frontend", "UI/UX" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1633356122544-f134324a6cee?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 1200
                },
                new BlogPost
                {
                    Id = 6,
                    Title = "Node.js: JavaScript phía server",
                    Content = @"<h2>Giới thiệu Node.js</h2>
<p>Node.js cho phép chạy JavaScript trên server, tạo ra khả năng phát triển full-stack chỉ với một ngôn ngữ.</p>

<h2>Event-driven Architecture</h2>
<p>Node.js sử dụng event-driven, non-blocking I/O model, giúp xử lý nhiều kết nối đồng thời hiệu quả.</p>

<h2>NPM Ecosystem</h2>
<p>NPM (Node Package Manager) cung cấp hàng triệu packages để mở rộng chức năng của ứng dụng Node.js.</p>

<h2>Express.js Framework</h2>
<p>Express.js là framework web phổ biến nhất cho Node.js, giúp tạo server và API một cách nhanh chóng.</p>

<h2>Real-time Applications</h2>
<p>Node.js rất phù hợp cho các ứng dụng real-time như chat, gaming, collaboration tools.</p>",
                    Excerpt = "Khám phá Node.js - nền tảng cho phép chạy JavaScript trên server và xây dựng ứng dụng full-stack.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-6),
                    UpdatedDate = DateTime.Now.AddDays(-3),
                    Category = "JavaScript",
                    Tags = new List<string> { "Node.js", "JavaScript", "Backend", "Full-stack" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1627398242454-45a1465c2479?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 900
                },
                new BlogPost
                {
                    Id = 7,
                    Title = "Java Collections Framework: Quản lý dữ liệu hiệu quả",
                    Content = @"<h2>Giới thiệu Collections Framework</h2>
<p>Java Collections Framework cung cấp các cấu trúc dữ liệu và thuật toán để quản lý nhóm các đối tượng một cách hiệu quả.</p>

<h2>List Interface</h2>
<p>ArrayList và LinkedList là hai implementation phổ biến của List interface, mỗi loại có ưu nhược điểm riêng.</p>

<h2>Set Interface</h2>
<p>HashSet, LinkedHashSet và TreeSet cung cấp các cách khác nhau để lưu trữ các phần tử duy nhất.</p>

<h2>Map Interface</h2>
<p>HashMap, LinkedHashMap và TreeMap giúp lưu trữ dữ liệu dạng key-value với các đặc tính khác nhau.</p>

<h2>Best Practices</h2>
<p>Hiểu rõ đặc điểm của từng collection sẽ giúp chọn lựa phù hợp và tối ưu hiệu suất ứng dụng.</p>",
                    Excerpt = "Tìm hiểu Java Collections Framework để quản lý và thao tác với dữ liệu một cách hiệu quả trong Java.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-7),
                    UpdatedDate = DateTime.Now.AddDays(-4),
                    Category = "Java",
                    Tags = new List<string> { "Java", "Collections", "Data Structures", "Performance" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 750
                },
                new BlogPost
                {
                    Id = 8,
                    Title = "Async/Await trong JavaScript: Lập trình bất đồng bộ hiện đại",
                    Content = @"<h2>Giới thiệu Async/Await</h2>
<p>Async/await là cú pháp hiện đại để xử lý các tác vụ bất đồng bộ trong JavaScript một cách dễ đọc và dễ hiểu.</p>

<h2>Promise vs Async/Await</h2>
<p>Async/await được xây dựng trên Promise nhưng cung cấp cú pháp đồng bộ để xử lý code bất đồng bộ.</p>

<h2>Cú pháp cơ bản</h2>
<p>Sử dụng từ khóa async để khai báo function bất đồng bộ và await để chờ kết quả của Promise.</p>

<h2>Error Handling</h2>
<p>Xử lý lỗi trong async/await sử dụng try-catch block giống như code đồng bộ thông thường.</p>

<h2>Thực hành với API</h2>
<p>Async/await rất hữu ích khi làm việc với API calls, file operations và các tác vụ I/O khác.</p>",
                    Excerpt = "Học cách sử dụng async/await để viết code JavaScript bất đồng bộ một cách sạch sẽ và dễ hiểu.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-8),
                    UpdatedDate = DateTime.Now.AddDays(-5),
                    Category = "JavaScript",
                    Tags = new List<string> { "JavaScript", "Async", "Promise", "Asynchronous" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 1050
                },
                new BlogPost
                {
                    Id = 9,
                    Title = "JUnit Testing trong Java: Viết test case hiệu quả",
                    Content = @"<h2>Giới thiệu JUnit</h2>
<p>JUnit là framework testing phổ biến nhất cho Java, giúp đảm bảo chất lượng code thông qua việc viết và chạy các test case.</p>

<h2>Annotations quan trọng</h2>
<p>@Test, @BeforeEach, @AfterEach, @BeforeAll, @AfterAll là những annotation cơ bản trong JUnit 5.</p>

<h2>Assertions</h2>
<p>JUnit cung cấp nhiều assertion methods như assertEquals, assertTrue, assertNotNull để kiểm tra kết quả mong đợi.</p>

<h2>Test Lifecycle</h2>
<p>Hiểu rõ lifecycle của test giúp setup và cleanup dữ liệu test một cách hiệu quả.</p>

<h2>Best Practices</h2>
<p>Viết test case tốt cần tuân theo các nguyên tắc như AAA (Arrange, Act, Assert) và FIRST (Fast, Independent, Repeatable, Self-validating, Timely).</p>",
                    Excerpt = "Hướng dẫn sử dụng JUnit để viết test case hiệu quả và đảm bảo chất lượng code Java.",
                    Author = "TRAN NHAN",
                    CreatedDate = DateTime.Now.AddDays(-9),
                    UpdatedDate = DateTime.Now.AddDays(-6),
                    Category = "Java",
                    Tags = new List<string> { "Java", "JUnit", "Testing", "Quality Assurance" },
                    FeaturedImageUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                    IsPublished = true,
                    ViewCount = 680
                }
            );
        }
    }
}
