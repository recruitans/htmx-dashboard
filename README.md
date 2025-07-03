# HTMX Performance Test Dashboard

A modern, responsive dashboard built with .NET Core MVC, HTMX, and Tailwind CSS. This project demonstrates the power of HTMX for creating dynamic, server-rendered applications with minimal JavaScript while maintaining excellent performance and user experience.

Bu proje, HTMX'in performansını test etmek için geliştirilmiş modern bir .NET Core MVC uygulamasıdır. Tailwind CSS ile tasarlanmış, JSONPlaceholder API'sini kullanarak gerçek zamanlı veri güncellemeleri ve dinamik içerik yükleme özelliklerini test eder.

## Key Features / Özellikler

### Modern UI Design
- **Tailwind CSS**: Utility-first CSS framework for rapid UI development
- **Responsive Design**: Mobile-first approach ensuring great experience on all devices
- **Dark Mode Support**: Built-in dark mode toggle for better user experience
- **Modern Components**: Card-based layouts, smooth transitions, and glassmorphism effects
- **Custom Animations**: Tailwind-powered animations for enhanced interactivity

### HTMX Integration

### 1. Infinite Scroll
- Post listesi otomatik olarak scroll edildiğinde yeni içerik yükler
- `hx-trigger="revealed"` kullanarak performanslı sayfalama
- Her seferinde 10 post yükleme

### 2. Live Search
- Kullanıcı arama özelliği
- 500ms debounce ile optimize edilmiş arama
- `hx-trigger="keyup changed delay:500ms"` kullanımı
- Minimum 3 karakter kontrolü

### 3. Lazy Loading
- Post yorumları talep üzerine yüklenir
- `hx-trigger="click"` ile tetikleme
- Loading spinner gösterimi

### 4. Polling
- Bildirim sayacı her 5 saniyede bir güncellenir
- `hx-trigger="every 5s"` kullanımı
- Random sayı üretimi ile simülasyon

### 5. Performance Metrics
- Yüklenen toplam post sayısı
- Aktif HTMX istekleri
- Son güncelleme zamanı

## Kurulum

1. Projeyi klonlayın veya indirin
2. Terminal/Command Prompt açın ve proje dizinine gidin
3. Bağımlılıkları yükleyin:
```bash
dotnet restore
```

4. Uygulamayı çalıştırın:
```bash
dotnet run
```

5. Tarayıcınızda şu adrese gidin:
```
https://localhost:5001
```

## Test Senaryoları

### 1. Infinite Scroll Testi
- Ana sayfada post listesini aşağı kaydırın
- Otomatik olarak yeni postların yüklendiğini gözlemleyin
- Performance Metrics'te post sayısının arttığını kontrol edin

### 2. Search Performance Testi
- Sağ taraftaki User Search kutusuna hızlıca yazın
- Debounce özelliğinin çalıştığını gözlemleyin
- Arama sonuçlarının dinamik güncellendiğini kontrol edin

### 3. Lazy Loading Testi
- Herhangi bir post'un "Load Comments" butonuna tıklayın
- Yorumların yüklenme süresini gözlemleyin
- Birden fazla post için aynı anda yorum yüklemeyi deneyin

### 4. Polling Testi
- Sağ üst köşedeki bildirim sayacını gözlemleyin
- Her 5 saniyede bir güncellendiğini kontrol edin
- Diğer işlemler sırasında polling'in devam ettiğini doğrulayın

### 5. Concurrent Request Testi
- Aynı anda birden fazla işlem başlatın
- Active HTMX Requests sayacını gözlemleyin
- Tüm isteklerin başarıyla tamamlandığını kontrol edin

## Technology Stack / Teknolojiler

### Backend
- **.NET Core 9.0 MVC**: Latest version of Microsoft's web framework
- **C# 12**: Modern language features for cleaner code
- **HttpClient**: For external API communication
- **JSONPlaceholder API**: Free fake REST API for testing

### Frontend
- **HTMX 1.9.10**: Modern library for AJAX, CSS Transitions, WebSockets and SSE
- **Tailwind CSS 3.4**: Utility-first CSS framework
- **Alpine.js**: Minimal framework for composing JavaScript behavior
- **Font Awesome**: Icon library for modern UI elements

### Development Tools
- **PostCSS**: For processing Tailwind CSS
- **Autoprefixer**: Vendor prefix automation
- **CSSnano**: CSS minification for production

## HTMX Features in Detail / HTMX Özellikleri

### Core Attributes
- `hx-get`: GET requests for fetching data
- `hx-post`: POST requests for submitting data
- `hx-trigger`: Event triggers (click, revealed, keyup, etc.)
- `hx-target`: Target element for response content
- `hx-swap`: Content swapping strategies (innerHTML, outerHTML, beforeend, etc.)
- `hx-indicator`: Loading state indicators
- `hx-push-url`: URL management without page reload

### Advanced Features
- **Polling**: Real-time updates with `hx-trigger="every Xs"`
- **Server-Sent Events (SSE)**: Live data streaming
- **WebSocket Support**: Bi-directional communication
- **Request Chaining**: Sequential and parallel requests
- **History Support**: Browser back/forward navigation
- **Extension System**: Custom behaviors and integrations

## Performance Tips / Performans İpuçları

### HTMX Optimization
1. **Debouncing**: Use delay for frequently triggered events (`delay:500ms`)
2. **Lazy Loading**: Load large content on demand with `hx-trigger="revealed"`
3. **Partial Updates**: Update only necessary sections, not entire pages
4. **Loading Indicators**: Provide visual feedback during requests
5. **Request Batching**: Combine multiple requests when possible

### Tailwind CSS Optimization
1. **PurgeCSS**: Remove unused styles in production
2. **JIT Mode**: Just-In-Time compilation for smaller builds
3. **Component Classes**: Extract common patterns to reduce repetition
4. **Critical CSS**: Inline critical styles for faster initial render

### General Best Practices
1. **Caching**: Implement proper HTTP caching headers
2. **Compression**: Enable gzip/brotli compression
3. **Image Optimization**: Use WebP format and lazy loading
4. **CDN Usage**: Serve static assets from CDN
5. **Minification**: Minify CSS, JS, and HTML in production

## Project Structure

```
HtmxDashboard/
├── Controllers/          # MVC Controllers
├── Models/              # Data models and view models
├── Views/               # Razor views with HTMX
│   ├── Shared/         # Layout and partial views
│   └── Home/           # Main dashboard views
├── wwwroot/            # Static assets
│   ├── css/           # Compiled CSS files
│   ├── js/            # JavaScript files
│   └── lib/           # Third-party libraries
├── tailwind.config.js  # Tailwind configuration
├── postcss.config.js   # PostCSS configuration
└── package.json        # Node.js dependencies
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.