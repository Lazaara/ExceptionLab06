using System;

namespace ExceptionLab
{
    [Serializable]
    public class UndefinedOrientationException : Exception
    {

        public UndefinedOrientationException() : base("Vector la vector khong")
        {
            
        }

        public UndefinedOrientationException(string message) : base(message)
        {
            
        }

        public UndefinedOrientationException(string message, Exception inner) : base(message, inner)
        {
            
        }
        
        public static void CheckNullVector(Vector3D v)
        {
            if (v == null || v.GetVectorLength() == 0)
            {
                throw new UndefinedOrientationException();
            }
        }


    }
}