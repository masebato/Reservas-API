using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Reservas_INFRASTRUCTURE.Finder.Util
{
    public class SQLreader
    {
        public static async Task<string> GetQuery(string query)
        {
            XmlTextReader xmlReader = new XmlTextReader(Directory.GetCurrentDirectory() + "/Configuration/queries.xml");
            var queryFounded = false;
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        if (xmlReader.Value.Equals(query))
                        {
                            queryFounded = true;
                            break;
                        }
                    }
                }
                if (queryFounded)
                {
                    var line = xmlReader.Value.ToLower();
                    if (line.Trim().Contains("select"))
                    {
                        //_logger.Information(xmlReader.Value);
                        return xmlReader.Value;
                    }
                }
            }

            return "";
        }
    }
}
