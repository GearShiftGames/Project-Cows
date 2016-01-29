// MonoGame Physics
// Written by D. Divers, 2015
// ==============================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Project_Cows.Source.System.Graphics
{
    class RotatedRectangle
    {
        public Rectangle collisionRectangle;
        public float m_Rotation;
        public Vector2 m_Origin;

        public RotatedRectangle(Rectangle theRectangle, float rotation)
        {
            collisionRectangle = theRectangle;
            m_Rotation = rotation;

            //Gets the Rects Origin
            m_Origin = new Vector2((int)theRectangle.Width / 2, (int)theRectangle.Height / 2);
        }

        /// Used for changing the X and Y position of the RotatedRectangle
        public void Move(int xPos, int yPos)
        {
            collisionRectangle.X += xPos;
            collisionRectangle.Y += yPos;
        }

        //ror use if the passed in object is non rotated Rectangle
        public bool Intersects(Rectangle theRectangle)
        {
            return Intersects(new RotatedRectangle(theRectangle, 0.0f));
        }

        //Check to see if two Rotated Rectangles have collided
        public bool Intersects(RotatedRectangle theRectangle)
        {
            //calculate the axis we will us to check collisions on
            //make 4, one for each side
            List<Vector2> rectangleAxis = new List<Vector2>();
            rectangleAxis.Add(UpperRightCorner() - UpperLeftCorner());
            rectangleAxis.Add(UpperRightCorner() - LowerRightCorner());
            rectangleAxis.Add(theRectangle.UpperLeftCorner() - theRectangle.LowerLeftCorner());
            rectangleAxis.Add(theRectangle.UpperLeftCorner() - theRectangle.UpperRightCorner());

            //loop through each axis, if one of them does not collide then there is no collision
            foreach (Vector2 axis in rectangleAxis)
            {
                if (!IsAxisCollision(theRectangle, axis))
                {
                    return false;
                }
            }

            return true;
        }

        //Determines if a collision has occurred on an Axis of one of the planes parallel to the Rectangle
        private bool IsAxisCollision(RotatedRectangle theRectangle, Vector2 axis)
        {
            //Project the corners of the Rectangle we are checking on to the Axis and
            //get a scalar value of that project we can then use for comparison
            List<int> rectangleAScalars = new List<int>();
            rectangleAScalars.Add(GenerateScalar(theRectangle.UpperLeftCorner(), axis));
            rectangleAScalars.Add(GenerateScalar(theRectangle.UpperRightCorner(), axis));
            rectangleAScalars.Add(GenerateScalar(theRectangle.LowerLeftCorner(), axis));
            rectangleAScalars.Add(GenerateScalar(theRectangle.LowerRightCorner(), axis));

            //Project the corners of the current Rectangle on to the Axis and
            //get a scalar value of that projection we can then use for comparison
            List<int> rectangleBScalars = new List<int>();
            rectangleBScalars.Add(GenerateScalar(UpperLeftCorner(), axis));
            rectangleBScalars.Add(GenerateScalar(UpperRightCorner(), axis));
            rectangleBScalars.Add(GenerateScalar(LowerLeftCorner(), axis));
            rectangleBScalars.Add(GenerateScalar(LowerRightCorner(), axis));

            //Get the Maximum and Minium Scalar values for each of the Rectangles
            int rectangleAMinimum = rectangleAScalars.Min();
            int rectangleAMaximum = rectangleAScalars.Max();
            int rectangleBMinimum = rectangleBScalars.Min();
            int rectangleBMaximum = rectangleBScalars.Max();

            //If we have overlaps between the Rectangles, then there is a collision between the rectangles on this Axis
            if (rectangleBMinimum <= rectangleAMaximum && rectangleBMaximum >= rectangleAMaximum)
            {
                return true;
            }
            else if (rectangleAMinimum <= rectangleBMaximum && rectangleAMaximum >= rectangleBMaximum)
            {
                return true;
            }

            return false;
        }

        //Generates a scalar value that can be used to compare where corners of 
        //a rectangle have been projected onto a particular axis.
        private int GenerateScalar(Vector2 rectangleCorner, Vector2 axis)
        {
            //project the corner passed in, onto the axis
            float divisionResult = ((rectangleCorner.X * axis.X) + (rectangleCorner.Y * axis.Y)) / ((axis.X * axis.X) + (axis.Y * axis.Y));
            Vector2 cornerProjected = new Vector2(divisionResult * axis.X, divisionResult * axis.Y);

            //create scalar relative to the vector, so calculations are easier
            float scalar = (axis.X * cornerProjected.X) + (axis.Y * cornerProjected.Y);
            return (int)scalar;
        }


        //Rotate a point from a given location and adjust using the Origin we are rotating around
        private Vector2 RotatePoint(Vector2 point, Vector2 origin, float rotation)
        {
            Vector2 TranslatedPoint = new Vector2();
            TranslatedPoint.X = (float)(origin.X + (point.X - origin.X) * Math.Cos(rotation)
                - (point.Y - origin.Y) * Math.Sin(rotation));
            TranslatedPoint.Y = (float)(origin.Y + (point.Y - origin.Y) * Math.Cos(rotation)
                + (point.X - origin.X) * Math.Sin(rotation));
            return TranslatedPoint;
        }

        public Vector2 UpperLeftCorner()
        {
            Vector2 UpperLeft = new Vector2(collisionRectangle.Left, collisionRectangle.Top);
            UpperLeft = RotatePoint(UpperLeft, UpperLeft + m_Origin, m_Rotation);
            return UpperLeft;
        }

        public Vector2 UpperRightCorner()
        {
            Vector2 UpperRight = new Vector2(collisionRectangle.Right, collisionRectangle.Top);
            UpperRight = RotatePoint(UpperRight, UpperRight + new Vector2(-m_Origin.X, m_Origin.Y), m_Rotation);
            return UpperRight;
        }

        public Vector2 LowerLeftCorner()
        {
            Vector2 LowerLeft = new Vector2(collisionRectangle.Left, collisionRectangle.Bottom);
            LowerLeft = RotatePoint(LowerLeft, LowerLeft + new Vector2(m_Origin.X, -m_Origin.Y), m_Rotation);
            return LowerLeft;
        }

        public Vector2 LowerRightCorner()
        {
            Vector2 LowerRight = new Vector2(collisionRectangle.Right, collisionRectangle.Bottom);
            LowerRight = RotatePoint(LowerRight, LowerRight + new Vector2(-m_Origin.X, -m_Origin.Y), m_Rotation);
            return LowerRight;
        }

        public int X
        {
            get { return collisionRectangle.X; }
        }

        public int Y
        {
            get { return collisionRectangle.Y; }
        }

        public int Width
        {
            get { return collisionRectangle.Width; }
        }

        public int Height
        {
            get { return collisionRectangle.Height; }
        }
    }
}
