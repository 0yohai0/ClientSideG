﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace theResearchSite.UserNewsInteractionService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="FavoriteList", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch", ItemName="Favorite")]
    [System.SerializableAttribute()]
    public class FavoriteList : System.Collections.Generic.List<theResearchSite.UserNewsInteractionService.Favorite> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Favorite", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class Favorite : theResearchSite.UserNewsInteractionService.UserNewsInteraction {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseEntity", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.News))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.AuthLevel))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Category))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Human))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.User))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Worker))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.UserNewsInteraction))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Comment))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Favorite))]
    public partial class BaseEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="News", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class News : theResearchSite.UserNewsInteractionService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private theResearchSite.UserNewsInteractionService.AuthLevel AuthLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private theResearchSite.UserNewsInteractionService.Category categoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateTimePublishedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string headLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string imagePathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string secondaryTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int viewsCountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public theResearchSite.UserNewsInteractionService.AuthLevel AuthLevel {
            get {
                return this.AuthLevelField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthLevelField, value) != true)) {
                    this.AuthLevelField = value;
                    this.RaisePropertyChanged("AuthLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public theResearchSite.UserNewsInteractionService.Category category {
            get {
                return this.categoryField;
            }
            set {
                if ((object.ReferenceEquals(this.categoryField, value) != true)) {
                    this.categoryField = value;
                    this.RaisePropertyChanged("category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string content {
            get {
                return this.contentField;
            }
            set {
                if ((object.ReferenceEquals(this.contentField, value) != true)) {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime dateTimePublished {
            get {
                return this.dateTimePublishedField;
            }
            set {
                if ((this.dateTimePublishedField.Equals(value) != true)) {
                    this.dateTimePublishedField = value;
                    this.RaisePropertyChanged("dateTimePublished");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string headLine {
            get {
                return this.headLineField;
            }
            set {
                if ((object.ReferenceEquals(this.headLineField, value) != true)) {
                    this.headLineField = value;
                    this.RaisePropertyChanged("headLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string imagePath {
            get {
                return this.imagePathField;
            }
            set {
                if ((object.ReferenceEquals(this.imagePathField, value) != true)) {
                    this.imagePathField = value;
                    this.RaisePropertyChanged("imagePath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string secondaryTitle {
            get {
                return this.secondaryTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.secondaryTitleField, value) != true)) {
                    this.secondaryTitleField = value;
                    this.RaisePropertyChanged("secondaryTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int viewsCount {
            get {
                return this.viewsCountField;
            }
            set {
                if ((this.viewsCountField.Equals(value) != true)) {
                    this.viewsCountField = value;
                    this.RaisePropertyChanged("viewsCount");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthLevel", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class AuthLevel : theResearchSite.UserNewsInteractionService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Category", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class Category : theResearchSite.UserNewsInteractionService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Human", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.User))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Worker))]
    public partial class Human : theResearchSite.UserNewsInteractionService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private theResearchSite.UserNewsInteractionService.AuthLevel authLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime joinDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string passwordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string userNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public theResearchSite.UserNewsInteractionService.AuthLevel authLevel {
            get {
                return this.authLevelField;
            }
            set {
                if ((object.ReferenceEquals(this.authLevelField, value) != true)) {
                    this.authLevelField = value;
                    this.RaisePropertyChanged("authLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string email {
            get {
                return this.emailField;
            }
            set {
                if ((object.ReferenceEquals(this.emailField, value) != true)) {
                    this.emailField = value;
                    this.RaisePropertyChanged("email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime joinDate {
            get {
                return this.joinDateField;
            }
            set {
                if ((this.joinDateField.Equals(value) != true)) {
                    this.joinDateField = value;
                    this.RaisePropertyChanged("joinDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string password {
            get {
                return this.passwordField;
            }
            set {
                if ((object.ReferenceEquals(this.passwordField, value) != true)) {
                    this.passwordField = value;
                    this.RaisePropertyChanged("password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                if ((object.ReferenceEquals(this.userNameField, value) != true)) {
                    this.userNameField = value;
                    this.RaisePropertyChanged("userName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class User : theResearchSite.UserNewsInteractionService.Human {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUserField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUser {
            get {
                return this.IdUserField;
            }
            set {
                if ((this.IdUserField.Equals(value) != true)) {
                    this.IdUserField = value;
                    this.RaisePropertyChanged("IdUser");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Worker", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class Worker : theResearchSite.UserNewsInteractionService.Human {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double salaryField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double salary {
            get {
                return this.salaryField;
            }
            set {
                if ((this.salaryField.Equals(value) != true)) {
                    this.salaryField = value;
                    this.RaisePropertyChanged("salary");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserNewsInteraction", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Comment))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(theResearchSite.UserNewsInteractionService.Favorite))]
    public partial class UserNewsInteraction : theResearchSite.UserNewsInteractionService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime dateTimeAddedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private theResearchSite.UserNewsInteractionService.News newsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private theResearchSite.UserNewsInteractionService.User userField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime dateTimeAdded {
            get {
                return this.dateTimeAddedField;
            }
            set {
                if ((this.dateTimeAddedField.Equals(value) != true)) {
                    this.dateTimeAddedField = value;
                    this.RaisePropertyChanged("dateTimeAdded");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public theResearchSite.UserNewsInteractionService.News news {
            get {
                return this.newsField;
            }
            set {
                if ((object.ReferenceEquals(this.newsField, value) != true)) {
                    this.newsField = value;
                    this.RaisePropertyChanged("news");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public theResearchSite.UserNewsInteractionService.User user {
            get {
                return this.userField;
            }
            set {
                if ((object.ReferenceEquals(this.userField, value) != true)) {
                    this.userField = value;
                    this.RaisePropertyChanged("user");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Comment", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    [System.SerializableAttribute()]
    public partial class Comment : theResearchSite.UserNewsInteractionService.UserNewsInteraction {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string contentField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string content {
            get {
                return this.contentField;
            }
            set {
                if ((object.ReferenceEquals(this.contentField, value) != true)) {
                    this.contentField = value;
                    this.RaisePropertyChanged("content");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="CommentList", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch", ItemName="Comment")]
    [System.SerializableAttribute()]
    public class CommentList : System.Collections.Generic.List<theResearchSite.UserNewsInteractionService.Comment> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Enums.userNewsInteracrionType", Namespace="http://schemas.datacontract.org/2004/07/ModelTheResearch")]
    public enum EnumsuserNewsInteracrionType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        favorite = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        comment = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        all = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserNewsInteractionService.IUserNewsInteraction")]
    public interface IUserNewsInteraction {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/selectAllFavorits", ReplyAction="http://tempuri.org/IUserNewsInteraction/selectAllFavoritsResponse")]
        theResearchSite.UserNewsInteractionService.FavoriteList selectAllFavorits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/selectAllFavorits", ReplyAction="http://tempuri.org/IUserNewsInteraction/selectAllFavoritsResponse")]
        System.Threading.Tasks.Task<theResearchSite.UserNewsInteractionService.FavoriteList> selectAllFavoritsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/selectAllComments", ReplyAction="http://tempuri.org/IUserNewsInteraction/selectAllCommentsResponse")]
        theResearchSite.UserNewsInteractionService.CommentList selectAllComments();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/selectAllComments", ReplyAction="http://tempuri.org/IUserNewsInteraction/selectAllCommentsResponse")]
        System.Threading.Tasks.Task<theResearchSite.UserNewsInteractionService.CommentList> selectAllCommentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/Add", ReplyAction="http://tempuri.org/IUserNewsInteraction/AddResponse")]
        int Add(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/Add", ReplyAction="http://tempuri.org/IUserNewsInteraction/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/Remove", ReplyAction="http://tempuri.org/IUserNewsInteraction/RemoveResponse")]
        int Remove(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserNewsInteraction/Remove", ReplyAction="http://tempuri.org/IUserNewsInteraction/RemoveResponse")]
        System.Threading.Tasks.Task<int> RemoveAsync(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserNewsInteractionChannel : theResearchSite.UserNewsInteractionService.IUserNewsInteraction, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserNewsInteractionClient : System.ServiceModel.ClientBase<theResearchSite.UserNewsInteractionService.IUserNewsInteraction>, theResearchSite.UserNewsInteractionService.IUserNewsInteraction {
        
        public UserNewsInteractionClient() {
        }
        
        public UserNewsInteractionClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserNewsInteractionClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserNewsInteractionClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserNewsInteractionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public theResearchSite.UserNewsInteractionService.FavoriteList selectAllFavorits() {
            return base.Channel.selectAllFavorits();
        }
        
        public System.Threading.Tasks.Task<theResearchSite.UserNewsInteractionService.FavoriteList> selectAllFavoritsAsync() {
            return base.Channel.selectAllFavoritsAsync();
        }
        
        public theResearchSite.UserNewsInteractionService.CommentList selectAllComments() {
            return base.Channel.selectAllComments();
        }
        
        public System.Threading.Tasks.Task<theResearchSite.UserNewsInteractionService.CommentList> selectAllCommentsAsync() {
            return base.Channel.selectAllCommentsAsync();
        }
        
        public int Add(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction) {
            return base.Channel.Add(userNewsInteracrionType, userNewsInteraction);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction) {
            return base.Channel.AddAsync(userNewsInteracrionType, userNewsInteraction);
        }
        
        public int Remove(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction) {
            return base.Channel.Remove(userNewsInteracrionType, userNewsInteraction);
        }
        
        public System.Threading.Tasks.Task<int> RemoveAsync(theResearchSite.UserNewsInteractionService.EnumsuserNewsInteracrionType userNewsInteracrionType, theResearchSite.UserNewsInteractionService.UserNewsInteraction userNewsInteraction) {
            return base.Channel.RemoveAsync(userNewsInteracrionType, userNewsInteraction);
        }
    }
}
