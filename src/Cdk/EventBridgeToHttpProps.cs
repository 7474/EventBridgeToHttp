using Amazon.CDK;

namespace Cdk
{
    public class EventBridgeToHttpProps : StackProps
    {
        public string EventSourceName { get; set; }
        public string WebhookUrl { get; set; }
    }
}
