﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApplication2.service_sql {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="service_sql.IFel4")]
    public interface IFel4 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFel4/Query", ReplyAction="http://tempuri.org/IFel4/QueryResponse")]
        string Query(string q);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFel4/Query", ReplyAction="http://tempuri.org/IFel4/QueryResponse")]
        System.Threading.Tasks.Task<string> QueryAsync(string q);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFel4Channel : WpfApplication2.service_sql.IFel4, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Fel4Client : System.ServiceModel.ClientBase<WpfApplication2.service_sql.IFel4>, WpfApplication2.service_sql.IFel4 {
        
        public Fel4Client() {
        }
        
        public Fel4Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Fel4Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Fel4Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Fel4Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Query(string q) {
            return base.Channel.Query(q);
        }
        
        public System.Threading.Tasks.Task<string> QueryAsync(string q) {
            return base.Channel.QueryAsync(q);
        }
    }
}
