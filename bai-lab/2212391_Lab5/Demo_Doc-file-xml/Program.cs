// See https://aka.ms/new-console-template for more information
using Demo_Doc_file_xml;
using System.Xml;
using System.Xml.Serialization;

var xmldoc = new XmlDocument();
xmldoc.Load("..\\books.xml");

var nodelist = xmldoc.DocumentElement.SelectNodes("/catalog/book");

foreach (XmlNode node in nodelist)
{
    var isbn = node.Attributes["ISBN"].Value;

    var title = node.SelectSingleNode("title").InnerText;
    var price = node.SelectSingleNode("price").InnerText;

    var firstName = node.SelectSingleNode("author/first-name").InnerText;
    var lastName = node.SelectSingleNode("author/last-name").InnerText;

    Console.WriteLine("{0,-15}{1,-50}{2,-15}{3,-15}{4,6}",isbn,title,firstName,lastName,price);
}

using (XmlWriter writer = XmlWriter.Create("books.xml"))
{
    String pi = "type=\"text/xsl\" href=\"books.xsl\"";
    writer.WriteProcessingInstruction("xml-stylesheet", pi);

    writer.WriteDocType("catalog", null, null, "<!ENTITY h \"hardcover\">");

    writer.WriteComment("This is a book sample XML");

    writer.WriteStartElement("book");

    writer.WriteAttributeString("ISBN", "9831123212");
    writer.WriteAttributeString("yearpublished", "2002");

    writer.WriteElementString("author", "Mahesh Chand");
    writer.WriteElementString("title", "Visual C# Programming");
    writer.WriteElementString("price", "44.95");

    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Flush();
}

List<Book> books = new List<Book>();
books.Add(new Book("9831123212", "A Programmer's Guide to ADO .Net using C#", "Mahesh Chand", (decimal)44.99, 2022));
books.Add(new Book("9781484234", "Pro Entity Framework Core 1", "Adam Freeman",(decimal)44.99,2018));

var serializer = new XmlSerializer(typeof(List<Book>));
using (var writer = new StreamWriter("books.xml"))
{
    serializer.Serialize(writer, books,null);
    writer.Close();
}