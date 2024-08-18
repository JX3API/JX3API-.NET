using JX3API.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JX3API
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void load()
        {
            Jx3Api.Jx3ApiUrl = "https://www.jx3api.com";
            Jx3Api.Jx3ApiWsUrl = "wss://socket.nicemoe.cn";
            Jx3Api.Jx3ApiTokenV1 = "";  // Configure the tokenV1 of the jx3 API 
            Jx3Api.Jx3ApiTokenV2 = "";  // Configure the tokenV2 of the jx3 API 
            Jx3Api.Jx3ApiTicket = ""; // Configure tuilan ticket
            Jx3Api.Jx3ApiWssToken = ""; // Configure the wsstoken of the jx3 API 
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var data = await Jx3Api.ActiveCalendar();
            Console.WriteLine(data);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            WssReception WssReception = new WssReception(); // Create an instance that receives WSS returns
            JX3APISocket.JX3APIConnect(); // connect
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JX3APISocket.webSocketClient.Send(1001); // 订阅奇遇报时

        }
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
}
