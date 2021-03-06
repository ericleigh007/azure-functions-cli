﻿using System;
using System.Threading.Tasks;
using Azure.Functions.Cli.Arm;

namespace Azure.Functions.Cli.Actions.AzureActions
{
    [Action(Name = "enable-git-repo", Context = Context.Azure, SubContext = Context.FunctionApp, HelpText = "Enable git repository on your Azure-hosted Function App")]
    internal class EnableGitRepoAction : BaseFunctionAppAction
    {
        private readonly IArmManager _armManager;

        public EnableGitRepoAction(IArmManager armManager)
        {
            _armManager = armManager;
        }

        public override async Task RunAsync()
        {
            var functionApp = await _armManager.GetFunctionAppAsync(FunctionAppName);
            await _armManager.EnsureScmTypeAsync(functionApp);
        }
    }
}
