using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_dom_2
{
    public delegate bool WherePredicate(Shape shape);
    static class ShapeExtensions
    {
        public static List<Shape> Where(this List<Shape> shapes,WherePredicate wherePredicate)
        {
            var resultShapes = new List<Shape>();
             foreach (var s in shapes)
             {
                if (wherePredicate(s))
                {
                    resultShapes.Add(s);
                }
             }
            return resultShapes;
        }
    }
}
