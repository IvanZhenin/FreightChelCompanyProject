using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace FreightChelCompanyProject.AppData
{
    /// <summary>
    /// Класс, предназначенный для переходов страниц в окнах.
    /// </summary>
    public class FrameSector
    {
        public static Frame AdminFrame { get; set; }
        public static Frame BookerFrame { get; set; }
        public static Frame BookerAssistFrame { get; set; }
        public static Frame DispatcherFrame { get; set; }
        public static Frame DispatcherAssistFrame { get; set; }
        public static Frame ManagerFrame { get; set; }
        public static Frame ManagerAssistFrame { get; set; }
        
    }
}