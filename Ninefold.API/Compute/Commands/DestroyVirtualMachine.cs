﻿using System;
using System.Net;
using Ninefold.API.Compute.Messages;
using Ninefold.API.Core;
using RestSharp;

namespace Ninefold.API.Compute.Commands
{
    public class DestroyVirtualMachine : ICommand
    {
        readonly ICommandAuthenticator _authenticator;
        readonly IRestClient _client;
        readonly IComputeRequestBuilder _computeRequestService;
        readonly string _apiKey;
        readonly string _base64Secret;

        public string MachineId { get; set; }

        public DestroyVirtualMachine(string apiKey, 
                                                        string base64Secret,
                                                        ICommandAuthenticator authenticator, 
                                                        IComputeRequestBuilder computeRequestService, 
                                                        IRestClient client)
        {
            _authenticator = authenticator;
            _client = client;
            _computeRequestService = computeRequestService;
            _apiKey = apiKey;
            _base64Secret = base64Secret;
        }

        public ICommandResponse ParseResponse(WebResponse response)
        {
            var request = _computeRequestService.GenerateRequest(null, _apiKey);
            _authenticator.AuthenticateRequest(WebRequest.Create(""), _base64Secret);//((RestClient)_client).BuildUri((RestRequest)request), _base64Secret);
            
            return _client.Execute<MachineResponse>((RestRequest)request).Data;
        }

        public HttpWebRequest Prepare()
        {
            return null;
        }
    }
}
