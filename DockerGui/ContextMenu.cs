using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DockerGui
{
    [XmlType(TypeName = "menu_item")]
    public class ContextMenuItem
    {
        [XmlText]
        public string Value;

        public static List<ContextMenuItem> LoadContextMenu(string contextMenuFile)
        {
            List<ContextMenuItem> contextMenuItems = null;
            XmlSerializer ser = new XmlSerializer(typeof(List<ContextMenuItem>), new XmlRootAttribute("menu_items"));
            using (XmlReader writer = XmlReader.Create(contextMenuFile))
            {
                contextMenuItems = ser.Deserialize(writer) as List<ContextMenuItem>;
            }
            return contextMenuItems;
        }

    }
}
