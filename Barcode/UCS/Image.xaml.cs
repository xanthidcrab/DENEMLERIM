﻿using Barcode.Classes;
using Barcode.INTERFACES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    /// Interaction logic for Image.xaml
    /// </summary>
    public partial class Image : UserControl, IData, IPositions, ISizes, IConvertDataRow, IImage
    {
        private MainWindow _mainWindow;
        private int _id;
        private string _elementName;
        private int _type;
        private Point _position;
        private Size _size;
       

        public CRUD CRUD
        {
            get => new CRUD();
        }
        
        public Size Size
        {
            get 
            {
                _size.Width = mainImage.Width;
                _size.Height = mainImage.Height;
                return _size;
            } 
            set  { mainImage.Width = value.Width;
                mainImage.Height = value.Height;
            }
            
        }

        public MainWindow MainWindow
        {
            get => _mainWindow;
            set => _mainWindow = value;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public string ElementName
        {
            get => _elementName;
            set => _elementName = value;
        }

        public int Type
        {
            get => 0;
        }

        public Point Position
        {
            get 
            {
                _position.X = Canvas.GetLeft(this);
                _position.Y = Canvas.GetTop(this);
                return _position;
            }
            set
            {
                Canvas.SetLeft(this, value.X);
                Canvas.SetTop(this, value.Y);
            }
        }

        public string ImagePath
        {
            get => mainImage.Source.ToString();
            set => mainImage.Source = new BitmapImage(new Uri(value));
        }
        public BitmapImage Bitmap
        {
            get => new BitmapImage(new Uri(mainImage.Source.ToString()));

        }
        public Image()
        {
            InitializeComponent();
            

        }

        public DataRow ConvertDataRow()
        {
            DataRow row = CRUD.ImageTable.NewRow();
            row["ID"] = ID;
            row["ElementName"] = ElementName;
            row["Width"] = Size.Width;
            row["Height"] = Size.Height;
            row["ImagePath"] = mainImage.Source.ToString();
            return row;
         }
    }
}
