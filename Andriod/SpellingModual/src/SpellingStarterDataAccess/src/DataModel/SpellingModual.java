package DataModel;

import java.util.*;

public class SpellingModual {

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

	public String getCreatedBy() {
		return CreatedBy;
	}

	public Date getCreatedDate() {
		return CreatedDate;
	}

	public int getDifficulty() {
		return Difficulty;
	}

	public float getFileVersion() {
		return FileVersion;
	}

	public List<SpellingModualItem> getItems() {
		return Items;
	}

	public int getMaxAge() {
		return MaxAge;
	}

	public int getMinAge() {
		return MinAge;
	}

	public String getModifiedBy() {
		return ModifiedBy;
	}

	public Date getModifiedDate() {
		return ModifiedDate;
	}

	public String getModualName() {
		return ModualName;
		// test
	}

	public float getModuleVersion() {
		return ModuleVersion;
	}

	public String getNotes() {
		return Notes;
	}

	public void setCreatedBy(String createdBy) {
		CreatedBy = createdBy;
	}

	public void setCreatedDate(Date createdDate) {
		CreatedDate = createdDate;
	}

	public void setDifficulty(int difficulty) {
		Difficulty = difficulty;
	}

	public void setFileVersion(float fileVersion) {
		FileVersion = fileVersion;
	}

	public void setItems(List<SpellingModualItem> items) {
		Items = items;
	}

	public void setMaxAge(int maxAge) {
		MaxAge = maxAge;
	}

	public void setMinAge(int minAge) {
		MinAge = minAge;
	}

	public void setModifiedBy(String modifiedBy) {
		ModifiedBy = modifiedBy;
	}

	public void setModifiedDate(Date modifiedDate) {
		ModifiedDate = modifiedDate;
	}

	public void setModualName(String modualName) {
		ModualName = modualName;
	}

	public void setModuleVersion(float moduleVersion) {
		ModuleVersion = moduleVersion;
	}

	public void setNotes(String notes) {
		Notes = notes;
	}

}
