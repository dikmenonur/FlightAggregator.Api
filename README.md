[](https://sdmntpritalynorth.oaiusercontent.com/files/00000000-5b08-6246-a362-4044c9921d46/raw?se=2025-05-02T18%3A18%3A49Z&sp=r&sv=2024-08-04&sr=b&scid=3dd00eb4-1fe4-5cdd-824f-d821406d3a8c&skoid=54ae6e2b-352e-4235-bc96-afa2512cc978&sktid=a48cca56-e6da-484e-a814-9c849652bcb3&skt=2025-05-02T06%3A56%3A34Z&ske=2025-05-03T06%3A56%3A34Z&sks=b&skv=2024-08-04&sig=AqHWRW/jl4nWrzFIFEOExbgEFZ2%2BbbPEwtP1VVXhbpI%3D)


# **Progressive Streaming Search Mimarisi**

## **1. Mimarinin Genel Bileşenleri**

### **1.1. Backend (ASP.NET Core + SignalR)**

**1.1.1. SearchAggregatorController**

- Kullanıcının arama isteğini alır.
- Arka planda, arama işlemlerini başlatır.

**1.1.2. IFlightProviderService**

- Her uçuş sağlayıcısının implementasyonunu içeren bir arayüzdür.
- Sağlayıcılar bu arayüzden türetilir.

**1.1.3. Parallel Task Yapısı**

- `Task.WhenAny`, `Task.Run` ve `CancellationToken`kullanarak asenkron işlemler gerçekleştirilir.
- Bu yapı, her sağlayıcının bağımsız bir şekilde çalışmasını sağlar.

**1.1.4. SignalR Hub**

- UI’ya her yanıtı "progressive" olarak gönderir.
- Kullanıcıya anlık güncellemeler sağlar.
