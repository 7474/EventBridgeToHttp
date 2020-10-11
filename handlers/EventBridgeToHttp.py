import os
import json
import urllib.request
import urllib.parse


def handler(event, context):
    # 単にペイロードをWebhookにバイパスする。
    url = os.environ['WEBHOOK_URL']
    print('Post to: ' + url)
    print(event)

    data = json.dumps(event).encode('utf-8')
    request = urllib.request.Request(url, data=data, headers={'Content-Type': 'application/json'}, method='POST')
    response = urllib.request.urlopen(request)
    print(response.getcode())
    html = response.read()
    print(html.decode('utf-8'))
