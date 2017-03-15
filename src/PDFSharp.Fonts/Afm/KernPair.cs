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

namespace PDFSharp.Fonts
{
    public sealed class KernPair : IEquatable<KernPair>
    {
        public string FirstKernCharacter { get; set; }
        public string SecondKernCharacter { get; set; }
        public float X { get; set; }
        public float Y { get; set; }

        public bool Equals(KernPair other)
        {
            return FirstKernCharacter == other.FirstKernCharacter && SecondKernCharacter == other.SecondKernCharacter && X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is KernPair)) return false;
            return Equals((KernPair)obj);
        }

        public override int GetHashCode()
        {
            return FirstKernCharacter.GetHashCode() ^ SecondKernCharacter.GetHashCode() ^ X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
