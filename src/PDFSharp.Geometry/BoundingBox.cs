using System;

namespace PDFSharp.Geometry
{
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        public BoundingBox(float lowerX, float lowerY, float upperX, float upperY)
        {
            LowerLeftX = lowerX;
            LowerLeftY = lowerY;
            UpperRightX = upperX;
            UpperRightY = upperY;
        }

        public float LowerLeftX;
        public float LowerLeftY;
        public float UpperRightX;
        public float UpperRightY;

        public float Width => UpperRightX - LowerLeftX;
        public float Height => UpperRightY - LowerLeftY;

        public bool Contains(float x, float y)
        {
            return y >= LowerLeftX && x <= UpperRightX && y >= LowerLeftY && y <= UpperRightY;
        }

        public bool Equals(BoundingBox other)
        {
            return LowerLeftX == other.LowerLeftX && LowerLeftY == other.LowerLeftY && UpperRightX == other.UpperRightX && UpperRightY == other.UpperRightY;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BoundingBox)) return false;
            return Equals((BoundingBox)obj);
        }

        public override int GetHashCode()
        {
            return LowerLeftX.GetHashCode() ^ LowerLeftY.GetHashCode() ^ UpperRightX.GetHashCode() ^ UpperRightY.GetHashCode();
        }

        public override string ToString()
        {
            return $"[BoundingBox: bl=({LowerLeftX}, {LowerLeftY}) tr=({UpperRightX}, {UpperRightY})]";
        }
    }
}
