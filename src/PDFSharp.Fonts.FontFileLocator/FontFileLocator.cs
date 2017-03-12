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

using System.Collections.Generic;
using System.IO;

namespace PDFSharp.Fonts
{
    public sealed class FontFileLocator
    {
        private readonly IFontDirectoryLocator DirectoryLocator;

        public FontFileLocator()
        {
            DirectoryLocator = new DefaultFontDirectoryLocator();
        }

        public FontFileLocator(IFontDirectoryLocator dirLocator)
        {
            DirectoryLocator = dirLocator;
        }

        public IEnumerable<FileInfo> FindFiles()
        {
            List<FileInfo> files = new List<FileInfo>();

            foreach (DirectoryInfo dir in DirectoryLocator.FindDirectories())
                SearchDirectory(dir, files);

            return files;
        }

        public IEnumerable<FileInfo> SearchDirectory(DirectoryInfo dir)
        {
            List<FileInfo> files = new List<FileInfo>();
            SearchDirectory(dir, files);
            return files;
        }

        private void SearchDirectory(DirectoryInfo directory, List<FileInfo> results)
        {
            Queue<DirectoryInfo> directoriesToSearch = new Queue<DirectoryInfo>();
            directoriesToSearch.Enqueue(directory);

            while (directoriesToSearch.Count > 0)
            {
                DirectoryInfo dir = directoriesToSearch.Dequeue();

                foreach (FileInfo file in directory.EnumerateFiles())
                {
                    // Skip hidden files.
                    if (file.Name.StartsWith(".")) continue;

                    if (IsFontFile(file)) results.Add(file);
                }

                foreach (DirectoryInfo subdir in directory.EnumerateDirectories())
                {
                    // Skip hidden directories.
                    if (subdir.Name.StartsWith(".")) continue;
                    directoriesToSearch.Enqueue(subdir);
                }
            }
        }

        private static bool IsFontFile(FileInfo file)
        {
            string name = file.Name.ToLowerInvariant();
            return name.EndsWith(".ttf") || name.EndsWith(".otf") || name.EndsWith(".pfb") || name.EndsWith(".ttc");
        }
    }
}
