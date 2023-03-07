using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";

        public static string ColorAdded = "Renk Eklendi";

        public static string BrandAdded = "Marka Eklendi";

        public static string CustomerAdded = "Müşteri Eklendi";

        public static string UserAdded = "Kullanıcı Eklendi";

        public static string RentalAdded = "Kiralama Eklendi";

        public static string CustomerNotAdded = "Müşteri Eklenemedi";



        public static string CarCountIsMax = "Maximim Araç Sayısına Ulaşıldı";
        public static string CarDescriptionMustDifferent = "Araç Açıklamaları farklı olmalı";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError = "Hatalı Şifre";
        internal static string SuccessfulLogin = "Başarılı Giriş";
        internal static string UserAlreadyExists = "Kullanıcı Mevcut";
        internal static string AccessTokenCreated = "Token Oluşturuldu";
        internal static string UserRegistered = "Kayıt Olundu";
    }
}
