﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationWeb.Client.RegistrationServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RegistrationServiceReference.IRegistrationService")]
    public interface IRegistrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/RegisterForCourse", ReplyAction="http://tempuri.org/IRegistrationService/RegisterForCourseResponse")]
        bool RegisterForCourse(int studentId, int courseScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/RegisterForCourse", ReplyAction="http://tempuri.org/IRegistrationService/RegisterForCourseResponse")]
        System.Threading.Tasks.Task<bool> RegisterForCourseAsync(int studentId, int courseScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/HoldCourse", ReplyAction="http://tempuri.org/IRegistrationService/HoldCourseResponse")]
        bool HoldCourse(int studentId, int courseScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/HoldCourse", ReplyAction="http://tempuri.org/IRegistrationService/HoldCourseResponse")]
        System.Threading.Tasks.Task<bool> HoldCourseAsync(int studentId, int courseScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/DropCourse", ReplyAction="http://tempuri.org/IRegistrationService/DropCourseResponse")]
        bool DropCourse(int studentId, int studentScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/DropCourse", ReplyAction="http://tempuri.org/IRegistrationService/DropCourseResponse")]
        System.Threading.Tasks.Task<bool> DropCourseAsync(int studentId, int studentScheduleId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentSchedule", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentScheduleResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[] ListStudentSchedule(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentSchedule", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentScheduleResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[]> ListStudentScheduleAsync(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentBookmarks", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentBookmarksResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[] ListStudentBookmarks(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudentBookmarks", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentBookmarksResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[]> ListStudentBookmarksAsync(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudents", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentsResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO[] ListStudents();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListStudents", ReplyAction="http://tempuri.org/IRegistrationService/ListStudentsResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO[]> ListStudentsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListCourses", ReplyAction="http://tempuri.org/IRegistrationService/ListCoursesResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[] ListCourses();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/ListCourses", ReplyAction="http://tempuri.org/IRegistrationService/ListCoursesResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[]> ListCoursesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/GetStudent", ReplyAction="http://tempuri.org/IRegistrationService/GetStudentResponse")]
        RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO GetStudent(int studentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationService/GetStudent", ReplyAction="http://tempuri.org/IRegistrationService/GetStudentResponse")]
        System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO> GetStudentAsync(int studentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrationServiceChannel : RegistrationWeb.Client.RegistrationServiceReference.IRegistrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationServiceClient : System.ServiceModel.ClientBase<RegistrationWeb.Client.RegistrationServiceReference.IRegistrationService>, RegistrationWeb.Client.RegistrationServiceReference.IRegistrationService {
        
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
        
        public bool RegisterForCourse(int studentId, int courseScheduleId) {
            return base.Channel.RegisterForCourse(studentId, courseScheduleId);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterForCourseAsync(int studentId, int courseScheduleId) {
            return base.Channel.RegisterForCourseAsync(studentId, courseScheduleId);
        }
        
        public bool HoldCourse(int studentId, int courseScheduleId) {
            return base.Channel.HoldCourse(studentId, courseScheduleId);
        }
        
        public System.Threading.Tasks.Task<bool> HoldCourseAsync(int studentId, int courseScheduleId) {
            return base.Channel.HoldCourseAsync(studentId, courseScheduleId);
        }
        
        public bool DropCourse(int studentId, int studentScheduleId) {
            return base.Channel.DropCourse(studentId, studentScheduleId);
        }
        
        public System.Threading.Tasks.Task<bool> DropCourseAsync(int studentId, int studentScheduleId) {
            return base.Channel.DropCourseAsync(studentId, studentScheduleId);
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[] ListStudentSchedule(int studentId) {
            return base.Channel.ListStudentSchedule(studentId);
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[]> ListStudentScheduleAsync(int studentId) {
            return base.Channel.ListStudentScheduleAsync(studentId);
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[] ListStudentBookmarks(int studentId) {
            return base.Channel.ListStudentBookmarks(studentId);
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentScheduleDAO[]> ListStudentBookmarksAsync(int studentId) {
            return base.Channel.ListStudentBookmarksAsync(studentId);
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO[] ListStudents() {
            return base.Channel.ListStudents();
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO[]> ListStudentsAsync() {
            return base.Channel.ListStudentsAsync();
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[] ListCourses() {
            return base.Channel.ListCourses();
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.CourseScheduleDAO[]> ListCoursesAsync() {
            return base.Channel.ListCoursesAsync();
        }
        
        public RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO GetStudent(int studentId) {
            return base.Channel.GetStudent(studentId);
        }
        
        public System.Threading.Tasks.Task<RegistrationWeb.Domain.RegistrationServiceReference.StudentDAO> GetStudentAsync(int studentId) {
            return base.Channel.GetStudentAsync(studentId);
        }
    }
}
