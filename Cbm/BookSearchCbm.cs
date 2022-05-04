using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using moyu.Vo;

namespace moyu.Cbm
{
    public class BookSearchCbm
    {
        public List<BookSearchVo> GetAll(string url, string keyword)
        {
            StartRequestText sR = new StartRequestText();
            string res = "";
            sR.RequestMessage(url + "\"" + keyword + "\"", out res);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(res);
            HtmlNode node = doc.DocumentNode;
            HtmlNodeCollection tr = node.SelectNodes("//table[@class='grid']/tr");
            tr.Remove(0);


            List<BookSearchVo> bookSearchVoList = new List<BookSearchVo>();
            foreach (var item in tr)
            {
                HtmlNode[] td = item.ChildNodes.Where(x => x.Name == "td").ToArray();
                HtmlNode td1a = td[0].FirstChild;
                HtmlNode td2a = td[1].FirstChild;
                HtmlNode td3 = td[2];
                HtmlNode td4 = td[3];
                BookSearchVo temp = new BookSearchVo();
                temp.BookUrl = td1a.Attributes?["href"]?.Value;
                temp.BookName = td1a.InnerHtml;
                temp.BookNewSetionUrl = td2a.Attributes?["href"]?.Value;
                temp.BookNewSetionName = td2a.InnerHtml;
                temp.author = td3.InnerHtml;
                temp.BookNewdate = td4.InnerHtml;
                bookSearchVoList.Add(temp);
            }
            return bookSearchVoList;
        }
    }
}
