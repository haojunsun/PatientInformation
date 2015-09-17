using PatientInformation.Core.Models;
using PatientInformation.Core.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PatientInformation.Core.Models;
using PagedList;

namespace PatientInformation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        //首页
        public ActionResult Index()
        {
            ViewBag.lunbotu = _articleService.List().Where(x => x.ColumnTags == "轮播图").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            ViewBag.tzgonggao = _articleService.List().Where(x => x.ColumnTags == "通知公告").OrderByDescending(x => x.CreatedUtc).Take(8).ToList();
            ViewBag.zxlingdao = _articleService.List().Where(x => x.ColumnTags == "领导简介").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            ViewBag.jgshezhi = _articleService.List().Where(x => x.ColumnTags == "机构设置").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            ViewBag.zxtongxun = _articleService.List().Where(x => x.ColumnTags == "中心快讯").OrderByDescending(x => x.CreatedUtc).Take(8).ToList();
            ViewBag.xwbolan = _articleService.List().Where(x => x.ColumnTags == "新闻博览").OrderByDescending(x => x.CreatedUtc).Take(8).ToList();
            ViewBag.yqlianjie = _articleService.List().Where(x => x.ColumnTags == "友情连接").OrderByDescending(x => x.CreatedUtc).Take(4).ToList();
            ViewBag.zyxz = _articleService.List().Where(x => x.ColumnTags == "下载中心").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            return View();
        }

        //单位概括----------------start
        //单位简介
        public ActionResult Dwjj()
        {
            ViewBag.dwjj = _articleService.List().Where(x => x.ColumnTags == "单位简介").FirstOrDefault();
            return View();
        }
        //领导简介
        public ActionResult Ldjj(string channelTag = "单位概况", string columnTag = "领导简介", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //机构设置
        public ActionResult Jgsz(string channelTag = "单位概况", string columnTag = "机构设置", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //特约研究员
        public ActionResult Tyyjy(string channelTag = "单位概况", string columnTag = "特约研究员", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //研究中心
        public ActionResult Yjzx(string channelTag = "单位概况", string columnTag = "研究中心", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //单位概括----------------end

        //详情页
        public ActionResult Detail(int? id = -1)
        {
            if (id == -1)
            {
                ViewBag.Detail = null;
            }
            else
            {
                ViewBag.Detail = _articleService.List().Where(x => x.ArticleId == id).FirstOrDefault();
            }
            ViewBag.Newlist = _articleService.List().Where(x => x.ColumnTags != "下载中心").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            return View();
        }

        //科研规划---------------start
        //科研动态
        public ActionResult Kykydt(string channelTag = "科研规划", string columnTag = "科研动态", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //科研项目
        public ActionResult Kykexm(string channelTag = "科研规划", string columnTag = "科研项目", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //全国艺术科研规划
        public ActionResult Kyqggh(string channelTag = "科研规划", string columnTag = "全国艺术科研规划", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //全国文化艺术资源标准化技术委员会
        public ActionResult Kyqgwyh(string channelTag = "科研规划", string columnTag = "全国文化艺术资源标准化技术委员会", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //科研规划---------------end

        //重大工程--------------start
        //中国民族民间文艺集成志书
        public ActionResult Gczgmzmj(string channelTag = "重大工程", string columnTag = "中国民族民间文艺集成志书", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //中国节日志
        public ActionResult Gcjrz(string channelTag = "重大工程", string columnTag = "中国节日志", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //中国史诗百部
        public ActionResult Gcssbb(string channelTag = "重大工程", string columnTag = "中国史诗百部", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //集成志书港澳台
        public ActionResult Gcgat(string channelTag = "重大工程", string columnTag = "集成志书港澳台", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //其他
        public ActionResult Gcqt(string channelTag = "重大工程", string columnTag = "重大工程其他", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //重大工程--------------end

        //文化科技-------------start
        //重点实验
        public ActionResult Whzdsy(string channelTag = "文化科技", string columnTag = "重点实验室", int tagtype = 1, int page = 1, int size = 20)
        {
            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //资源建设
        public ActionResult Whzyjs(string channelTag = "文化科技", string columnTag = "数据库", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //文化科技-------------end

        //文化交流------------start
        //展览展演
        public ActionResult Whjlzlby(string channelTag = "文化交流", string columnTag = "展览展演", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //大赛
        public ActionResult Whjlds(string channelTag = "文化交流", string columnTag = "大赛", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //其他
        public ActionResult Whjlqt(string channelTag = "文化交流", string columnTag = "其他", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //文化交流------------end

        //专项管理-----------start
        //艺术学工作
        public ActionResult Zxysx(string channelTag = "专项管理", string columnTag = "艺术学工作", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //节庆管理
        public ActionResult Zxjqgl(string channelTag = "专项管理", string columnTag = "节庆管理", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }

        //标准化管理
        public ActionResult Zxbzh(string channelTag = "专项管理", string columnTag = "标准化建设", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //专项管理-----------end

        //下载中心
        public ActionResult Xzzx(string channelTag = "首页", string columnTag = "下载中心", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            return View(personsAsIPagedList);
        }
        //中心快讯
        public ActionResult Zxkx(string channelTag = "首页", string columnTag = "中心快讯", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            ViewBag.Newlist = _articleService.List().Where(x => x.ColumnTags == "中心快讯").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            return View(personsAsIPagedList);
        }
        //新闻博览
        public ActionResult Xwbl(string channelTag = "首页", string columnTag = "新闻博览", int tagtype = 1, int page = 1, int size = 20)
        {
            ViewBag.columnTag = columnTag;

            var pageIndex = page;
            var pageSize = size;
            var totalCount = 0;

            var list = new List<Article>();
            ViewBag.channelTag = channelTag;
            ViewBag.columnTag = columnTag;
            ViewBag.tagtype = tagtype;
            list = tagtype == 0 ? _articleService.GetByChannelTag(channelTag, pageIndex, pageSize, ref totalCount).ToList() : _articleService.GetByColumnTag(columnTag, pageIndex, pageSize, ref totalCount).ToList();
            var personsAsIPagedList = new StaticPagedList<Article>(list, pageIndex, pageSize, totalCount);
            ViewBag.Newlist = _articleService.List().Where(x => x.ColumnTags == "新闻博览").OrderByDescending(x => x.CreatedUtc).Take(5).ToList();
            return View(personsAsIPagedList);
        }
    }
}