# Server
IOTECHMFirat
Görsel Arayüz:
Arayüzde 2 grup halinde 4 komponent olmalı.
1. Grup (Lamba Grubu): Üzerinde lambayı simgeleyen bir grafik olmalı ve bir buton bulunmalı.
2. Grup (Text Grubu): Bir text alan ile bir buton bulunmalı.
Lamba ikonunu 2 bildirim (state) sahibi olmalı;
1-Açık, 
2-Kapalı.
Fonksiyon:
- Lamba butonuna basıldığında lamba ikonu açık ise kapalı konuma (state) geçmeli, kapalı ise açık 
konuma geçmeli. 
- Lamba ikonu her durum değiştirdiğinde client uygulamalara hangi konuma geçtiğini bildirmeli .
- Text alana klavyeden giriş yapılabilmeli ve alan her değiştiğinde client uygulamalara son text değerini 
göndermeli. 
- Text butonuna basıldığında random bir sayı oluşturulup text alana yazılmalı. 
-Client uygulamalarda lamba durumunu değiştir yada text alana random sayı yaz gibi komutlar yerini 
getirilmeli. Yapılan değişiklikler tüm clientlara gönderilmeli.
Client Uygulaması: 
Görsel Arayüz:
Arayüz üzerinde 2 adet buton olmalı.
1-Lamba Butonu. 
2-Text Butonu.
Fonksiyon:
-Lamba butonuna basıldığında server yazılımına bu butona basıldığı bilgisi gitmeli. Server bilgiyi aldığında 
lambanın Durumunu değiştirmeli (serverdaki lamba açık ise kapanmalı, kapalı ise açık konuma geçmeli).
-Serverdan lambanın durumunun değiştiğine dair bir bilgi geldiğinde lamba butonu serverdaki lambanın 
durumuna göre renk değiştirmeli. Serverdaki lamba açık ise açık renkli, kapalı ise daha koyu renkli olarak.
-Text butonunun üzerindeki yazı serverdaki text alandaki ile aynı olmalı ve serverdaki text alan değişince 
değişmeli. 
-Client üzerindeki text butonuna basıldığında server random bir sayı oluşturup text alana yerleştirmeli ve 
serverda oluşan random sayı clienttaki text butonunun üzerinde görüntülenmeli. 
-Client ilk açıldığında servera bağlanıp uygulamadaki lambanın ve textin mevcut değerlerini alıp ilgili 
yerlerde göstermeli.
