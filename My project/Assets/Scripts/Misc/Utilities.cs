using System;

public class Utilities
{
    public static double GetTimeStamp() {
        DateTime origin = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan diff = DateTime.Now - origin;
        return diff.TotalSeconds;
    }
}
