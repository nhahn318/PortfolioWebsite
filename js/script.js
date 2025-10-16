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

        // Load projects
        this.loadProjects();
        
        // Load contact info
        this.loadContactInfo();
    }

    async loadProjects() {
        try {
            const response = await fetch('/api/portfolio/projects');
            const projects = await response.json();
            this.renderProjects(projects);
        } catch (error) {
            console.error('Error loading projects:', error);
        }
    }

    renderProjects(projects) {
        const projectsGrid = document.getElementById('projectsGrid');
        if (!projectsGrid) return;

        projectsGrid.innerHTML = projects.map(project => `
            <div class="project-card">
                <img src="${project.imageUrl}" alt="${project.title}" class="project-image" 
                     onerror="this.src='https://via.placeholder.com/300x200?text=Project+Image'">
                <div class="project-content">
                    <h3 class="project-title">${project.title}</h3>
                    <p class="project-description">${project.description}</p>
                    <div class="project-technologies">${project.technologies}</div>
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

// Add some CSS for project links
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
`;
document.head.appendChild(style);
