using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using moyu.Vo;

namespace moyu.Cbm
{
    public class BookSetionSearchCbm
    {
        public List<BookSetionSearchVo> GetAll(string url)
        {
            StartRequestText sR = new StartRequestText();
            string res = "";
            sR.RequestMessage(url, out res);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(res);
            HtmlNode node = doc.DocumentNode;
            HtmlNodeCollection dd = node.SelectNodes("//div[@id='list']/dl[1]/dd");

            List<BookSetionSearchVo> bookSetionSearchVo = new List<BookSetionSearchVo>();
            foreach (var item in dd)
            {
                HtmlNode a = item.FirstChild;

                BookSetionSearchVo temp = new BookSetionSearchVo();
                temp.BookSetionUrl = a.Attributes?["href"]?.Value;
                temp.BookSetionName = a.InnerHtml;
                bookSetionSearchVo.Add(temp);
            }
            return bookSetionSearchVo;
        }
    }
}
