using Barcode.UCS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Barcode.Classes
{
    public static class Helpers
    {
        public static Size TempSize { get; set; }
        public static void UpdateUI(ComboBox comboBox)
        {
            UpdatePapersCb(comboBox);
        }

        private static void UpdatePapersCb(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "PAPERS\\");
            foreach (string file in files)
            {
                comboBox.Items.Add(System.IO.Path.GetFileName(file));
            }
        }
        public static Size RatioAlligner(Border border, Size size)
        {
            TempSize = size;
            double RatioOfRecievedSize = (size.Width ) / (size.Height );
            double CanvasWidth = border.ActualWidth ;
            
            double ratio = CanvasWidth/(size.Width)  ;
            Size TransmiteSize = new Size()
            {
                Width = size.Width * (ratio/1.2)
            };
            TransmiteSize.Height = (TransmiteSize.Width / RatioOfRecievedSize) ;
            return TransmiteSize;
        }
        public static Size RatioDeAlligner(Border border, Size size)
        {
            double RatioOfRecievedSize = (size.Width) / (size.Height);
            double CanvasWidth = border.ActualWidth;

            double ratio = CanvasWidth / (size.Width);
            Size TransmiteSize = new Size()
            {
                Width = size.Width / (ratio / 1.2)
            };
            TransmiteSize.Height = (TransmiteSize.Width / RatioOfRecievedSize);
            return TransmiteSize;
        }
    }
}
