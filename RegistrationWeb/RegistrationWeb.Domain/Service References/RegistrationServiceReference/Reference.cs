﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationWeb.Domain.RegistrationServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StudentDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class StudentDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.DepartmentDAO MajorDepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.PersonDAO PersonField;
        
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
        public RegistrationWeb.Domain.RegistrationServiceReference.DepartmentDAO MajorDepartment {
            get {
                return this.MajorDepartmentField;
            }
            set {
                if ((object.ReferenceEquals(this.MajorDepartmentField, value) != true)) {
                    this.MajorDepartmentField = value;
                    this.RaisePropertyChanged("MajorDepartment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RegistrationWeb.Domain.RegistrationServiceReference.PersonDAO Person {
            get {
                return this.PersonField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonField, value) != true)) {
                    this.PersonField = value;
                    this.RaisePropertyChanged("Person");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DepartmentDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class DepartmentDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class PersonDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CourseScheduleDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class CourseScheduleDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short CapacityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.CourseDAO CourseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.PersonDAO ProfessorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.ScheduleDAO ScheduleField;
        
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
        public short Capacity {
            get {
                return this.CapacityField;
            }
            set {
                if ((this.CapacityField.Equals(value) != true)) {
                    this.CapacityField = value;
                    this.RaisePropertyChanged("Capacity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RegistrationWeb.Domain.RegistrationServiceReference.CourseDAO Course {
            get {
                return this.CourseField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseField, value) != true)) {
                    this.CourseField = value;
                    this.RaisePropertyChanged("Course");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RegistrationWeb.Domain.RegistrationServiceReference.PersonDAO Professor {
            get {
                return this.ProfessorField;
            }
            set {
                if ((object.ReferenceEquals(this.ProfessorField, value) != true)) {
                    this.ProfessorField = value;
                    this.RaisePropertyChanged("Professor");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RegistrationWeb.Domain.RegistrationServiceReference.ScheduleDAO Schedule {
            get {
                return this.ScheduleField;
            }
            set {
                if ((object.ReferenceEquals(this.ScheduleField, value) != true)) {
                    this.ScheduleField = value;
                    this.RaisePropertyChanged("Schedule");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CourseDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class CourseDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.DepartmentDAO CourseDepartmentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short CreditField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
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
        public RegistrationWeb.Domain.RegistrationServiceReference.DepartmentDAO CourseDepartment {
            get {
                return this.CourseDepartmentField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseDepartmentField, value) != true)) {
                    this.CourseDepartmentField = value;
                    this.RaisePropertyChanged("CourseDepartment");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Credit {
            get {
                return this.CreditField;
            }
            set {
                if ((this.CreditField.Equals(value) != true)) {
                    this.CreditField = value;
                    this.RaisePropertyChanged("Credit");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ScheduleDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class ScheduleDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan StartTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short TimeBlocksField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan StartTime {
            get {
                return this.StartTimeField;
            }
            set {
                if ((this.StartTimeField.Equals(value) != true)) {
                    this.StartTimeField = value;
                    this.RaisePropertyChanged("StartTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short TimeBlocks {
            get {
                return this.TimeBlocksField;
            }
            set {
                if ((this.TimeBlocksField.Equals(value) != true)) {
                    this.TimeBlocksField = value;
                    this.RaisePropertyChanged("TimeBlocks");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="StudentScheduleDAO", Namespace="http://schemas.datacontract.org/2004/07/RegistrationApp.DataClient.Models")]
    [System.SerializableAttribute()]
    public partial class StudentScheduleDAO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO CourseScheduleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EnrolledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO StudentField;
        
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
        public RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO CourseSchedule {
            get {
                return this.CourseScheduleField;
            }
            set {
                if ((object.ReferenceEquals(this.CourseScheduleField, value) != true)) {
                    this.CourseScheduleField = value;
                    this.RaisePropertyChanged("CourseSchedule");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Enrolled {
            get {
                return this.EnrolledField;
            }
            set {
                if ((this.EnrolledField.Equals(value) != true)) {
                    this.EnrolledField = value;
                    this.RaisePropertyChanged("Enrolled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO Student {
            get {
                return this.StudentField;
            }
            set {
                if ((object.ReferenceEquals(this.StudentField, value) != true)) {
                    this.StudentField = value;
                    this.RaisePropertyChanged("Student");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RegistrationServiceReference.IRegistrationService")]
    public interface IRegistrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/RegisterForCourse", ReplyAction="http://tempuri.org/IRegistrationService/RegisterForCourseResponse")]
        bool RegisterForCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/RegisterForCourse", ReplyAction="http://tempuri.org/IRegistrationService/RegisterForCourseResponse")]
        System.Threading.Tasks.Task<bool> RegisterForCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/HoldCourse", ReplyAction="http://tempuri.org/IRegistrationService/HoldCourseResponse")]
        bool HoldCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/HoldCourse", ReplyAction="http://tempuri.org/IRegistrationService/HoldCourseResponse")]
        System.Threading.Tasks.Task<bool> HoldCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/DropCourse", ReplyAction="http://tempuri.org/IRegistrationService/DropCourseResponse")]
        bool DropCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO studentScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/DropCourse", ReplyAction="http://tempuri.org/IRegistrationService/DropCourseResponse")]
        System.Threading.Tasks.Task<bool> DropCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO studentScheduleDAO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentSchedule", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentScheduleResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[] ListStudentSchedule(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentSchedule", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentScheduleResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[]> ListStudentScheduleAsync(int studentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrationServiceChannel : RegistrationWeb.Domain.RegistrationServiceReference.IRegistrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationServiceClient : System.ServiceModel.ClientBase<RegistrationWeb.Domain.RegistrationServiceReference.IRegistrationService>, RegistrationWeb.Domain.RegistrationServiceReference.IRegistrationService {
        
        public RegistrationServiceClient() {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool RegisterForCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO) {
            return base.Channel.RegisterForCourse(studentDAO, courseScheduleDAO);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterForCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO) {
            return base.Channel.RegisterForCourseAsync(studentDAO, courseScheduleDAO);
        }
        
        public bool HoldCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO) {
            return base.Channel.HoldCourse(studentDAO, courseScheduleDAO);
        }
        
        public System.Threading.Tasks.Task<bool> HoldCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO courseScheduleDAO) {
            return base.Channel.HoldCourseAsync(studentDAO, courseScheduleDAO);
        }
        
        public bool DropCourse(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO studentScheduleDAO) {
            return base.Channel.DropCourse(studentDAO, studentScheduleDAO);
        }
        
        public System.Threading.Tasks.Task<bool> DropCourseAsync(RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO studentDAO, RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO studentScheduleDAO) {
            return base.Channel.DropCourseAsync(studentDAO, studentScheduleDAO);
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[] ListStudentSchedule(int studentId) {
            return base.Channel.ListStudentSchedule(studentId);
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[]> ListStudentScheduleAsync(int studentId) {
            return base.Channel.ListStudentScheduleAsync(studentId);
        }
    }
}
