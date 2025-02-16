public class Scripture{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(string reference, string text){
        _reference = new Reference(reference);
        _words = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray){
            _words.Add(new Word(word));
        }
        
        _random = new Random();
    }

    public bool HideRandomWords(int count){
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words){
            if (!word.IsHidden()){
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0){
            return false;
        }

        for (int i = 0; i < count && visibleWords.Count > 0; i++){
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }

        return true;
    }

    public bool IsCompletelyHidden(){
        foreach (Word word in _words){
            if (!word.IsHidden()){
                return false;
            }
        }
        return true;
    }

    public void Display(){
        Console.Clear();
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine();
        
        string displayText = "";
        foreach (Word word in _words){
            displayText += word.GetDisplayText() + " ";
        }
        Console.WriteLine(displayText);
    }
}