namespace TracingNetCore.Business.Constants
{
    public static class DataMessages
    {
        // For Devices Success
        public static string AddDevice = "Cihaz Başarıyla Eklendi.";
        public static string UpdateDevice = "Cihaz Başarıyla Güncellendi.";
        public static string DeleteDevice = "Cihaz Başarıyla Silindi.";

        // For Device Error
        public static string DeviceAlreadyExist = "Cihaz Zaten Sistemde Kayıtlı.";


        // For Requests
        public static string AddRequest = "İstek Başarıyla Eklendi.";
        public static string UpdateRequest = "İstek Başarıyla Güncellendi.";

        // For Employees
        public static string AddEmployee = "Kullanıcı Başarıyla Eklendi";
        public static string UpdateEmployee = "Kullanıcı Başarıyla Güncellendi.";
        public static string DeleteEmployee = "Kullanıcı Başarıyla Silindi.";

        // For Region
        public static string AddRegion = "Bölge Başarıyla Eklendi.";
        public static string UpdateRegion = "Bölge Başarıyla Güncellendi.";
        public static string DeleteRegion = "Bölge Başarıyla Silindi.";

        // For Device Type
        public static string AddDeviceType = "Cihaz Türü Başarıyla Eklendi.";
        public static string UpdateDeviceType = "Cihaz Türü Başarıyla Güncellendi.";
        public static string DeleteDeviceType = "Cihaz Türü Başarıyla Silindi.";

        // For Employee Devices
        public static string AddEmployeeDevice = "Personele Cihaz Başarıyla Atandı.";
        public static string DeleteEmployeeDevice = "Personele Atanmış Cihaz Başarıyla Kaldırıldı.";

        // For Alarm
        public static string AddAlarm = "Personele Durum Mesajı İletildi.";

        // For User & Access Token
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Hatalı Parola Girdiniz.";
        public static string SuccessfulLogin = "Başarıyla Giriş Yapıldı.";
        public static string UserAlreadyExists = "Bu Kullanıcı Zaten Sistemde Kayıtlı.";
        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi.";
        public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz Bulunmuyor.";

    }
}
