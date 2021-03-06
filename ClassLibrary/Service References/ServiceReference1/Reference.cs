﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.SmsSoap")]
    public interface SmsSoap {
        
        // CODEGEN: Generating message contract since element name requestData from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/XmsRequest", ReplyAction="*")]
        ClassLibrary.ServiceReference1.XmsRequestResponse XmsRequest(ClassLibrary.ServiceReference1.XmsRequestRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class XmsRequestRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="XmsRequest", Namespace="http://tempuri.org/", Order=0)]
        public ClassLibrary.ServiceReference1.XmsRequestRequestBody Body;
        
        public XmsRequestRequest() {
        }
        
        public XmsRequestRequest(ClassLibrary.ServiceReference1.XmsRequestRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class XmsRequestRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string requestData;
        
        public XmsRequestRequestBody() {
        }
        
        public XmsRequestRequestBody(string requestData) {
            this.requestData = requestData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class XmsRequestResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="XmsRequestResponse", Namespace="http://tempuri.org/", Order=0)]
        public ClassLibrary.ServiceReference1.XmsRequestResponseBody Body;
        
        public XmsRequestResponse() {
        }
        
        public XmsRequestResponse(ClassLibrary.ServiceReference1.XmsRequestResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class XmsRequestResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public object XmsRequestResult;
        
        public XmsRequestResponseBody() {
        }
        
        public XmsRequestResponseBody(object XmsRequestResult) {
            this.XmsRequestResult = XmsRequestResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SmsSoapChannel : ClassLibrary.ServiceReference1.SmsSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SmsSoapClient : System.ServiceModel.ClientBase<ClassLibrary.ServiceReference1.SmsSoap>, ClassLibrary.ServiceReference1.SmsSoap {
        
        public SmsSoapClient() {
        }
        
        public SmsSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SmsSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmsSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClassLibrary.ServiceReference1.XmsRequestResponse ClassLibrary.ServiceReference1.SmsSoap.XmsRequest(ClassLibrary.ServiceReference1.XmsRequestRequest request) {
            return base.Channel.XmsRequest(request);
        }
        
        public object XmsRequest(string requestData) {
            ClassLibrary.ServiceReference1.XmsRequestRequest inValue = new ClassLibrary.ServiceReference1.XmsRequestRequest();
            inValue.Body = new ClassLibrary.ServiceReference1.XmsRequestRequestBody();
            inValue.Body.requestData = requestData;
            ClassLibrary.ServiceReference1.XmsRequestResponse retVal = ((ClassLibrary.ServiceReference1.SmsSoap)(this)).XmsRequest(inValue);
            return retVal.Body.XmsRequestResult;
        }
    }
}
