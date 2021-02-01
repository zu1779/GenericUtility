namespace Zu1779.GenUtil.Extension.FileSystemExtension
{
    using System;
    using System.IO;

    public static class FileSystemExtension
    {
        /// <summary>
        /// Get the file name without extension.
        /// </summary>
        public static string NoExtension(this FileInfo fileInfo) => Path.GetFileNameWithoutExtension(fileInfo.Name);

        #region ToDecide
        //public static IEnumerable<FileSystemInfo> EnumAll(this FileSystemInfo fsi, Predicate<DirectoryInfo> dirFilter = null)
        //{
        //	try
        //	{
        //		var dir = fsi.AsDirectory();
        //		if (dirFilter == null || dirFilter(dir))
        //		{
        //			var items = dir.EnumerateFileSystemInfos();
        //			foreach (var item in items.ToArray())
        //			{
        //				if (item.IsDirectory()) items = items.Union(item.EnumAll(dirFilter));
        //			}
        //			return items;
        //		}
        //		else return Enumerable.Empty<FileSystemInfo>();
        //	}
        //	catch (Exception ex)
        //	{
        //		ex.Dump();
        //		return Enumerable.Empty<FileSystemInfo>();
        //	}
        //}
        //public static IEnumerable<FileInfo> EnumAllFiles(this DirectoryInfo dirInfo)
        //{
        //	try
        //	{
        //		var files = dirInfo.EnumerateFiles();
        //		var dirs = dirInfo.EnumerateDirectories();
        //		foreach (var dir in dirs) files = files.Union(dir.EnumAllFiles());
        //		return files;
        //	}
        //	catch (Exception ex)
        //	{
        //		ex.Message.Dump();
        //		return Enumerable.Empty<FileInfo>();
        //	}
        //}

        //public static bool IsFile(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Archive);
        //public static bool IsDirectory(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Directory);
        //public static bool IsSystem(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.System);
        //public static bool IsHidden(this FileSystemInfo fsi) => fsi.Attributes.HasFlag(FileAttributes.Hidden);

        //public static DirectoryInfo AsDirectory(this FileSystemInfo fsi) => (DirectoryInfo)fsi;

        //public static bool CanReadData(this DirectoryInfo dirInfo) => dirInfo.CanDo(FileSystemRights.ReadData);
        //private static bool CanDo(this DirectoryInfo dirInfo, FileSystemRights right)
        //{
        //	try
        //	{
        //		var rules = dirInfo.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
        //		var canDo = rules.Cast<FileSystemAccessRule>().Any(c => c.FileSystemRights.HasFlag(right) && c.AccessControlType == AccessControlType.Allow);
        //		var cannotDo = rules.Cast<FileSystemAccessRule>().Any(c => c.FileSystemRights.HasFlag(right) && c.AccessControlType == AccessControlType.Deny);
        //		return canDo && !cannotDo;
        //	}
        //	catch (Exception ex)
        //	{
        //		return false;
        //	}
        //}
        #endregion
    }
}
