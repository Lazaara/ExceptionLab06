using System;
using System.Collections.Generic;

namespace ExceptionLab
{
    internal class Program
    {
        public static void Main(string[] args)
        { 
            List<Vector3D> vectors = new List<Vector3D>();
            
            vectors.Add(new Vector3D(0, 0, 0));
            vectors.Add(new Vector3D(0, 0, 0));
            vectors.Add(new Vector3D(3, 0, 1));
            vectors.Add(new Vector3D(-2, 1, 3));
            vectors.Add(new Vector3D(5, 2, -3));

            try
            {
                Console.WriteLine($"Phuong cua vector 1 va 2: {vectors[0].GetOrientation(vectors[1])}");
            }
            catch (UndefinedOrientationException e)
            {
                Console.WriteLine(e);
            }
            
            try
            {
                Console.WriteLine($"Phuong cua vector 3 va 5: {vectors[2].GetOrientation(vectors[4])}");
            }
            catch (UndefinedOrientationException e)
            {
                Console.WriteLine(e);
            }

            Vector3D vector = vectors[2] + vectors[3];
            Console.WriteLine($"Ket qua: V({vector.GetX()}, {vector.GetY()}, {vector.GetZ()})");
            
            Console.WriteLine($"Goc giua vector 4 va 5: {vectors[3] * vectors[4]}");
            
            Console.ReadLine();
        }
    }
}