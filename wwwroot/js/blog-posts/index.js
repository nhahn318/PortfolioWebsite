// Blog Posts Index - Quản lý việc load các bài viết
class BlogPostsManager {
    constructor() {
        this.posts = [];
        this.loadedPosts = new Set();
    }

    // Load tất cả bài viết
    async loadAllPosts() {
        const postFiles = [
            'post-1.json', 'post-2.json', 'post-3.json', 'post-4.json', 'post-5.json',
            'post-6.json', 'post-7.json', 'post-8.json', 'post-9.json'
        ];

        const loadPromises = postFiles.map(file => this.loadPost(file));
        
        try {
            const results = await Promise.all(loadPromises);
            this.posts = results.filter(post => post !== null);
            return this.posts;
        } catch (error) {
            console.error('Error loading posts:', error);
            return [];
        }
    }

    // Load một bài viết cụ thể
    async loadPost(filename) {
        try {
            const response = await fetch(`./PortfolioWebsite/js/blog-posts/${filename}`);
            if (!response.ok) {
                throw new Error(`Failed to load ${filename}: ${response.status}`);
            }
            const post = await response.json();
            this.loadedPosts.add(post.id);
            return post;
        } catch (error) {
            console.error(`Error loading ${filename}:`, error);
            return null;
        }
    }

    // Load bài viết theo ID
    async loadPostById(id) {
        const filename = `post-${id}.json`;
        return await this.loadPost(filename);
    }

    // Lấy tất cả bài viết đã load
    getAllPosts() {
        return this.posts;
    }

    // Lấy bài viết theo ID
    getPostById(id) {
        return this.posts.find(post => post.id === id);
    }

    // Lấy bài viết theo category
    getPostsByCategory(category) {
        return this.posts.filter(post => 
            post.category.toLowerCase() === category.toLowerCase()
        );
    }

    // Lấy bài viết theo tag
    getPostsByTag(tag) {
        return this.posts.filter(post => 
            post.tags.includes(tag)
        );
    }

    // Lấy bài viết nổi bật (có view count cao nhất)
    getFeaturedPosts(limit = 3) {
        return this.posts
            .sort((a, b) => b.viewCount - a.viewCount)
            .slice(0, limit);
    }

    // Lấy tất cả tags
    getAllTags() {
        const allTags = new Set();
        this.posts.forEach(post => {
            post.tags.forEach(tag => allTags.add(tag));
        });
        return Array.from(allTags);
    }

    // Lấy tất cả categories
    getAllCategories() {
        const categories = new Set();
        this.posts.forEach(post => categories.add(post.category));
        return Array.from(categories);
    }

    // Tìm kiếm bài viết
    searchPosts(query) {
        const searchTerm = query.toLowerCase();
        return this.posts.filter(post => 
            post.title.toLowerCase().includes(searchTerm) ||
            post.excerpt.toLowerCase().includes(searchTerm) ||
            post.content.toLowerCase().includes(searchTerm) ||
            post.tags.some(tag => tag.toLowerCase().includes(searchTerm))
        );
    }
}

// Export để sử dụng trong các file khác
window.BlogPostsManager = BlogPostsManager;
