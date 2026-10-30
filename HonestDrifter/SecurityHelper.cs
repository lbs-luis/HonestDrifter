#pragma warning disable CS0618 // SecurityAction.RequestMinimum is obsolete but still works for publicizing
using System.Security;
using System.Security.Permissions;

// Required for accessing private/internal members in publicized assemblies
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618
