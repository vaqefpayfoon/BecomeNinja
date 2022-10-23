using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advanced
{
    public class Person : BaseClasse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public struct Point<T>
    {
        // Generic state data.
        private T _xPos;
        private T _yPos;
        // Generic constructor.
        public Point(T xVal, T yVal)
        {
            _xPos = xVal;
            _yPos = yVal;
        }
        // Generic properties.
        public T X
        {
            get => _xPos;
            set => _xPos = value;
        }
        public T Y
        {
            get => _yPos;
            set => _yPos = value;
        }
        public override string ToString() => $"[{_xPos}, {_yPos}]";
        // value of a type parameter.
        public void ResetPoint()
        {
            _xPos = default(T);
            _yPos = default(T);
        }
    }
    public class BaseClasse
    {
        public int Id { get; set; }
    }


}