# StoreFlow - Entity Framework Core & LINQ Mastery Project

StoreFlow, **ASP.NET Core MVC** mimarisi üzerine inşa edilmiş, veri erişim katmanında **Entity Framework Core**'un ileri düzey özelliklerini ve **LINQ** sorgularının gücünü sonuna kadar kullanan kapsamlı bir Dashboard ve yönetim sistemidir.

## 🚀 Proje Amacı
Bu proje; veritabanı yönetiminden performans optimizasyonuna, karmaşık raporlama sorgularından asenkron programlamaya kadar modern backend geliştirme süreçlerini gerçek bir senaryo üzerinde uygulamak amacıyla geliştirilmiştir.

## 🛠️ Teknik Yetkinlikler & Özellikler

### 🏗️ Mimari ve Veritabanı
- **Code First Yaklaşımı:** Migration süreçleri, model oluşturma ve `DbContext` yapılandırması.
- **İlişkisel Veri Yönetimi:** Bire-çok (One-to-Many) ilişkiler ve Navigation Property yönetimi.
- **Performans Odaklılık:** `AsNoTracking`, `SplitQuery` ve `AsQueryable` ile optimize edilmiş veri erişimi.

### 📊 İleri Düzey LINQ & EF Core Kullanımı
Proje kapsamında 70'ten fazla metot aktif olarak kullanılmıştır:
- **Sorgulama:** `Where`, `Select`, `OrderBy`, `OrderByDescending`, `Take`, `Skip`, `Distinct`.
- **Agrega Operasyonlar:** `Sum`, `Average`, `Count`, `Min`, `Max`, `Aggregate`.
- **İlişkisel Sorgular:** `Include`, `Join`, `GroupJoin`, `Concat`, `Union`, `Except`.
- **Mantıksal Denetimler:** `Any`, `All`, `Contains`, `StartsWith`, `EndsWith`.
- **Gelişmiş Metotlar:** `Chunk`, `Append`, `Prepend`, `DefaultIfEmpty`.

### 🖥️ Dashboard & UI Özellikleri
- **View Components:** Dinamik ve modüler bileşenler (Navbar, Sidebar, Statistics Cards).
- **Asenkron Programlama:** `Async/Await` yapısı ile bloklanmayan UI deneyimi.
- **İstatistik Yönetimi:** Alt sorgular ve karmaşık LINQ gruplandırmaları ile anlık veri analizi.

## 📂 Kullanılan Teknolojiler
- **Backend:** .NET 8 / ASP.NET Core MVC
- **ORM:** Entity Framework Core
- **Database:** MS SQL Server
- **Frontend:** Bootstrap, View Components, Partial Views
- **Tools:** Git, Bash, NuGet Package Manager

## 🔧 Kurulum
1. Projeyi klonlayın.
2. `appsettings.json` dosyasındaki Connection String'i kendi veritabanınıza göre düzenleyin.
3. Package Manager Console üzerinden `update-database` komutunu çalıştırın.
4. Projeyi ayağa kaldırın.
