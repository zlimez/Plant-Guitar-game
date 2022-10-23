using UnityEngine;

public class StringWrapper : Countable<Strings>
{
    public StringWrapper(Strings thisString, int stock) : base(stock) {
        this.data = thisString;
    }

    public string GetStringName() {
        return Utilities.NotesToString(data.note);
    }

    public Sprite GetStringSprite() {
        return data.image;
    }
}
