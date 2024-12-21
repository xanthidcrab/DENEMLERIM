﻿using System;
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
using SharpDX.Direct3D11;

namespace CsvVisualizer.CLASSES
{
    public class DXFfields
    {
        public System.Windows.Shapes.Path path { get; set; }
        public   List<System.Windows.Point> lineses { get; set; }
        public DXFfields()
        {
            path = new System.Windows.Shapes.Path();
            lineses = new List<System.Windows.Point>();
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
                                lineses.Add(new System.Windows.Point(polyline2DVertex[0].Position.X, polyline2DVertex[0].Position.Y));

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
        public GeometryModel3D ExtrudePath2(PathGeometry pathGeometry, double extrusionDepth)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            List<Point3D> positions = new List<Point3D>();
            Int32Collection triangleIndices = new Int32Collection();

            foreach (var pathFigure in pathGeometry.Figures)
            {
                List<Point3D> topPoints = new List<Point3D>();
                List<Point3D> bottomPoints = new List<Point3D>();

                // Start point
                System.Windows.Point startPoint = pathFigure.StartPoint;
                topPoints.Add(new Point3D(startPoint.X, startPoint.Y, extrusionDepth));
                bottomPoints.Add(new Point3D(startPoint.X, startPoint.Y, 0));

                foreach (var segment in pathFigure.Segments)
                {
                    if (segment is PolyLineSegment lineSegment)
                    {
                        foreach (var point in lineSegment.Points)
                        {
                            topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                            bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                        }
                    }
                    else if (segment is LineSegment lineSegments)
                    {
                        System.Windows.Point point = lineSegments.Point;
                        topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                        bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                    }
                    else if (segment is ArcSegment arcSegment)
                    {
                        Point3D startPoints = topPoints.Count > 0 ? topPoints.Last() : new Point3D(pathFigure.StartPoint.X, pathFigure.StartPoint.Y, extrusionDepth);
                        double radiusX = arcSegment.Size.Width;
                        double radiusY = arcSegment.Size.Height;
                        double startAngle = Math.Atan2(startPoints.Y - arcSegment.Point.Y, startPoint.X - arcSegment.Point.X);
                        double endAngle = startAngle + (arcSegment.IsLargeArc ? Math.PI : 0) + (arcSegment.SweepDirection == SweepDirection.Clockwise ? 1 : -1) * Math.Acos((arcSegment.Point.X - startPoint.X) / radiusX);
                        int numPoints = 20; // Daha fazla nokta eklemek, daha düzgün yay verir

                        for (int i = 0; i <= numPoints; i++)
                        {
                            double angle = startAngle + (endAngle - startAngle) * i / numPoints;
                            double x = arcSegment.Point.X + radiusX * Math.Cos(angle);
                            double y = arcSegment.Point.Y + radiusY * Math.Sin(angle);

                            topPoints.Add(new Point3D(x, y, extrusionDepth));
                            bottomPoints.Add(new Point3D(x, y, 0));
                        }
                    }
                }

                int bottomStartIndex = positions.Count;
                positions.AddRange(bottomPoints);
                int topStartIndex = positions.Count;
                positions.AddRange(topPoints);

                int pointCount = bottomPoints.Count;

                // Create side faces
                for (int i = 0; i < pointCount - 1; i++)
                {
                    triangleIndices.Add(bottomStartIndex + i);
                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);

                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);
                }

                // Close the shape if it is closed
                if (pathFigure.IsClosed)
                {
                    triangleIndices.Add(bottomStartIndex + pointCount - 1);
                    triangleIndices.Add(bottomStartIndex);
                    triangleIndices.Add(topStartIndex + pointCount - 1);

                    triangleIndices.Add(bottomStartIndex);
                    triangleIndices.Add(topStartIndex);
                    triangleIndices.Add(topStartIndex + pointCount - 1);
                }
            }

            // Convert List<Point3D> to Point3DCollection
            meshGeometry.Positions = new Point3DCollection(positions);
            meshGeometry.TriangleIndices = triangleIndices;

            // Create material and apply gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new System.Windows.Point(0, 0);
            gradientBrush.EndPoint = new System.Windows.Point(1, 0);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));

            Material material = new DiffuseMaterial(gradientBrush);
            GeometryModel3D geometryModel = new GeometryModel3D();
            geometryModel.Geometry = meshGeometry;
            geometryModel.Material = material;

            return geometryModel;
        }
        public GeometryModel3D ExtrudePath3(PathGeometry pathGeometry, double extrusionDepth)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            List<Point3D> positions = new List<Point3D>();
            Int32Collection triangleIndices = new Int32Collection();

            foreach (var pathFigure in pathGeometry.Figures)
            {
                List<Point3D> topPoints = new List<Point3D>();
                List<Point3D> bottomPoints = new List<Point3D>();

                // Start point
                System.Windows.Point startPoint = pathFigure.StartPoint;
                topPoints.Add(new Point3D(startPoint.X, startPoint.Y, extrusionDepth));
                bottomPoints.Add(new Point3D(startPoint.X, startPoint.Y, 0));

                foreach (var segment in pathFigure.Segments)
                {
                    if (segment is PolyLineSegment lineSegment)
                    {
                        foreach (var point in lineSegment.Points)
                        {
                            topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                            bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                        }
                    }
                    else if (segment is LineSegment lineSegments)
                    {
                        System.Windows.Point point = lineSegments.Point;
                        topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                        bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                    }
                    else if (segment is ArcSegment arcSegment)
                    {
                        Point3D startPoints = topPoints.Count > 0 ? topPoints.Last() : new Point3D(pathFigure.StartPoint.X, pathFigure.StartPoint.Y, extrusionDepth);
                        double radiusX = arcSegment.Size.Width;
                        double radiusY = arcSegment.Size.Height;
                        double startAngle = Math.Atan2(startPoints.Y - arcSegment.Point.Y, startPoints.X - arcSegment.Point.X);
                        double endAngle = startAngle + (arcSegment.IsLargeArc ? Math.PI : 0) + (arcSegment.SweepDirection == SweepDirection.Clockwise ? 1 : -1) * Math.Acos((arcSegment.Point.X - startPoints.X) / radiusX);
                        int numPoints = 20; // Daha fazla nokta eklemek, daha düzgün yay verir

                        for (int i = 0; i <= numPoints; i++)
                        {
                            double angle = startAngle + (endAngle - startAngle) * i / numPoints;
                            double x = arcSegment.Point.X + radiusX * Math.Cos(angle);
                            double y = arcSegment.Point.Y + radiusY * Math.Sin(angle);

                            topPoints.Add(new Point3D(x, y, extrusionDepth));
                            bottomPoints.Add(new Point3D(x, y, 0));
                        }
                    }
                }

                int bottomStartIndex = positions.Count;
                positions.AddRange(bottomPoints);
                int topStartIndex = positions.Count;
                positions.AddRange(topPoints);

                int pointCount = bottomPoints.Count;

                // Create side faces
                for (int i = 0; i < pointCount - 1; i++)
                {
                    triangleIndices.Add(bottomStartIndex + i);
                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);

                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);
                }

                // Close the shape if it is closed
                if (pathFigure.IsClosed)
                {
                    triangleIndices.Add(bottomStartIndex + pointCount - 1);
                    triangleIndices.Add(bottomStartIndex);
                    triangleIndices.Add(topStartIndex + pointCount - 1);

                    triangleIndices.Add(bottomStartIndex);
                    triangleIndices.Add(topStartIndex);
                    triangleIndices.Add(topStartIndex + pointCount - 1);
                }
            }

            // Convert List<Point3D> to Point3DCollection
            meshGeometry.Positions = new Point3DCollection(positions);
            meshGeometry.TriangleIndices = triangleIndices;

            // Create material and apply gradient
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new System.Windows.Point(0, 0);
            gradientBrush.EndPoint = new System.Windows.Point(1, 0);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Red, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Blue, 1.0));

            Material material = new DiffuseMaterial(gradientBrush);
            GeometryModel3D geometryModel = new GeometryModel3D();
            geometryModel.Geometry = meshGeometry;
            geometryModel.Material = material;

            return geometryModel;
        }

        public GeometryModel3D ExtrudePathWithThickness(PathGeometry pathGeometry, double extrusionDepth, double thickness)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            List<Point3D> positions = new List<Point3D>();
            Int32Collection triangleIndices = new Int32Collection();

            foreach (var pathFigure in pathGeometry.Figures)
            {
                List<Point3D> topPoints = new List<Point3D>();
                List<Point3D> bottomPoints = new List<Point3D>();
                List<Point3D> upperTopPoints = new List<Point3D>();
                List<Point3D> upperBottomPoints = new List<Point3D>();

                // Start point
                System.Windows.Point startPoint = pathFigure.StartPoint;
                topPoints.Add(new Point3D(startPoint.X, startPoint.Y, extrusionDepth));
                bottomPoints.Add(new Point3D(startPoint.X, startPoint.Y, 0));
                upperTopPoints.Add(new Point3D(startPoint.X, startPoint.Y, extrusionDepth + thickness));
                upperBottomPoints.Add(new Point3D(startPoint.X, startPoint.Y, thickness));

                foreach (var segment in pathFigure.Segments)
                {
                    if (segment is PolyLineSegment lineSegment)
                    {
                        foreach (var point in lineSegment.Points)
                        {
                            topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                            bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                            upperTopPoints.Add(new Point3D(point.X, point.Y, extrusionDepth + thickness));
                            upperBottomPoints.Add(new Point3D(point.X, point.Y, thickness));
                        }
                    }
                    else if (segment is LineSegment lineSegments)
                    {
                        System.Windows.Point point = lineSegments.Point;
                        topPoints.Add(new Point3D(point.X, point.Y, extrusionDepth));
                        bottomPoints.Add(new Point3D(point.X, point.Y, 0));
                        upperTopPoints.Add(new Point3D(point.X, point.Y, extrusionDepth + thickness));
                        upperBottomPoints.Add(new Point3D(point.X, point.Y, thickness));
                    }
                    else if (segment is ArcSegment arcSegment)
                    {
                        Point3D startPoints = topPoints.Count > 0 ? topPoints.Last() : new Point3D(pathFigure.StartPoint.X, pathFigure.StartPoint.Y, extrusionDepth);
                        double radiusX = arcSegment.Size.Width;
                        double radiusY = arcSegment.Size.Height;
                        double startAngle = Math.Atan2(startPoints.Y - arcSegment.Point.Y, startPoints.X - arcSegment.Point.X);
                        double endAngle = startAngle + (arcSegment.IsLargeArc ? Math.PI : 0) + (arcSegment.SweepDirection == SweepDirection.Clockwise ? 1 : -1) * Math.Acos((arcSegment.Point.X - startPoints.X) / radiusX);
                        int numPoints = 20; // Daha fazla nokta eklemek, daha düzgün yay verir

                        for (int i = 0; i <= numPoints; i++)
                        {
                            double angle = startAngle + (endAngle - startAngle) * i / numPoints;
                            double x = arcSegment.Point.X + radiusX * Math.Cos(angle);
                            double y = arcSegment.Point.Y + radiusY * Math.Sin(angle);

                            topPoints.Add(new Point3D(x, y, extrusionDepth));
                            bottomPoints.Add(new Point3D(x, y, 0));
                            upperTopPoints.Add(new Point3D(x, y, extrusionDepth + thickness));
                            upperBottomPoints.Add(new Point3D(x, y, thickness));
                        }
                    }
                }

                int bottomStartIndex = positions.Count;
                positions.AddRange(bottomPoints);
                int topStartIndex = positions.Count;
                positions.AddRange(topPoints);
                int upperBottomStartIndex = positions.Count;
                positions.AddRange(upperBottomPoints);
                int upperTopStartIndex = positions.Count;
                positions.AddRange(upperTopPoints);

                int pointCount = bottomPoints.Count;

                // Create side faces
                for (int i = 0; i < pointCount - 1; i++)
                {
                    // Bottom to top
                    triangleIndices.Add(bottomStartIndex + i);
                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);

                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i + 1);
                    triangleIndices.Add(topStartIndex + i);

                    // Top to upper top
                    triangleIndices.Add(topStartIndex + i);
                    triangleIndices.Add(topStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i);

                    triangleIndices.Add(topStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i);

                    // Bottom to upper bottom
                    triangleIndices.Add(upperBottomStartIndex + i);
                    triangleIndices.Add(upperBottomStartIndex + i + 1);
                    triangleIndices.Add(bottomStartIndex + i);

                    triangleIndices.Add(upperBottomStartIndex + i + 1);
                    triangleIndices.Add(bottomStartIndex + i + 1);
                    triangleIndices.Add(bottomStartIndex + i);

                    // Upper bottom to upper top
                    triangleIndices.Add(upperBottomStartIndex + i);
                    triangleIndices.Add(upperBottomStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i);

                    triangleIndices.Add(upperBottomStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i + 1);
                    triangleIndices.Add(upperTopStartIndex + i);
                }

                // Fill the area between polylines (bottom and upper bottom)
                FillAreaBetweenPolylines(meshGeometry, bottomPoints, upperBottomPoints, 50);

                // Fill the area between polylines (top and upper top)
                FillAreaBetweenPolylines(meshGeometry, topPoints, upperTopPoints, 50);
            }

            // Convert List<Point3D> to Point3DCollection
            meshGeometry.Positions = new Point3DCollection(positions);
            meshGeometry.TriangleIndices = triangleIndices;

            // Create material and apply gradient
            SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.GhostWhite);

            // SpecularMaterial ile ışık yansıması ekleyin
            SpecularMaterial specularMaterial = new SpecularMaterial(solidColorBrush, 100.0);

            // DiffuseMaterial ile temel rengi belirleyin
            DiffuseMaterial diffuseMaterial = new DiffuseMaterial(solidColorBrush);

            // Modelin materyalini oluşturma
            MaterialGroup materialGroup = new MaterialGroup();
            materialGroup.Children.Add(diffuseMaterial);
            materialGroup.Children.Add(specularMaterial);

            GeometryModel3D geometryModel = new GeometryModel3D();

            geometryModel.Geometry = meshGeometry;
            geometryModel.Material = materialGroup;
            return geometryModel;
        }

        private void FillAreaBetweenPolylines(MeshGeometry3D meshGeometry, List<Point3D> polyline1, List<Point3D> polyline2, double maxDistance)
        {
            int startIndex = meshGeometry.Positions.Count;

            // Add points from polyline1 to mesh positions
            foreach (var point in polyline1)
            {
                meshGeometry.Positions.Add(point);
            }

            // Add points from polyline2 to mesh positions
            foreach (var point in polyline2)
            {
                meshGeometry.Positions.Add(point);
            }

            int pointCount = polyline1.Count;

            for (int i = 0; i < pointCount - 1; i++)
            {
                // Calculate distance between corresponding points in the polylines
                double distance = (polyline1[i] - polyline2[i]).Length;

                // Only create triangles if the distance is less than maxDistance
                if (distance <= maxDistance)
                {
                    // Create triangles to fill the area between polyline1 and polyline2
                    meshGeometry.TriangleIndices.Add(startIndex + i);
                    meshGeometry.TriangleIndices.Add(startIndex + i + 1);
                    meshGeometry.TriangleIndices.Add(startIndex + pointCount + i);

                    meshGeometry.TriangleIndices.Add(startIndex + i + 1);
                    meshGeometry.TriangleIndices.Add(startIndex + pointCount + i + 1);
                    meshGeometry.TriangleIndices.Add(startIndex + pointCount + i);
                }
            }
        }


        // GeometryModel3D'yi oluşturma
        public  GeometryModel3D ExtrudePolyline(List<System.Windows.Point> polyline, double extrusionDepth)
        {
            MeshGeometry3D meshGeometry = new MeshGeometry3D();
            List<Point3D> positions = new List<Point3D>();
            Int32Collection triangleIndices = new Int32Collection();

            // Polylinenin 3D noktalarını oluştur
            foreach (var point in polyline)
            {
                positions.Add(new Point3D(point.X, point.Y, 0)); // Alt yüzey
                positions.Add(new Point3D(point.X, point.Y, extrusionDepth)); // Üst yüzey
            }

            int pointCount = polyline.Count;

            // Yanal yüzeyleri oluştur
            for (int i = 0; i < pointCount - 1; i++)
            {
                int baseIndex = i * 2;

                // İlk üçgen
                triangleIndices.Add(baseIndex);
                triangleIndices.Add(baseIndex + 1);
                triangleIndices.Add(baseIndex + 2);

                // İkinci üçgen
                triangleIndices.Add(baseIndex + 1);
                triangleIndices.Add(baseIndex + 3);
                triangleIndices.Add(baseIndex + 2);
            }

            // Son yüzeyleri kapat
            int lastIndex = (pointCount - 1) * 2;
            triangleIndices.Add(lastIndex);
            triangleIndices.Add(lastIndex + 1);
            triangleIndices.Add(0);

            triangleIndices.Add(lastIndex + 1);
            triangleIndices.Add(1);
            triangleIndices.Add(0);

            meshGeometry.Positions = new Point3DCollection(positions);
            meshGeometry.TriangleIndices = triangleIndices;

            // Malzeme oluştur ve modeli geri döndür
            DiffuseMaterial material = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));
            GeometryModel3D geometryModel = new GeometryModel3D(meshGeometry, material);

            return geometryModel;
        }
    }

    
}
