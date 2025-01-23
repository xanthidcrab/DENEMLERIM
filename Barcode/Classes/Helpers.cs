using Barcode.INTERFACES;
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
using System.Windows.Media.Animation;

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
  
        public static void WidthAligner(Paper paper, IPositions element)
        {
            // Elementin pozisyonunu alıyoruz (x, y koordinatları)
            var elementPosition = element.RealPosition;

            // Paper'ın gerçek genişlik ve yüksekliği
            var paperRealWidth = paper.RealSize.Width;
            var paperRealHeight = paper.RealSize.Height;

            // Paper'ın aktif genişlik ve yüksekliği
            var paperActHeight = paper.ActualHeight;
            var paperActWidth = paper.ActualWidth;

            var pwxprw = paperActWidth * elementPosition.X;
            var paxprh = paperActHeight * elementPosition.Y;
            var widthCont = element as ISizes;

            var x = (pwxprw/paperRealWidth) - widthCont.Size.Width ;
            var y = (paxprh/paperRealHeight) - widthCont.Size.Height;
            // Paper'ın pozisyonunu ayarla
            element.Position = new Point(x, y);
        }
        public static void PaperWidthAligner(ISizes paper, Border border)
        {
            // Kağıdın gerçek genişlik ve yüksekliği
            var paperRealWidth = paper.RealSize.Width;
            var paperRealHeight = paper.RealSize.Height;

            // Border'ın gerçek genişlik ve yüksekliği
            var borderActHeight = border.ActualHeight;
            var borderActWidth = border.ActualWidth;

            // Border alanının %60'ı
            var borderArea = (borderActHeight * borderActWidth) * 0.6;

            // Kağıdın en-boy oranı (aspect ratio)
            var aspectRatioOfPaper = paperRealWidth / paperRealHeight;

            // Paper'ın yeni genişliği ve yüksekliği, %60'lık alanı kapsayacak şekilde hesaplanıyor
            var targetWidth = Math.Sqrt(borderArea * aspectRatioOfPaper);
            var targetHeight = targetWidth / aspectRatioOfPaper;

            // Paper'ı hizalama (gerçek boyutları atama)
            Size size = new Size(targetWidth, targetHeight);
            paper.Size = size;

            // Paper'ı Border'ın merkezine yerleştirmek
            var offsetX = (borderActWidth - targetWidth) / 2;
            var offsetY = (borderActHeight - targetHeight) / 2;
        }
        public static void ElementAllignerWidth(ISizes paper, Paper border)
        {
            // Kağıdın gerçek genişlik ve yüksekliği
            var paperRealWidth = paper.RealSize.Width;
            var paperRealHeight = paper.RealSize.Height;

            var paperActWidth = border.Size.Width;
            var paperActHeight = border.Size.Height;

            var borderRealw = border.RealSize.Width;
            var borderRealh = border.RealSize.Height;

            // Border'ın gerçek genişlik ve yüksekliği
            var borderActHeight = border.ActualHeight;
            var borderActWidth = border.ActualWidth;

            var targetWidth = (paperRealWidth * borderActWidth) / borderRealw;

            var targetHeight = (paperRealHeight * borderActHeight) / borderRealh;


            // Paper'ı hizalama (gerçek boyutları atama)
            Size size = new Size(targetWidth, targetHeight);
            paper.Size = size;

            // Paper'ı Border'ın merkezine yerleştirmek
            var offsetX = (borderActWidth - targetWidth) / 2;
            var offsetY = (borderActHeight - targetHeight) / 2;
            
        }
    }
}
