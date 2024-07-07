using System.Security.AccessControl;

namespace AccessControl;

public static class AccessRightsToLoggingFile
{
    private const string ACCOUNT = @"LAPTOP-6VDUE8G6\Adilya";
    public static bool IsUnLock { get; set; }
    public static void AddRights()
    {
        FileInfo fileInfo = new(Logger.PATH);
        FileSecurity fSecurity = fileInfo.GetAccessControl();

        // Add the FileSystemAccessRule to the security settings.
        fSecurity.AddAccessRule(new FileSystemAccessRule(ACCOUNT,
            FileSystemRights.FullControl, AccessControlType.Deny));

        // Set the new access settings.
        fileInfo.SetAccessControl(fSecurity);
    }

    public static void RemoveRights()
    {
        FileInfo fileInfo = new(Logger.PATH);
        FileSecurity fSecurity = fileInfo.GetAccessControl();

        // Add the FileSystemAccessRule to the security settings.
        fSecurity.RemoveAccessRule(new FileSystemAccessRule(ACCOUNT,
            FileSystemRights.FullControl, AccessControlType.Deny));
        fSecurity.AddAccessRule(new FileSystemAccessRule(ACCOUNT,
            FileSystemRights.FullControl, AccessControlType.Allow));

        // Set the new access settings.
        fileInfo.SetAccessControl(fSecurity);
    }
}