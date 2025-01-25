using Barcode.INTERFACES;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Barcode.UCS
{
    /// <summary>
    /// Interaction logic for Text.xaml
    /// </summary>
    public partial class Text : UserControl, ITexts, IData, IPositions
    {
        public string Textss
        {
            get => MainTb.Text;
            set => MainTb.Text = value;
        }
        public string FontFamilys
        {
            get => MainTb.FontFamily.Source;
            set => SetFontFam(value);
        }

        private void SetFontFam(string fontFamilyName)
        {
            try
            {
                // Gelen string değeri FontFamily nesnesine çevirip kontrolün FontFamily özelliğine atıyoruz.
                MainTb.FontFamily = new FontFamily(fontFamilyName);
            }
            catch (Exception ex)
            {
                // Hata durumunda bir işlem yapabilir veya log yazabilirsiniz.
                Debug.WriteLine($"FontFamily ataması sırasında hata: {ex.Message}");
            }
        }

        public double FontSizes
        {
            get => MainTb.FontSize;
            set => MainTb.FontSize = value;
        }
        public string FontStylese
        {
            get { return MainTb.FontStyle.ToString(); }
            set { SetFontStyle(value); }
            }

        private void SetFontStyle(string fontStyleName)
        {
            try
            {
                FontStyle fontStyle;

                // Gelen string değeri FontStyle ile eşleştiriyoruz.
                if (fontStyleName.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                {
                    fontStyle = FontStyles.Normal;
                }
                else if (fontStyleName.Equals("Italic", StringComparison.OrdinalIgnoreCase))
                {
                    fontStyle = FontStyles.Italic;
                }
                else if (fontStyleName.Equals("Oblique", StringComparison.OrdinalIgnoreCase))
                {
                    fontStyle = FontStyles.Oblique;
                }
                else
                {
                    throw new ArgumentException($"Geçersiz FontStyle: {fontStyleName}");
                }

                MainTb.FontStyle = fontStyle;
            }
            catch (Exception ex)
            {
                // Hata durumunda bir işlem yapabilir veya log yazabilirsiniz.
                Debug.WriteLine($"FontStyle ataması sırasında hata: {ex.Message}");
            }
        }

        public string FontWeightse
        {
            get => MainTb.FontWeight.ToString();
            set => SetFontWeight(value);
        }
        private void SetFontWeight(string fontWeightName)
        {
            try
            {
                FontWeight fontWeight;

                // Gelen string değeri FontWeight ile eşleştiriyoruz.
                if (fontWeightName.Equals("Normal", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.Normal;
                }
                else if (fontWeightName.Equals("Bold", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.Bold;
                }
                else if (fontWeightName.Equals("Light", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.Light;
                }
                else if (fontWeightName.Equals("Thin", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.Thin;
                }
                else if (fontWeightName.Equals("Medium", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.Medium;
                }
                else if (fontWeightName.Equals("SemiBold", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.SemiBold;
                }
                else if (fontWeightName.Equals("ExtraBold", StringComparison.OrdinalIgnoreCase))
                {
                    fontWeight = FontWeights.ExtraBold;
                }
                else
                {
                    throw new ArgumentException($"Geçersiz FontWeight: {fontWeightName}");
                }

                MainTb.FontWeight = fontWeight;
            }
            catch (Exception ex)
            {
                // Hata durumunda bir işlem yapabilir veya log yazabilirsiniz.
                Debug.WriteLine($"FontWeight ataması sırasında hata: {ex.Message}");
            }
        }

        public void UserControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private MainWindow _MainWindow;
        private int _ID;
        private string _ElementName;

        public MainWindow MainWindow 
        { 
            get => _MainWindow;
            set => _MainWindow = value; 
        }

        public int ID 
        { 
            get => _ID;
            set => _ID = value;
        }
        public string ElementName 
        { 
            get => _ElementName;
            set => _ElementName = value;
        }

        public int Type => 1;

        public Point Position 
        { 
            get => new Point(Canvas.GetLeft(this), Canvas.GetTop(this)); 
            set 
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }
        }
        private Point _RealPosition;
        public Point RealPosition 
        { 
            get => _RealPosition;
            set => _RealPosition = value; 
        }
        private Paper _paper;   
        public Paper Paper 
        { 
            get => _paper;
            set => _paper = value; 
        }

        public Text()
        {
            InitializeComponent();
        }
    }
}
