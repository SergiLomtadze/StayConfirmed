﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mailer
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Mail", Namespace="http://schemas.datacontract.org/2004/07/Mindcube")]
    public partial class Mail : object
    {
        
        private Mailer.Attachment[] AttachmentsField;
        
        private Mailer.MailAddress[] BccField;
        
        private string BodyField;
        
        private Mailer.MailAddress[] CcField;
        
        private Mailer.MailAddress FromField;
        
        private System.Net.Mail.MailPriority PriorityField;
        
        private Mailer.MailAddress ReplyToField;
        
        private string SmtpField;
        
        private string SubjectField;
        
        private Mailer.MailAddress[] ToField;
        
        private bool isBodyHtmlField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.Attachment[] Attachments
        {
            get
            {
                return this.AttachmentsField;
            }
            set
            {
                this.AttachmentsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.MailAddress[] Bcc
        {
            get
            {
                return this.BccField;
            }
            set
            {
                this.BccField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Body
        {
            get
            {
                return this.BodyField;
            }
            set
            {
                this.BodyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.MailAddress[] Cc
        {
            get
            {
                return this.CcField;
            }
            set
            {
                this.CcField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.MailAddress From
        {
            get
            {
                return this.FromField;
            }
            set
            {
                this.FromField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Net.Mail.MailPriority Priority
        {
            get
            {
                return this.PriorityField;
            }
            set
            {
                this.PriorityField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.MailAddress ReplyTo
        {
            get
            {
                return this.ReplyToField;
            }
            set
            {
                this.ReplyToField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Smtp
        {
            get
            {
                return this.SmtpField;
            }
            set
            {
                this.SmtpField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject
        {
            get
            {
                return this.SubjectField;
            }
            set
            {
                this.SubjectField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Mailer.MailAddress[] To
        {
            get
            {
                return this.ToField;
            }
            set
            {
                this.ToField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool isBodyHtml
        {
            get
            {
                return this.isBodyHtmlField;
            }
            set
            {
                this.isBodyHtmlField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MailAddress", Namespace="http://schemas.datacontract.org/2004/07/Mindcube")]
    public partial class MailAddress : object
    {
        
        private string DisplayNameField;
        
        private string EmailField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName
        {
            get
            {
                return this.DisplayNameField;
            }
            set
            {
                this.DisplayNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Attachment", Namespace="http://schemas.datacontract.org/2004/07/Mindcube")]
    public partial class Attachment : object
    {
        
        private byte[] ContentField;
        
        private string ContentTypeField;
        
        private string FilenameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                this.ContentField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ContentType
        {
            get
            {
                return this.ContentTypeField;
            }
            set
            {
                this.ContentTypeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Filename
        {
            get
            {
                return this.FilenameField;
            }
            set
            {
                this.FilenameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TemplateParameter", Namespace="http://schemas.datacontract.org/2004/07/Mindcube")]
    public partial class TemplateParameter : object
    {
        
        private string NameField;
        
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Mailer.IMailer")]
    public interface IMailer
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailer/SendMail", ReplyAction="http://tempuri.org/IMailer/SendMailResponse")]
        System.Threading.Tasks.Task<string> SendMailAsync(Mailer.Mail mail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailer/SendTemplateMail", ReplyAction="http://tempuri.org/IMailer/SendTemplateMailResponse")]
        System.Threading.Tasks.Task<string> SendTemplateMailAsync(Mailer.Mail mail, string templateName, Mailer.TemplateParameter[] templateParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMailer/SendTemplateMailV2", ReplyAction="http://tempuri.org/IMailer/SendTemplateMailV2Response")]
        System.Threading.Tasks.Task<string> SendTemplateMailV2Async(Mailer.Mail mail, string templateName, Mailer.TemplateParameter[] templateParameters, string language);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IMailerChannel : Mailer.IMailer, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class MailerClient : System.ServiceModel.ClientBase<Mailer.IMailer>, Mailer.IMailer
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public MailerClient() : 
                base(MailerClient.GetDefaultBinding(), MailerClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IMailer.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailerClient(EndpointConfiguration endpointConfiguration) : 
                base(MailerClient.GetBindingForEndpoint(endpointConfiguration), MailerClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailerClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(MailerClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailerClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(MailerClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public MailerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> SendMailAsync(Mailer.Mail mail)
        {
            return base.Channel.SendMailAsync(mail);
        }
        
        public System.Threading.Tasks.Task<string> SendTemplateMailAsync(Mailer.Mail mail, string templateName, Mailer.TemplateParameter[] templateParameters)
        {
            return base.Channel.SendTemplateMailAsync(mail, templateName, templateParameters);
        }
        
        public System.Threading.Tasks.Task<string> SendTemplateMailV2Async(Mailer.Mail mail, string templateName, Mailer.TemplateParameter[] templateParameters, string language)
        {
            return base.Channel.SendTemplateMailV2Async(mail, templateName, templateParameters, language);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMailer))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IMailer))
            {
                return new System.ServiceModel.EndpointAddress("http://mailer2.travelplace.ch/Mailer.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return MailerClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IMailer);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return MailerClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IMailer);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IMailer,
        }
    }
}
