# HTMX Performans Test Dashboard

.NET Core MVC, HTMX ve Tailwind CSS ile oluşturulmuş modern, responsive bir dashboard. Bu proje, minimum JavaScript ile dinamik, sunucu taraflı uygulamalar oluşturmak için HTMX'in gücünü gösterirken mükemmel performans ve kullanıcı deneyimi sağlar.

Bu proje, HTMX'in performansını test etmek için geliştirilmiş modern bir .NET Core MVC uygulamasıdır. Tailwind CSS ile tasarlanmış, JSONPlaceholder API'sini kullanarak gerçek zamanlı veri güncellemeleri ve dinamik içerik yükleme özelliklerini test eder.

## Özellikler

### Modern UI Tasarım
- **Tailwind CSS**: Hızlı UI geliştirme için utility-first CSS framework
- **Responsive Tasarım**: Tüm cihazlarda mükemmel deneyim için mobile-first yaklaşım
- **Dark Mode Desteği**: Daha iyi kullanıcı deneyimi için entegre karanlık mod geçişi
- **Modern Bileşenler**: Kart tabanlı düzenler, yumuşak geçişler ve glassmorphism efektleri
- **Özel Animasyonlar**: Gelişmiş etkileşim için Tailwind destekli animasyonlar

### HTMX Entegrasyonu

### 1. Sonsuz Scroll
- Post listesi otomatik olarak scroll edildiğinde yeni içerik yükler
- `hx-trigger="revealed"` kullanarak performanslı sayfalama
- Her seferinde 10 post yükleme

### 2. Canlı Arama
- Kullanıcı arama özelliği
- 500ms debounce ile optimize edilmiş arama
- `hx-trigger="keyup changed delay:500ms"` kullanımı
- Minimum 3 karakter kontrolü

### 3. Tembel Yükleme
- Post yorumları talep üzerine yüklenir
- `hx-trigger="click"` ile tetikleme
- Loading spinner gösterimi

### 4. Polling
- Bildirim sayacı her 5 saniyede bir güncellenir
- `hx-trigger="every 5s"` kullanımı
- Random sayı üretimi ile simülasyon

### 5. Performans Metrikleri
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

### 1. Sonsuz Scroll Testi
- Ana sayfada post listesini aşağı kaydırın
- Otomatik olarak yeni postların yüklendiğini gözlemleyin
- Performans Metrikleri'nde post sayısının arttığını kontrol edin

### 2. Arama Performans Testi
- Sağ taraftaki Kullanıcı Arama kutusuna hızlıca yazın
- Debounce özelliğinin çalıştığını gözlemleyin
- Arama sonuçlarının dinamik güncellendiğini kontrol edin

### 3. Tembel Yükleme Testi
- Herhangi bir post'un "Yorumları Yükle" butonuna tıklayın
- Yorumların yüklenme süresini gözlemleyin
- Birden fazla post için aynı anda yorum yüklemeyi deneyin

### 4. Polling Testi
- Sağ üst köşedeki bildirim sayacını gözlemleyin
- Her 5 saniyede bir güncellendiğini kontrol edin
- Diğer işlemler sırasında polling'in devam ettiğini doğrulayın

### 5. Eşzamanlı İstek Testi
- Aynı anda birden fazla işlem başlatın
- Aktif HTMX İstekleri sayacını gözlemleyin
- Tüm isteklerin başarıyla tamamlandığını kontrol edin

## Teknoloji Yığını

### Backend
- **.NET Core 9.0 MVC**: Microsoft'un web framework'ünün en son sürümü
- **C# 12**: Daha temiz kod için modern dil özellikleri
- **HttpClient**: Harici API iletişimi için
- **JSONPlaceholder API**: Test için ücretsiz sahte REST API

### Frontend
- **HTMX 1.9.10**: AJAX, CSS Geçişleri, WebSocket ve SSE için modern kütüphane
- **Tailwind CSS 3.4**: Utility-first CSS framework
- **Alpine.js**: JavaScript davranışları oluşturmak için minimal framework
- **Font Awesome**: Modern UI öğeleri için ikon kütüphanesi

### Geliştirme Araçları
- **PostCSS**: Tailwind CSS işleme için
- **Autoprefixer**: Satıcı öneki otomasyonu
- **CSSnano**: Üretim için CSS küçültme

## HTMX Özellikleri Detayları

### Temel Nitelikler
- `hx-get`: Veri getirmek için GET istekleri
- `hx-post`: Veri göndermek için POST istekleri
- `hx-trigger`: Olay tetikleyicileri (click, revealed, keyup, vb.)
- `hx-target`: Yanıt içeriği için hedef öğe
- `hx-swap`: İçerik değiştirme stratejileri (innerHTML, outerHTML, beforeend, vb.)
- `hx-indicator`: Yükleme durumu göstergeleri
- `hx-push-url`: Sayfa yenileme olmadan URL yönetimi

### Gelişmiş Özellikler
- **Polling**: `hx-trigger="every Xs"` ile gerçek zamanlı güncellemeler
- **Server-Sent Events (SSE)**: Canlı veri akışı
- **WebSocket Desteği**: İki yönlü iletişim
- **İstek Zincirleme**: Sıralı ve paralel istekler
- **Geçmiş Desteği**: Tarayıcı geri/ileri navigasyonu
- **Eklenti Sistemi**: Özel davranışlar ve entegrasyonlar

## Performans İpuçları

### HTMX Optimizasyonu
1. **Debouncing**: Sık tetiklenen olaylar için gecikme kullanın (`delay:500ms`)
2. **Tembel Yükleme**: Büyük içeriği talep üzerine yükleyin `hx-trigger="revealed"`
3. **Kısmi Güncellemeler**: Tüm sayfalar değil, sadece gerekli bölümleri güncelleyin
4. **Yükleme Göstergeleri**: İstekler sırasında görsel geri bildirim sağlayın
5. **İstek Toplu İşleme**: Mümkün olduğunda birden fazla isteği birleştirin

### Tailwind CSS Optimizasyonu
1. **PurgeCSS**: Üretimde kullanılmayan stilleri kaldırın
2. **JIT Modu**: Daha küçük yapılar için Just-In-Time derleme
3. **Bileşen Sınıfları**: Tekrarı azaltmak için yaygın kalıpları çıkarın
4. **Kritik CSS**: Daha hızlı ilk render için kritik stilleri satır içi yapın

### Genel En İyi Uygulamalar
1. **Önbellekleme**: Uygun HTTP önbellekleme başlıkları uygulayın
2. **Sıkıştırma**: gzip/brotli sıkıştırmasını etkinleştirin
3. **Görüntü Optimizasyonu**: WebP formatı ve tembel yükleme kullanın
4. **CDN Kullanımı**: Statik varlıkları CDN'den sunun
5. **Küçültme**: Üretimde CSS, JS ve HTML'yi küçültün

## Proje Yapısı

```
HtmxDashboard/
├── Controllers/          # MVC Controller'ları
├── Models/              # Veri modelleri ve görünüm modelleri
├── Views/               # HTMX ile Razor görünümleri
│   ├── Shared/         # Düzen ve kısmi görünümler
│   └── Home/           # Ana dashboard görünümleri
├── wwwroot/            # Statik varlıklar
│   ├── css/           # Derlenmiş CSS dosyaları
│   ├── js/            # JavaScript dosyaları
│   └── lib/           # Üçüncü taraf kütüphaneleri
├── tailwind.config.js  # Tailwind yapılandırması
├── postcss.config.js   # PostCSS yapılandırması
└── package.json        # Node.js bağımlılıkları
```

## Katkıda Bulunma

Katkılarınızı memnuniyetle karşılıyoruz! Lütfen Pull Request göndermekten çekinmeyin.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için LICENSE dosyasına bakın.