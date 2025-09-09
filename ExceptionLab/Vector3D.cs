using System;
using System.Diagnostics;
using System.Web;

namespace ExceptionLab
{
    public class Vector3D
    {
        private double x;
        private double y;
        private double z;

        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double GetX()
        {
            return this.x;
        }

        public double GetY()
        {
            return this.y;
        }

        public double GetZ()
        {
            return this.z;
        }

        public double GetDot(Vector3D other)
        {
            double result = 0;
            result = this.GetX() * other.GetX() + this.GetY() * other.GetY() + this.GetZ() * other.GetZ();
            return result;
        }

        public double GetVectorLength()
        {
            double result = 0;

            result = Math.Sqrt(
                Math.Pow(this.x, 2)
                + Math.Pow(this.y, 2)
                + Math.Pow(this.z, 2)
                );

            return result;
        }

        public Vector3D GetNormalizedVector()
        {
            double length = this.GetVectorLength();

            try
            {
                UndefinedOrientationException.CheckNullVector(this);
            }
            catch (UndefinedOrientationException e)
            {
                throw new UndefinedOrientationException();
            }

            double x = this.x / length;
            double y = this.y / length;
            double z = this.z / length;
            return new Vector3D(x, y, z);
        }

        public string GetLinearCombination()
        {
            Vector3D vector = this.GetNormalizedVector();
            return $"({vector.GetX():F2}e1, {vector.GetY():F2}e2, {vector.GetZ():F2}e3)";
        }

        public string GetOrientation(Vector3D vector)
        {
            Vector3D vectorNormalized = this.GetNormalizedVector();
            Vector3D vectorTwoNormalized = vector.GetNormalizedVector();

            try
            {
                
                UndefinedOrientationException.CheckNullVector(vectorNormalized);
                UndefinedOrientationException.CheckNullVector(vectorTwoNormalized);

            }
            catch (UndefinedOrientationException e)
            {
                throw new UndefinedOrientationException();
            }
            double dot =  vectorNormalized.GetDot(vectorTwoNormalized);

            if (Math.Abs(dot - 1) < 1e-9)
            {
                return "Hai vector cung phuong";
            }
            else if (Math.Abs(dot + 1) < 1e-9)
            {
                return "Hai vector nguoc phuong";
            }
            else if (Math.Abs(dot) < 1e-9)
            {
                return "Hai vector vuong goc";
            }
            else
            {
                double angle = Math.Acos(dot) * 180.0 / Math.PI;
                return $"Hai vector tao goc {angle:F2} do voi nhau";
            }
        }

        public static double operator *(Vector3D vone, Vector3D vtwo)
        {
            double result = 0;
            double dot = vone.GetDot(vtwo);
            double lenghthprod = vone.GetVectorLength() * vtwo.GetVectorLength();
            if (lenghthprod == 0) throw new UndefinedOrientationException();
            double cosTheta = dot / lenghthprod;
            result = Math.Max(-1.0, Math.Min(1.0, cosTheta));
            return result;
        }

        public static Vector3D operator +(Vector3D vone, Vector3D vtwo)
        {
            return new Vector3D(vone.GetX() + vtwo.GetX(), vone.GetY() + vtwo.GetY(), vone.GetZ() + vtwo.GetZ());
        }

    }
}