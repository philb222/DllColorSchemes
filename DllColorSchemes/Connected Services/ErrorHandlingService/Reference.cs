﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DllColorSchemes.ErrorHandlingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ErrorHandlingService.ILocalErrorService")]
    public interface ILocalErrorService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocalErrorService/ServiceAvail", ReplyAction="http://tempuri.org/ILocalErrorService/ServiceAvailResponse")]
        bool ServiceAvail();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocalErrorService/ServiceAvail", ReplyAction="http://tempuri.org/ILocalErrorService/ServiceAvailResponse")]
        System.Threading.Tasks.Task<bool> ServiceAvailAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocalErrorService/Add", ReplyAction="http://tempuri.org/ILocalErrorService/AddResponse")]
        string Add(System.DateTime timeOfError, string appNameInError, string targetSite, byte[] ex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILocalErrorService/Add", ReplyAction="http://tempuri.org/ILocalErrorService/AddResponse")]
        System.Threading.Tasks.Task<string> AddAsync(System.DateTime timeOfError, string appNameInError, string targetSite, byte[] ex);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILocalErrorServiceChannel : DllColorSchemes.ErrorHandlingService.ILocalErrorService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LocalErrorServiceClient : System.ServiceModel.ClientBase<DllColorSchemes.ErrorHandlingService.ILocalErrorService>, DllColorSchemes.ErrorHandlingService.ILocalErrorService {
        
        public LocalErrorServiceClient() {
        }
        
        public LocalErrorServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LocalErrorServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocalErrorServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LocalErrorServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ServiceAvail() {
            return base.Channel.ServiceAvail();
        }
        
        public System.Threading.Tasks.Task<bool> ServiceAvailAsync() {
            return base.Channel.ServiceAvailAsync();
        }
        
        public string Add(System.DateTime timeOfError, string appNameInError, string targetSite, byte[] ex) {
            return base.Channel.Add(timeOfError, appNameInError, targetSite, ex);
        }
        
        public System.Threading.Tasks.Task<string> AddAsync(System.DateTime timeOfError, string appNameInError, string targetSite, byte[] ex) {
            return base.Channel.AddAsync(timeOfError, appNameInError, targetSite, ex);
        }
    }
}
