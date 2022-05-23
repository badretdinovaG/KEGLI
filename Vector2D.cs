using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Vector2D
    {
        public readonly static Vector2D zero = new Vector2D(0f, 0f);
        private float x;
        private float y;

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public Vector2D()
        {
            x = 0.0f;
            y = 0.0f;
        }

        public Vector2D(float x1, float y1)
        {
            x = x1;
            y = y1;
            
        }

        public Vector2D(Vector2D v)
        {
            x = v.x;
            y = v.y;
            
        }

        public Vector2D(Point point)
        {
            x = point.X;
            y = point.Y;
        }

        public Vector2D(Point p1, Point p2)
        {
            x = p2.X - p1.X;
            y = p2.Y - p1.Y;
        }

        public Vector2D(float x1, float y1, float x2, float y2)
        {
            x = x2 - x1;
            y = y2 - y1;
        }

        // длина вектора
        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }

        // проверка равности векторов по координатам
        public bool Equal(Vector2D v2)
        {
            if (x == v2.X && y == v2.Y)
                return true;
            else
                return false;
        }

        //
        public float DotProduct(Vector2D v2)
        {
            return (x * v2.X + y * v2.Y);
        }

        
        

        // получение единичного вектора
        public Vector2D Unit()
        {
            float length = (float)Math.Sqrt(x * x + y * y);
            return new Vector2D(x / length, y / length);
        }

 

        // оператор увеличения(удлинения) вектора в scale раз
        public Vector2D Scale(float scale)
        {
            return new Vector2D(scale * x, scale * y);
        }

        // оператор "*" для числа и вектора
        public static Vector2D operator *(float k, Vector2D v1)
        {
            return new Vector2D(k * v1.x, k * v1.y);
        }

        // оператор "*" для вектора и числа
        public static Vector2D operator *(Vector2D v1, float k)
        {
            return new Vector2D(k * v1.x, k * v1.y);
        }

        // оператор "+" для 2х векторов
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        // оператор "-" для 2х векторов
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        // оператор умножения на "-1", разворот на 180 градусов
        public static Vector2D operator -(Vector2D v1)
        {
            return new Vector2D(-v1.x, -v1.y);
        }
    }
}
