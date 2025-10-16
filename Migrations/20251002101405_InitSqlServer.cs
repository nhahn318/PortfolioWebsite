using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioWebsite.Migrations
{
    /// <inheritdoc />
    public partial class InitSqlServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excerpt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeaturedImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BackgroundImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalleryImages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_GitHub = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Technologies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortfolioDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_PortfolioData_PortfolioDataId",
                        column: x => x.PortfolioDataId,
                        principalTable: "PortfolioData",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Category", "Content", "CreatedDate", "Excerpt", "FeaturedImageUrl", "IsPublished", "Tags", "Title", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { 1, "TRAN NHAN", "Lập trình", "<h2>Giới thiệu</h2>\r\n<p>Java và JavaScript là hai ngôn ngữ lập trình rất phổ biến trong thế giới công nghệ hiện tại. Mặc dù có tên gọi tương tự nhau, nhưng chúng có những đặc điểm và mục đích sử dụng hoàn toàn khác nhau.</p>\r\n\r\n<h2>Java - Ngôn ngữ lập trình hướng đối tượng</h2>\r\n<p>Java là ngôn ngữ lập trình hướng đối tượng, được biên dịch thành bytecode và chạy trên JVM. Java có hiệu suất cao, bảo mật tốt và phù hợp cho các ứng dụng enterprise.</p>\r\n\r\n<h2>JavaScript - Ngôn ngữ lập trình đa nền tảng</h2>\r\n<p>JavaScript là ngôn ngữ interpreted, chạy trên trình duyệt và có thể phát triển full-stack với Node.js. JavaScript dễ học, phát triển nhanh và có ecosystem phong phú.</p>\r\n\r\n<h2>Kết luận</h2>\r\n<p>Việc lựa chọn ngôn ngữ phụ thuộc vào mục đích sử dụng, quy mô dự án và yêu cầu hiệu suất. Cả hai đều có ưu điểm riêng và phù hợp cho các tình huống khác nhau.</p>", new DateTime(2025, 9, 27, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6432), "So sánh chi tiết giữa Java và JavaScript - hai ngôn ngữ lập trình phổ biến nhất hiện nay.", "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Java\",\"JavaScript\",\"L\\u1EADp tr\\u00ECnh\",\"So s\\u00E1nh\"]", "Java vs JavaScript: So sánh hai ngôn ngữ lập trình phổ biến", new DateTime(2025, 10, 1, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6494), 1250 },
                    { 2, "TRAN NHAN", "Java", "<h2>Giới thiệu về Java</h2>\r\n<p>Java là một trong những ngôn ngữ lập trình phổ biến nhất thế giới, được sử dụng rộng rãi trong phát triển ứng dụng web, mobile và enterprise.</p>\r\n\r\n<h2>Cài đặt môi trường phát triển</h2>\r\n<p>Để bắt đầu học Java, bạn cần cài đặt JDK (Java Development Kit) và một IDE như IntelliJ IDEA hoặc Eclipse.</p>\r\n\r\n<h2>Cú pháp cơ bản</h2>\r\n<p>Java có cú pháp rõ ràng và dễ hiểu. Mọi chương trình Java đều bắt đầu từ phương thức main().</p>\r\n\r\n<h2>Hướng dẫn thực hành</h2>\r\n<p>Học Java cần thực hành nhiều. Bắt đầu với các bài tập đơn giản và dần dần nâng cao độ khó.</p>", new DateTime(2025, 9, 28, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6521), "Hướng dẫn học Java từ cơ bản đến nâng cao với các ví dụ thực tế và bài tập thực hành.", "https://images.unsplash.com/photo-1522202176988-66273c2fd55f?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Java\",\"H\\u1ECDc l\\u1EADp tr\\u00ECnh\",\"C\\u01A1 b\\u1EA3n\",\"H\\u01B0\\u1EDBng d\\u1EABn\"]", "Học Java từ cơ bản đến nâng cao: Hướng dẫn chi tiết", new DateTime(2025, 9, 30, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6522), 980 },
                    { 3, "TRAN NHAN", "JavaScript", "<h2>Giới thiệu ES6+</h2>\r\n<p>ES6 (ECMAScript 2015) đã mang đến nhiều tính năng mới mạnh mẽ cho JavaScript, làm cho việc lập trình trở nên dễ dàng và hiệu quả hơn.</p>\r\n\r\n<h2>Arrow Functions</h2>\r\n<p>Arrow functions cung cấp cú pháp ngắn gọn hơn cho việc viết functions và tự động bind this.</p>\r\n\r\n<h2>Template Literals</h2>\r\n<p>Template literals cho phép nhúng biến vào chuỗi một cách dễ dàng với cú pháp ${}.</p>\r\n\r\n<h2>Destructuring</h2>\r\n<p>Destructuring assignment cho phép trích xuất dữ liệu từ arrays và objects một cách nhanh chóng.</p>\r\n\r\n<h2>Classes</h2>\r\n<p>ES6 giới thiệu cú pháp class giúp việc lập trình hướng đối tượng trong JavaScript trở nên rõ ràng hơn.</p>", new DateTime(2025, 9, 29, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6534), "Khám phá những tính năng mới của JavaScript ES6+ và cách sử dụng chúng trong dự án thực tế.", "https://images.unsplash.com/photo-1579468118864-1b9ea3c0db4a?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"JavaScript\",\"ES6\",\"T\\u00EDnh n\\u0103ng m\\u1EDBi\",\"Web Development\"]", "JavaScript ES6+: Những tính năng mới bạn cần biết", new DateTime(2025, 10, 1, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6544), 1100 },
                    { 4, "TRAN NHAN", "Java", "<h2>Giới thiệu Spring Boot</h2>\r\n<p>Spring Boot là framework phổ biến nhất để phát triển ứng dụng Java, giúp tạo ra các ứng dụng web và microservices một cách nhanh chóng.</p>\r\n\r\n<h2>Tạo dự án Spring Boot</h2>\r\n<p>Sử dụng Spring Initializr để tạo dự án Spring Boot với các dependencies cần thiết.</p>\r\n\r\n<h2>Xây dựng REST API</h2>\r\n<p>Spring Boot cung cấp các annotation như @RestController, @RequestMapping để tạo REST API dễ dàng.</p>\r\n\r\n<h2>Kết nối Database</h2>\r\n<p>Spring Data JPA giúp kết nối và thao tác với database một cách đơn giản.</p>\r\n\r\n<h2>Deploy ứng dụng</h2>\r\n<p>Spring Boot hỗ trợ nhiều cách deploy từ JAR file đến Docker container.</p>", new DateTime(2025, 9, 30, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6553), "Hướng dẫn xây dựng REST API với Spring Boot - framework Java phổ biến nhất hiện nay.", "https://images.unsplash.com/photo-1555066931-4365d14bab8c?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Spring Boot\",\"Java\",\"REST API\",\"Backend\"]", "Spring Boot: Xây dựng REST API với Java", new DateTime(2025, 10, 2, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6554), 850 },
                    { 5, "TRAN NHAN", "JavaScript", "<h2>Giới thiệu React.js</h2>\r\n<p>React.js là thư viện JavaScript phổ biến nhất để xây dựng giao diện người dùng, được phát triển bởi Facebook.</p>\r\n\r\n<h2>Components và JSX</h2>\r\n<p>React sử dụng components để chia nhỏ giao diện thành các phần có thể tái sử dụng. JSX cho phép viết HTML trong JavaScript.</p>\r\n\r\n<h2>State và Props</h2>\r\n<p>State quản lý dữ liệu nội bộ của component, trong khi Props truyền dữ liệu từ component cha xuống component con.</p>\r\n\r\n<h2>Hooks</h2>\r\n<p>React Hooks cho phép sử dụng state và lifecycle methods trong functional components.</p>\r\n\r\n<h2>Ecosystem phong phú</h2>\r\n<p>React có ecosystem rất phong phú với nhiều thư viện hỗ trợ như Redux, React Router, Material-UI.</p>", new DateTime(2025, 10, 1, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6734), "Học React.js từ cơ bản đến nâng cao để xây dựng giao diện người dùng hiện đại và tương tác.", "https://images.unsplash.com/photo-1633356122544-f134324a6cee?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"React\",\"JavaScript\",\"Frontend\",\"UI/UX\"]", "React.js: Xây dựng giao diện người dùng hiện đại", new DateTime(2025, 10, 2, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6735), 1200 },
                    { 6, "TRAN NHAN", "JavaScript", "<h2>Giới thiệu Node.js</h2>\r\n<p>Node.js cho phép chạy JavaScript trên server, tạo ra khả năng phát triển full-stack chỉ với một ngôn ngữ.</p>\r\n\r\n<h2>Event-driven Architecture</h2>\r\n<p>Node.js sử dụng event-driven, non-blocking I/O model, giúp xử lý nhiều kết nối đồng thời hiệu quả.</p>\r\n\r\n<h2>NPM Ecosystem</h2>\r\n<p>NPM (Node Package Manager) cung cấp hàng triệu packages để mở rộng chức năng của ứng dụng Node.js.</p>\r\n\r\n<h2>Express.js Framework</h2>\r\n<p>Express.js là framework web phổ biến nhất cho Node.js, giúp tạo server và API một cách nhanh chóng.</p>\r\n\r\n<h2>Real-time Applications</h2>\r\n<p>Node.js rất phù hợp cho các ứng dụng real-time như chat, gaming, collaboration tools.</p>", new DateTime(2025, 9, 26, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6740), "Khám phá Node.js - nền tảng cho phép chạy JavaScript trên server và xây dựng ứng dụng full-stack.", "https://images.unsplash.com/photo-1627398242454-45a1465c2479?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Node.js\",\"JavaScript\",\"Backend\",\"Full-stack\"]", "Node.js: JavaScript phía server", new DateTime(2025, 9, 29, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6741), 900 },
                    { 7, "TRAN NHAN", "Java", "<h2>Giới thiệu Collections Framework</h2>\r\n<p>Java Collections Framework cung cấp các cấu trúc dữ liệu và thuật toán để quản lý nhóm các đối tượng một cách hiệu quả.</p>\r\n\r\n<h2>List Interface</h2>\r\n<p>ArrayList và LinkedList là hai implementation phổ biến của List interface, mỗi loại có ưu nhược điểm riêng.</p>\r\n\r\n<h2>Set Interface</h2>\r\n<p>HashSet, LinkedHashSet và TreeSet cung cấp các cách khác nhau để lưu trữ các phần tử duy nhất.</p>\r\n\r\n<h2>Map Interface</h2>\r\n<p>HashMap, LinkedHashMap và TreeMap giúp lưu trữ dữ liệu dạng key-value với các đặc tính khác nhau.</p>\r\n\r\n<h2>Best Practices</h2>\r\n<p>Hiểu rõ đặc điểm của từng collection sẽ giúp chọn lựa phù hợp và tối ưu hiệu suất ứng dụng.</p>", new DateTime(2025, 9, 25, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6748), "Tìm hiểu Java Collections Framework để quản lý và thao tác với dữ liệu một cách hiệu quả trong Java.", "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Java\",\"Collections\",\"Data Structures\",\"Performance\"]", "Java Collections Framework: Quản lý dữ liệu hiệu quả", new DateTime(2025, 9, 28, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6749), 750 },
                    { 8, "TRAN NHAN", "JavaScript", "<h2>Giới thiệu Async/Await</h2>\r\n<p>Async/await là cú pháp hiện đại để xử lý các tác vụ bất đồng bộ trong JavaScript một cách dễ đọc và dễ hiểu.</p>\r\n\r\n<h2>Promise vs Async/Await</h2>\r\n<p>Async/await được xây dựng trên Promise nhưng cung cấp cú pháp đồng bộ để xử lý code bất đồng bộ.</p>\r\n\r\n<h2>Cú pháp cơ bản</h2>\r\n<p>Sử dụng từ khóa async để khai báo function bất đồng bộ và await để chờ kết quả của Promise.</p>\r\n\r\n<h2>Error Handling</h2>\r\n<p>Xử lý lỗi trong async/await sử dụng try-catch block giống như code đồng bộ thông thường.</p>\r\n\r\n<h2>Thực hành với API</h2>\r\n<p>Async/await rất hữu ích khi làm việc với API calls, file operations và các tác vụ I/O khác.</p>", new DateTime(2025, 9, 24, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6757), "Học cách sử dụng async/await để viết code JavaScript bất đồng bộ một cách sạch sẽ và dễ hiểu.", "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"JavaScript\",\"Async\",\"Promise\",\"Asynchronous\"]", "Async/Await trong JavaScript: Lập trình bất đồng bộ hiện đại", new DateTime(2025, 9, 27, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6757), 1050 },
                    { 9, "TRAN NHAN", "Java", "<h2>Giới thiệu JUnit</h2>\r\n<p>JUnit là framework testing phổ biến nhất cho Java, giúp đảm bảo chất lượng code thông qua việc viết và chạy các test case.</p>\r\n\r\n<h2>Annotations quan trọng</h2>\r\n<p>@Test, @BeforeEach, @AfterEach, @BeforeAll, @AfterAll là những annotation cơ bản trong JUnit 5.</p>\r\n\r\n<h2>Assertions</h2>\r\n<p>JUnit cung cấp nhiều assertion methods như assertEquals, assertTrue, assertNotNull để kiểm tra kết quả mong đợi.</p>\r\n\r\n<h2>Test Lifecycle</h2>\r\n<p>Hiểu rõ lifecycle của test giúp setup và cleanup dữ liệu test một cách hiệu quả.</p>\r\n\r\n<h2>Best Practices</h2>\r\n<p>Viết test case tốt cần tuân theo các nguyên tắc như AAA (Arrange, Act, Assert) và FIRST (Fast, Independent, Repeatable, Self-validating, Timely).</p>", new DateTime(2025, 9, 23, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6766), "Hướng dẫn sử dụng JUnit để viết test case hiệu quả và đảm bảo chất lượng code Java.", "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", true, "[\"Java\",\"JUnit\",\"Testing\",\"Quality Assurance\"]", "JUnit Testing trong Java: Viết test case hiệu quả", new DateTime(2025, 9, 26, 17, 14, 4, 715, DateTimeKind.Local).AddTicks(6767), 680 }
                });

            migrationBuilder.InsertData(
                table: "PortfolioData",
                columns: new[] { "Id", "Contact_Email", "Contact_GitHub", "Contact_LinkedIn", "Contact_Location", "Contact_Phone", "About", "BackgroundImageUrl", "GalleryImages", "Name", "ProfileImageUrl", "Quote", "Resume" },
                values: new object[] { 1, "xuan.dang@email.com", "https://github.com/xuandang", "https://linkedin.com/in/xuandang", "New York, NY", "+1 (555) 123-4567", "Passionate developer with a love for clean code and innovative solutions.", "https://images.unsplash.com/photo-1540575467063-178a50c2df87?ixlib=rb-4.0.3&auto=format&fit=crop&w=2070&q=80", "[]", "TRAN NHAN", "https://images.unsplash.com/photo-1494790108755-2616b612b786?ixlib=rb-4.0.3&auto=format&fit=crop&w=687&q=80", "WORK HARD\nIN SILENCE\nLET SUCCESS\nMAKE NOISE", "/documents/resume.pdf" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "ImageUrl", "PortfolioDataId", "ProjectUrl", "Technologies", "Title" },
                values: new object[,]
                {
                    { 1, "Full-stack e-commerce solution with payment integration", "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", null, "https://github.com/xuandang/ecommerce", "ASP.NET Core, React, SQL Server, Azure", "E-Commerce Platform" },
                    { 2, "Collaborative task management with real-time updates", "https://images.unsplash.com/photo-1611224923853-80b023f02d71?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", null, "https://github.com/xuandang/taskmanager", "ASP.NET Core, SignalR, Entity Framework", "Task Management App" },
                    { 3, "Modern responsive portfolio website with API integration", "https://images.unsplash.com/photo-1467232004584-a241de8bcf5d?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80", null, "https://github.com/xuandang/portfolio", "ASP.NET Core, HTML5, CSS3, JavaScript", "Portfolio Website" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PortfolioDataId",
                table: "Projects",
                column: "PortfolioDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "PortfolioData");
        }
    }
}
