// Projects data and management
const projectsData = [
    {
        id: 1,
        title: "Hệ thống quản lý quán cafe",
        image: "images/HeThongQLCafeWinform.png",
        technologies: "C#, WinForm, SQL Server, Entity Framework, ADO.NET",
        description: "Phần mềm quản lý toàn diện cho quán cafe với các chức năng: quản lý bán hàng (order, thanh toán), quản lý nhân viên (ca làm, lương thưởng), quản lý kho (nhập/xuất hàng), quản lý menu và báo cáo thống kê. Giao diện thân thiện với sơ đồ bàn trực quan, hỗ trợ quản lý đa tầng và nhiều khu vực.",
        features: [
            "Quản lý bán hàng: Order món, thanh toán, in hóa đơn",
            "Quản lý bàn: Sơ đồ bàn trực quan, quản lý đa tầng (trệt, lầu 1-3, phòng lạnh)",
            "Quản lý nhân viên: Ca làm, lịch làm việc, tính lương thưởng",
            "Quản lý kho: Nhập/xuất hàng, quản lý nhà cung cấp",
            "Quản lý menu: Thêm/sửa/xóa món, upload hình ảnh",
            "Báo cáo thống kê: Doanh thu, tồn kho, lương nhân viên"
        ],
        screenshots: [
            "Giao diện chính với sơ đồ bàn",
            "Form chọn món từ menu",
            "Form quản lý nhân viên và ca làm",
            "Form quản lý kho và nhập/xuất hàng",
            "Form báo cáo thống kê"
        ]
    },
    {
        id: 2,
        title: "Tự động cung cấp tài nguyên theo nhu cầu Serverless",
        image: "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
        technologies: "Amazon Aurora Serverless v2, Amazon RDS, AWS Lambda, MySQL, DBeaver, Cloud Computing",
        description: "Nghiên cứu và thực nghiệm về kiến trúc Serverless với khả năng tự động cung cấp tài nguyên theo nhu cầu thực tế. Sử dụng Amazon Aurora Serverless v2 để kiểm chứng khả năng auto-scaling, tối ưu hóa chi phí và hiệu suất trong môi trường cloud computing.",
        features: [
            "Kiến trúc Event-driven: Hệ thống phản ứng tự động với các sự kiện",
            "Auto-scaling: Tự động mở rộng từ 0.5 đến hàng trăm ACU trong vài giây",
            "Cost optimization: Tính phí theo giây dựa trên tài nguyên sử dụng thực tế",
            "Zero-downtime scaling: Không gián đoạn khi mở rộng tài nguyên",
            "Event-driven architecture: Hoạt động dựa trên sự kiện, không cần server chạy liên tục",
            "Resource monitoring: Theo dõi ACU Utilization để đánh giá hiệu suất"
        ],
        screenshots: [
            "Thiết lập môi trường Aurora Serverless v2 với 0.5-2 ACU",
            "Nhập dữ liệu lớn: 100,000 sinh viên và 500,000 điểm số",
            "Mô phỏng truy vấn đồng thời để tạo tải cho hệ thống",
            "Theo dõi biểu đồ ACU Utilization: tăng từ 25% lên 100% khi có tải",
            "Kiểm chứng auto-scaling: hệ thống tự thu hẹp khi giảm tải"
        ]
    },
    {
        id: 3,
        title: "Hệ thống hỗ trợ phúc khảo",
        image: "images/HeThongPhucKhaoOnl.png",
        technologies: "ASP.NET Core, Entity Framework, SQL Server, HTML/CSS/JavaScript, Bootstrap, C#, Visual Studio 2022",
        description: "Website quản lý toàn diện quy trình phúc khảo điểm thi cho sinh viên đại học. Hệ thống hỗ trợ 4 vai trò: sinh viên (nộp đơn, theo dõi), giảng viên (chấm bài), nhân viên (quản lý, phân công), admin (quản trị hệ thống). Tích hợp email notification và quản lý file bài thi số hóa.",
        features: [
            "Quản lý đa vai trò: Sinh viên, Giảng viên, Nhân viên, Admin",
            "Nộp đơn phúc khảo trực tuyến: Chọn môn học, nhập lý do, upload tài liệu",
            "Theo dõi trạng thái đơn: Từ nộp đơn đến nhận kết quả cuối cùng",
            "Phân công giảng viên: Tự động phân công dựa trên môn học",
            "Chấm bài số hóa: Upload file bài thi, chấm lại, nhập điểm mới",
            "Thông báo email: Tự động gửi email cho sinh viên và giảng viên",
            "Báo cáo thống kê: Số lượng đơn, kết quả phúc khảo theo học kỳ",
            "Quản lý đợt phúc khảo: Mở/đóng đợt theo học kỳ"
        ],
        screenshots: [
            "Dashboard Admin: Quản lý người dùng, đợt phúc khảo, thống kê",
            "Giao diện sinh viên: Nộp đơn, xem điểm, theo dõi trạng thái",
            "Giao diện nhân viên: Duyệt đơn, phân công, upload bài thi",
            "Giao diện giảng viên: Nhận phân công, chấm bài, nhập kết quả",
            "Hệ thống thông báo: Email tự động cho tất cả bên liên quan"
        ]
    },
    {
        id: 4,
        title: "Hacking Windows - Bảo mật thông tin",
        image: "https://images.unsplash.com/photo-1555949963-aa79dcee981c?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
        technologies: "Python, Metasploit, Wireshark, Nmap, John the Ripper, Hydra, VirtualBox, VMware, Ethical Hacking",
        description: "Nghiên cứu và thực nghiệm về các phương pháp tấn công mạng trên hệ điều hành Windows, bao gồm phân tích lỗ hổng bảo mật, tạo malware, và các biện pháp phòng chống. Đồ án tập trung vào việc hiểu rõ cách thức hacker tấn công để phát triển các giải pháp bảo mật hiệu quả.",
        features: [
            "Phân tích lỗ hổng bảo mật: Nghiên cứu các lỗ hổng phổ biến trên Windows",
            "Tạo malware và backdoor: Phát triển các công cụ tấn công để hiểu cơ chế hoạt động",
            "Penetration Testing: Thực hiện kiểm tra thâm nhập hợp pháp",
            "Phân tích malware: Nghiên cứu các loại virus, trojan, ransomware",
            "Bảo mật hệ thống: Đề xuất các biện pháp phòng chống tấn công",
            "Ethical Hacking: Thực hiện hacking có đạo đức để bảo vệ hệ thống"
        ],
        screenshots: [
            "Demo tấn công: Kết nối và điều khiển máy nạn nhân từ xa",
            "Screenshot từ xa: Chụp ảnh màn hình máy nạn nhân",
            "Keylogging: Thu thập dữ liệu bàn phím theo thời gian thực",
            "Webcam access: Sử dụng webcam của máy nạn nhân",
            "File management: Quản lý file và thư mục từ xa"
        ]
    }
];

// Render projects grid
function renderProjects() {
    const projectsGrid = document.getElementById('projectsGrid');
    if (!projectsGrid) return;

    const projectLinks = {
        1: 'project-cafe.html',
        2: 'project-serverless.html', 
        3: 'project-phuckhao.html',
        4: 'project-hacking.html'
    };

    projectsGrid.innerHTML = projectsData.map(project => `
        <div class="project-card" onclick="window.location.href='${projectLinks[project.id]}'">
            <img src="${project.image}" alt="${project.title}" class="project-image" 
                 onerror="this.src='https://via.placeholder.com/300x200?text=Project+Image'">
            <div class="project-content">
                <h3 class="project-title">${project.title}</h3>
                <div class="project-technologies">${project.technologies}</div>
                <div class="project-click-hint">Click để xem chi tiết</div>
            </div>
        </div>
    `).join('');
}


// Initialize projects when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    console.log('Projects script loaded');
    renderProjects();
});

// Also try to render immediately in case DOM is already loaded
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', renderProjects);
} else {
    renderProjects();
}
