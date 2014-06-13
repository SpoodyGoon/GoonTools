package IO;
import java.io.File;
import java.sql.Date;
import java.util.Arrays;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

public class ModuleReader
{
    private String ModuleFilePath = "";

    public ModuleReader()
    {
    }

    public ModuleReader(String filePath)
    {
    }

    public String getModualFilePath()
    {
        return this.ModuleFilePath;
    }

    private String getValue(String tag, Element element)
    {
        NodeList nodes = element.getElementsByTagName(tag).item(0).getChildNodes();
        Node node = nodes.item(0);
        return node.getNodeValue();
    }

    public DataModel.SpellingModule ParseModule()
    {
        DataModel.SpellingModule spellingModule = new DataModel.SpellingModule();
        try
        {
            File moduleFile = new File(this.ModuleFilePath);
            DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            Document doc = dBuilder.parse(moduleFile);
            doc.getDocumentElement().normalize();
            // get the root level elements
            Element element = (Element) doc.getElementsByTagName("SpellingModule").item(0);
            spellingModule.setModuleVersion(Float.valueOf(element.getAttribute("ModuleVersion")));
            spellingModule.setFileVersion(Float.valueOf(element.getAttribute("FileVersion")));
            spellingModule.setModualName(this.getValue("ModuleName", element));
            spellingModule.setCreatedBy(this.getValue("CreatedBy", element));
            spellingModule.setCreatedDate(Date.valueOf(this.getValue("CreatedDate", element)));
            spellingModule.setModifiedBy(this.getValue("ModifiedBy", element));
            spellingModule.setModifiedDate(Date.valueOf(this.getValue("ModifiedDate", element)));
            spellingModule.setNotes(this.getValue("Notes", element));
            Element ages = (Element) ((Element) element.getElementsByTagName("Difficulty").item(0)).getElementsByTagName("Ages").item(0);
            spellingModule.setMinAge(Integer.valueOf(ages.getAttribute("Min")));
            spellingModule.setMaxAge(Integer.valueOf(ages.getAttribute("Max")));
            // get the spelling items
            NodeList itemNodeList = doc.getElementsByTagName("Item");
            for (int i = 0; i < itemNodeList.getLength(); i++)
            {
                Node node = itemNodeList.item(i);
                if (node.getNodeType() == Node.ELEMENT_NODE)
                {
                    DataModel.SpellingModuleItem moduleItem = new DataModel.SpellingModuleItem();
                    Element item = (Element) node;
                    moduleItem.setPosition(Integer.valueOf(item.getAttribute("Position")));
                    moduleItem.setBonus(Boolean.valueOf(item.getAttribute("Bonus")));
                    moduleItem.setWord(this.getValue("Word", item));
                    moduleItem.setFilePath(this.getValue("Image", item));
                    moduleItem.setDifficulty(Integer.valueOf(this.getValue("Difficulty", item)));
                    moduleItem.setIncludedLetters(Arrays.asList(this.getValue("Included", item).split(",")));
                    moduleItem.setExcludedLetters(Arrays.asList(this.getValue("Excluded", item).split(",")));
                    spellingModule.AddItem(moduleItem);
                }
            }
        }
        catch (Exception ex)
        {
            ex.printStackTrace();
        }
        
        return spellingModule;
    }

    public void setModualFilePath(String modualFilePath)
    {
        this.ModuleFilePath = modualFilePath;
    }
}
// <?xml version="1.0" encoding="UTF-8"?>
// <stocks>
// <stock>
// <symbol>Citibank</symbol>
// <price>100</price>
// <quantity>1000</quantity>
// </stock>
// <stock>
// <symbol>Axis bank</symbol>
// <price>90</price>
// <quantity>2000</quantity>
// </stock>
// </stocks>
// Read more:
// http://javarevisited.blogspot.com/2011/12/parse-xml-file-in-java-example-tutorial.html#ixzz346CjITVZ
// Output:
//
// root of xml file stocks
// ==========================
// Stock Symbol: Citibank
// Stock Price: 100
// Stock Quantity: 1000
// Stock Symbol: Axis bank
// Stock Price: 90
// Stock Quantity: 2000
//
//
// Read more:
// http://javarevisited.blogspot.com/2011/12/parse-xml-file-in-java-example-tutorial.html#ixzz346CL27MK