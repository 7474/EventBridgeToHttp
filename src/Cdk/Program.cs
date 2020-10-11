using Amazon.CDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdk
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var config = System.Environment.GetEnvironmentVariable("CONFIG");
            var props = JsonConvert.DeserializeObject<EventBridgeToHttpProps>(config);

            var app = new App();
            new EventBridgeToHttpStack(app, props.StackName ?? "EventBridgeToHttpStack", props);
            app.Synth();
        }
    }
}
