using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Xml.Linq;
using netDxf;
using netDxf.Entities;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Diagnostics;
using netDxf.Blocks;
using System.Windows.Media.Media3D;
using SharpDX;

namespace CsvVisualizer.CLASSES
{
    public class DXFfields
    {
        public System.Windows.Shapes.Path path { get; set; }
        public DXFfields()
        {
            path = new System.Windows.Shapes.Path();
        }
        //Summary: Bu method içerisine aldığı dosya yolundan okuduğu dxf dosyasını gönderilen canvasın ortasına path olarak ekler.
        public void LoadFiles(string FilePath, Canvas canvas)
        {

            DxfDocument dxfDocument = DxfDocument.Load(FilePath);
            
            path.Stroke = new SolidColorBrush(Colors.Black);
            PathGeometry pathGeometry = new PathGeometry();

            path.StrokeThickness = 0.2;
            var a = dxfDocument.Blocks;
            foreach (var block in a.Items)
            {
                if (block.Entities.Count > 0)
                {
                    var b = block;

                    foreach (var child in b.Entities)
                    {

                        switch (child.Type)
                        {
                            case EntityType.Line:
                                netDxf.Entities.Line line = (netDxf.Entities.Line)child;
                                PathFigure pathFigure = new PathFigure();
                                pathFigure.StartPoint = new System.Windows.Point(line.StartPoint.X, line.StartPoint.Y);
                                LineSegment lineSegment = new LineSegment() { Point = new System.Windows.Point(line.EndPoint.X, line.EndPoint.Y) };
                                pathFigure.Segments.Add(lineSegment);
                                pathGeometry.Figures.Add(pathFigure);
                                break;
                            case EntityType.Arc:
                                Arc arc = (Arc)child;
                                PathFigure arcSegment = CreateArc(arc.Center.X, arc.Center.Y, arc.Radius, arc.StartAngle, arc.EndAngle);
                                pathGeometry.Figures.Add(arcSegment);
                                break;
                            case EntityType.Polyline2D:
                                netDxf.Entities.Polyline2D lines = (netDxf.Entities.Polyline2D)child;
                                List<Polyline2DVertex> polyline2DVertex = lines.Vertexes;

                                if (polyline2DVertex == null || polyline2DVertex.Count == 0)
                                    break;

                                // PathFigure başlat
                                PathFigure pathFigures = new PathFigure
                                {
                                    StartPoint = new System.Windows.Point(polyline2DVertex[0].Position.X, polyline2DVertex[0].Position.Y),
                                    IsClosed = lines.IsClosed // Polyline kapalı mı açık mı kontrol et
                                };

                                // PolyLineSegment oluştur ve tüm noktaları ekle
                                PolyLineSegment polyLineSegment = new PolyLineSegment();

                                for (int i = 1; i < polyline2DVertex.Count; i++) // İlk nokta zaten StartPoint
                                {
                                    polyLineSegment.Points.Add(new System.Windows.Point(polyline2DVertex[i].Position.X, polyline2DVertex[i].Position.Y));
                                }

                                // PolyLineSegment'i PathFigure'a ekle
                                pathFigures.Segments.Add(polyLineSegment);

                                // PathGeometry'ye ekle
                                pathGeometry.Figures.Add(pathFigures);
                                break;
                        }
                    }
                    foreach (var child in b.Entities)
                    {

                        switch (child.Type)
                        {
                            case EntityType.Line:
                                netDxf.Entities.Line line = (netDxf.Entities.Line)child;
                                PathFigure pathFigure = new PathFigure();
                                pathFigure.StartPoint = new System.Windows.Point(line.StartPoint.X, line.StartPoint.Y);
                                LineSegment lineSegment = new LineSegment() { Point = new System.Windows.Point(line.EndPoint.X, line.EndPoint.Y) };
                                pathFigure.Segments.Add(lineSegment);
                                pathGeometry.Figures.Add(pathFigure);
                                break;
                            case EntityType.Arc:
                                Arc arc = (Arc)child;
                                PathFigure arcSegment = CreateArc(arc.Center.X, arc.Center.Y, arc.Radius, arc.StartAngle, arc.EndAngle);
                                pathGeometry.Figures.Add(arcSegment);
                                break;
                            case EntityType.Polyline2D:
                                netDxf.Entities.Polyline2D lines = (netDxf.Entities.Polyline2D)child;
                                List<Polyline2DVertex> polyline2DVertex = lines.Vertexes;

                                if (polyline2DVertex == null || polyline2DVertex.Count == 0)
                                    break;

                                // PathFigure başlat
                                PathFigure pathFigures = new PathFigure
                                {
                                    StartPoint = new System.Windows.Point(polyline2DVertex[0].Position.X, polyline2DVertex[0].Position.Y),
                                    IsClosed = lines.IsClosed // Polyline kapalı mı açık mı kontrol et
                                };

                                // PolyLineSegment oluştur ve tüm noktaları ekle
                                PolyLineSegment polyLineSegment = new PolyLineSegment();

                                for (int i = 1; i < polyline2DVertex.Count; i++) // İlk nokta zaten StartPoint
                                {
                                    polyLineSegment.Points.Add(new System.Windows.Point(polyline2DVertex[i].Position.X, polyline2DVertex[i].Position.Y));
                                }

                                // PolyLineSegment'i PathFigure'a ekle
                                pathFigures.Segments.Add(polyLineSegment);

                                // PathGeometry'ye ekle
                                pathGeometry.Figures.Add(pathFigures);
                                break;
                        }

                    }
                }
            }




            path.Data = pathGeometry;
            // Path geometrisinin sınırlarını hesapla
            Rect bounds = path.Data.Bounds;

            // Canvas'ın merkezini hesapla
            double canvasCenterX = canvas.ActualWidth / 2;
            double canvasCenterY = canvas.ActualHeight / 2;

            // Geometri merkezini hesapla
            double geometryCenterX = bounds.Left + bounds.Width / 2;
            double geometryCenterY = bounds.Top + bounds.Height / 2;

            // Merkeze taşıma için konum belirle
            double offsetX = canvasCenterX - geometryCenterX;
            double offsetY = canvasCenterY - geometryCenterY;
            if (bounds.Size.Width > 100)
            {
                ScaleTransform scaleTransform = new ScaleTransform(3, 3);
                // Merkez noktası (Path'in merkezinden ölçekleme yapmak için ayarlayın)

                scaleTransform.CenterX = bounds.Left + bounds.Width / 2;
                scaleTransform.CenterY = bounds.Top + bounds.Height / 2;

                // ScaleTransform'u Path'e ekle
                path.RenderTransform = scaleTransform;

            }
            else
            {

                ScaleTransform scaleTransform = new ScaleTransform(5, 5);
                // Merkez noktası (Path'in merkezinden ölçekleme yapmak için ayarlayın)

                scaleTransform.CenterX = bounds.Left + bounds.Width / 2;
                scaleTransform.CenterY = bounds.Top + bounds.Height / 2;

                // ScaleTransform'u Path'e ekle
                path.RenderTransform = scaleTransform;
            }



            Canvas.SetLeft(path, offsetX);
            Canvas.SetTop(path, offsetY);
            if (canvas.Children.Count > 0)
            {
                canvas.Children.Clear();
            }

            canvas.Children.Add(path);

        }
        

        public PathFigure CreateArc(double centerX, double centerY, double radius, double startAngle, double endAngle)
        {
            // Başlangıç ve bitiş açılarını radyana çevir.
            double startAngleRad = startAngle * Math.PI / 180;
            double endAngleRad = endAngle * Math.PI / 180;

            // Yayın başlangıç ve bitiş noktalarını hesapla.
            System.Windows.Point startPoint = new System.Windows.Point(
                centerX + radius * Math.Cos(startAngleRad),
                centerY + radius * Math.Sin(startAngleRad)
            );

            System.Windows.Point endPoint = new System.Windows.Point(
                centerX + radius * Math.Cos(endAngleRad),
                centerY + radius * Math.Sin(endAngleRad)
            );

            // ArcSegment oluştur.
            ArcSegment arcSegment = new ArcSegment
            {
                Point = endPoint,
                Size = new Size(radius, radius), // Elipsin yarıçapları
                SweepDirection = SweepDirection.Clockwise, // Saat yönünde mi, ters mi?
                IsLargeArc = false // Büyük bir yay mı?
            };

            // PathFigure ile başlat.
            PathFigure pathFigure = new PathFigure
            {
                StartPoint = startPoint,
                Segments = new PathSegmentCollection { arcSegment }
            };
            return pathFigure;
        }
        public GeometryModel3D ConvertPathToGeometryModel3D(PathGeometry pathGeometry)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            Point3DCollection positions = new Point3DCollection();
            Int32Collection triangleIndices = new Int32Collection();

            foreach (var pathFigure in pathGeometry.Figures)
            {
                List<Point3D> figurePoints = new List<Point3D>();
                foreach (var segment in pathFigure.Segments)
                {
                    if (segment is PolyLineSegment lineSegment)
                    {
                        var a = lineSegment.Points;
                        foreach (var point in a)
                        {
                            figurePoints.Add(new Point3D(point.X, point.Y, 0));

                        }
                    }
                    else if (segment is ArcSegment arcSegment)
                    {
                        // Yay segmentini daha fazla noktayla yaklaşık olarak temsil et
                        Point3D startPoint = figurePoints.Count > 0 ? figurePoints.Last() : new Point3D(pathFigure.StartPoint.X, pathFigure.StartPoint.Y, 0);
                        double radiusX = arcSegment.Size.Width;
                        double radiusY = arcSegment.Size.Height;
                        double startAngle = Math.Atan2(startPoint.Y - arcSegment.Point.Y, startPoint.X - arcSegment.Point.X) * 180 / Math.PI;
                        double sweepAngle = arcSegment.IsLargeArc ? (arcSegment.SweepDirection == SweepDirection.Clockwise ? 360 - startAngle : -360 - startAngle) : (arcSegment.SweepDirection == SweepDirection.Clockwise ? startAngle : -startAngle);
                        int numPoints = Math.Max(3, (int)Math.Abs(sweepAngle) / 10); // Yay uzunluğuna göre nokta sayısı
                        for (int i = 1; i <= numPoints; i++)
                        {
                            double angle = startAngle + sweepAngle * i / numPoints;
                            double x = arcSegment.Point.X + radiusX * Math.Cos(angle * Math.PI / 180);
                            double y = arcSegment.Point.Y + radiusY * Math.Sin(angle * Math.PI / 180);
                            figurePoints.Add(new Point3D(x, y, 0));
                        }
                    }
                }

                // Figure noktalarını üçgenlere dönüştür (fan triangulation)
                if (figurePoints.Count > 2)
                {
                    int firstPointIndex = positions.Count;
                    foreach (var point in figurePoints)
                    {
                        positions.Add(point);
                    }
                    for (int i = 1; i < figurePoints.Count - 1; i++)
                    {
                        triangleIndices.Add(firstPointIndex);
                        triangleIndices.Add(firstPointIndex + i);
                        triangleIndices.Add(firstPointIndex + i + 1);
                    }
                }
            }

            meshGeometry.Positions = positions;
            meshGeometry.TriangleIndices = triangleIndices;

            Material material = new DiffuseMaterial(new SolidColorBrush(Colors.Black));
            GeometryModel3D geometryModel = new GeometryModel3D();
            geometryModel.Geometry = meshGeometry;
            geometryModel.Material = material;

            return geometryModel;
        }
        public GeometryModel3D ExtrudePath(PathGeometry pathGeometry, double extrusionDepth)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            List<Point3D> positions = new List<Point3D>(); // List kullanıyoruz
            Int32Collection triangleIndices = new Int32Collection();

            foreach (var pathFigure in pathGeometry.Figures)
            {
                List<Point3D> topPoints = new List<Point3D>();
                List<Point3D> bottomPoints = new List<Point3D>();

                foreach (var segment in pathFigure.Segments)
                {
                    if (segment is PolyLineSegment lineSegment)
                    {
                        
                            var a = lineSegment.Points;
                            foreach (var point in a)
                            {
                            topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                            bottomPoints.Add(new Point3D(point.X, point.Y, 0));

                        }
                        
                        
                    }
                    else if (segment is LineSegment LineSegmentasyonu)
                    {
                        topPoints.Add(new Point3D(LineSegmentasyonu.Point.X, LineSegmentasyonu.Point.Y, extrusionDepth));
                        bottomPoints.Add(new Point3D(LineSegmentasyonu.Point.X, LineSegmentasyonu.Point.Y, 0));

                        // Yay segmentini noktalarla yaklaşık olarak temsil et (önceki örnekteki gibi)
                        //Point3D startPoint = topPoints.Count > 0 ? topPoints.Last() : new Point3D(pathFigure.StartPoint.X, pathFigure.StartPoint.Y, extrusionDepth);
                        //double radiusX = arcSegment.Size.Width;
                        //double radiusY = arcSegment.Size.Height;
                        //double startAngle = Math.Atan2(startPoint.Y - arcSegment.Point.Y, startPoint.X - arcSegment.Point.X) * 180 / Math.PI;
                        //double sweepAngle = arcSegment.IsLargeArc ? (arcSegment.SweepDirection == SweepDirection.Clockwise ? 360 - startAngle : -360 - startAngle) : (arcSegment.SweepDirection == SweepDirection.Clockwise ? startAngle : -startAngle);
                        //int numPoints = Math.Max(3, (int)Math.Abs(sweepAngle) / 10);
                        //for (int i = 1; i <= numPoints; i++)
                        //{
                        //    double angle = startAngle + sweepAngle * i / numPoints;
                        //    double x = arcSegment.Point.X + radiusX * Math.Cos(angle * Math.PI / 180);
                        //    double y = arcSegment.Point.Y + radiusY * Math.Sin(angle * Math.PI / 180);
                        //    topPoints.Add(new Point3D(x, y, extrusionDepth));
                        //    bottomPoints.Add(new Point3D(x, y, 0));
                        //}
                    }
                }

                // Noktaları positions listesine ekle
                positions.AddRange(bottomPoints);
                positions.AddRange(topPoints);
                int bottomCount = bottomPoints.Count;

                // Yan yüzeyler için üçgenleri oluştur
                for (int i = 0; i < bottomCount - 1; i++)
                {
                    triangleIndices.Add(i);
                    triangleIndices.Add(i + 1);
                    triangleIndices.Add(bottomCount + i);

                    triangleIndices.Add(i + 1);
                    triangleIndices.Add(bottomCount + i + 1);
                    triangleIndices.Add(bottomCount + i);
                }

                //Kapalı şekiller için başlangıç ve bitiş noktalarını birleştirme
                if (pathFigure.IsClosed)
                {
                    triangleIndices.Add(bottomCount - 1);
                    triangleIndices.Add(0);
                    triangleIndices.Add(bottomCount + bottomCount - 1);

                    triangleIndices.Add(0);
                    triangleIndices.Add(bottomCount);
                    triangleIndices.Add(bottomCount + bottomCount - 1);
                }
            }

            // List<Point3D>'yi Point3DCollection'a dönüştür
            meshGeometry.Positions = new Point3DCollection(positions); // Dönüştürme burada

            meshGeometry.TriangleIndices = triangleIndices;

            // ... (Malzeme ve GeometryModel3D oluşturma kodları aynı)
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new System.Windows.Point(0, 0);
            gradientBrush.EndPoint = new System.Windows.Point(1, 0);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));

            // Malzeme oluştur ve gradyanı uygula
            Material material = new DiffuseMaterial(gradientBrush);
            GeometryModel3D geometryModel = new GeometryModel3D();
            geometryModel.Geometry = meshGeometry;
            geometryModel.Material = material;

            return geometryModel;
        }
    }
    
}
