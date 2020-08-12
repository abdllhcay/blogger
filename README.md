# blogger

.NET Core 3.0 ile örnek projelerde kullanılmak üzere yazılmış basit bir blog API'si. 

Projede yer alan pattern'ler:
- DDD (Domain Driven Design) : Mimarisel bir pattern olan DDD kullanarak data-access layer, business layer ve application layer birbirinden ayrı olarak geliştirilebilir, bağımlılık azalır.
- Repository Pattern : Her bir entity class'ı için CRUD operasyonlarını ayrı ayrı yazmak yerine bir base class kullanarak tüm entity'ler için ortak metodlar tanımlanabilir. EF Core zaten size bu imkanı sağlasa da gösterim amaçlı kullanmak tercih edilmiştir.
- Builder Pattern : Filtrelemede uzun ve karmaşık metodlardan sakınmak için builder pattern tercih edilmiştir. Böylece her bir filtre birbirinden bağımsız olarak uygulanabilir.

Projede kullanılan teknolojiler:
- SQLServer : SQL Server ile birçok proje geliştirdim
- EF Core : EF Core ile pek çok projede ORM işlevlerini kullandım
- Design pattern'ler : Projede yer alan design pattern'lerin hepsi ile geliştirme yaptım

Projeye eklenecek özellikler:
- Üyelik sistemi
- Makale yayınlanma tarihini schedule etme
