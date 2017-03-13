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
using System.Collections.Generic;
using PDFSharp.Geometry;

namespace PDFSharp.Fonts.Afm
{
    public sealed class CharacterMetric : IEquatable<CharacterMetric>
    {
        public BoundingBox BoundingBox { get; set; }
        public int CharacterCode { get; set; }
        public List<Ligature> Ligatures { get; set; }
        public string Name { get; set; }
        public float[] VV { get; set; }
        public float[] W { get; set; }
        public float[] W0 { get; set; }
        public float W0X { get; set; }
        public float W0Y { get; set; }
        public float[] W1 { get; set; }
        public float W1X { get; set; }
        public float W1Y { get; set; }
        public float WX { get; set; }
        public float WY { get; set; }

        public bool Equals(CharacterMetric other)
        {
            return BoundingBox.Equals(other.BoundingBox) &&
                CharacterCode == other.CharacterCode &&
                Ligatures.Equals(other.Ligatures) &&
                Name == other.Name &&
                VV == other.VV &&
                W == other.W &&
                W0 == other.W0 &&
                W0X == other.W0X &&
                W0Y == other.W0Y &&
                W1 == other.W1 &&
                W1X == other.W1X &&
                W1Y == other.W1Y &&
                WX == other.WX &&
                WY == other.WY;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return false;
            if (!(obj is CharacterMetric)) return false;
            return Equals((CharacterMetric)obj);
        }

        public override int GetHashCode()
        {
            return BoundingBox.GetHashCode() ^ CharacterCode.GetHashCode() ^ Ligatures.GetHashCode() ^ Name.GetHashCode() ^
                VV.GetHashCode() ^ W.GetHashCode() ^ W0.GetHashCode() ^ W0X.GetHashCode() ^ W0Y.GetHashCode() ^ W1.GetHashCode() ^
                W1X.GetHashCode() ^ W1Y.GetHashCode() ^ WX.GetHashCode() ^ WY.GetHashCode();
        }

        public override string ToString()
        {
            return $"[AFM CharacterMetric: {Name}]";
        }
    }
}
