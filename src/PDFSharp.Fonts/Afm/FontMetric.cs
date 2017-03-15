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
    public sealed class FontMetric
    {
        private int mMetricSets;
        private readonly List<string> mComments = new List<string>();
        private List<CharacterMetric> mCharMetrics = new List<CharacterMetric>();

        public float AfmVersion { get; private set; }
        public string FontName { get; set; }
        public string FullName { get; set; }
        public string FamilyName { get; set; }
        public string Weight { get; set; }
        public BoundingBox FontBBox { get; set; }
        public string FontVersion { get; set; }
        public string Notice { get; set; }
        public string EncodingScheme { get; set; }
        public int MappingScheme { get; set; }
        public int EscChar { get; set; }
        public string CharacterSet { get; set; }
        public int Characters { get; set; }
        public bool IsBaseFont { get; set; }
        public float[] VVector { get; set; }
        public bool IsFixedV { get; set; }
        public float CapHeight { get; set; }
        public float XHeight { get; set; }
        public float Ascender { get; set; }
        public float Descender { get; set; }
        public float UnderlinePosition { get; set; }
        public float UnderlineThickness { get; set; }
        public float ItalicAngle { get; set; }
        public float[] CharWidth { get; set; }
        public bool IsFixedPitch { get; set; }
        public float StandardHorizontalWidth { get; set; }
        public float StandardVerticalWidth { get; set; }

        private Dictionary<string, CharacterMetric> CharMetricsMap = new Dictionary<string, CharacterMetric>();
        public List<TrackKern> TrackKern { get; set; } = new List<TrackKern>();
        public List<Composite> Composites { get; set; } = new List<Composite>();
        public List<KernPair> KernPairs { get; set; } = new List<KernPair>();
        public List<KernPair> KernPairs0 { get; set; } = new List<KernPair>();
        public List<KernPair> KernPairs1 { get; set; } = new List<KernPair>();

        public List<CharacterMetric> CharMetrics
        {
            get
            {
                return new List<CharacterMetric>(mCharMetrics);
            }

            set
            {
                mCharMetrics = value;
                CharMetricsMap = new Dictionary<string, CharacterMetric>();

                foreach (CharacterMetric metric in value) CharMetricsMap[metric.Name] = metric;
            }
        }

        public int MetricSets
        {
            get
            {
                return mMetricSets;
            }

            set
            {
                if (value < 0 || value > 2)
                    throw new ArgumentException("The MetricSets attribute must be 0, 1, or 2.", nameof(value));

                mMetricSets = value;
            }
        }

        public float GetCharacterWidth(string name)
        {
            float result = 0;
            bool found = CharMetricsMap.TryGetValue(name, out CharacterMetric value);
            if (found) result = value.WX;
            return result;
        }

        public float GetCharacterHeight(string name)
        {
            float result = 0;
            bool found = CharMetricsMap.TryGetValue(name, out CharacterMetric metric);

            if (found)
            {
                result = metric.WY;
                if (result == 0) result = metric.BoundingBox.Height;
            }

            return result;
        }

        public float GetAverageCharacterWidth()
        {
            float average = 0;
            float totalWidths = 0;
            int characterCount = 0;

            foreach (CharacterMetric metric in CharMetrics)
            {
                if (metric.WX > 0)
                {
                    totalWidths += metric.WX;
                    characterCount++;
                }
            }

            if (totalWidths > 0) average = totalWidths / characterCount;
            return average;
        }

        public void AddComment(string comment) => mComments.Add(comment);
        public IReadOnlyList<string> Comments => mComments;

        public void AddCharMetric(CharacterMetric metric)
        {
            mCharMetrics.Add(metric);
            CharMetricsMap[metric.Name] = metric;
        }
    }
}
