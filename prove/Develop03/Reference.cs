public class Reference{
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string referenceText){
        ParseReference(referenceText);
    }

    private void ParseReference(string referenceText){
        // Split the reference into parts (e.g., "John 3:16" -> ["John", "3:16"])
        string[] parts = referenceText.Split(' ');
        _book = parts[0];

        // Handle the chapter and verse (e.g., "3:16" -> ["3", "16"])
        string[] verseNumbers = parts[1].Split(':');
        _startChapter = int.Parse(verseNumbers[0]);

        // Check if there's a verse range (e.g., "5-6")
        if (verseNumbers[1].Contains("-")){
            string[] verses = verseNumbers[1].Split('-');
            _startVerse = int.Parse(verses[0]);
            _endVerse = int.Parse(verses[1]);
        }
        else{
            _startVerse = int.Parse(verseNumbers[1]);
            _endVerse = null;
        }
    }

    public string GetDisplayText(){
        if (_endVerse != null){
            return _book + " " + _startChapter + ":" + _startVerse + "-" + _endVerse;
        }
        return _book + " " + _startChapter + ":" + _startVerse;
    }
}