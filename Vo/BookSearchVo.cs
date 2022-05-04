using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moyu.Vo
{
    public class BookSearchVo
    {
        //书名
        public string BookName { get; set; }
        //书地址
        public string BookUrl { get; set; }
        //最新章名
        public string BookNewSetionName { get; set; }
        //最新章地址
        public string BookNewSetionUrl { get; set; }
        //作者
        public string author { get; set; }
        //最新日期
        public string BookNewdate { get; set; }
        //所有章节
        public List<string> BookSetionList = new List<string>();

    }
}
