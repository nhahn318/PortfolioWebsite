// Portfolio Website JavaScript
class PortfolioApp {
    constructor() {
        this.portfolioData = null;
        this.init();
    }

    async init() {
        await this.loadPortfolioData();
        this.setupEventListeners();
        this.updateUI();
    }

    async loadPortfolioData() {
        try {
            const response = await fetch('/api/portfolio');
            this.portfolioData = await response.json();
            console.log('Portfolio data loaded:', this.portfolioData);
        } catch (error) {
            console.error('Error loading portfolio data:', error);
        }
    }

    setupEventListeners() {
        // Navigation smooth scrolling
        document.querySelectorAll('.nav-link').forEach(link => {
            link.addEventListener('click', (e) => {
                const href = link.getAttribute('href');
                
                // Only prevent default for internal anchor links (starting with #)
                if (href.startsWith('#')) {
                    e.preventDefault();
                    const targetId = href.substring(1);
                    const targetElement = document.getElementById(targetId);
                    if (targetElement) {
                        targetElement.scrollIntoView({ behavior: 'smooth' });
                    }
                }
                // For external links (like blog.html), let the browser handle navigation normally
            });
        });


        // Update active navigation link on scroll
        window.addEventListener('scroll', () => this.updateActiveNavLink());
    }


    updateActiveNavLink() {
        const sections = document.querySelectorAll('section[id]');
        const navLinks = document.querySelectorAll('.nav-link');
        
        let currentSection = '';
        sections.forEach(section => {
            const rect = section.getBoundingClientRect();
            if (rect.top <= 100 && rect.bottom >= 100) {
                currentSection = section.id;
            }
        });

        navLinks.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href') === `#${currentSection}`) {
                link.classList.add('active');
            }
        });
    }

    updateUI() {
        if (!this.portfolioData) return;

        // Update name
        const nameTag = document.getElementById('nameTag');
        if (nameTag) {
            nameTag.textContent = 'TRAN NHAN//';
        }

        // Update quote
        const mainQuote = document.getElementById('mainQuote');
        if (mainQuote) {
            mainQuote.innerHTML = this.portfolioData.quote.replace(/\n/g, '<br>');
        }

        // Update about text
        const aboutText = document.getElementById('aboutText');
        if (aboutText) {
            aboutText.textContent = this.portfolioData.about;
        }

        // Update profile image
        const profileImage = document.getElementById('profileImage');
        if (profileImage && this.portfolioData.profileImageUrl) {
            profileImage.src = this.portfolioData.profileImageUrl;
        }


        // Update copyright
        const copyright = document.getElementById('copyright');
        if (copyright) {
            const currentYear = new Date().getFullYear();
            copyright.textContent = `© ${currentYear} by TRAN NHAN`;
        }

        // Load projects - always use static projects for now
        console.log('Loading static projects');
        
        // Debug: Check if portfolio section exists
        const portfolioSection = document.getElementById('portfolio');
        if (portfolioSection) {
            console.log('Portfolio section found:', portfolioSection);
        } else {
            console.error('Portfolio section not found!');
        }
        
        // Ensure projects load after DOM is ready
        setTimeout(() => {
            this.renderProjects(this.getStaticProjects());
        }, 100);
        
        // Load contact info
        this.loadContactInfo();
    }

    async loadProjects() {
        try {
            const response = await fetch('/api/portfolio/projects');
            if (response.ok) {
                const projects = await response.json();
                this.renderProjects(projects);
            } else {
                throw new Error('API not available');
            }
        } catch (error) {
            console.error('Error loading projects:', error);
            console.log('Using static projects as fallback');
            // Fallback to static projects if API fails
            this.renderProjects(this.getStaticProjects());
        }
    }

    getStaticProjects() {
        return [
            {
                title: "Hệ thống quản lý quán cafe",
                description: "Phần mềm quản lý toàn diện cho quán cafe với các chức năng: quản lý bán hàng (order, thanh toán), quản lý nhân viên (ca làm, lương thưởng), quản lý kho (nhập/xuất hàng), quản lý menu và báo cáo thống kê. Giao diện thân thiện với sơ đồ bàn trực quan, hỗ trợ quản lý đa tầng và nhiều khu vực.",
                imageUrl: "https://images.unsplash.com/photo-1554118811-1e0d58224f24?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                technologies: "C#, WinForm, SQL Server, Entity Framework, ADO.NET",
                projectUrl: "",
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
                title: "Tự động cung cấp tài nguyên theo nhu cầu Serverless",
                description: "Hệ thống tự động cung cấp và quản lý tài nguyên serverless dựa trên nhu cầu thực tế, tối ưu hóa chi phí và hiệu suất.",
                imageUrl: "https://images.unsplash.com/photo-1558494949-ef010cbdcc31?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                technologies: "AWS Lambda, Serverless Framework, Node.js, CloudFormation",
                projectUrl: ""
            },
            {
                title: "Hệ thống phúc khảo điểm online",
                description: "Website cho phép sinh viên nộp đơn phúc khảo điểm số trực tuyến, quản lý quy trình phúc khảo từ nộp đơn đến xử lý kết quả.",
                imageUrl: "https://images.unsplash.com/photo-1516321318423-f06f85e504b3?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80",
                technologies: "ASP.NET Core, Entity Framework, SQL Server, HTML/CSS/JavaScript",
                projectUrl: ""
            }
        ];
    }

    renderProjects(projects) {
        const projectsGrid = document.getElementById('projectsGrid');
        if (!projectsGrid) {
            console.error('projectsGrid element not found');
            return;
        }

        console.log('Rendering projects:', projects);
        
        // Clear loading message and render projects
        projectsGrid.innerHTML = projects.map(project => `
            <div class="project-card">
                <img src="${project.imageUrl}" alt="${project.title}" class="project-image" 
                     onerror="this.src='https://via.placeholder.com/300x200?text=Project+Image'">
                <div class="project-content">
                    <h3 class="project-title">${project.title}</h3>
                    <p class="project-description">${project.description}</p>
                    <div class="project-technologies">${project.technologies}</div>
                    ${project.features ? `
                        <div class="project-features">
                            <h4>Tính năng chính:</h4>
                            <ul>
                                ${project.features.map(feature => `<li>${feature}</li>`).join('')}
                            </ul>
                        </div>
                    ` : ''}
                    ${project.screenshots ? `
                        <div class="project-screenshots">
                            <h4>Giao diện:</h4>
                            <ul>
                                ${project.screenshots.map(screenshot => `<li>${screenshot}</li>`).join('')}
                            </ul>
                        </div>
                    ` : ''}
                    ${project.projectUrl ? `<a href="${project.projectUrl}" target="_blank" class="project-link">View Project</a>` : ''}
                </div>
            </div>
        `).join('');
    }

    loadContactInfo() {
        if (!this.portfolioData || !this.portfolioData.contact) return;

        const contactInfo = document.getElementById('contactInfo');
        if (!contactInfo) return;

        const contact = this.portfolioData.contact;
        contactInfo.innerHTML = `
            <div class="contact-item">
                <div class="contact-label">Email</div>
                <a href="mailto:${contact.email}" class="contact-value">${contact.email}</a>
            </div>
            <div class="contact-item">
                <div class="contact-label">Phone</div>
                <a href="tel:${contact.phone}" class="contact-value">${contact.phone}</a>
            </div>
            <div class="contact-item">
                <div class="contact-label">Location</div>
                <div class="contact-value">${contact.location}</div>
            </div>
            <div class="contact-item">
                <div class="contact-label">LinkedIn</div>
                <a href="${contact.linkedIn}" target="_blank" class="contact-value">LinkedIn Profile</a>
            </div>
            <div class="contact-item">
                <div class="contact-label">GitHub</div>
                <a href="${contact.github}" target="_blank" class="contact-value">GitHub Profile</a>
            </div>
        `;
    }
}

// Initialize the app when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    new PortfolioApp();
});

// Add some CSS for project links and features
const style = document.createElement('style');
style.textContent = `
    .project-link {
        display: inline-block;
        margin-top: 10px;
        color: #20b2aa;
        text-decoration: none;
        font-weight: 500;
        transition: color 0.3s ease;
    }
    
    .project-link:hover {
        color: #1a9b94;
    }
    
    .project-features, .project-screenshots {
        margin-top: 15px;
        padding: 10px;
        background-color: #f8f9fa;
        border-radius: 5px;
        border-left: 3px solid #20b2aa;
    }
    
    .project-features h4, .project-screenshots h4 {
        margin: 0 0 10px 0;
        color: #333;
        font-size: 14px;
        font-weight: 600;
    }
    
    .project-features ul, .project-screenshots ul {
        margin: 0;
        padding-left: 20px;
    }
    
    .project-features li, .project-screenshots li {
        margin-bottom: 5px;
        font-size: 13px;
        color: #666;
        line-height: 1.4;
    }
    
    .project-card {
        background: white;
        border-radius: 8px;
        box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        overflow: hidden;
        transition: transform 0.3s ease, box-shadow 0.3s ease;
    }
    
    .project-card:hover {
        transform: translateY(-5px);
        box-shadow: 0 5px 20px rgba(0,0,0,0.15);
    }
    
    .project-click-hint {
        margin-top: 10px;
        color: #20b2aa;
        font-size: 12px;
        font-style: italic;
        text-align: center;
    }
    
    /* Project Modal Styles */
    .project-modal {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0,0,0,0.8);
        z-index: 1000;
        display: flex;
        justify-content: center;
        align-items: center;
        padding: 20px;
    }
    
    .modal-content {
        background: white;
        border-radius: 10px;
        max-width: 800px;
        max-height: 90vh;
        overflow-y: auto;
        position: relative;
        animation: modalSlideIn 0.3s ease-out;
    }
    
    @keyframes modalSlideIn {
        from {
            opacity: 0;
            transform: scale(0.8);
        }
        to {
            opacity: 1;
            transform: scale(1);
        }
    }
    
    .close-modal {
        position: absolute;
        top: 15px;
        right: 20px;
        font-size: 30px;
        font-weight: bold;
        color: #aaa;
        cursor: pointer;
        z-index: 1001;
    }
    
    .close-modal:hover {
        color: #000;
    }
    
    .modal-header {
        display: flex;
        gap: 20px;
        padding: 30px;
        border-bottom: 1px solid #eee;
    }
    
    .modal-image {
        width: 200px;
        height: 150px;
        object-fit: cover;
        border-radius: 8px;
        flex-shrink: 0;
    }
    
    .modal-title-section {
        flex: 1;
    }
    
    .modal-title {
        margin: 0 0 10px 0;
        color: #333;
        font-size: 24px;
    }
    
    .modal-technologies {
        color: #20b2aa;
        font-weight: 500;
        font-size: 14px;
    }
    
    .modal-body {
        padding: 30px;
    }
    
    .modal-description,
    .modal-features,
    .modal-screenshots {
        margin-bottom: 25px;
    }
    
    .modal-description h3,
    .modal-features h3,
    .modal-screenshots h3 {
        margin: 0 0 15px 0;
        color: #333;
        font-size: 18px;
        border-bottom: 2px solid #20b2aa;
        padding-bottom: 5px;
    }
    
    .modal-description p {
        line-height: 1.6;
        color: #666;
        margin: 0;
    }
    
    .modal-features ul,
    .modal-screenshots ul {
        margin: 0;
        padding-left: 20px;
    }
    
    .modal-features li,
    .modal-screenshots li {
        margin-bottom: 8px;
        color: #666;
        line-height: 1.5;
    }
    
    @media (max-width: 768px) {
        .modal-header {
            flex-direction: column;
            text-align: center;
        }
        
        .modal-image {
            width: 100%;
            height: 200px;
        }
        
        .modal-content {
            margin: 10px;
            max-height: 95vh;
        }
    }
`;
document.head.appendChild(style);
