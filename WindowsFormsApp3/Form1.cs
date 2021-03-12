using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;

public enum PointColour
{
    Red,
    Green,
    Blue
}
interface IReflectable
{
    void ReflectX();
    void ReflectY();
}

class Point : IReflectable
{


    public decimal X { get; protected set; }
    public decimal Y { get; protected set; }

    public Point(decimal x)
    {
        X = x;
        Y = 0.0m;
    }

    public Point(decimal x, decimal y)
    {
        X = x;
        Y = y;
    }

    public void ReflectX()
    {
        X = -X;
    }

    public void ReflectY()
    {
        Y = -Y;
    }


}

class ColourfulPoint : Point
{
    public PointColour Colour { get; set; }
    public ColourfulPoint(decimal x, decimal y, PointColour colour) : base(x, y)
    {
        Colour = colour;
    }

    public ColourfulPoint(decimal x, PointColour colour) : base(x)
    {
        Colour = colour;
    }


}
