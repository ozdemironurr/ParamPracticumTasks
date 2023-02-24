using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Erişim belirteci oluşturuldu";

        public static string WrongIdEntry = "Bu id için kayıt bulunmamaktadır.";
        public static string CategoryNameAlreadyExists = "Bu kategori adınında bir kategori bulunmaktadır.";
        public static string ProductNameAlreadyExists = "Bu ürün adınında bir ürün bulunmaktadır.";

        public static string UsersListed = "Kullanıclar listelendi.";
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
        

        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductListed = "Ürünler listelendi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductLimitExceded = "Maksimum ürün ekleme sınırına ulaşıldı.";

        public static string CategoryAdded = "Kategori eklendi.";
        public static string CategoryListed = "Kategoriler listelendi.";
        public static string CategoryUpdated = "Kategori güncellendi.";
        public static string CategoryDeleted = "Kategori silindi.";
        public static string CategoryLimitExceded = "Maksimum kategori ekleme sınırına ulaşıldı.";
        
    }
}
