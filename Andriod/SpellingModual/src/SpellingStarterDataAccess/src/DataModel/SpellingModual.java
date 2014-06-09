package DataModel;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class SpellingModual
{
    private String ModualName = "Default";

    private float FileVersion = 1.0f;

    private float ModuleVersion = 1.0f;

    private String CreatedBy = "Unknown";

    private Date CreatedDate = new Date();

    private String ModifiedBy = "Unknown";

    private Date ModifiedDate = new Date();

    private int Difficulty = 3;

    private int MaxAge = 2;

    private int MinAge = 4;

    private String Notes = "";

    private List<SpellingModualItem> Items = new ArrayList<SpellingModualItem>();

    public String getCreatedBy()
    {
        return this.CreatedBy;
    }

    public Date getCreatedDate()
    {
        return this.CreatedDate;
    }

    public int getDifficulty()
    {
        return this.Difficulty;
    }

    public float getFileVersion()
    {
        return this.FileVersion;
    }

    public List<SpellingModualItem> getItems()
    {
        return this.Items;
    }

    public int getMaxAge()
    {
        return this.MaxAge;
    }

    public int getMinAge()
    {
        return this.MinAge;
    }

    public String getModifiedBy()
    {
        return this.ModifiedBy;
    }

    public Date getModifiedDate()
    {
        return this.ModifiedDate;
    }

    public String getModualName()
    {
        return this.ModualName;
    }

    public float getModuleVersion()
    {
        return this.ModuleVersion;
    }

    public String getNotes()
    {
        return this.Notes;
    }

    public void setCreatedBy(String createdBy)
    {
        this.CreatedBy = createdBy;
    }

    public void setCreatedDate(Date createdDate)
    {
        this.CreatedDate = createdDate;
    }

    public void setDifficulty(int difficulty)
    {
        this.Difficulty = difficulty;
    }

    public void setFileVersion(float fileVersion)
    {
        this.FileVersion = fileVersion;
    }

    public void setItems(List<SpellingModualItem> items)
    {
        this.Items = items;
    }

    public void setMaxAge(int maxAge)
    {
        this.MaxAge = maxAge;
    }

    public void setMinAge(int minAge)
    {
        this.MinAge = minAge;
    }

    public void setModifiedBy(String modifiedBy)
    {
        this.ModifiedBy = modifiedBy;
    }

    public void setModifiedDate(Date modifiedDate)
    {
        this.ModifiedDate = modifiedDate;
    }

    public void setModualName(String modualName)
    {
        this.ModualName = modualName;
    }

    public void setModuleVersion(float moduleVersion)
    {
        this.ModuleVersion = moduleVersion;
    }

    public void setNotes(String notes)
    {
        this.Notes = notes;
    }
}