# StoreFlow - ASP.NET Core MVC & EF Core Mastery

StoreFlow, veri erişim katmanında **Entity Framework Core**'un tüm gücünü ve **LINQ** sorgularının esnekliğini sergileyen, modern bir Dashboard yönetim sistemidir. Bu proje, **M&Y Yazılım Eğitim Akademi Danışmanlık** çatısı altında, değerli eğitmenim **Murat Yücedağ** rehberliğinde geliştirilmiş bir Case Study çalışmasıdır.

## 🎯 Proje Amacı
StoreFlow; ürün, sipariş ve müşteri döngüsünü yöneten bir iş modeli üzerinden, sadece "çalışan kod" değil, "en optimize kod" prensibiyle kurgulanmıştır. Proje kapsamında 80'e yakın farklı EF Core ve LINQ metodu gerçek hayat senaryoları üzerinde uygulanmıştır.

## 🛠️ Teknolojik Yığın
- **Framework:** .NET 9.0 (ASP.NET Core MVC)
- **ORM:** Entity Framework Core (Code First)
- **Database:** MS SQL Server
- **UI/UX:** Bootstrap, Razor View Engine, ViewComponents
- **Asistan Araçlar:** Google Stitch AI & Claude AI (UI Optimisation)

## 📈 EF Core & LINQ Yetkinlikleri (80+ Metot)
Proje içerisinde veritabanı sorgulama yeteneklerini maksimize eden şu yapılar aktif olarak kullanılmıştır:
- **Gelişmiş Sorgular:** `Join`, `GroupJoin`, `Include`, `Intersect`, `Union`, `ExceptBy`, `DefaultIfEmpty`.
- **Performans Optimizasyonu:** `AsNoTracking`, `SplitQuery`, `AsParallel`, `Tracking` davranışları ve `AsQueryable` ile dinamik sorgu yönetimi.
- **Veri Manipülasyonu:** `Chunk`, `Append`, `Prepend`, `AddRange`, `Entry/Property bazlı Update`.
- **Agregalar & Analitik:** Alt sorgularla desteklenmiş `Sum`, `Avg`, `Min`, `Max`, `Count` ve `Select` kombinasyonları.

## ✨ Öne Çıkan Özellikler
- **Dinamik Dashboard:** Günlük, haftalık ve aylık bazda satış ve aktivite verilerinin anlık analizi.
- **Modüler Mimari:** `ViewComponent` ve `Partial View` yapıları ile sürdürülebilir arayüz bileşenleri.
- **İstatistik Yönetimi:** Karmaşık LINQ gruplandırmaları ile zengin veri görselleştirme.
- **Görev (ToDo) Takibi:** Önceliklendirme sistemine sahip, tam fonksiyonel görev yönetim modülü.
- **Asenkron Yapı:** Tüm veritabanı süreçlerinde `Task` ve `Async/Await` kullanımı.
## 💻 Kurulum

Projeyi yerelinizde çalıştırmak için aşağıdaki adımları sırasıyla uygulayın:

```bash
# 1. Projeyi bilgisayarınıza indirin
git clone [https://github.com/bariscoskunl/StoreFlow.git](https://github.com/bariscoskunl/StoreFlow.git)

# 2. appsettings.json dosyasındaki Connection String bilgisini kendi SQL Server ayarlarınıza göre güncelleyin.

# 3. Package Manager Console üzerinden veritabanını oluşturun
Update-Database

# 4. Projeyi ayağa kaldırın!

📫 İletişim
Proje hakkında sorularınız veya iş birliği teklifleriniz için bana aşağıdaki kanallardan ulaşabilirsiniz:

LinkedIn: linkedin.com/in/bariscoskun441

E-Posta: bariscoskun441@gmail.com

GitHub: github.com/bariscoskunl
