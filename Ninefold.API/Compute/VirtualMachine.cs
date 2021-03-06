﻿using System;
using Ninefold.API.Compute.Commands;
using Ninefold.API.Compute.Messages;
using Ninefold.API.Core;
using RestSharp;

namespace Ninefold.API.Compute
{
    public class VirtualMachine : IVirtualMachine
    {
        readonly string _apiKey;
        readonly string _base64Secret;
        readonly string _serviceUrlRoot;
        readonly IComputeRequestBuilder _computeRequestBuilder;
        readonly ICommandAuthenticator _requestSigner;
        readonly IRestClient _client;

        public IComputeRequestBuilder ComputeRequestBuilder { get { return _computeRequestBuilder; } }
        public ICommandAuthenticator Authenticator { get { return _requestSigner; } }
        public IRestClient RestClient { get { return _client; } }
        
        public VirtualMachine(string apiKey, string base64Secret, string serviceUrlRoot)
        {
            _apiKey = apiKey;
            _serviceUrlRoot = serviceUrlRoot;
            _base64Secret = base64Secret;
            _client = new RestClient(serviceUrlRoot);
            _computeRequestBuilder = new ComputeRequestBuilder();
            _requestSigner = new ComputeRequestAuthenticator();
        }

        public MachineResponse Deploy(DeployVirtualMachineRequest parameters)
        {
            var command = new DeployVirtualMachine(_apiKey, _base64Secret,_requestSigner, _computeRequestBuilder, _client);
            command.Parameters = parameters;
            //return (MachineResponse) command.Execute();

            throw new NotImplementedException("Not yet implemented");
        }

        public MachineResponse Start(StartVirtualMachineRequest parameters)
        {
            var command = new StartVirtualMachine(_apiKey, _base64Secret, _serviceUrlRoot, _requestSigner, _computeRequestBuilder);
            command.Parameters = parameters;
            //return (MachineResponse) command.Execute();

            throw new NotImplementedException("Not yet implemented");
        }

        public MachineResponse Stop()
        {
            throw new NotImplementedException();
        }
    }
}
