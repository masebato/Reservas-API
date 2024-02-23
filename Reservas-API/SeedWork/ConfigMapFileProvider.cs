﻿using Microsoft.Extensions.FileProviders.Internal;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System.Collections.Concurrent;
using System.Reflection;

namespace Reservas_API.SeedWork
{
    public class ConfigMapFileProvider : IFileProvider
    {
        ConcurrentDictionary<string, ConfigMapFileProviderChangeToken> watchers;
        public string RootPath { get; }

        public static IFileProvider FromRelativePath(string subPath)
        {
            var executableLocation = Assembly.GetEntryAssembly().Location;
            var executablePath = Path.GetDirectoryName(executableLocation);
            var configPath = Path.Combine(executablePath, subPath);
            if (Directory.Exists(configPath))
            {
                return new ConfigMapFileProvider(configPath);
            }

            return null;
        }
        public ConfigMapFileProvider(string rootPath)
        {
            if (string.IsNullOrWhiteSpace(rootPath))
            {
                throw new System.ArgumentException("Invalid root path", nameof(rootPath));
            }

            RootPath = rootPath;
            watchers = new ConcurrentDictionary<string, ConfigMapFileProviderChangeToken>();
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            return new PhysicalDirectoryContents(Path.Combine(RootPath, subpath));
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            var fi = new FileInfo(Path.Combine(RootPath, subpath));
            return new PhysicalFileInfo(fi);
        }

        public IChangeToken Watch(string filter)
        {
            var watcher = watchers.AddOrUpdate(filter,
                addValueFactory: (f) =>
                {
                    return new ConfigMapFileProviderChangeToken(RootPath, filter);
                },
                updateValueFactory: (f, e) =>
                {
                    e.Dispose();
                    return new ConfigMapFileProviderChangeToken(RootPath, filter);
                });

            watcher.EnsureStarted();
            return watcher;
        }
    }
}
