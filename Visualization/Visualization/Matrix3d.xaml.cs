using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Media3D;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Visualization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Matrix3d : Page
    {
        public Matrix3d()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void ApplyProjection(Object sender, PointerRoutedEventArgs e)
        {
            // Translate the image along the negative Z-axis such that it occupies 50% of the
            // vertical field of view.
            Matrix3D m = new Matrix3D();

            // This matrix simply translates the image 100 pixels
            // down and 100 pixels right.
            m.M11 = 1.0; m.M12 = 0.0; m.M13 = 0.0; m.M14 = 0.0;
            m.M21 = 0.0; m.M22 = 1.0; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = 0.0; m.M32 = 0.0; m.M33 = 1.0; m.M34 = 0.0;
            m.OffsetX = 100; m.OffsetY = 100; m.OffsetZ = 0; m.M44 = 1.0;

            Matrix3DProjection m3dProjection = new Matrix3DProjection();
            m3dProjection.ProjectionMatrix = m;

            BeachImage.Projection = m3dProjection;

        }

        private Matrix3D TranslationTransform(double tx, double ty, double tz)
        {
            Matrix3D m = new Matrix3D();

            m.M11 = 1.0; m.M12 = 0.0; m.M13 = 0.0; m.M14 = 0.0;
            m.M21 = 0.0; m.M22 = 1.0; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = 0.0; m.M32 = 0.0; m.M33 = 1.0; m.M34 = 0.0;
            m.OffsetX = tx; m.OffsetY = ty; m.OffsetZ = tz; m.M44 = 1.0;

            return m;
        }

        private Matrix3D CreateScaleTransform(double sx, double sy, double sz)
        {
            Matrix3D m = new Matrix3D();

            m.M11 = sx; m.M12 = 0.0; m.M13 = 0.0; m.M14 = 0.0;
            m.M21 = 0.0; m.M22 = sy; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = 0.0; m.M32 = 0.0; m.M33 = sz; m.M34 = 0.0;
            m.OffsetX = 0.0; m.OffsetY = 0.0; m.OffsetZ = 0.0; m.M44 = 1.0;

            return m;
        }

        private Matrix3D RotateYTransform(double theta)
        {
            double sin = Math.Sin(theta);
            double cos = Math.Cos(theta);

            Matrix3D m = new Matrix3D();

            m.M11 = cos; m.M12 = 0.0; m.M13 = -sin; m.M14 = 0.0;
            m.M21 = 0.0; m.M22 = 1.0; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = sin; m.M32 = 0.0; m.M33 = cos; m.M34 = 0.0;
            m.OffsetX = 0.0; m.OffsetY = 0.0; m.OffsetZ = 0.0; m.M44 = 1.0;

            return m;
        }

        private Matrix3D RotateZTransform(double theta)
        {
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            Matrix3D m = new Matrix3D();
            m.M11 = cos; m.M12 = sin; m.M13 = 0.0; m.M14 = 0.0;
            m.M21 = -sin; m.M22 = cos; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = 0.0; m.M32 = 0.0; m.M33 = 1.0; m.M34 = 0.0;
            m.OffsetX = 0.0; m.OffsetY = 0.0; m.OffsetZ = 0.0; m.M44 = 1.0;
            return m;
        }

        private Matrix3D PerspectiveTransformFovRH(double fieldOfViewY, double aspectRatio, double zNearPlane, double zFarPlane)
        {
            double height = 1.0 / Math.Tan(fieldOfViewY / 2.0);
            double width = height / aspectRatio;
            double d = zNearPlane - zFarPlane;

            Matrix3D m = new Matrix3D();
            m.M11 = width; m.M12 = 0; m.M13 = 0; m.M14 = 0;
            m.M21 = 0; m.M22 = height; m.M23 = 0; m.M24 = 0;
            m.M31 = 0; m.M32 = 0; m.M33 = zFarPlane / d; m.M34 = -1;
            m.OffsetX = 0; m.OffsetY = 0; m.OffsetZ = zNearPlane * zFarPlane / d; m.M44 = 0;

            return m;
        }

        private Matrix3D ViewportTransform(double width, double height)
        {
            Matrix3D m = new Matrix3D();

            m.M11 = width / 2.0; m.M12 = 0.0; m.M13 = 0.0; m.M14 = 0.0;
            m.M21 = 0.0; m.M22 = -height / 2.0; m.M23 = 0.0; m.M24 = 0.0;
            m.M31 = 0.0; m.M32 = 0.0; m.M33 = 1.0; m.M34 = 0.0;
            m.OffsetX = width / 2.0; m.OffsetY = height / 2.0; m.OffsetZ = 0.0; m.M44 = 1.0;

            return m;
        }


    }
}
