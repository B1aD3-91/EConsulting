﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbCloneApp.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DbCloneApp.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE [{0}];
        ///GO
        ///BEGIN
        ///    DECLARE @Path nvarchar(100);
        ///    SET @Path = &apos;{1}&apos;
        ///    EXEC master.dbo.xp_create_subdir @Path
        ///    SET @Path = @Path + &apos;{0}.bak&apos;
        ///    BACKUP DATABASE [{0}]
        ///        TO DISK = @Path
        ///            WITH FORMAT,
        ///        MEDIANAME = &apos;SQLServerBackups&apos;,
        ///        NAME = &apos;Full Backup of SQLTestDB&apos;;
        ///END;.
        /// </summary>
        internal static string BackupDBQuery {
            get {
                return ResourceManager.GetString("BackupDBQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE [master]
        ///GO
        ///BEGIN
        ///    DECLARE @sourceDbName nvarchar(50) = &apos;{0}&apos;;
        ///    DECLARE @tmpFolder nvarchar(50) = &apos;C:\tmp\&apos;
        ///    DECLARE @sqlServerDbFolder nvarchar(100) = &apos;C:\mydatabases\&apos;
        ///
        ///    DECLARE @sourceDbFile nvarchar(50);
        ///    DECLARE @sourceDbFileLog nvarchar(50);
        ///    DECLARE @destinationDbName nvarchar(50) = &apos;{1}&apos;
        ///    DECLARE @backupPath nvarchar(400) = @tmpFolder + @destinationDbName + &apos;.bak&apos;
        ///    DECLARE @destMdf nvarchar(100) = @sqlServerDbFolder + @destinationDbName + &apos;.mdf&apos;
        ///    DECLARE @d [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CloneDbQuery {
            get {
                return ResourceManager.GetString("CloneDbQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Data Source=(localdb)\MSSQLLocalDB.
        /// </summary>
        internal static string connectionString {
            get {
                return ResourceManager.GetString("connectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE [master]
        ///GO
        ///CREATE DATABASE [{0}]
        ///GO
        ///USE [{0}]
        ///GO
        ///CREATE TABLE [{1}]
        ///(
        ///      Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
        ///      [start] DATETIME NOT NULL,
        ///      [end] DATETIME NOT NULL
        ///);
        ///GO
        ///INSERT INTO [{1}] ([start], [end]) VALUES (&apos;2020-10-10&apos;, &apos;2021-08-25&apos;);
        ///INSERT INTO [{1}] ([start], [end]) VALUES (&apos;2019-10-10&apos;, &apos;2020-05-30&apos;);
        ///INSERT INTO [{1}] ([start], [end]) VALUES (&apos;2018-10-10&apos;, &apos;2019-01-15&apos;);
        ///INSERT INTO [{1}] ([start], [end]) VALUES (&apos;2017-10-10&apos;, &apos;2018-03-05&apos;);
        ///INSERT INTO [ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string CreateDBQuery {
            get {
                return ResourceManager.GetString("CreateDBQuery", resourceCulture);
            }
        }
    }
}
