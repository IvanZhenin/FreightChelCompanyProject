using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightChelCompanyProject.AppData
{
    /// <summary>
    /// Класс, который получает и хранит впоследствии ключевую информацию прошедшего авторизацию пользователя.
    /// </summary>
    public class LoginSector
    {
        public static int UserId { get; set; }
        public static int RoleId { get; set; }
        public static string Name { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static bool IsLoggedIn { get; set; } = false;
    }
}