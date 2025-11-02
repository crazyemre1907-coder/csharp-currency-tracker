# 💹 CurrencyTracker_Chart

Basit bir **C# WinForm** projesidir. Gerçek zamanlı döviz kurlarını çeker ve bir **grafik (chart)** üzerinde gösterir.

## 🚀 Özellikler
- TRY bazlı döviz verisi çeker (USD, EUR, GBP)
- Verileri **sütun grafiği** (Column Chart) olarak gösterir
- API: [exchangerate.host](https://exchangerate.host)

## 🧩 Kullanım
1. Visual Studio’da yeni bir **Windows Forms App (.NET 6)** projesi oluşturun.  
2. Form’a şu bileşenleri ekleyin:
   - 1 adet **Chart** → `chart1`
   - 1 adet **Button** → `btnGetRates`
   - 1 adet **Label** → `lblInfo`
3. `Form1.cs` içeriğini bu repodaki dosya ile değiştirin.
4. Çalıştırın ve “Kurları Getir” butonuna tıklayın 🎯

## 📂 Dosya Yapısı
```
CurrencyTracker_Chart/
│
├── Form1.cs
└── README.md
```

## 👤 Hazırlayan
**Emre Dinç**  
🛠️ LinkedIn portföy örneği olarak kullanılabilir.
