﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DNTCms.Resources.Administrator.Role {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class EditRole_cshtml {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal EditRole_cshtml() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DNTCms.Resources.Administrator.Role.EditRole_cshtml", typeof(EditRole_cshtml).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to توضیحات.
        /// </summary>
        public static string DisplayForDescription {
            get {
                return ResourceManager.GetString("DisplayForDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to کاربران این گروه غیرفعال شوند؟.
        /// </summary>
        public static string DisplayForIsBanned {
            get {
                return ResourceManager.GetString("DisplayForIsBanned", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to گروه کاربری سیستمی.
        /// </summary>
        public static string DisplayForIsSystemRole {
            get {
                return ResourceManager.GetString("DisplayForIsSystemRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام گروه.
        /// </summary>
        public static string DisplayForName {
            get {
                return ResourceManager.GetString("DisplayForName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to دسترسی ها.
        /// </summary>
        public static string DisplayForPermissionIds {
            get {
                return ResourceManager.GetString("DisplayForPermissionIds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عنوان.
        /// </summary>
        public static string DisplayForTitle {
            get {
                return ResourceManager.GetString("DisplayForTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to قبلا یک گروه کاربری با این نام در سیستم درج شده است.
        /// </summary>
        public static string RemoteValidationNameMessage {
            get {
                return ResourceManager.GetString("RemoteValidationNameMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to لطفا نام گروه را وارد کنید.
        /// </summary>
        public static string RequiredNameMessage {
            get {
                return ResourceManager.GetString("RequiredNameMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to توضیحات گروه کاربری نباید بیشتر از 100 کاراکتر باشد.
        /// </summary>
        public static string StringLengthDescriptionMessage {
            get {
                return ResourceManager.GetString("StringLengthDescriptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to نام گروه کاربری باید بین 5 تا 20 کاراکتر باشد.
        /// </summary>
        public static string StringLengthNameMessage {
            get {
                return ResourceManager.GetString("StringLengthNameMessage", resourceCulture);
            }
        }
    }
}
