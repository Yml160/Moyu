using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moyu.Vo
{
    public class BookSetionSearchTextVo
    {
        //章名
        public string BookSetionName { get; set; }
        //章内容
        public string[] BookContent { get; set; }
        //上一章地址
        public string PrevUrl { get; set; }
        //下一章地址
        public string NextUrl { get; set; }

    }
}
