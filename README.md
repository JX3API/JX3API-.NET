> [!CAUTION]
> Only C# .net 6.0 or later versions are supported
# JX3API.NET
The C#.net6.0+ SDK to the JX3API.
# Installation
## From .NET CLI
```
dotnet add package JX3API --version 1.0.1
```
## From Package Manager
```
dotnet add package JX3API --version 1.0.1
```
## Quick installation

nuget searches for the JX3API

## Quick Start
> And don't copy it exactly the same
![DS~5$(H Y@~H~)3(Y(A5Y47](https://github.com/user-attachments/assets/59e85926-7f1a-484e-964d-bf145bbd879a)

```C#
using JX3API.NET;

// Configure basic authentication
private void config()
{
    Jx3Api.Jx3ApiUrl = "https://www.jx3api.com";
    Jx3Api.Jx3ApiWsUrl = "wss://socket.nicemoe.cn";
    Jx3Api.Jx3ApiTokenV1 = "";  // Configure the tokenV1 of the jx3 API 
    Jx3Api.Jx3ApiTokenV2 = "";  // Configure the tokenV2 of the jx3 API 
    Jx3Api.Jx3ApiTicket = ""; // Configure tuilan ticket
    Jx3Api.Jx3ApiWssToken = ""; // Configure the wsstoken of the jx3 API 
}

// Invoke an API request
private async void Inquire()
{
   JObject data = await Jx3Api.ActiveCalendar(); // Calendar of events
   Console.WriteLine(data); // Print back
}

```
## Wss
```C#
using JX3API.NET;

// Connect to wss
private void WssConnect()
{
   WssReception WssReception = new WssReception(); // Create an instance that receives WSS returns
   JX3APISocket.JX3APIConnect(); // connect
}

// Create a subscription message
private void WssSend()
{
    JX3APISocket.webSocketClient.Send(1001); // 订阅奇遇报时
}

 // Receive a WSS message
 public class WssReception
 {
     public WssReception()
     {
         JX3APISocket._WebSocketMessageReceived += async (data) =>
         {
             Console.WriteLine(data);
             int action = (int)data["action"];
             switch (action)
             {
                 //奇遇报时
                 case 1001:
                     break;
                 //抓马报时
                 case 1002:

                     break;
                 //扶摇报时
                 case 1004:

                     break;
                 //玄晶报时
                 case 1007:

                     break;
                 //追魂点名
                 case 1008:

                     break;
                 //诛恶事件
                 case 1009:

                     break;
                 //的卢报时
                 case 1010:

                     break;
                 //前线战况
                 case 1101:

                     break;
                 //开服监控
                 case 2001:

                     break;
                 //新闻资讯
                 case 2002:

                     break;
                 //游戏更新
                 case 2003:

                     break;
                 //八卦速报
                 case 2004:

                     break;
                 //关隘预告
                 case 2005:

                     break;
                 //云从预告
                 case 2006:

                     break;

                 default:
                     break;
             }

         };
     }
 }
```

# FYI
