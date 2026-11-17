using System;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
namespace XmlTB1_2415053122127
{
    class Program
        static void  Main(string[] args)
    {
        String? lenhGoc = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(lenhGoc))
        {
            Console.WriteLine("Lenh khong hop le");
            return;
        }
        string noiDungXml = Console.In.ReadToEnd();
        if (string.IsNullOrWhiteSpace(noiDungXml))
        {
            Console.WriteLine("Lenh khong hop le");
            return;
        }
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.LoadXml(noiDungXml);
        }
        catch
        {
            Console.WriteLine("Lenh khong hop le");
            return;
        }
        string lenh = lenhGoc.Trim();
        if (lenh.StartsWith("LUONG_TREN"))
        {
            XuLyLuongTren(doc, lenh.Substring(11).Trim());

        }
        else
        {
            Console.WriteLine("Lenh khong hop le");
        }
    }
    static void XuLyLuongTren (XmlDocument doc, string xStr)
    {
        if (!double.TryParse(xStr,NumberStyles.Any,CultureInfo.InvariantCulture, out double x))
        {
            Console.WriteLine("Lenh khong hop le");
            return;
        }
        string xpath = $"//nhanvien[luong > {x.ToString(CultureInfo.InvariantCulture)}]";
        XmlNodeList? dsNV = doc.SelectNodes(xpath);
        if (dsNV == null || dsNV.Count==0)
        {
            Console.WriteLine("Lenh khong hop le");
            return;
        }
        foreach (XmlNode nv in dsNV)
        {
            string ma = nv.Attributes?["ma"]?.Value ?? "";
            string hoten = nv.SelectSingleNode("hoten")?.InnerText ?? "";
            string luong = nv.SelectSingleNode("luong")?.InnerText ?? "";
            Console.WriteLine($"{ma}-{hoten}-{luong}");
        }

        }
    }
}