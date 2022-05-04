using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using moyu.Vo;

namespace moyu.Cbm
{
    public class BookSetionSearchTextCbm
    {
        public BookSetionSearchTextVo GetAll(string url)
        {
            BookSetionSearchTextVo OutVo = new BookSetionSearchTextVo();
            string text = "";
            StartRequestText sR = new StartRequestText();
            string res = "";
            sR.RequestMessage(url, out res);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(res);
            HtmlNode node = doc.DocumentNode;
            HtmlNode dd = node.SelectNodes("//div[@id='content']")[0];
            HtmlNode h1 = node.SelectNodes("//h1")[0];
            var a = node.SelectNodes("//div[@class='bottem1']//a").Where(x => x.InnerHtml == "上一章" || x.InnerHtml == "下一章").ToList();
            string prev = a?[0].Attributes?["href"]?.Value;
            string next = a?[1].Attributes?["href"]?.Value;

            dd.RemoveChild(dd.LastChild);
            text = dd.InnerHtml;
            text = text.Replace("&nbsp;", "");
            text = text.Replace("<br><br>", "");
            text = h1.InnerHtml + "\r<br>\r<br>" + text;
            OutVo.BookContent = Regex.Split(text, "\r<br>\r<br>", RegexOptions.IgnoreCase);
            OutVo.PrevUrl = prev;
            OutVo.NextUrl = next;
            OutVo.BookSetionName = h1.InnerHtml;

            return OutVo;
        }
    }
}
