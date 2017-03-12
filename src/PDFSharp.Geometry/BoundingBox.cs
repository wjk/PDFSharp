/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
