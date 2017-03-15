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

namespace PDFSharp.Fonts.Afm
{
    public sealed class TrackKern : IEquatable<TrackKern>
    {
        public int Degree { get; set; }
        public float MinKern { get; set; }
        public float MaxKern { get; set; }
        public float MinPointSize { get; set; }
        public float MaxPointSize { get; set; }

        public bool Equals(TrackKern other)
        {
            return Degree == other.Degree && MinKern == other.MinKern && MaxKern == other.MaxKern && MinPointSize == other.MinPointSize && MaxPointSize == other.MaxPointSize;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is TrackKern)) return false;
            return Equals((TrackKern)obj);
        }

        public override int GetHashCode()
        {
            return Degree.GetHashCode() ^ MinKern.GetHashCode() ^ MaxKern.GetHashCode() ^ MinPointSize.GetHashCode() ^ MaxPointSize.GetHashCode();
        }

        public override string ToString()
        {
            return $"[TrackKern: Kern={MinKern}-{MaxKern} PointSize={MinPointSize}-{MaxPointSize}]";
        }
    }
}
