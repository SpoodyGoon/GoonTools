package DataModel;

import java.util.*;

public class SpellingModualItem {
	
	private int Position = 0;
	private boolean Bonus = false;
	private String Word = "";
	private String FilePath = "";
	private int Difficulty = 3;
	private List<String> IncludedLetters = new ArrayList<String>();
	private List<String> ExcludedLetters = new ArrayList<String>();

	public int getDifficulty() {
		return Difficulty;
	}

	public List<String> getExcludedLetters() {
		return ExcludedLetters;
	}

	public String getFilePath() {
		return FilePath;
	}

	public List<String> getIncludedLetters() {
		return IncludedLetters;
	}

	public int getPosition() {
		return Position;
	}

	public String getWord() {
		return Word;
	}

	public boolean isBonus() {
		return Bonus;
	}

	public void setBonus(boolean bonus) {
		Bonus = bonus;
	}

	public void setDifficulty(int difficulty) {
		Difficulty = difficulty;
	}

	public void setExcludedLetters(List<String> excludedLetters) {
		ExcludedLetters = excludedLetters;
	}

	public void setFilePath(String filePath) {
		FilePath = filePath;
	}

	public void setIncludedLetters(List<String> includedLetters) {
		IncludedLetters = includedLetters;
	}

	public void setPosition(int position) {
		Position = position;
	}

	public void setWord(String word) {
		Word = word;
	}
}
