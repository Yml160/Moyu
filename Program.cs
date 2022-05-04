using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;
using moyu.Cbm;
using moyu.Vo;

namespace moyu
{
    public class Program
    {
        private static readonly string URL = Properties.Settings.Default.URL;
        private static readonly string HOST_URL = Properties.Settings.Default.HOST_URL;
        private static readonly BookSearchCbm bookSearchCbm = new BookSearchCbm();
        private static readonly BookSetionSearchCbm bookSetionSearchCbm = new BookSetionSearchCbm();
        private static readonly BookSetionSearchTextCbm bookSetionSearchTextCbm = new BookSetionSearchTextCbm();


        static void Main(string[] args)
        {

            Console.WriteLine("请输入搜索关键词");
            string keyword = Console.ReadLine();
            Console.WriteLine("您搜索的关键词是：" + keyword);
            //获取数据
            List<BookSearchVo> bookSearchVoList = bookSearchCbm.GetAll(URL, keyword);
            //打印数据
            for (int i = 0; i < (bookSearchVoList.Count > 10 ? 10 : bookSearchVoList.Count); i++)
            {
                Console.WriteLine(i.ToString() + ":" + bookSearchVoList[i].BookName + "\t" + bookSearchVoList[i].BookUrl + "\t" + bookSearchVoList[i].author + "\t" + bookSearchVoList[i].BookNewSetionName + "\t" + bookSearchVoList[i].BookNewdate);
            }
            Console.WriteLine("请选择0-9");
            int index = Convert.ToInt16(Console.ReadLine());
            //获取数据
            List<BookSetionSearchVo> bookSetionSearchVo = bookSetionSearchCbm.GetAll(bookSearchVoList[index].BookUrl);
            //打印数据
            for (int i = 0; i < (bookSetionSearchVo.Count > 10 ? 10 : bookSetionSearchVo.Count); i++)
            {
                Console.WriteLine(i.ToString() + ":" + bookSetionSearchVo[i].BookSetionName + "\t" + bookSetionSearchVo[i].BookSetionUrl);
            }
            Console.WriteLine("请选择0-9");
            int index2 = Convert.ToInt16(Console.ReadLine());
            BookSetionSearchTextVo bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchVo[index2].BookSetionUrl);
            //Console.WriteLine(string.Join("\n", bookSetionSearchTextVo.BookContent));
            int textindex = 0;
            int textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;

            Console.Clear();
            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
            //var a = Console.ReadKey().Key;
            bool flg = true;
            do
            {
                var info = Console.ReadKey();
                switch (info.Key)
                {
                    case ConsoleKey.Backspace:
                        break;
                    case ConsoleKey.Tab:
                        Console.WriteLine(bookSetionSearchTextVo.BookSetionName);
                        break;
                    case ConsoleKey.Clear:
                        break;
                    case ConsoleKey.Enter:
                        break;
                    case ConsoleKey.Pause:
                        break;
                    case ConsoleKey.Escape:
                        break;
                    case ConsoleKey.Spacebar:
                        break;
                    case ConsoleKey.PageUp:
                        bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.PrevUrl);
                        textindex = 0;
                        textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                        Console.Clear();
                        Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        break;
                    case ConsoleKey.PageDown:
                        bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.NextUrl);
                        textindex = 0;
                        textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                        Console.Clear();
                        Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        break;
                    case ConsoleKey.End:
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                        textindex--;
                        if (textindex < 0)
                        {
                            bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.PrevUrl);
                            textindex = bookSetionSearchTextVo.BookContent.Length - 1;
                            textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.RightArrow:
                        textindex++;
                        if (textindex > textLastIndex)
                        {
                            bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.NextUrl);
                            textindex = 0;
                            textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        break;
                    case ConsoleKey.DownArrow:

                        break;
                    case ConsoleKey.Select:
                        break;
                    case ConsoleKey.Print:
                        break;
                    case ConsoleKey.Execute:
                        break;
                    case ConsoleKey.PrintScreen:
                        break;
                    case ConsoleKey.Insert:
                        break;
                    case ConsoleKey.Delete:
                        break;
                    case ConsoleKey.Help:
                        break;
                    case ConsoleKey.D0:
                        break;
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        break;
                    case ConsoleKey.D6:
                        break;
                    case ConsoleKey.D7:
                        break;
                    case ConsoleKey.D8:
                        break;
                    case ConsoleKey.D9:
                        break;
                    case ConsoleKey.A:
                        textindex--;
                        if (textindex < 0)
                        {
                            bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.PrevUrl);
                            textindex = bookSetionSearchTextVo.BookContent.Length - 1;
                            textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        break;
                    case ConsoleKey.B:
                        break;
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.D:
                        textindex++;
                        if (textindex > textLastIndex)
                        {
                            bookSetionSearchTextVo = bookSetionSearchTextCbm.GetAll(HOST_URL + bookSetionSearchTextVo.NextUrl);
                            textindex = 0;
                            textLastIndex = bookSetionSearchTextVo.BookContent.Length - 1;
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(bookSetionSearchTextVo.BookContent[textindex]);
                        }
                        break;
                    case ConsoleKey.E:
                        break;
                    case ConsoleKey.F:
                        break;
                    case ConsoleKey.G:
                        break;
                    case ConsoleKey.H:
                        break;
                    case ConsoleKey.I:
                        break;
                    case ConsoleKey.J:
                        break;
                    case ConsoleKey.K:
                        break;
                    case ConsoleKey.L:
                        break;
                    case ConsoleKey.M:
                        break;
                    case ConsoleKey.N:
                        break;
                    case ConsoleKey.O:
                        break;
                    case ConsoleKey.P:
                        break;
                    case ConsoleKey.Q:
                        break;
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.S:
                        Console.Clear();
                        Console.WriteLine("系统正在运行中。。。");
                        break;
                    case ConsoleKey.T:
                        break;
                    case ConsoleKey.U:
                        break;
                    case ConsoleKey.V:
                        break;
                    case ConsoleKey.W:
                        break;
                    case ConsoleKey.X:
                        break;
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.Z:
                        break;
                    case ConsoleKey.LeftWindows:
                        break;
                    case ConsoleKey.RightWindows:
                        break;
                    case ConsoleKey.Applications:
                        break;
                    case ConsoleKey.Sleep:
                        break;
                    case ConsoleKey.NumPad0:
                        break;
                    case ConsoleKey.NumPad1:
                        break;
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.NumPad4:
                        break;
                    case ConsoleKey.NumPad5:
                        break;
                    case ConsoleKey.NumPad6:
                        break;
                    case ConsoleKey.NumPad7:
                        break;
                    case ConsoleKey.NumPad8:
                        break;
                    case ConsoleKey.NumPad9:
                        break;
                    case ConsoleKey.Multiply:
                        break;
                    case ConsoleKey.Add:
                        break;
                    case ConsoleKey.Separator:
                        break;
                    case ConsoleKey.Subtract:
                        break;
                    case ConsoleKey.Decimal:
                        break;
                    case ConsoleKey.Divide:
                        break;
                    case ConsoleKey.F1:
                        break;
                    case ConsoleKey.F2:
                        break;
                    case ConsoleKey.F3:
                        break;
                    case ConsoleKey.F4:
                        break;
                    case ConsoleKey.F5:
                        break;
                    case ConsoleKey.F6:
                        break;
                    case ConsoleKey.F7:
                        break;
                    case ConsoleKey.F8:
                        break;
                    case ConsoleKey.F9:
                        break;
                    case ConsoleKey.F10:
                        break;
                    case ConsoleKey.F11:
                        break;
                    case ConsoleKey.F12:
                        break;
                    case ConsoleKey.F13:
                        break;
                    case ConsoleKey.F14:
                        break;
                    case ConsoleKey.F15:
                        break;
                    case ConsoleKey.F16:
                        break;
                    case ConsoleKey.F17:
                        break;
                    case ConsoleKey.F18:
                        break;
                    case ConsoleKey.F19:
                        break;
                    case ConsoleKey.F20:
                        break;
                    case ConsoleKey.F21:
                        break;
                    case ConsoleKey.F22:
                        break;
                    case ConsoleKey.F23:
                        break;
                    case ConsoleKey.F24:
                        break;
                    case ConsoleKey.BrowserBack:
                        break;
                    case ConsoleKey.BrowserForward:
                        break;
                    case ConsoleKey.BrowserRefresh:
                        break;
                    case ConsoleKey.BrowserStop:
                        break;
                    case ConsoleKey.BrowserSearch:
                        break;
                    case ConsoleKey.BrowserFavorites:
                        break;
                    case ConsoleKey.BrowserHome:
                        break;
                    case ConsoleKey.VolumeMute:
                        break;
                    case ConsoleKey.VolumeDown:
                        break;
                    case ConsoleKey.VolumeUp:
                        break;
                    case ConsoleKey.MediaNext:
                        break;
                    case ConsoleKey.MediaPrevious:
                        break;
                    case ConsoleKey.MediaStop:
                        break;
                    case ConsoleKey.MediaPlay:
                        break;
                    case ConsoleKey.LaunchMail:
                        break;
                    case ConsoleKey.LaunchMediaSelect:
                        break;
                    case ConsoleKey.LaunchApp1:
                        break;
                    case ConsoleKey.LaunchApp2:
                        break;
                    case ConsoleKey.Oem1:
                        break;
                    case ConsoleKey.OemPlus:
                        break;
                    case ConsoleKey.OemComma:
                        break;
                    case ConsoleKey.OemMinus:
                        break;
                    case ConsoleKey.OemPeriod:
                        break;
                    case ConsoleKey.Oem2:
                        break;
                    case ConsoleKey.Oem3:
                        break;
                    case ConsoleKey.Oem4:
                        break;
                    case ConsoleKey.Oem5:
                        break;
                    case ConsoleKey.Oem6:
                        break;
                    case ConsoleKey.Oem7:
                        break;
                    case ConsoleKey.Oem8:
                        break;
                    case ConsoleKey.Oem102:
                        break;
                    case ConsoleKey.Process:
                        break;
                    case ConsoleKey.Packet:
                        break;
                    case ConsoleKey.Attention:
                        break;
                    case ConsoleKey.CrSel:
                        break;
                    case ConsoleKey.ExSel:
                        break;
                    case ConsoleKey.EraseEndOfFile:
                        break;
                    case ConsoleKey.Play:
                        break;
                    case ConsoleKey.Zoom:
                        break;
                    case ConsoleKey.NoName:
                        break;
                    case ConsoleKey.Pa1:
                        break;
                    case ConsoleKey.OemClear:
                        break;
                    default:
                        break;
                }
            } while (flg);
            Console.ReadLine();

        }


    }

}
