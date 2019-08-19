using System;
public class SimpleProgressBar : DomainObject<SimpleProgressBar> {
    private static readonly object ConsoleWriterLock = new object();
    private string StartingString = "[";
    private string EndingString = "]";
    private string ProgressBarIncrementString = "=";    
    private bool HasInitialised = false;
    private char PadChar = ' ';
    private double Progress = 0.0;
    private int ProgressBarWidth = 10;    
    private int Bars = 0;
    private int LineIndex;

    SimpleProgressBar(bool initialise = true){
        if(initialise)
            Initialise();
    }

    SimpleProgressBar(double initialProgess, bool initialise = true){
        Progress = initialProgess > 100.0 
        ? 100.0
        : initialProgess < 0.0 
        ? 0.0
        : initialProgess;

        if(initialise)
            Initialise();
    }

    public int Width { get => ProgressBarWidth; set => ProgressBarWidth = value; }

    public int LineNumber { get => LineIndex; set => LineIndex = value; }

    public string StartString { get => StartingString; set => StartingString = value; }

    public string EndString { get => EndingString; set => EndingString = value; }

    public string ProgressBarString { get => ProgressBarIncrementString; set => ProgressBarIncrementString = value; }

    void Initialise(bool writeBar = true){
        lock(ConsoleWriterLock){
            LineIndex = Console.CursorTop;
            Console.SetCursorPosition(0, LineIndex);
            Console.Write(string.Format(StartingString + new String(PadChar, ProgressBarWidth) + EndingString + " {0}%", Progress));
            HasInitialised = true;
        }
    }

    void Update(double newProgress){
        if(HasInitialised){
            if(newProgress >= 0.0 && newProgress < 100.0){
                var PercentageGainForNewProgress = 100.0/ProgressBarWidth; //percentage for new bar (100/5 = 20, 20% needed for each increment)
                var NumberOfBars = (int)Math.Floor(Progress/PercentageGainForNewProgress); // (int)67.5/20 == 3, ROUND DOWN  
                //get index of startchar ([) or last progress char (=), check if number of bars is correct if not, if more, add more progress chars (=), if less, delete progress chars
                lock(ConsoleWriterLock){
                    //write new bars
                    Console.SetCursorPosition(0, LineIndex);
                    Bars = NumberOfBars;
                }  
            }          
        }        
    }

    int GetCompleteWidth(){
        return 1;
        //return sum of all elements [ + number of units + ] + 0 + % = n units wide
    }

    void CompleteAndThen(Action action){
        CompleteProgressBar();
        action();
    }

    private void CompleteProgressBar(){
        if(Progress < 100.0){
            //print all progress strings progressString
            Progress = 100.0;
        }
    }
}