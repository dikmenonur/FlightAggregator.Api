
# *![image](https://github.com/user-attachments/assets/f9761fa6-a77a-439f-bf98-fc65f9280eed)
*Progressive Streaming Search Mimarisi**

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
