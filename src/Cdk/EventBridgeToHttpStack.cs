using Amazon.CDK;
using Amazon.CDK.AWS.Events;
using Amazon.CDK.AWS.Events.Targets;
using Amazon.CDK.AWS.Lambda;
using System.Collections.Generic;

namespace Cdk
{
    public class EventBridgeToHttpStack : Stack
    {
        internal EventBridgeToHttpStack(Construct scope, string id, EventBridgeToHttpProps props = null) : base(scope, id, props)
        {
            var bridgeFunction = new Function(this, "EventBridgeToHttpFunction", new FunctionProps()
            {
                Runtime = Runtime.PYTHON_3_7,
                Code = Code.FromAsset("handlers"),
                Handler = "EventBridgeToHttp.handler",
                Environment = new Dictionary<string, string>()
                {
                    ["WEBHOOK_URL"] = props.WebhookUrl,
                },
            });

            var eventBus = new EventBus(this, "EventBridgeToHttpBus", new EventBusProps()
            {
                EventSourceName = props.EventSourceName,
            });

            var eventRule = new Rule(this, "EventBridgeToHttpRule", new RuleProps()
            {
                EventBus = eventBus,
                EventPattern = new EventPattern()
                {
                    Account = new string[]{
                        this.Account,
                    },
                },
                Targets = new IRuleTarget[] {
                    new LambdaFunction(bridgeFunction),
                },
            });
        }
    }
}
