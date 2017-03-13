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
    public sealed class Ligature : IEquatable<Ligature>
    {
        public string SuccessorCharacters { get; set; }
        public string LigatureValue { get; set; }

        public bool Equals(Ligature other)
        {
            return SuccessorCharacters == other.SuccessorCharacters && LigatureValue == other.LigatureValue;
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is Ligature)) return false;
            return Equals((Ligature)obj);
        }

        public override int GetHashCode()
        {
            return SuccessorCharacters.GetHashCode() ^ LigatureValue.GetHashCode();
        }

        public override string ToString()
        {
            return $"[AFM Ligature: Successor={SuccessorCharacters} Value={LigatureValue}]";
        }
    }
}
