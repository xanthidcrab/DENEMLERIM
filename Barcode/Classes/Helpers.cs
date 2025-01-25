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
  
        public static void PositionsAlligner(Paper paper, IPositions element)
        {
            // Elementin pozisyonunu alıyoruz (x, y koordinatları)
            var elementPosition = element.RealPosition;

            // Paper'ın gerçek genişlik ve yüksekliği
            var paperRealWidth = paper.RealSize.Width;
            var paperRealHeight = paper.RealSize.Height;

            // Paper'ın aktif genişlik ve yüksekliği
            var paperActHeight = paper.Size.Height;
            var paperActWidth = paper.Size.Width;

            var pwxprw = paperActWidth * elementPosition.X;
            var paxprh = paperActHeight * elementPosition.Y;
            var widthCont = element as ISizes;

            var x = (pwxprw/paperRealWidth) - (widthCont.Size.Width / 2) ;
            var y = (paxprh/paperRealHeight) - (widthCont.Size.Height / 2);
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
        public static void ElementAllignerWidth(ISizes Element, Paper Paper)
        {
            // Kağıdın gerçek genişlik ve yüksekliği
            var ElementRealWidth = Element.RealSize.Width;
            var ElementRealHeight = Element.RealSize.Height;

            var ElementActWidth = Paper.Size.Width;
            var ElementActHeight = Paper.Size.Height;

            var PaperRealw = Paper.RealSize.Width;
            var PaperRealh = Paper.RealSize.Height;

            // Paper'ın gerçek genişlik ve yüksekliği
            var PaperActHeight = Paper.PaperCanvas.ActualHeight;
            var PaperActWidth = Paper.PaperCanvas.ActualWidth;

            var targetWidth = (ElementRealWidth * ElementActWidth) / PaperRealw;

            var targetHeight = (ElementRealHeight * ElementActHeight) / PaperRealh;


            // Element'ı hizalama (gerçek boyutları atama)
            Size size = new Size(targetWidth, targetHeight);
            Element.Size = size;

            // Element'ı Paper'ın merkezine yerleştirmek
            var offsetX = (PaperActWidth - targetWidth) / 2;
            var offsetY = (PaperActHeight - targetHeight) / 2;
            
        }
        public static void UpdateRealPos(IPositions element)
        {
            var elementsizes = (ISizes)element;
            var elementPosition = element.Position;
            var elementRealPosition = element.RealPosition; 
           var elementSize = elementsizes.Size;    
            var elementRealSize = elementsizes.RealSize;
            var elementPaper = (IHasPaper)element;
            var paper = elementPaper.Paper;
            var paperRealSize = paper.RealSize;
            var paperSize = paper.Size;

            var ratioX = elementPosition.X / elementRealPosition.X;
            var ratioY = elementPosition.Y / elementRealPosition.Y;

            var newX = element.Position.X * ratioX;
            var newY = element.Position.Y * ratioY;

            Point newRealPosition = new Point(newX, newY);
            element.RealPosition = newRealPosition;


        }
    }
}
