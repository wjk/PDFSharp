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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace PDFSharp.Fonts
{
    public sealed class DefaultFontDirectoryLocator : IFontDirectoryLocator
    {
        private string[] GetPathsMac()
        {
            string home = Environment.GetEnvironmentVariable("HOME");
            return new[]
            {
                Path.Combine(home, "Library", "Fonts"),
                "/Library/Fonts",
                "/System/Library/Fonts",
                "/Network/Library/Fonts"
            };
        }

        private string[] GetPathsWindows()
        {
            string windir = Environment.GetEnvironmentVariable("SystemRoot");
            return new[]
            {
                Path.Combine(windir, "Fonts"),
                Path.Combine(windir, "PSFONTS")
            };
        }

        private string[] GetPathsLinux()
        {
            string home = Environment.GetEnvironmentVariable("HOME");
            return new[]
            {
                Path.Combine(home, ".fonts"),
                "/usr/local/fonts",
                "/usr/local/share/fonts",
                "/usr/share/fonts",
                "/usr/X11R6/lib/X11/fonts"
            };
        }

        public IEnumerable<DirectoryInfo> FindDirectories()
        {
            string[] paths;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) paths = GetPathsMac();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) paths = GetPathsWindows();
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) paths = GetPathsLinux();
            else throw new PlatformNotSupportedException();

            return paths.Select(path => new DirectoryInfo(path)).Where(dir => dir.Exists);
        }
    }
}
