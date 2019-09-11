# Katmanli-Mimari<br/><br/>

*Katmanlı Mimari Projemizde(LAP-Layered Architectural Project ) genelde kullanılacak teknolojiler:<br/>
<br/>
1-Katmanlar Entities-Dal-Bll-UI(mvc)-servis(Api)-Core(AOP uygulamayı dikene kesen yapılar) <br/>
2-Entity Framework Core un Code First yaklaşımı<br/>
3-Migration Ekleme<br/>
4-LocalDb insert<br/>
5-Interface,Abstract,Static,Generic sınıflar,virtual , Override <br/>
6-DataAnnotations ,Customer Attribute ,<br/>
7-Context LazyLoading<br/>
8-IOC , AOP (Asp.Net Core build-in Service, Castle Windsor, loglama,Exception Handling )<br/>
9-Loglama<br/>
10-Exception Handling<br/>
11-DI (Dependency Injection)<br/>
12-SOLID prensiplerine göre kodlama<br/>
13-unit Test(TDD)<br/>
14-MVC <br/>
15-AngularJs <br/>
16-DevExtreme<br/>
17-Unit Of Work Design Pattern<br/>
18-ASP.NET Core Identity<br/>
19-Redis<br/>
20-Docker<br/>
21-Bundler ve Minifier ile cs ve js dosyaları<br/>
22-Swagger ile Apileri test etme<br/>


<br/>
 *** Asp.net Core en az Version="2.2.0" olmalı. öğrenmek içi CMD aç  "dotnet --version " komutunu yaz.<br/>
 dotnet version 2.2.0 düşükse yada dotnet komutu çalışmıyorsa SDK yı aşağıdaki linkden indir.<br/>
 https://github.com/dotnet/core/blob/master/release-notes/2.2/2.2.7/2.2.7-download.md buradaki linkden uygun SDK yı indirebilirsiniz.<br/>
 <br/>
 
 *** Projeyi indir , Visual Studio da açtıktan sonra "LAP.MVC" seçili proje yap (Set as StartUp Project ),<br/>
 onra "Package Manager Console" aç, Default project olarak  "LAP.DAL" seç <br/>
 console  "Update-Database " komutunu  yaz enter ,  LocalDb veritabanı create edilecek.<br/>
 <br/>
 
 ***Api katmanında istekte yapmak içi Vs çalıştırmadan(IIS olmadan) yapmak için, CMD aç ve aşağıdai komutları yaz. (.Net Core CLI). Projedeki dll yolunu yaz.<br/>
    dotnet "C:\Users\hasan\source\repos\LAP\LAP.API\bin\Debug\netcoreapp2.2\LAP.API.dll"<br/>
 komutunu yazdıktan sonra POSTMAN gibi programlar ile  http://localhost:5000/api/customer istek yaptığında tüm müşteri listesi gelecek<br/>
 <br/>

