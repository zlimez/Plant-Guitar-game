using System;

public class Utilities
{
    public static double GetTimeStamp() {
        DateTime origin = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan diff = DateTime.Now - origin;
        return diff.TotalSeconds;
    }
    
    public static int NotesToIndex(Notes note) {
        return (int) note - 1;
    }

    public static string NotesToString(Notes note) {
        switch (note) {
            case Notes.C:
                return "C";
            case Notes.D:
                return "D";
            case Notes.E:
                return "E";
            case Notes.F:
                return "F";
            case Notes.G:
                return "G";
            case Notes.A:
                return "A";
            case Notes.B:
                return "B";
            case Notes.Db:
                return "C#/Db";
            case Notes.Eb:
                return "D#/Eb";
            case Notes.Gb:
                return "F#/Gb";
            case Notes.Ab:
                return "G#/Ab";
            case Notes.Bb:
                return "A#/Bb";
            default:
                return "Error";
        }
    }
}
