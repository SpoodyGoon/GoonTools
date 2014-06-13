package IO;
import junit.framework.Assert;
import junit.framework.TestCase;
import DataModel.SpellingModule;

public class ModuleReaderTest extends TestCase
{
    private String testFilePath = "C:\\TEMP\\SpellingModule\\Default\\config.xml";

    public void testModuleReader()
    {
    }

    public void testModuleReaderString()
    {
        ModuleReader reader = new ModuleReader(this.testFilePath);
        Assert.assertEquals(this.testFilePath, reader.getModualFilePath());
    }

    public void testParseModule()
    {
        ModuleReader reader = new ModuleReader(this.testFilePath);
        Assert.assertEquals(this.testFilePath, reader.getModualFilePath());
        SpellingModule module = reader.ParseModule();
        Assert.assertNotNull(module);
    }
}
