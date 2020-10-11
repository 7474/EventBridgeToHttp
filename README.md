# EventBridgeToHttp

A Lambda function application that bypasses the contents of the [Amazon EventBridge](https://aws.amazon.com/eventbridge/) to a webhook.

## Useful commands

* `dotnet build src` compile this app
* `cdk deploy`       deploy this stack to your default AWS account/region
* `cdk diff`         compare deployed stack with current state
* `cdk synth`        emits the synthesized CloudFormation template

## Configure

Set `CONFIG` environment variable.

Example:
```sh
CONFIG='{"EventSourceName":"<your_event_source_naem>","WebhookUrl":"<your_webhook_url>"}'
```
