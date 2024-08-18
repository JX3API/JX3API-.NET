using Newtonsoft.Json.Linq;

namespace JX3API.NET
{
    public class Jx3Api
    {

        /// <summary>
        /// jx3api请求连接
        /// </summary>
        public static string Jx3ApiUrl = "https://www.jx3api.com";
        /// <summary>
        /// jx3apiws连接
        /// </summary>
        public static string Jx3ApiWsUrl = "wss://socket.nicemoe.cn";
        /// <summary>
        /// jx3api token  购买：https://store.nicemoe.cn
        /// </summary>
        /// 
        public static string Jx3ApiTokenV1 { get; set; }

        /// <summary>
        /// jx3api tokenV2
        /// </summary>
        public static string Jx3ApiTokenV2 { get; set; }
        public static string Jx3ApiWssToken { get; set; }
        /// <summary>
        /// 推栏ticket
        /// </summary>
        public static string Jx3ApiTicket { get; set; }

        /// <summary>
        /// 游戏区服
        /// </summary>
        public string Server { get; set; }


        //FREE API
        #region FREE API 免费api
        /// <summary>
        /// 活动日历
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="num"> 指定日期，查询指定日期的日常，默认值 : 0 为当天，1 为明天，以此类推 </param>

        /// <returns>
        ///  今天、明天、后天、日常任务。
        ///  只有 星期三、星期五、星期六、星期日 才有美人画图，星期三、星期五 才有世界首领，若非活动时间不返回相关键对值。
        /// </returns>
        public static async Task<JObject> ActiveCalendar(string server = null, int? num = null)
        {

            var query = new
            {
                server,
                num,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/active/calendar", query);
            Console.WriteLine("321");
            return data;
        }

        /// <summary>
        /// 活动月历
        /// </summary>
        /// <param name="num">预测时间，查询指定时间内的月历，默认值 : ``15`` 为前后15天的月历"</param>
        /// <returns> 预测每天的日常任务 </returns>
        public static async Task<JObject> ActiveListCalendar(int? num = null)
        {
            var query = new
            {
                num,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/view/active/calendar", query);
            return data;
        }

        /// <summary>
        /// 行侠事件
        /// </summary>
        /// <param name="name"> 名称，查询指定事件的记录 </param>
        /// <returns> 当前时间的楚天社/云从社进度 </returns>
        public static async Task<JObject> ActiveCelebs(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/active/celebs", query);
            return data;
        }

        /// <summary>
        /// 科举答题
        /// </summary>
        /// <param name="subject"> 科举试题，支持首字母，支持模糊查询 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 科举答题 </returns>
        public static async Task<JObject> ActiveAnswer(string subject, int? limit = null)
        {
            var query = new
            {
                subject,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/exam/answer", query);
            return data;
        }

        /// <summary>
        /// 家园装饰
        /// </summary>
        /// <param name="name"> 指定装饰，查找该装饰的详细记录 </param>
        /// <returns> 装饰详情 </returns>
        public static async Task<JObject> ActiveFurniture(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/home/furniture", query);
            return data;
        }

        /// <summary>
        /// 器物图谱
        /// </summary>
        /// <param name="name"> 指定地图，查找该地图的装饰产出 </param>
        /// <returns> 器物谱地图产出装饰 </returns>
        public static async Task<JObject> ActiveTravel(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/home/travel", query);
            return data;
        }

        /// <summary>
        /// 新闻资讯
        /// </summary>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 官方最新公告及新闻 </returns>
        public static async Task<JObject> ActiveAllnews(int? limit = null)
        {
            var query = new
            {
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/news/allnews", query);
            return data;
        }

        /// <summary>
        /// 维护公告
        /// </summary>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 官方最新维护公告 </returns>
        public static async Task<JObject> ActiveAnnounce(int? limit = null)
        {
            var query = new
            {
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/news/announce", query);
            return data;
        }


        /// <summary>
        /// 搜索区服
        /// </summary>
        /// <param name="name"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 简称搜索主次服务器的结果 </returns>
        public static async Task<JObject> ActiveMaster(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/master", query);
            return data;
        }

        /// <summary>
        /// 开服检查
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 服务器当前状态 [已开服/维护中] </returns>
        public static async Task<JObject> ActiveCheck(string server = null)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/check", query);
            return data;
        }

        /// <summary>
        /// 查看状态
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 服务器当前状态 [维护/正常/繁忙/爆满] </returns>
        public static async Task<JObject> ActiveStatus(string server)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/status", query);
            return data;
        }


        /// <summary>
        /// 鲜花价格
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 指定鲜花，查找该鲜花的相关记录 </param>
        /// <param name="map"> 指定地图，查找该地图的相关记录 </param>
        /// <returns> 家园鲜花最高价格线路 </returns>
        public static async Task<JObject> GetFlowerPrice(string server, string name = null, string map = null)
        {
            var query = new
            {
                server,
                name,
                map,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/home/flower", query);
            return data;
        }

        #endregion


        //VIP V1
        #region VIP1 API 需要token

        /// <summary>
        /// 角色更新
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="roleId"> 角色UID，保存该角色的详细记录 </param>
        /// <param name="ticket"> 推栏标识，检查请求权限 </param>
        /// <param name="token"> 站点标识，检查请求权限 </param>
        /// <returns> 自动更新的角色信息 </returns>
        public static async Task<JObject> ActiveDetailed(string server, string roleId, string ticket)
        {
            var query = new
            {
                server,
                roleId,
                ticket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestPost("/data/save/detailed", query);
            return data;
        }


        /// <summary>
        /// 角色信息
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 角色名称，查找目标角色的相关记录 </param>
        /// <param name="ticket"> 推栏标识，检查请求权限 </param>
        /// <param name="token"> 站点标识，检查请求权限 </param>
        /// <returns> 角色详细信息 </returns>
        public static async Task<JObject> Active_Role_Detailed(string server, string name, string ticket)
        {
            var query = new
            {
                server,
                name,
                ticket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/role/detailed", query);
            return data;
        }


        /// <summary>
        /// 阵眼效果
        /// </summary>
        /// <param name="name"> 心法名称，查找该心法的相关记录 </param>
        /// <param name="token"> 站点标识，检查请求权限 </param>
        /// <returns> 职业阵眼效果 </returns>
        public static async Task<JObject> ActiveMatrix(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/school/matrix", query);
            return data;
        }


        /// <summary>
        /// 奇穴效果
        /// </summary>
        /// <param name="name"> 心法名称，查找该心法的相关记录 </param>
        /// <returns> 奇穴详细效果 </returns>
        public static async Task<JObject> ActiveForce(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/school/force", query);
            return data;
        }


        /// <summary>
        /// 技能效果
        /// </summary>
        /// <param name="name"> 心法名称，查找该心法的相关记录 </param>
        /// <returns> 技能详细效果 </returns>
        public static async Task<JObject> ActiveSkills(string name)
        {
            var query = new
            {
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/school/skills", query);
            return data;
        }


        /// <summary>
        /// 八卦帖子
        /// </summary>
        /// <param name="class"> 帖子分类，可选范围：818 616 鬼网三 鬼网3 树洞 记录 教程 街拍 故事 避雷 吐槽 提问 </param>
        /// <param name="server"> 区服名称，查找该区服的相关记录，默认值：- 为全区服 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 随机搜索贴吧 </returns>
        public static async Task<JObject> ActiveRandom(string @class, string server = "-", int? limit = null)
        {
            var query = new
            {
                @class,
                server,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/tieba/random", query);
            return data;
        }


        /// <summary>
        /// 装备属性
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 角色名称，查找该角色的相关记录 </param>
        /// <param name="ticket"> 推栏标识，检查请求权限 </param>
        /// <param name="token"> 站点标识，检查请求权限 </param>
        /// <returns> 角色装备属性详情 </returns>
        public static async Task<JObject> ActiveRoleAttribute(string server, string name)
        {
            var query = new
            {
                server,
                name,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/role/attribute", query);
            return data;
        }


        /// <summary>
        /// 副本记录
        /// </summary>
        /// <param name="server"> 区服名称，查找该区服的记录 </param>
        /// <param name="name"> 角色名称，查找该角色的记录 </param>
        /// <returns> 角色副本记录 </returns>
        public static async Task<JObject> ActiveTeamCdList(string server, string name)
        {
            var query = new
            {
                server,
                name,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/role/teamCdList", query);
            return data;
        }


        /// <summary>
        /// 奇遇记录
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 角色名称，查找该角色的相关记录 </param>
        /// <returns> 角色奇遇触发记录 </returns>
        public static async Task<JObject> ActiveAdventure(string server, string name)
        {
            var query = new
            {
                server,
                name,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/luck/adventure", query);
            return data;
        }



        /// <summary>
        /// 奇遇统计
        /// </summary>
        /// <param name="server"> 区服名称，查找该区服的记录 </param>
        /// <param name="name"> 奇遇名称，查找该奇遇的记录 </param>
        /// <param name="limit"> 单页数量，单页返回的数量，默认值 : 20 </param>
        /// <returns> 奇遇近期触发统计 </returns>
        public static async Task<JObject> ActiveLuckStatistical(string server, string name, int? limit = null)
        {
            var query = new
            {
                server,
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/luck/statistical", query);
            return data;
        }



        /// <summary>
        /// 全服统计
        /// </summary>
        /// <param name="name"> 奇遇名称，查找该奇遇的全服统计 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 全服近期奇遇记录 </returns>
        public static async Task<JObject> ActiveLuckServerStatistical(string name, int? limit = null)
        {
            var query = new
            {
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/luck/server/statistical", query);
            return data;
        }



        /// <summary>
        /// 奇遇汇总
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="num"> 汇总时间，汇总指定天数内的记录，默认值 : 7 </param>
        /// <returns> 统计奇遇近期触发角色记录 </returns>
        public static async Task<JObject> ActiveCollect(string server, int? num = null)
        {
            var query = new
            {
                server,
                num,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/luck/collect", query);
            return data;
        }


        /// <summary>
        /// 成就百科
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="role"> 角色名称，查找该角色的成就记录 </param>
        /// <param name="name"> 成就/系列名称，查询该成就/系列的完成进度 </param>
        /// <returns> 角色成就进度 </returns>
        public static async Task<JObject> ActiveAchievement(string server, string role, string name)
        {
            var query = new
            {
                server,
                role,
                name,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/role/achievement", query);
            return data;
        }



        /// <summary>
        /// 名剑战绩
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 角色名称，查找该角色的相关记录 </param>
        /// <param name="mode"> 比赛模式，查找该模式的相关记录 </param>
        /// <returns> 角色近期战绩记录 </returns>
        public static async Task<JObject> ActiveRecent(string server, string name, int? mode = null)
        {
            var query = new
            {
                server,
                name,
                mode,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/match/recent", query);
            return data;
        }



        /// <summary>
        /// 名剑排行
        /// </summary>
        /// <param name="mode"> 比赛模式，查找该模式的相关记录，默认值 : 33 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 20 </param>
        /// <returns> 角色近期战绩记录 </returns>
        public static async Task<JObject> ActiveAwesome(int? mode = null, int? limit = null)
        {
            var query = new
            {
                mode,
                limit,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/match/awesome", query);
            return data;
        }



        /// <summary>
        /// 名剑统计
        /// </summary>
        /// <param name="mode"> 比赛模式，查找该模式的相关记录，默认值 : 33 </param>
        /// <returns> 角色近期战绩记录 </returns>
        public static async Task<JObject> ActiveSchools(int? mode = null)
        {
            var query = new
            {
                mode,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/match/schools", query);
            return data;
        }



        /// <summary>
        /// 团队招募
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="keyword"> 关键字，模糊匹配记录，用=关键字完全匹配记录 </param>
        /// <param name="table"> 指定表记录，1=本服+跨服，2=本服，3=跨服，默认值：1 </param>
        /// <returns> 团队招募信息 </returns>
        public static async Task<JObject> ActiveRecruit(string server, string keyword = null, int? table = null)
        {
            var query = new
            {
                server,
                keyword,
                table,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/member/recruit", query);
            return data;
        }



        /// <summary>
        /// 师父列表
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="keyword"> 关键字，查找该关键字的相关记录 </param>
        /// <returns> 客户端师徒系统 </returns>
        public static async Task<JObject> ActiveTeacher(string server, string keyword = null)
        {
            var query = new
            {
                server,
                keyword,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/member/teacher", query);
            return data;
        }



        /// <summary>
        /// 徒弟列表
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="keyword"> 关键字，查找该关键字的相关记录 </param>
        /// <returns> 客户端师徒系统 </returns>
        public static async Task<JObject> ActiveStudent(string server, string keyword = null)
        {
            var query = new
            {
                server,
                keyword,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/member/student", query);
            return data;
        }



        /// <summary>
        /// 沙盘信息
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 查看阵营沙盘信息 </returns>
        public static async Task<JObject> ActiveSand(string server)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/sand", query);
            return data;
        }



        /// <summary>
        /// 阵营事件
        /// </summary>
        /// <param name="name"> 阵营名称，查找该阵营的相关记录 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 100 </param>
        /// <returns> 全服阵营大事件 </returns>
        public static async Task<JObject> ActiveEvent(string name = null, int? limit = null)
        {
            var query = new
            {
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/event", query);
            return data;
        }



        /// <summary>
        /// 金币比例
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 金价比例信息 </returns>
        public static async Task<JObject> ActiveDemon(string server = null, int? limit = null)
        {
            var query = new
            {
                server,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/trade/demon", query);
            return data;
        }



        /// <summary>
        /// 物品价格
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 外观名称，查找该外观的记录 </param>
        /// <returns> 黑市物品价格统计 </returns>
        public static async Task<JObject> ActiveTradeRecord(string name, string server = null)
        {
            var query = new
            {
                server,
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/trade/record", query);
            return data;
        }



        /// <summary>
        /// 贴吧记录
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 物品名称，查找该物品的相关记录 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 来自贴吧的外观记录 </returns>
        public static async Task<JObject> ActiveTiebaItemRecord(string name, string server = null, int? limit = null)
        {
            var query = new
            {
                server,
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/tieba/item/record", query);
            return data;
        }



        /// <summary>
        /// 掉落统计
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 物品名称，查找该物品的相关记录 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 20 </param>
        /// <returns> 统计副本掉落的贵重物品 </returns>
        public static async Task<JObject> ActiveStatistical(string server, string name, int? limit = null)
        {
            var query = new
            {
                server,
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/valuables/statistical", query);
            return data;
        }



        /// <summary>
        /// 全服掉落
        /// </summary>
        /// <param name="name"> 物品名称，查找该物品的相关记录 </param>
        /// <param name="limit"> 限制查询结果的数量，默认值 10 </param>
        /// <returns> 统计当前赛季副本掉落的特殊物品 </returns>
        public static async Task<JObject> ActiveStatistical(string name, int? limit = null)
        {
            var query = new
            {
                name,
                limit,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/valuables/server/statistical", query);
            return data;
        }



        /// <summary>
        /// 诛恶事件
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 诛恶事件历史记录 </returns>
        public static async Task<JObject> ActiveAntivice(string server = null)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/server/antivice", query);
            return data;
        }



        /// <summary>
        /// 风云榜单
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="table"> [table] [name] 榜单类型与榜单名称，[table] 与 [name] 的关联 </param>
        /// <param name="name"> [table] [name] 榜单类型与榜单名称，[table] 与 [name] 的关联 </param>
        /// 
        /// [table] : 个人，[name] : [名士五十强 老江湖五十强 兵甲藏家五十强 名师五十强 阵营英雄五十强 薪火相传五十强 庐园广记一百强]；
        /// [table] : 帮会，[name] : [浩气神兵宝甲五十强 恶人神兵宝甲五十强 浩气爱心帮会五十强 恶人爱心帮会五十强]；
        /// [table] : 阵营，[name] : [赛季恶人五十强 赛季浩气五十强 上周恶人五十强 上周浩气五十强 本周恶人五十强 本周浩气五十强]；
        /// [table] : 试炼，[name] : [万花 七秀 少林 纯阳 天策 五毒 唐门 明教 苍云 长歌 藏剑 丐帮 霸刀 蓬莱 凌雪 衍天 药宗 刀宗]；
        /// 
        /// <returns> 客户端战功榜与风云录 </returns>
        public static async Task<JObject> ActiveStatistical(string server, string table, string name)
        {
            var query = new
            {
                server,
                table,
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/rank/statistical", query);
            return data;
        }



        /// <summary>
        /// 全服榜单
        /// </summary>
        /// <param name="table"> [table] [name] 榜单类型与榜单名称，[table] 与 [name] 的关联 </param>
        /// <param name="name"> [table] [name] 榜单类型与榜单名称，[table] 与 [name] 的关联 </param>
        /// 
        /// [table] : 个人，[name] : [名士五十强 老江湖五十强 兵甲藏家五十强 名师五十强 阵营英雄五十强 薪火相传五十强 庐园广记一百强]；
        /// [table] : 帮会，[name] : [浩气神兵宝甲五十强 恶人神兵宝甲五十强 浩气爱心帮会五十强 恶人爱心帮会五十强]；
        /// [table] : 阵营，[name] : [赛季恶人五十强 赛季浩气五十强 上周恶人五十强 上周浩气五十强 本周恶人五十强 本周浩气五十强]；
        /// [table] : 试炼，[name] : [万花 七秀 少林 纯阳 天策 五毒 唐门 明教 苍云 长歌 藏剑 丐帮 霸刀 蓬莱 凌雪 衍天 药宗 刀宗]；
        /// 
        /// <returns> 客户端战功榜与风云录 </returns>
        public static async Task<JObject> ActiveRankServerStatistical(string table, string name)
        {
            var query = new
            {
                table,
                name,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/rank/server/statistical", query);
            return data;
        }



        /// <summary>
        /// 资历榜单
        /// </summary>
        /// <param name="school"> 门派简称，默认值 : ALL </param>
        /// <param name="server"> 指定区服，默认值 : ALL </param>
        /// <returns> 游戏资历榜单 </returns>
        public static async Task<JObject> ActiveSchoolRankStatistical(string school = null, string server = null)
        {
            var query = new
            {
                school,
                server,
                ticket = Jx3ApiTicket,
                token = Jx3ApiTokenV1
            };
            var data = await common.RequestGet("/data/school/rank/statistical", query);
            return data;
        }

        #endregion


        //VIP V2
        #region VIP2 API 需要token

        /// <summary>
        /// 百战首领
        /// </summary>
        /// <returns> 本周百战异闻录刷新的首领以及特殊效果 </returns>
        public static async Task<JObject> ActiveMonster()
        {
            var query = new
            {
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/active/monster", query);
            return data;
        }

        /// <summary>
        /// 的卢统计
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 客户端的卢刷新记录 </returns>
        public static async Task<JObject> ActiveHorseRecord(string server = null)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/horse/record", query);
            return data;
        }


        /// <summary>
        /// 马场事件
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <returns> 客户端马场刷新记录 </returns>
        public static async Task<JObject> ActiveHorseRanch(string server)
        {
            var query = new
            {
                server,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/horse/ranch", query);
            return data;
        }


        /// <summary>
        /// 烟花记录
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 角色名称，查找该角色的相关记录 </param>
        /// <returns> 烟花赠送与接收的历史记录 </returns>
        public static async Task<JObject> ActiveFireworkRecord(string server, string name)
        {
            var query = new
            {
                server,
                name,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/firework/record", query);
            return data;
        }


        /// <summary>
        /// 烟花统计
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="name"> 烟花名称，查找该烟花的相关统计 </param>
        /// <param name="limit"> 单页数量，设置返回的数量，默认值 : 20 </param>
        /// <returns> 烟花统计信息 </returns>
        public static async Task<JObject> ActiveFireworkStatistical(string server, string name, int? limit = null)
        {
            var query = new
            {
                server,
                name,
                limit,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/firework/statistical", query);
            return data;
        }


        /// <summary>
        /// 烟花汇总
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="num"> 统计时间，默认值：7 天 </param>
        /// <returns> 烟花汇总记录 </returns>
        public static async Task<JObject> ActiveFireworkCollect(string server, int? num = 7)
        {
            var query = new
            {
                server,
                num,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/firework/collect", query);
            return data;
        }


        /// <summary>
        /// 烟花排行
        /// </summary>
        /// <param name="server"> 指定区服，查找该区服的相关记录 </param>
        /// <param name="column"> 排行列，[sender recipient name] </param>
        /// <param name="this_time"> 统计开始的时间，与结束的时间不得超过3个月 </param>
        /// <param name="that_time"> 统计结束的时间，与开始的时间不得超过3个月 </param>
        /// <returns> 烟花赠送与接收的榜单 </returns>
        public static async Task<JObject> ActiveFireworkRank(string server, string column, long this_time, long that_time)
        {
            var query = new
            {
                server,
                column,
                this_time,
                that_time,
                token = Jx3ApiTokenV2
            };
            var data = await common.RequestGet("/data/firework/rank/statistical", query);
            return data;
        }

        #endregion

        //VRF API
        #region VRF API 需要token

        /// <summary>
        /// 智障聊天
        /// </summary>
        /// <param name="name"> 机器人的名称 </param>
        /// <param name="text"> 聊天的完整内容 </param>
        /// <returns> 机器人的回复 </returns>
        public static async Task<JObject> ActiveChat(string name, string text)
        {
            var query = new
            {
                name,
                text
            };
            var data = await common.RequestGet("/data/mixed/chat", query);
            return data;
        }


        /// <summary>
        /// 搜索腾讯音乐歌曲编号
        /// </summary>
        /// <param name="name"> 歌曲名称 </param>
        /// <returns> 歌曲编号信息 </returns>
        public static async Task<JObject> ActiveTencentMusic(string name)
        {
            var query = new
            {
                name
            };
            var data = await common.RequestGet("/data/music/tencent", query);
            return data;
        }


        /// <summary>
        /// 搜索网易云音乐歌曲编号
        /// </summary>
        /// <param name="name"> 歌曲名称 </param>
        /// <returns> 歌曲编号信息 </returns>
        public static async Task<JObject> ActiveNeteaseMusic(string name)
        {
            var query = new
            {
                name
            };
            var data = await common.RequestGet("/data/music/netease", query);
            return data;
        }



        /// <summary>
        /// 搜索酷狗音乐歌曲编号
        /// </summary>
        /// <param name="name"> 歌曲名称 </param>
        /// <returns> 歌曲编号信息 </returns>
        public static async Task<JObject> ActiveKugouMusic(string name)
        {
            var query = new
            {
                name
            };
            var data = await common.RequestGet("/data/music/kugou", query);
            return data;
        }



        /// <summary>
        /// 搜索贴吧的行骗记录
        /// </summary>
        /// <param name="uid"> 用户QQ号 </param>
        /// <returns> 行骗记录信息 </returns>
        public static async Task<JObject> ActiveFraudDetailed(long uid)
        {
            var query = new
            {
                uid,
            };
            var data = await common.RequestGet("/data/fraud/detailed", query);
            return data;
        }



        /// <summary>
        /// 校对成语并返回相关成语
        /// </summary>
        /// <param name="name"> 查找对应词语 </param>
        /// <returns> 成语接龙的相关信息 </returns>
        public static async Task<JObject> ActiveIdiomSolitaire(string name)
        {
            var query = new
            {
                name
            };
            var data = await common.RequestGet("/data/idiom/solitaire", query);
            return data;
        }



        /// <summary>
        /// 获取万花门派的骚话
        /// </summary>
        /// <returns> 撩人骚话 </returns>
        public static async Task<JObject> ActiveSaohuaRandom()
        {
            var data = await common.RequestGet("/data/saohua/random");
            return data;
        }



        /// <summary>
        /// 获取一条舔狗日记
        /// </summary>
        /// <returns> 舔狗日记 </returns>
        public static async Task<JObject> ActiveSaohuaContent()
        {
            var data = await common.RequestGet("/data/saohua/content");
            return data;
        }



        /// <summary>
        /// 阿里云语音合成（TTS）
        /// </summary>
        /// <param name="appkey">阿里云应用的 appkey</param>
        /// <param name="access">阿里云的 access 密钥</param>
        /// <param name="secret">阿里云的 secret 密钥</param>
        /// <param name="text">合成的内容</param>
        /// <param name="voice">发音人，默认值 [Aitong]</param>
        /// <param name="format">编码格式，范围 [PCM][WAV][MP3]，默认值 [MP3]</param>
        /// <param name="sample_rate">采样率，默认值 [16000]</param>
        /// <param name="volume">音量，范围 [0～100]，默认值 [50]</param>
        /// <param name="speech_rate">语速，范围 [-500～500]，默认值 [0]</param>
        /// <param name="pitch_rate">音调，范围 [-500～500]，默认值 [0]</param>
        /// <returns>语音合成结果</returns>
        public static async Task<JObject> ActiveSoundConverter(
            string appkey,
            string access,
            string secret,
            string text,
            string voice = "Aitong",
            string format = "mp3",
            int sample_rate = 16000,
            int volume = 50,
            int speech_rate = 0,
            int pitch_rate = 0)
        {
            var query = new
            {
                appkey,
                access,
                secret,
                text,
                voice,
                format,
                sample_rate,
                volume,
                speech_rate,
                pitch_rate
            };
            var data = await common.RequestPost("/data/sound/converter", query);
            return data;
        }

        #endregion


        //wws
        #region wws


        #endregion

    }


    public class JX3APISocket
    {
        //public JX3APISocket()
        //{
        //    common._WebSocketMessageReceived += async (data) =>
        //    {
        //        Console.WriteLine(data);
        //        int action = (int)data["action"];
        //        switch (action)
        //        {
        //            //奇遇报时
        //            case 1001:
        //                break;
        //            //抓马报时
        //            case 1002:

        //                break;
        //            //扶摇报时
        //            case 1004:

        //                break;
        //            //玄晶报时
        //            case 1007:

        //                break;
        //            //追魂点名
        //            case 1008:

        //                break;
        //            //诛恶事件
        //            case 1009:

        //                break;
        //            //的卢报时
        //            case 1010:

        //                break;
        //            //前线战况
        //            case 1101:

        //                break;
        //            //开服监控
        //            case 2001:

        //                break;
        //            //新闻资讯
        //            case 2002:

        //                break;
        //            //游戏更新
        //            case 2003:

        //                break;
        //            //八卦速报
        //            case 2004:

        //                break;
        //            //关隘预告
        //            case 2005:

        //                break;
        //            //云从预告
        //            case 2006:

        //                break;


        //            default:
        //                break;
        //        }

        //    };

        //}

        /// <summary>
        /// 用于监控接受websocket消息
        /// </summary>
        public static event Action<JObject> _WebSocketMessageReceived;

        /// <summary>
        /// WebSocketClient作为成员变量
        /// </summary>
        public static WebSocketClient webSocketClient;

        /// <summary>
        /// 用于传递
        /// </summary>
        /// <param name="message"></param>
        public static void OnWebSocketMessageReceived(JObject message)
        {
            _WebSocketMessageReceived?.Invoke(message);
        }


        public static async void JX3APIConnect()
        {

            // 创建 WebSocketClient 实例
            webSocketClient = new WebSocketClient();
            try
            {
                // 连接到 WebSocket 服务器
                await webSocketClient.Connect();
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务器链接失败请检查网络状况: " + ex.Message);
            }
        }
    }
}
