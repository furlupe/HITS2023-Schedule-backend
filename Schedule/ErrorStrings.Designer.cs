﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schedule {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ErrorStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ErrorStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Schedule.ErrorStrings", typeof(ErrorStrings).Assembly);
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
        ///   Looks up a localized string similar to Access denied.
        /// </summary>
        public static string ACCESS_DENIED {
            get {
                return ResourceManager.GetString("ACCESS_DENIED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Access denied.
        /// </summary>
        public static string ACCESS_DENIED_ERROR {
            get {
                return ResourceManager.GetString("ACCESS_DENIED_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Editor\\admin given, yet group id was provided.
        /// </summary>
        public static string EDITOR_ADMIN_GROUP_GIVEN_ERROR {
            get {
                return ResourceManager.GetString("EDITOR_ADMIN_GROUP_GIVEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Editor\\admin given, yet teacher id was provided.
        /// </summary>
        public static string EDITOR_ADMIN_TEACHER_GIVEN_ERROR {
            get {
                return ResourceManager.GetString("EDITOR_ADMIN_TEACHER_GIVEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Group w/ id = {0} does not exist.
        /// </summary>
        public static string GROUP_WRONG_ID_ERROR {
            get {
                return ResourceManager.GetString("GROUP_WRONG_ID_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Group w/ number = {0} does not exist.
        /// </summary>
        public static string GROUP_WRONG_NUMBER_ERROR {
            get {
                return ResourceManager.GetString("GROUP_WRONG_NUMBER_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid credentials.
        /// </summary>
        public static string INVALID_CREDENTIALS_ERROR {
            get {
                return ResourceManager.GetString("INVALID_CREDENTIALS_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Login is already taken.
        /// </summary>
        public static string LOGIN_TAKEN_ERROR {
            get {
                return ResourceManager.GetString("LOGIN_TAKEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User must have ROOT right in order to execute that action.
        /// </summary>
        public static string NOT_A_ROOT_ERROR {
            get {
                return ResourceManager.GetString("NOT_A_ROOT_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t register a new ROOT.
        /// </summary>
        public static string ROOT_GIVEN_ERROR {
            get {
                return ResourceManager.GetString("ROOT_GIVEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Student given, yet teacher id was provided.
        /// </summary>
        public static string STUDENT_TEACHER_GIVEN_ERROR {
            get {
                return ResourceManager.GetString("STUDENT_TEACHER_GIVEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There&apos;s already an account for teacher w/ id = {0}.
        /// </summary>
        public static string TEACHER_ACCOUNT_EXISTS_ERROR {
            get {
                return ResourceManager.GetString("TEACHER_ACCOUNT_EXISTS_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Teacher given, yet group id was provided.
        /// </summary>
        public static string TEACHER_GROUP_GIVEN_ERROR {
            get {
                return ResourceManager.GetString("TEACHER_GROUP_GIVEN_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Teacher given, yet no id was specified.
        /// </summary>
        public static string TEACHER_NO_ID_ERROR {
            get {
                return ResourceManager.GetString("TEACHER_NO_ID_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Teacher w/ id= {0} does not exist.
        /// </summary>
        public static string TEACHER_WRONG_ID_ERROR {
            get {
                return ResourceManager.GetString("TEACHER_WRONG_ID_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User w/ id = {0} does not exist.
        /// </summary>
        public static string USER_WRONG_ID_ERROR {
            get {
                return ResourceManager.GetString("USER_WRONG_ID_ERROR", resourceCulture);
            }
        }
    }
}
