using JX3API.NET;
using System.Net.WebSockets;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class WebSocketClient
{
    private ClientWebSocket webSocket;                // WebSocket客户端
    private CancellationTokenSource cancellationTokenSource;    // 用于取消操作的标记源
    private bool isRunning;                           // WebSocket连接是否正在运行

    public WebSocketClient()
    {
        webSocket = new ClientWebSocket();           // 创建WebSocket客户端实例
        cancellationTokenSource = new CancellationTokenSource();   // 创建用于取消操作的标记源
        isRunning = false;                           // 初始化连接状态为未运行
    }

    public WebSocketState State
    {
        get { return webSocket.State; }
    }

    /// <summary>
    /// 连接到WebSocket服务器
    /// </summary>
    /// <param name="url">WebSocket服务器的URL</param>
    public async Task Connect()
    {
        if (isRunning)
        {
            // 如果已经处于运行状态，则先断开连接
            await Disconnect();
        }

        isRunning = true; // 设置连接状态为正在运行

        while (isRunning)
        {
            try
            {
                if (webSocket.State == WebSocketState.Open)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "关闭一个WebSocket连接", CancellationToken.None); // 关闭现有的 WebSocket 连接
                }

                webSocket = new ClientWebSocket(); // 创建新的 WebSocket 客户端实例

                // 设置请求头部
                webSocket.Options.SetRequestHeader("token", Jx3Api.Jx3ApiWssToken);
                await webSocket.ConnectAsync(new Uri(Jx3Api.Jx3ApiWsUrl), cancellationTokenSource.Token); // 使用URL连接到WebSocket服务器
                Console.WriteLine("[INFO] [WebSocket] 建立连接成功....");
                await StartReceiving(); // 开始接收消息
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] [WebSocket] 连接已断开....");
            }
            // 等待一段时间后进行重连
            await Task.Delay(3000);
        }
    }


    /// <summary>
    /// 断开与WebSocket服务器的连接
    /// </summary>
    public async Task Disconnect()
    {
        isRunning = false;                           // 设置连接状态为停止运行
        cancellationTokenSource.Cancel();            // 取消操作
    }

    /// <summary>
    /// 发送消息到WebSocket服务器
    /// </summary>
    /// <param name="message">要发送的消息</param>
    public async Task Send(int action)
    {
        // 创建一个示例对象
        var person = new { action };

        // 将对象序列化为 JSON 字符串
        string jsonString = JsonConvert.SerializeObject(person, Newtonsoft.Json.Formatting.Indented);


        if (webSocket.State != WebSocketState.Open)
        {
            Console.WriteLine("[ERROR] [WebSocket] 连接已断开....");
            return;
        }

        byte[] buffer = Encoding.UTF8.GetBytes(jsonString);
        await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }


    /// <summary>
    /// 开始接收WebSocket服务器发送的消息
    /// </summary>
    private async Task StartReceiving()
    {
        while (isRunning)
        {
            WebSocketReceiveResult result;
            byte[] buffer = new byte[1024];

            try
            {
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationTokenSource.Token); // 接收消息

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    // 在这里处理接收到的消息，可以将其传递给其他函数进行进一步处理
                    JObject data = common.Jobject(receivedMessage);
                    JX3APISocket.OnWebSocketMessageReceived(data);
                }
            }
            catch (WebSocketException ex)
            {
                // WebSocket连接发生错误，跳出循环等待重连
                Console.WriteLine("[ERROR] [WebSocket] 连接已断开,正在重连....");
                break;
            }

            // 如果连接状态为正在运行，并且WebSocket状态为 Closed 或 CloseReceived，则发起重连
            if (isRunning && (webSocket.State == WebSocketState.Closed || webSocket.State == WebSocketState.CloseReceived))
            {
                Console.WriteLine("[ERROR] [WebSocket] 连接已断开,正在重连....");
                await Connect();
                break; // 在进行重连后跳出循环，避免无限重连
            }
        }

    }


}
