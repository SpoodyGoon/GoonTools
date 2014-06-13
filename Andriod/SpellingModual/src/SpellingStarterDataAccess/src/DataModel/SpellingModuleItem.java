package DataModel;
import java.util.ArrayList;
import java.util.List;

public class SpellingModuleItem
{
    private int Position = 0;

    private boolean Bonus = false;

    private String Word = "";

    private String FilePath = "";

    private int Difficulty = 3;

    private List<String> IncludedLetters = new ArrayList<String>();

    private List<String> ExcludedLetters = new ArrayList<String>();

    public int getDifficulty()
    {
        return this.Difficulty;
    }

    public List<String> getExcludedLetters()
    {
        return this.ExcludedLetters;
    }

    public String getFilePath()
    {
        return this.FilePath;
    }

    public List<String> getIncludedLetters()
    {
        return this.IncludedLetters;
    }

    public int getPosition()
    {
        return this.Position;
    }

    public String getWord()
    {
        return this.Word;
    }

    public boolean isBonus()
    {
        return this.Bonus;
    }

    public void setBonus(boolean bonus)
    {
        this.Bonus = bonus;
    }

    public void setDifficulty(int difficulty)
    {
        this.Difficulty = difficulty;
    }

    public void setExcludedLetters(List<String> excludedLetters)
    {
        this.ExcludedLetters = excludedLetters;
    }

    public void setFilePath(String filePath)
    {
        this.FilePath = filePath;
    }

    public void setIncludedLetters(List<String> includedLetters)
    {
        this.IncludedLetters = includedLetters;
    }

    public void setPosition(int position)
    {
        this.Position = position;
    }

    public void setWord(String word)
    {
        this.Word = word;
    }
}